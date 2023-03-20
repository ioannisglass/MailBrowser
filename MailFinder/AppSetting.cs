using MailFinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MailFinder
{
    public class AppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.ini";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            try
            {
                File.WriteAllText(fileName, JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented));
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(pSettings, Newtonsoft.Json.Formatting.Indented));
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            try
            {
                T t = new T();
                if (File.Exists(fileName))
                    t = JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
                else
                    return default(T);
                return t;
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
                return default(T);
            }
        }
    }

    public class UserSetting : AppSettings<UserSetting>
    {
        public int COUNTS_PER_PAGE = 10;
        public int SEARCH_MAILS_NUM_PER_THREAD = 500;

        public string MAIL_SERVER_HOST = "192.168.208.24";
        public int MAIL_SERVER_PORT = 143;
        public bool MAIL_SSL = true;

        /*public string MAIL_SERVER_HOST = "outlook.office365.com";
        public int MAIL_SERVER_PORT = 993;
        public bool MAIL_SSL = true;*/
    }
}
