using BaseModule;
using MailFinder;
using MailKit;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailHelper
{
    partial class MailChecker
    {
        public async Task<int> Search()
        {
            try
            {
                int w_return_value = connect();

                if (w_return_value != ConstEnv.CONNECT_LOGIN_SUCCESS)
                    return w_return_value;

                List<FetchParam> w_fetch_param_list = get_FetchParamList(m_search_param);

                Program.log_info($"Fetch param list count - {w_fetch_param_list.Count}");

                if (w_fetch_param_list.Count == 0)
                    return ConstEnv.SEARCH_SUCCESS;

                Program.g_prog_total = w_fetch_param_list.Count;
                Program.g_prog_current = 0;


                int w_threads_num = (w_fetch_param_list.Count - 1) / Program.g_setting.SEARCH_MAILS_NUM_PER_THREAD + 1;

                

                await SearchWorkFlow(w_fetch_param_list, w_threads_num);

                

                if (client.IsConnected)
                    disconnect();

                is_search_finished = true;
                return ConstEnv.SEARCH_SUCCESS;
            }
            catch(Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}.");
                return ConstEnv.SEARCH_ERROR;
            }
        }

        public async Task SearchWorkFlow(List<FetchParam> in_fetch_param_list, int in_thread_num)
        {
            int w_thread_finished_count = 0;

            for (int i = 0; i < in_thread_num; i ++)
            {
                new Thread(() =>
                {
                    MailChecker sub = new MailChecker(m_account, m_proxy);

                    sub.connect();

                    string previous_folder = "";

                    while (true)
                    {
                        if (Program.g_must_end)
                            break;

                        FetchParam param = null;

                        lock (in_fetch_param_list)
                        {
                            if (in_fetch_param_list.Count == 0)
                                break;

                            param = in_fetch_param_list[0];
                            in_fetch_param_list.RemoveAt(0);
                        }

                        if (param == null)
                            break;

                        Program.log_info($"{System.Reflection.MethodBase.GetCurrentMethod().Name} param is not null.");

                        previous_folder = param.folder_path;

                        int retry_count = 0;
                        while (true)
                        {
                            if (Program.g_must_end)
                                break;

                            try
                            {
                                IMailFolder w_mail_box = sub.client.GetFolder(param.folder_path);

                                Program.log_info($"{System.Reflection.MethodBase.GetCurrentMethod().Name} mail box is got.");

                                if (!w_mail_box.IsOpen)
                                {
                                    w_mail_box.Subscribe();
                                    w_mail_box.Open(FolderAccess.ReadOnly);
                                }

                                Program.log_info($"{System.Reflection.MethodBase.GetCurrentMethod().Name} mailbox is opened.");

                                MimeMessage message = w_mail_box.GetMessage(param.idx_mail);

                                get_item_result(message, param.folder_path, param.idx_mail);

                                break;
                            }
                            catch (Exception exception)
                            {
                                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}.");

                                if (!sub.client.IsConnected)
                                {
                                    retry_count++;
                                    if (retry_count > 2)
                                    {
                                        Program.log_error($"({System.Reflection.MethodBase.GetCurrentMethod().Name}): retry connection failed. {m_account.mail_address}");
                                        break;
                                    }
                                    sub.connect();
                                }
                                else
                                {

                                }
                            }
                        }

                        Program.g_prog_current++;
                    }
                    sub.disconnect();
                    w_thread_finished_count++;
                }).Start();
            }
            while (true)
            {
                if (w_thread_finished_count >= in_thread_num)
                    break;
                await Task.Delay(1000);
            }
            Program.log_info($"{w_thread_finished_count} threads finished.");
        }

        public List<FetchParam> get_FetchParamList(SearchParam searchparam)
        {
            List<FetchParam> w_output_list = new List<FetchParam>();

            try
            {
                Program.log_info($"start fetch_mails : user = {m_account.mail_address}");

                SearchQuery w_search_query = get_search_query(m_search_param);

                if (searchparam.is_AllFolders || searchparam.is_All)
                    w_output_list = get_FetchParamList_retry(w_search_query);
                else
                {
                    if (searchparam.is_InboxOnly)
                        w_output_list.AddRange(get_FetchParamList_retry("INBOX", w_search_query));
                    if (searchparam.is_SentOnly)
                        w_output_list.AddRange(get_FetchParamList_retry("Sent Items", w_search_query));
                }

                /*bool w_is_duplicated = check_FetchParamList_duplicated(w_output_list);
                if (w_is_duplicated)
                    Program.log_info($"Fetch param list is duplicated. User = {m_account.mail_address}");*/
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message} - SUGH");
            }

            return w_output_list;
        }

        private void get_item_result(MimeMessage message, string path, UniqueId id)
        {
            Program.log_info($"{System.Reflection.MethodBase.GetCurrentMethod().Name} started. {path} - {id.ToString()}");

            SearchResult result_item = new SearchResult();

            string subject = message.Subject == null ? string.Empty : message.Subject;

            if (!check_key_contains(subject, m_search_param.lstrSubjectKeys))
                return;

            /*if (m_search_param.lstrSubjectKeys != null && m_search_param.lstrSubjectKeys[0] != "")
            {
                foreach (string subject_key in m_search_param.lstrSubjectKeys)
                {
                    if (subject_key.Replace(" ", "") == string.Empty)
                        continue;

                    if (subject_key == null || subject_key == string.Empty)
                        continue;

                    string temp = remove_first_end_space(subject_key);

                    if (subject.IndexOf(temp, StringComparison.InvariantCultureIgnoreCase) != -1)
                    {
                        keywords_flag = true;
                        break;
                    }
                }
                if (!keywords_flag)
                    return;
            }*/
            

            string body = message.TextBody == null ? string.Empty : message.TextBody;

            if (!check_key_contains(body, m_search_param.lstrBodyKeys))
                return;

            /*if (m_search_param.lstrBodyKeys != null && m_search_param.lstrBodyKeys[0] != "")
            {
                foreach (string body_key in m_search_param.lstrBodyKeys)
                {
                    if (body_key.Replace(" ", "") == string.Empty)
                        continue;

                    if (body_key == null || body_key == string.Empty)
                        continue;

                    string temp = remove_first_end_space(body_key);

                    if (body.IndexOf(temp, StringComparison.InvariantCultureIgnoreCase) != -1)
                    {
                        keywords_flag = true;
                        break;
                    }
                }
                if (!keywords_flag)
                    return;
            }*/

            Program.log_info($"{System.Reflection.MethodBase.GetCurrentMethod().Name} body and subject checked.");

            string sender = get_sender_from_mimemessage(message);
            DateTime date = DateTime.Parse(message.Date.ToString("yyyy-MM-dd HH:mm:ss"));
            string sender_name = get_sender_name_from_mimemessage(message);

            /*if (sender == m_account.mail_address)
                continue;*/

            result_item.strMail = m_account.mail_address;
            result_item.strSubject = subject;
            result_item.nAttachNum = message.Attachments.Count();
            result_item.dteDate = date;
            result_item.strFrom = sender;
            result_item.strName = sender_name;


            string rel_path = get_mail_store_relative_path(path, date);
            Directory.CreateDirectory(rel_path);

            string eml_path = Path.Combine(rel_path, $"message_{id.ToString()}.eml");
            message.WriteTo(eml_path);

            result_item.strEmlPath = eml_path;

            result_item.strSize = get_mail_size(eml_path);

            lock (Program.g_search_result)
            {
                Program.g_search_result.Add(result_item);
            }

            Program.log_info($"{System.Reflection.MethodBase.GetCurrentMethod().Name} finished.");
        }

        private bool check_FetchParamList_duplicated(List<FetchParam> in_list)
        {
            if (in_list == null || in_list.Count == 0)
                return false;

            while (in_list.Count > 0)
            {
                FetchParam param = in_list[0];
                in_list.RemoveAt(0);

                if (in_list.Contains(param))
                    return true;
            }
            return false;
        }

        private bool check_key_contains(string in_content, List<string> in_lstrKeys)
        {
            bool is_contained = false;
            bool is_all_blank = true;

            if (in_lstrKeys == null || in_lstrKeys.Count == 0 || in_lstrKeys[0].Replace(" ", "") == "" && in_lstrKeys.Count == 1)
                return true;

            foreach (string key in in_lstrKeys)
            {
                if (key.Replace(" ", "") == string.Empty)
                    continue;

                if (key == null || key == string.Empty)
                    continue;

                is_all_blank = false;

                string temp = remove_first_end_space(key);

                if (in_content.IndexOf(temp, StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    is_contained = true;
                    break;
                }
            }
            if (is_all_blank)
                return true;
            return is_contained;
        }
    }
}
