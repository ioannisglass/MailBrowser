using BaseModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailFinder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        public static UserSetting g_setting = new UserSetting();
        public static System.Object g_locker = new object();
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static Form1 g_main_frm = null;

        public static frmLog g_log_frm = null;
        public static bool g_show_log_frm = false;
        public static string g_full_log = "";
        public static string g_working_directory = "";

        public static bool g_must_end = false;

        public static List<SearchResult> g_search_result = new List<SearchResult>();
        public static int g_page_num = 1;

        public static int g_prog_total = 0;
        public static int g_prog_current = 0;
        public static string g_prog_curr_mail = "";

        public static List<ProxyData> g_clsProxy = new List<ProxyData>();
        public static int g_last_used_proxy_idx = 0;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            // if (!File.Exists("base.dat"))
            // {
            //     MessageBox.Show("No base file.");
            //     Environment.Exit(0);
            // }

            // frmPass dlg_pass = new frmPass();
            // if (dlg_pass.ShowDialog() != DialogResult.OK)
            //     Environment.Exit(0);

            //g_setting = UserSetting.Load();
            if (g_setting == null)
            {
                g_setting = new UserSetting();
                //g_setting.Save();
            }

            g_working_directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            g_main_frm = new Form1();
            Application.Run(g_main_frm);
        }

        public static void show_log_window()
        {
            if (!g_show_log_frm)
            {
                Thread thread = new Thread(() =>
                {
                    g_log_frm = new frmLog();

                    g_log_frm.ShowDialog();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                g_show_log_frm = true;
            }
            else
            {
                if (g_log_frm != null)
                {
                    g_log_frm.BeginInvoke(new Action(() => { g_log_frm.Activate(); }));
                }
            }
        }
        public static void close_log_window()
        {
            if (g_log_frm != null)
            {
                g_log_frm.BeginInvoke(new Action(() => { g_log_frm.Close(); }));
            }
        }
        public static void log(string msg, string logtype, bool msgbox = false)
        {
            lock (g_locker)
            {
                try
                {
                    if (logtype == "error")
                        logger.Error(msg);
                    else
                        logger.Info(msg);

                    if (msgbox)
                        MessageBox.Show(msg);

                    msg = DateTime.Now.ToString("dd.MM.yyyy_hh:mm:ss ") + msg;
                    g_main_frm.log(msg, logtype);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public static void log_info(string msg, bool msgbox = false)
        {
            log(msg, "info", msgbox);
        }

        public static void log_error(string msg, bool msgbox = false)
        {
            log(msg, "error", msgbox);
        }
        public static void log_todo(string msg)
        {
            log(msg, "todo", false);
        }
    }
}
