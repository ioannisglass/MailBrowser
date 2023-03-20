using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BaseModule;
using MailFinder;
using MailKit.Net.Imap;
using MailKit.Search;

namespace MailHelper
{
    public partial class MailChecker
    {
        public ImapClient client = new ImapClient();

        private UserInfo m_account = new UserInfo();

        public ProxyData m_proxy;

        //private int m_account_id = -1;
        #region, search pro - params

        public int m_thread_num;
        public SearchParam m_search_param = new SearchParam();

        public bool is_search_finished;

        #endregion

        public MailChecker(UserInfo user, ProxyData proxy)
        {
            is_search_finished = false;

            m_account = user;
            
            m_proxy = proxy;
        }
                

        public MailChecker(UserInfo user, ProxyData proxy, SearchParam param)
        {
            is_search_finished = false;

            m_account = user;
            
            m_proxy = proxy;
            m_search_param = param;
        }
        public MailChecker(string addr, string pwd, string server, int portt, bool is_ssl, ProxyData proxy, SearchParam param)
        {
            is_search_finished = false;

            m_account.mail_address = addr;
            m_account.password = pwd;
            m_account.mail_server = server;
            m_account.mail_server_port = portt;
            m_account.ssl = is_ssl;

            m_proxy = proxy;
            m_search_param = param;
        }
        public int try_connect()
        {
            int output = connect();

            if (output >= ConstEnv.CONNECT_SERVER_CON_SUCCESS)
                disconnect();

            return output;
        }
    }
}
