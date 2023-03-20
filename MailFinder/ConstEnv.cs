using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFinder
{
    public static class ConstEnv
    {
        public static readonly int ACCOUNT_MAIL_CONNECT_FAILED = 0;

        public static readonly int PROXY_TYPE_HTTPS = 0;
        public static readonly int PROXY_TYPE_SOCKS4 = 1;
        public static readonly int PROXY_TYPE_SOCKS5 = 2;

        public static readonly int LOGIN_STARTED = 0;
        public static readonly int LOGIN_SUCCESS = 1;

        public static readonly int MAIL_SERVER_IMAP = 0;
        public static readonly int MAIL_SERVER_POP3 = 1;
        public static readonly int MAIL_SERVER_SMTP = 2;

        public static readonly int MAIL_UNCHECKED = 0;
        public static readonly int MAIL_CHECKED = 1;

        public static readonly string MAIL_CSV_DEFAULT_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mail.txt");
        public static readonly string PROXY_TXT_DEFAULT_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "proxy.txt");

        public static readonly int STATUS_UNCHECKED = 0;
        public static readonly int STATUS_VALID = 1;
        public static readonly int STATUS_INVALID = 2;

        public static readonly string PATH_MAILS = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Messages");

        //public static readonly int FETCH_CONNECT_FAILED = 0;
        //public static readonly int FETCH_ERROR = 3;
        //public static readonly int FETCH_SUCCESS = 4;

        public static readonly int CONNECT_FAILED = 0;
        public static readonly int CONNECT_SERVER_CON_SUCCESS = 1;
        public static readonly int CONNECT_LOGIN_SUCCESS = 2;

        public static readonly int SEARCH_ERROR = 3;
        public static readonly int SEARCH_SUCCESS = 4;
    }
}
