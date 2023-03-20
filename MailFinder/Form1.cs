using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using MailFinder;
using BaseModule;
using MailHelper;
using System.Threading;
using System.Diagnostics;
using BASELIB;

namespace MailFinder
{
    public partial class Form1 : Form
    {        
        List<UserInfo> m_lstMails = new List<UserInfo>();
        
        ImageList m_lstimgStatus = new ImageList();
        
        public Form1()
        {
            InitializeComponent();

            lvMails.Columns.Add("#");
            
            m_lstimgStatus.ImageSize = new Size(16, 16);

            Bitmap bmp1 = new Bitmap(Properties.Resources._unchecked);
            Bitmap bmp2 = new Bitmap(Properties.Resources.valid);
            Bitmap bmp3 = new Bitmap(Properties.Resources.unvalid);
            m_lstimgStatus.Images.Add(bmp1);
            m_lstimgStatus.Images.Add(bmp2);
            m_lstimgStatus.Images.Add(bmp3);

            lvMails.SmallImageList = m_lstimgStatus;

            lvMails.Columns[0].Width = 290;

            lvSearchResult.Columns.Add("No");
            lvSearchResult.Columns.Add("Mail");
            lvSearchResult.Columns.Add("Subject");
            lvSearchResult.Columns.Add("Name");
            lvSearchResult.Columns.Add("From");
            lvSearchResult.Columns.Add("Size");
            lvSearchResult.Columns.Add("Date");
            lvSearchResult.Columns.Add("Attachments");

            lvSearchResult.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            if (File.Exists(ConstEnv.MAIL_CSV_DEFAULT_PATH))
                load_accounts(ConstEnv.MAIL_CSV_DEFAULT_PATH);

            /*if (File.Exists(ConstEnv.PROXY_TXT_DEFAULT_PATH))
                ProxyData.load_proxies(ConstEnv.PROXY_TXT_DEFAULT_PATH);*/

            
            picbxFirst.Enabled = false;
            picbxPrevious.Enabled = false;
            picbxNext.Enabled = false;
            picbxLast.Enabled = false;

            prgbSearchStatus.Visible = false;
            
            //prgbSearchStatus.Style = ProgressBarStyle.Marquee;
            //prgbSearchStatus.MarqueeAnimationSpeed = 30;

            if (System.Diagnostics.Debugger.IsAttached)
                btnLog.Visible = true;
            else
                btnLog.Visible = false;

            //emlBrowser.DocumentText = MailChecker.get_mail_content_from_mimemessage("F:\\Freelancer_project\\C_sharp_FOX_mail\\Test\\OP_14-280.eml");
            emlBrowser.ScriptErrorsSuppressed = true;

        }

        public void show_log_window()
        {
            Program.g_log_frm.Show();
            Program.g_log_frm.Activate();
        }

        public void log(string msg, string logtype)
        {
            Program.g_full_log += "\n" + msg;

            this.InvokeOnUiThreadIfRequired(() =>
            {
                txt_last_log.Text = msg;
            });

            if (Program.g_log_frm != null)
                Program.g_log_frm.update_log();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        #region function part

        void load_accounts(string filename)
        {
            /*DataTable dt = new DataTable();

            dt = CSVUtil.csv2dt(filename);
            if (dt == null)
            {
                Program.log_error("Mail CSV file is invalid.", true);
            }
            else
            {
                Program.log_info($"{dt.Rows.Count} mails are loaded.");
                add_mails_to_checklistbox(dt);
            }*/

            List<string> lstr_accs = File.ReadAllLines(filename).ToList();

            if (lstr_accs.Count == 0)
            {
                MessageBox.Show("This file does not contain any lines.");
                return;
            }

            foreach(string s in lstr_accs)
            {
                string line = s;
                if (line.EndsWith("\n"))
                    line = line.Substring(0, line.Length - 1);

                string[] x = line.Split(':');
                if (x.Length != 2)
                {
                    MessageBox.Show("The file contains a invalid line. -> " + line);
                    return;
                }
            }

            add_mails_to_checklistbox(lstr_accs);
        }

        

        private void add_mails_to_checklistbox(DataTable dt)
        {
            List<string> cur_list = new List<string>();

            if (lvMails != null && lvMails.Items.Count > 0)
            {
                /*foreach(ListViewItem item in lvMails.Items)
                {
                    cur_list.Add(item.Text);
                }*/
                lvMails.Items.Clear();
            }
            m_lstMails.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string mail = row["Mail"].ToString();
                
                ListViewItem item = new ListViewItem();
                item.Text = mail;
                item.ImageIndex = ConstEnv.STATUS_UNCHECKED;
                lvMails.Items.Add(item);

                UserInfo info = UserInfo.GetInfoFromDataRow(row);
                if (info != null)
                    m_lstMails.Add(info);                
            }
        }

        private void add_mails_to_checklistbox(List<string> lstr_accs)
        {
            List<string> cur_list = new List<string>();

            if (lvMails != null && lvMails.Items.Count > 0)
            {
                /*foreach(ListViewItem item in lvMails.Items)
                {
                    cur_list.Add(item.Text);
                }*/
                lvMails.Items.Clear();
            }
            m_lstMails.Clear();

            foreach (string acc in lstr_accs)
            {
                string mail = acc.Split(':')[0];
                string pass = acc.Split(':')[1];

                ListViewItem item = new ListViewItem();
                item.Text = mail;
                item.ImageIndex = ConstEnv.STATUS_UNCHECKED;
                lvMails.Items.Add(item);

                UserInfo info = new UserInfo();
                info.mail_address = mail;
                info.password = pass;
                info.mail_server = Program.g_setting.MAIL_SERVER_HOST;
                info.mail_server_port = Program.g_setting.MAIL_SERVER_PORT;
                info.ssl = Program.g_setting.MAIL_SSL;

                if (info != null)
                    m_lstMails.Add(info);
            }
        }

        #endregion

        private void BtnLoadMail_Click(object sender, EventArgs e)
        {
            chkbMailSelAll.Checked = false;
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Open a file containing mail information";
                dlg.Filter = "TXT files|*.TXT|All files|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Program.log_info($"Mail file selected: {dlg.FileName}");
                    load_accounts(dlg.FileName);                    
                }
            }
            catch (Exception ex)
            {
                Program.log_error(ex.Message + "\n" + ex.StackTrace, true);
            }
        }

        private void BtnLog_Click(object sender, EventArgs e)
        {
            Program.show_log_window();
        }

        private void ChkbMailSelAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbMailSelAll.Checked == true)
            {
                for (int i = 0; i < lvMails.Items.Count; i++)
                {
                    lvMails.Items[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < lvMails.Items.Count; i++)
                {
                    lvMails.Items[i].Checked = false;
                }
            }
        }

        private void ChkbSearchAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbSearchAll.Checked == true)
            {
                lbAfter.Enabled = false;
                dteFromPicker.Enabled = false;
                dteBeforePicker.Enabled = false;
                lbBody.Enabled = false;
                rchtbxBody.Enabled = false;
                lbSubject.Enabled = false;
                rchtbxSubject.Enabled = false;
                chkboxAllFolders.Enabled = false;
                chkboxInbox.Enabled = false;
                chkboxSent.Enabled = false;
            }
            else
            {
                lbAfter.Enabled = true;
                dteFromPicker.Enabled = true;
                dteBeforePicker.Enabled = true;
                lbBody.Enabled = true;
                rchtbxBody.Enabled = true;
                lbSubject.Enabled = true;
                rchtbxSubject.Enabled = true;
                chkboxAllFolders.Enabled = true;
                chkboxInbox.Enabled = true;
                chkboxSent.Enabled = true;
            }
        }

        private void ChkboxAllFolders_CheckedChanged(object sender, EventArgs e)
        {
            if(chkboxAllFolders.Checked == true)
            {
                chkboxInbox.Enabled = false;
                chkboxSent.Enabled = false;
            }
            else
            {
                chkboxInbox.Enabled = true;
                chkboxSent.Enabled = true;
            }
        }

        private async void BtnCheckValid_Click(object sender, EventArgs e)
        {
            if(lvMails.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select mails.", "Item select error.");
                return;
            }

            List<UserInfo> checked_user_list;
            List<int> checked_idx_list;

            GetCheckedMails(out checked_user_list, out checked_idx_list);

            Program.g_last_used_proxy_idx = -1;
            
            if (btnCheckValid.Text == "Check")
            {
                //tbxEmlContent.Clear();
                emlBrowser.Refresh();
                    
                Program.g_must_end = false;
                btnCheckValid.Text = "Stop";

                bool is_check_finished = false;
                new Thread((ThreadStart)(async () =>
                {
                    await Task.Delay(100);

                    foreach (UserInfo user in checked_user_list)
                    {
                        if (Program.g_must_end)
                            break;

                        if (user != null)
                        {
                            Program.log_info($"Checking validity started - {user.mail_address}");

                            while (true)
                            {
                                ProxyData proxy = ProxyData.take_proxy_server_from_list();
                                MailChecker checker = new MailChecker(user, proxy);
                                int check_result = checker.try_connect();

                                bool is_escape_here = false;
                                switch (check_result)
                                {
                                    case 0:
                                        if (proxy != null)
                                        {
                                            ProxyData.remove_proxy_class(proxy);

                                            Program.log_info($"Proxy - {proxy} deleted from Form class list.");
                                        }
                                        else
                                            Program.log_info($"Connection with your own IP failed. Mail - {user.mail_address}");
                                        break;

                                    case 1:
                                        BeginInvoke(new Action(() =>
                                        {
                                            lvMails.Items[checked_idx_list[checked_user_list.IndexOf(user)]].ImageIndex = ConstEnv.STATUS_INVALID;
                                            user.validity = ConstEnv.STATUS_INVALID;
                                        }));
                                        is_escape_here = true;
                                        break;

                                    case 2:
                                        BeginInvoke(new Action(() =>
                                        {
                                            lvMails.Items[checked_idx_list[checked_user_list.IndexOf(user)]].ImageIndex = ConstEnv.STATUS_VALID;
                                            user.validity = ConstEnv.STATUS_VALID;
                                        }));
                                        is_escape_here = true;
                                        break;

                                    default:

                                        break;
                                }
                                if (is_escape_here || proxy == null)
                                    break;
                            }
                        }
                    }
                    is_check_finished = true;
                })).Start();

                await Task.Run(async () =>
                {
                    while(true)
                    {
                        await Task.Delay(100);
                        if (is_check_finished)
                            break;
                    }
                    Program.log_info("Validity check finished.");
                });
                btnCheckValid.Text = "Check";
            }
            else if (btnCheckValid.Text == "Stop")
            {
                Program.g_must_end = true;
                btnCheckValid.Text = "Check";
            }
            
            Program.log_info($"{lvMails.CheckedItems.Count} mails checked.");
        }

        

        private UserInfo GetUserInfoFromAddress(string addr)
        {
            foreach(UserInfo item in m_lstMails)
            {
                if (item.mail_address == addr)
                    return item;
            }
            return null;
        }

        private DataTable GetValidTableFromList()
        {
            try
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("Mail");
                dt.Columns.Add("Password");
                dt.Columns.Add("Mail Server");
                dt.Columns.Add("Port");
                dt.Columns.Add("SSL");

                foreach(UserInfo item in m_lstMails)
                {
                    if (item.validity != ConstEnv.STATUS_VALID)
                        continue;

                    DataRow row = dt.NewRow();
                    row["Mail"] = item.mail_address;
                    row["Password"] = item.password;
                    row["Mail Server"] = item.mail_server;
                    row["Port"] = item.mail_server_port;
                    row["SSL"] = item.ssl ? "1" : "0";

                    dt.Rows.Add(row);
                }

                return dt;
            }
            catch(Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
            return null;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "TXT files|*.txt";
            dialog.Title = "Save the Valid Mails";

            DataTable dt = GetValidTableFromList();
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show($"No Valid Mails.", "Save Result");
                return;
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;

                try
                {
                    string str_out = string.Empty;
                    foreach (UserInfo item in m_lstMails)
                    {
                        if (item.validity != ConstEnv.STATUS_VALID)
                            continue;

                        str_out += item.mail_address + ":" + item.password + "\n";
                    }

                    File.WriteAllText(filename, str_out);
                    MessageBox.Show($"{dt.Rows.Count} Valid Mails saved successfully.", "Save Result");
                }
                catch(Exception exception)
                {
                    Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
                    MessageBox.Show($"Check if file is opened. Then try again.", "Error");
                }
            }
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            Program.g_last_used_proxy_idx = -1;

            if (btnSearch.Text == "Search")
            {
                emlBrowser.Refresh();

                Stopwatch wt = new Stopwatch();
                wt.Start();

                lbTotalNum.Text = "";
                lbRange.Text = "/";
                Program.g_must_end = false;
                btnSearch.Text = "Stop";

                SearchParam searchparam = GetSearchParamFromUI();
                bool is_query_error = CheckParam(searchparam);
                if (!is_query_error)
                {
                    btnSearch.Text = "Search";
                    return;
                }

                prgbSearchStatus.Visible = true;
                /*int threads_num = 5;
                try
                {
                    threads_num = int.Parse(tbxThreadsNum.Text);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Threads Num Error");
                    btnSearch.Text = "Search";
                    return;
                }*/

                List<UserInfo> checked_valid_mails = GetCheckedValidMails();

                if (checked_valid_mails.Count > 0)
                {
                    Program.g_page_num = 1;
                    lvSearchResult.Items.Clear();
                    Program.g_search_result.Clear();

                    bool w_is_thread_finished = false;

                    new Thread((ThreadStart)(async () =>
                    {
                        foreach (UserInfo user in checked_valid_mails)
                        {
                            Program.g_prog_curr_mail = user.mail_address;

                            while(true)
                            {
                                if (Program.g_must_end)
                                    break;

                                ProxyData proxy = ProxyData.take_proxy_server_from_list();

                                MailChecker checker = new MailChecker(user, proxy, searchparam);
                                int search_result = await checker.Search();

                                if (search_result == ConstEnv.CONNECT_FAILED)
                                {
                                    if (proxy == null)
                                    {
                                        Program.log_info($"Connection to server using own IP failed. Mail - {user.mail_address}");
                                        break;
                                    }
                                    else
                                        continue;
                                }
                                else if (search_result == ConstEnv.CONNECT_SERVER_CON_SUCCESS)
                                {
                                    Program.log_info($"Login failed. Mail - {user.mail_address}. Proxy - {proxy}");
                                    break;
                                }
                                else if (search_result == ConstEnv.SEARCH_ERROR)
                                {
                                    Program.log_info($"Search error. Mail - {user.mail_address}. Proxy - {proxy}");
                                    break;
                                }
                                else if (search_result == ConstEnv.SEARCH_SUCCESS)
                                    break;
                                else
                                {
                                    Program.log_info($"Unexpectable result.");
                                    break;
                                }
                            }
                        }
                        w_is_thread_finished = true;
                    })).Start();

                    Program.log_info($"Search Results num - {Program.g_search_result.Count}");

                    new Thread((ThreadStart)(async () =>
                    {
                        while(true)
                        {
                            await Task.Delay(1000);
                            //if (Program.g_search_result.Count >= Program.g_setting.COUNTS_PER_PAGE)
                            if (Program.g_search_result.Count >= 1)
                            {
                                ShowResults(1);
                                break;
                            }
                            if (w_is_thread_finished)
                                break;
                        }
                    })).Start();

                    await Task.Run(async () =>
                    {
                        while (true)
                        {
                            int last_value = -1;
                            if (last_value != Program.g_page_num)
                            {
                                SetTypeArrows(Program.g_page_num);
                                last_value = Program.g_page_num;
                            }

                            if(Program.g_search_result.Count.ToString() != lbTotalNum.Text)
                            {
                                Invoke(new Action(() =>
                                {
                                    lbTotalNum.Text = Program.g_search_result.Count.ToString();
                                }));
                            }

                            Invoke(new Action(() =>
                            {
                                if (Program.g_prog_total > 0)
                                {
                                    prgbSearchStatus.Value = Math.Min(100, (int)((float)Program.g_prog_current * 100 / Program.g_prog_total));
                                    prgbSearchStatus.CustomText = Program.g_prog_curr_mail + " searching ";
                                }
                                else
                                    prgbSearchStatus.CustomText = Program.g_prog_curr_mail + " searching ";
                            }));
                            

                            if (w_is_thread_finished)
                            {
                                //if (Program.g_search_result.Count < Program.g_setting.COUNTS_PER_PAGE)
                                    ShowResults(1);
                                Program.log_info($"Search finished. Search Results - {Program.g_search_result.Count}");
                                break;
                            }          

                            await Task.Delay(1000);
                        }                        
                    });                    
                }
                else
                {
                    MessageBox.Show("No checked and valid mails.", "Search Error");
                }
                prgbSearchStatus.Visible = false;
                btnSearch.Text = "Search";

                Program.log_info($"Time elapsed - {((float)wt.ElapsedMilliseconds / 1000).ToString()}s.");
            }
            else if(btnSearch.Text == "Stop")
            {
                prgbSearchStatus.Visible = false;
                Program.g_must_end = true;
                btnSearch.Text = "Search";
            }
        }

        private void ShowResults(int page_num)
        {
            SetTypeArrows(page_num);

            int idx_from;
            int idx_to;

            if (Program.g_search_result.Count <= (page_num - 1) * Program.g_setting.COUNTS_PER_PAGE ||
                                                    Program.g_search_result.Count == 0)
                return;

            SetRangeLabel(out idx_from, out idx_to);

            Invoke(new Action(() =>
            {
                lvSearchResult.Items.Clear();
                for (int i = idx_from; i <= idx_to; i++)
                {
                    SearchResult item = Program.g_search_result[i - 1];

                    ListViewItem lvI = new ListViewItem(i.ToString());
                    lvI.SubItems.Add(item.strMail);
                    lvI.SubItems.Add(item.strSubject);
                    lvI.SubItems.Add(item.strName);
                    lvI.SubItems.Add(item.strFrom);
                    lvI.SubItems.Add(item.strSize);
                    lvI.SubItems.Add(item.dteDate.ToString());
                    lvI.SubItems.Add(item.nAttachNum.ToString());

                    lvSearchResult.Items.Add(lvI);
                }
                lvSearchResult.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }));
        }

        private void SetTypeArrows(int page_num)
        {
            if (Program.g_search_result.Count > page_num * Program.g_setting.COUNTS_PER_PAGE)
            {
                Invoke(new Action(() =>
                {
                    picbxNext.Enabled = true;
                    picbxLast.Enabled = true;
                }));                
            }
            else
            {
                BeginInvoke(new Action(() =>
                {
                    picbxNext.Enabled = false;
                    picbxLast.Enabled = false;
                }));
            }

            if(page_num == 1)
            {
                BeginInvoke(new Action(() =>
                {
                    picbxPrevious.Enabled = false;
                    picbxFirst.Enabled = false;
                }));
            }
            else
            {
                BeginInvoke(new Action(() =>
                {
                    picbxPrevious.Enabled = true;
                    picbxFirst.Enabled = true;
                }));
            }
        }

        private List<UserInfo> GetCheckedValidMails()
        {
            List<UserInfo> output = new List<UserInfo>();

            foreach (ListViewItem item in lvMails.CheckedItems)
            {
                UserInfo user = GetUserInfoFromAddress(item.Text);
                if (user == null)
                    continue;

                if (user.validity != ConstEnv.STATUS_VALID)
                    continue;
                output.Add(user);
            }
            return output;
        }

        private void GetCheckedMails(out List<UserInfo> userlist, out List<int> idxlist)
        {
            userlist = new List<UserInfo>();
            idxlist = new List<int>();

            foreach (ListViewItem item in lvMails.CheckedItems)
            {
                UserInfo user = GetUserInfoFromAddress(item.Text);
                int idx = item.Index;
                if (user == null)
                    continue;

                userlist.Add(user);
                idxlist.Add(idx);
            }
        }

        private bool CheckParam(SearchParam searchparam)
        {
            List<string> searchparam_check = new List<string>();

            if (!searchparam.is_All)
            {
                if (searchparam.dteAfter > searchparam.dteBefore + new TimeSpan(1, 0, 0, 0))
                {
                    searchparam_check.Add("After must be less than Before.");
                }
                if (!(searchparam.is_AllFolders || searchparam.is_InboxOnly || searchparam.is_SentOnly))
                {
                    searchparam_check.Add("Check at least one folder.");
                }
            }

            if (searchparam_check.Count > 0)
            {
                string error_msg = "";
                for (int i = 0; i < searchparam_check.Count; i++)
                {
                    if (i != 0)
                        error_msg += "\n";
                    error_msg += searchparam_check[i];
                }

                MessageBox.Show(error_msg, "Search Query Error");

                return false;
            }
            else
                return true;
        }

        private void SetRangeLabel(out int from, out int to)
        {
            from = Math.Min((Program.g_page_num - 1) * Program.g_setting.COUNTS_PER_PAGE + 1, Program.g_search_result.Count);
            to = Math.Min(Program.g_page_num * Program.g_setting.COUNTS_PER_PAGE, Program.g_search_result.Count);

            int from_num = from;
            int to_num = to;

            BeginInvoke(new Action(() =>
            {
                lbRange.Text = "/ " + from_num.ToString() + " ~ " + to_num.ToString();
            }));
        }

        private SearchParam GetSearchParamFromUI()
        {
            SearchParam w_SearchParam = new SearchParam();

            if (chkbSearchAll.Checked)
                w_SearchParam.is_All = true;
            else
            {
                w_SearchParam.is_All = false;

                w_SearchParam.dteAfter = dteFromPicker.Value;
                w_SearchParam.dteBefore = dteBeforePicker.Value;

                w_SearchParam.lstrSubjectKeys = rchtbxSubject.Text.Split('\n').ToList();
                w_SearchParam.lstrBodyKeys = rchtbxBody.Text.Split('\n').ToList();

                if (chkboxAllFolders.Checked)
                    w_SearchParam.is_AllFolders = true;
                else
                {
                    w_SearchParam.is_AllFolders = false;
                    w_SearchParam.is_InboxOnly = chkboxInbox.Checked;
                    w_SearchParam.is_SentOnly = chkboxSent.Checked;
                }
            }
            return w_SearchParam;
        }

        private void LvSearchResult_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lvSearchResult.FocusedItem != null && lvSearchResult.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    /*if (lvSearchResult.SelectedItems.Count > 1)
                        return;*/

                    /*int id = int.Parse(lvSearchResult.SelectedItems[0].SubItems["No"].Text);

                    string eml_path = Program.g_search_result[id].strEmlPath;
                    string mail_content = MailChecker.get_mail_content_from_mimemessage(eml_path);

                    tbxEmlContent.Text = mail_content;*/
                    SelectAction(sender, e);
                }
            }
        }

        private void SelectAction(object sender, MouseEventArgs e)
        {
            //id is extra value when you need or delete it
            ListView ListViewControl = sender as ListView;

            if (ListViewControl.SelectedItems.Count > 1)
                return;
            int id = int.Parse(ListViewControl.SelectedItems[0].SubItems[0].Text) - 1;

            string eml_path = Program.g_search_result[id].strEmlPath;
            string mail_content = MailChecker.get_html_from_eml(eml_path);

            lbSubj.Text = string.Empty;
            lbFrom.Text = string.Empty;
            lbDate.Text = string.Empty;
            lbTo.Text = string.Empty;

            string strSubj = string.Empty;
            string strFrom = string.Empty;
            string strTo = string.Empty;
            string strDate = string.Empty;

            MailChecker.get_meta_from_eml(eml_path, out strFrom, out strSubj, out strTo, out strDate);

            lbSubj.Text = strSubj;
            lbFrom.Text = strFrom;
            lbDate.Text = strDate;
            lbTo.Text = strTo;

            emlBrowser.DocumentText = mail_content;
        }

        private void PicbxFirst_Click(object sender, EventArgs e)
        {
            Program.g_page_num = 1;
            Program.log_info($"Page Number - {Program.g_page_num}");
            ShowResults(Program.g_page_num);
        }

        private void PicbxFirst_MouseHover(object sender, EventArgs e)
        {
            picbxFirst.Image = Properties.Resources.first_hover;
        }

        private void PicbxPrevious_Click(object sender, EventArgs e)
        {
            Program.g_page_num--;
            Program.log_info($"Page Number - {Program.g_page_num}");
            ShowResults(Program.g_page_num);
        }

        private void PicbxPrevious_MouseHover(object sender, EventArgs e)
        {
            picbxPrevious.Image = Properties.Resources.previous_hover;
        }

        private void PicbxNext_Click(object sender, EventArgs e)
        {
            Program.g_page_num++;
            Program.log_info($"Page Number - {Program.g_page_num}");
            ShowResults(Program.g_page_num);
        }

        private void PicbxNext_MouseHover(object sender, EventArgs e)
        {
            picbxNext.Image = Properties.Resources.next_hover;
        }

        private void PicbxLast_Click(object sender, EventArgs e)
        {
            Program.g_page_num = Program.g_search_result.Count / Program.g_setting.COUNTS_PER_PAGE + 1;
            Program.log_info($"Page Number - {Program.g_page_num}");
            ShowResults(Program.g_page_num);
        }

        private void PicbxLast_MouseHover(object sender, EventArgs e)
        {
            picbxLast.Image = Properties.Resources.last_hover;
        }

        private void PicbxFirst_MouseLeave(object sender, EventArgs e)
        {
            if (!picbxFirst.Enabled)
                return;
            picbxFirst.BackColor = Color.Transparent;
            picbxFirst.BorderStyle = BorderStyle.None;
            picbxFirst.Image = Properties.Resources.first;
            Invalidate();
        }

        private void PicbxPrevious_MouseLeave(object sender, EventArgs e)
        {

        }

        private void PicbxNext_MouseLeave(object sender, EventArgs e)
        {
            if (!picbxNext.Enabled)
                return;
            picbxNext.BackColor = Color.Transparent;
            picbxNext.BorderStyle = BorderStyle.None;
            picbxNext.Image = Properties.Resources.next;
            Invalidate();
        }

        private void PicbxLast_MouseLeave(object sender, EventArgs e)
        {
            if (!picbxLast.Enabled)
                return;
            picbxLast.BackColor = Color.Transparent;
            picbxLast.BorderStyle = BorderStyle.None;
            picbxLast.Image = Properties.Resources.last;
            Invalidate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(btnSearch.Text == "Stop")
            {
                MessageBox.Show("Working now. After finishing, Close.", "Warning");
                e.Cancel = true;
                return;
            }
            try
            {
                Program.close_log_window();
                Program.g_must_end = true;
                //Program.g_setting.Save();

                if(Directory.Exists(ConstEnv.PATH_MAILS))
                    Directory.Delete(ConstEnv.PATH_MAILS, true);
            }
            catch(Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
        }

        private void PicbxFirst_EnabledChanged(object sender, EventArgs e)
        {
            if(picbxFirst.Enabled)
            {
                picbxFirst.BackColor = Color.Transparent;
                picbxFirst.BorderStyle = BorderStyle.None;
                picbxFirst.Image = Properties.Resources.first;
                Invalidate();
            }
            else
            {
                picbxFirst.Image = Properties.Resources.first_grey;
                Invalidate();
            }
        }

        private void PicbxPrevious_EnabledChanged(object sender, EventArgs e)
        {
            if (picbxPrevious.Enabled)
            {
                picbxPrevious.BackColor = Color.Transparent;
                picbxPrevious.BorderStyle = BorderStyle.None;
                picbxPrevious.Image = Properties.Resources.previous;
                Invalidate();
            }
            else
            {
                picbxPrevious.Image = Properties.Resources.previous_grey;
                Invalidate();
            }
        }

        private void PicbxNext_EnabledChanged(object sender, EventArgs e)
        {
            if (picbxNext.Enabled)
            {
                picbxNext.BackColor = Color.Transparent;
                picbxNext.BorderStyle = BorderStyle.None;
                picbxNext.Image = Properties.Resources.next;
                Invalidate();
            }
            else
            {
                picbxNext.Image = Properties.Resources.next_grey;
                Invalidate();
            }
        }

        private void PicbxLast_EnabledChanged(object sender, EventArgs e)
        {
            if (picbxLast.Enabled)
            {
                picbxLast.BackColor = Color.Transparent;
                picbxLast.BorderStyle = BorderStyle.None;
                picbxLast.Image = Properties.Resources.last;
                Invalidate();
            }
            else
            {
                picbxLast.Image = Properties.Resources.last_grey;
                picbxLast.Invalidate();
            }
        }

        private void BtnProxy_Click(object sender, EventArgs e)
        {
            frmProxy dlgProxy = new frmProxy();
            dlgProxy.ShowDialog();
        }

        private void LvMails_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvMails.FocusedItem != null && lvMails.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ContextMenu m = new ContextMenu();

                    MenuItem delMenuItem = new MenuItem("Delete");
                    delMenuItem.Click += delegate (object sender2, EventArgs e2)
                    {
                        InfoAction(sender, e);
                    };// your action here 
                    m.MenuItems.Add(delMenuItem);

                    m.Show(lvMails, new Point(e.X, e.Y));
                }
            }
        }

        private void InfoAction(object sender, MouseEventArgs e)
        {
            //id is extra value when you need or delete it
            ListView ListViewControl = sender as ListView;

            if (ListViewControl.SelectedItems.Count > 1)
                return;
            string mail = ListViewControl.SelectedItems[0].SubItems[0].Text.ToString();

            UserInfo selected_user = GetUserInfoFromAddress(mail);
            m_lstMails.Remove(selected_user);
            lvMails.Items.Remove(ListViewControl.SelectedItems[0]);
        }

        private void btnNewPass_Click(object sender, EventArgs e)
        {
            frmNewPass dlg = new frmNewPass();
            dlg.ShowDialog();
        }
    }
}
