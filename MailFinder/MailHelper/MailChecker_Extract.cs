using BaseModule;
using MailFinder;
using MailKit;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailHelper
{
    partial class MailChecker
    {
        private SearchQuery get_search_query(SearchParam param)
        {
            SearchQuery search_query = SearchQuery.All;
            if (param.is_All)
                search_query = SearchQuery.All;
            else
            {
                //search_query = SearchQuery.DeliveredAfter(param.dteAfter.Date).And(SearchQuery.DeliveredBefore(param.dteBefore.Date + new TimeSpan(1, 0, 0, 0)));

                DateTime after = param.dteAfter.Date - new TimeSpan(1, 0, 0, 0);
                DateTime before = param.dteBefore.Date + new TimeSpan(1, 0, 0, 0);

                //search_query = SearchQuery.SentSince(param.dteAfter.Date).And(SearchQuery.SentBefore(param.dteBefore.Date + new TimeSpan(1, 1, 0, 0)));
                search_query = SearchQuery.SentSince(after).And(SearchQuery.SentBefore(before));

                //search_query = search_query.Or(SearchQuery.SentOn(after));
                //search_query = search_query.Or(SearchQuery.SentOn(before));

                /*SearchQuery subject_query = null;
                foreach (string subject_key in param.lstrSubjectKeys)
                {
                    if (subject_key == null || subject_key == string.Empty)
                        continue;

                    SearchQuery sub_subject_query = SearchQuery.SubjectContains(subject_key);
                    subject_query = subject_query == null ? sub_subject_query : subject_query.Or(sub_subject_query);
                }
                if(subject_query != null)
                    search_query = search_query.And(subject_query);

                SearchQuery body_query = null;
                foreach(string body_key in param.lstrBodyKeys)
                {
                    if (body_key == null || body_key == string.Empty)
                        continue;
                    SearchQuery sub_body_query = SearchQuery.BodyContains(body_key);
                    body_query = body_query == null ? sub_body_query : body_query.Or(sub_body_query);
                }
                if(body_query != null)
                    search_query = search_query.And(body_query);*/
            }
            return search_query;
        }
        private string get_sender_from_mimemessage(MimeMessage message)
        {
            string sender = "";

            if (message.Sender != null)
            {
                sender = message.Sender.Address;
            }
            else if (message.From != null)
            {
                foreach (MailboxAddress from in message.From)
                {
                    if (sender == "")
                        sender = from.Address;
                    else
                        sender = sender + "|" + from.Address;
                }
            }
            return sender;
        }
        private string get_sender_name_from_mimemessage(MimeMessage message)
        {
            string name = "";
            if (message.Sender != null)
            {
                name = message.Sender.Name;
            }
            else if (message.From != null)
            {
                foreach (MailboxAddress from in message.From)
                {
                    if (name == "")
                        name = from.Name;
                    else
                        name += "|" + from.Name;
                }
            }
            return name;
        }
        public static string get_mail_content_from_mimemessage(string eml_path)
        {
            MimeMessage message = MimeMessage.Load(eml_path);

            string content = "";
            /*if (message.Sender != null)
                content = "From - " + message.Sender.ToString();
            else if (message.From != null)
                content = "From - " + message.From.ToString();

            content += "\n" + "To - " + message.To.ToString();
            content += "\n" + "Subject - " + message.Subject;
            content += "\n" + "Date - " + DateTime.Parse(message.Date.ToString("yyyy-MM-dd HH:mm:ss")).ToString();
            content += "\n" + "Body - " + "\n";
            content += "\n" + message.TextBody;*/

            content = message.HtmlBody;
            return content;
        }

        public static string get_html_from_eml(string eml_path)
        {
            MimeMessage msg = MimeMessage.Load(eml_path);
            return msg.HtmlBody;
        }

        public static void get_meta_from_eml(string eml_path, out string strFrom, out string strSubj, out string strTo, out string strDate)
        {
            MimeMessage message = MimeMessage.Load(eml_path);

            strFrom = string.Empty;
            strSubj = string.Empty;
            strTo = string.Empty;
            strDate = string.Empty;

            if (message.Sender != null)
                strFrom = message.Sender.ToString();
            else if (message.From != null)
                strFrom = message.From.ToString();

            strSubj = message.Subject;
            strTo = message.To.ToString();
            strDate = DateTime.Parse(message.Date.ToString("yyyy-MM-dd HH:mm:ss")).ToString();
        }

        private List<FetchParam> get_FetchParamList_retry(SearchQuery in_query)
        {
            int idx_nss = 0;
            int idx_ns = 0;
            int idx_box = 0;

            List<FetchParam> paramlist = new List<FetchParam>();

            FolderNamespaceCollection[] ns_lists = new FolderNamespaceCollection[]
            {
                client.PersonalNamespaces,
                client.SharedNamespaces,
                client.OtherNamespaces
            };

            Program.log_info($"Start getting fetch params : {m_account.mail_address}");

            while (true)
            {
                try
                {
                    int count_nss = ns_lists.Length;
                    while (idx_nss < count_nss)
                    {
                        var nss = ns_lists[idx_nss];
                        int count_ns = nss.Count;

                        while (idx_ns < count_ns)
                        {
                            var ns = nss[idx_ns];
                            var boxes = client.GetFolders(ns);
                            int count_box = boxes.Count;

                            while (idx_box < count_box)
                            {
                                IMailFolder box = boxes[idx_box];

                                box.Subscribe();
                                box.Open(FolderAccess.ReadOnly);

                                var ret = box.Search(in_query);

                                string strBoxName = box.FullName;
                                //int recnum = box.Count;
                                int recnum = ret.Count;

                                if (recnum > 0)
                                {
                                    foreach (var uid in ret)
                                    {
                                        FetchParam mid = new FetchParam(strBoxName, uid);

                                        paramlist.Add(mid);
                                    }
                                }

                                idx_box++;
                            }
                            idx_ns++;
                        }
                        idx_nss++;
                    }
                    break;
                }
                catch (Exception exception)
                {
                    Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
                    if (!client.IsConnected)
                        connect();
                    else
                    {
                        Program.log_error("SUGH.");
                        break;
                    }
                }
            }

            Program.log_info($"End getting fetch params : {m_account.mail_address}. Params num = {paramlist.Count}");

            return paramlist;
        }

        private List<FetchParam> get_FetchParamList_retry(string path, SearchQuery in_query)
        {
            int idx = 0;
            List<FetchParam> paramlist = new List<FetchParam>();

            Program.log_info($"Start getting fetch params : {m_account.mail_address}");

            while (true)
            {
                try
                {
                    IMailFolder box = client.GetFolder(path);
                    box.Subscribe();
                    box.Open(FolderAccess.ReadOnly);

                    var ret = box.Search(in_query);

                    string strBoxName = box.FullName;
                    int recnum = ret.Count;

                    if (recnum > 0)
                    {
                        while (idx < recnum)
                        {
                            var uid = ret[idx];
                            FetchParam mid = new FetchParam(strBoxName, uid);

                            paramlist.Add(mid);
                            idx++;
                        }
                    }
                    break;
                }
                catch (Exception exception)
                {
                    Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
                    if (!client.IsConnected)
                        connect();
                    else
                    {
                        Program.log_error("SUGH.");
                        break;
                    }
                }
            }
            Program.log_info($"End getting fetch params : {m_account.mail_address}. Params num = {paramlist.Count}");
            return paramlist;
        }
    }
}
