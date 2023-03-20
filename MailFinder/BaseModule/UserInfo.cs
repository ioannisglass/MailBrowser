using MailFinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule
{
    public class UserInfo
    {
        public string mail_address;
        public string password;

        public string mail_server;
        public int mail_server_port;
        public bool ssl;

        public int validity = ConstEnv.STATUS_UNCHECKED;
        [JsonConverter(typeof(MailServerTypeConverter))]
        public int server_type;

        public static List<UserInfo> GetInfoFromDataTable(DataTable dt)
        {
            List<UserInfo> output = new List<UserInfo>();

            try
            {
                if (dt == null || dt.Rows.Count == 0)
                    return output;

                foreach (DataRow row in dt.Rows)
                {
                    UserInfo item = new UserInfo();
                    item.mail_address = row["Mail"].ToString();
                    item.password = row["Password"].ToString();
                    item.mail_server = row["Mail Server"].ToString();
                    item.mail_server_port = int.Parse(row["Port"].ToString());
                    item.ssl = row["SSL"].ToString() == "1";

                    output.Add(item);
                }
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
            return output;
        }

        public static UserInfo GetInfoFromDataRow(DataRow row)
        {
            UserInfo item = new UserInfo();

            try
            {
                item.mail_address = row["Mail"].ToString();
                item.password = row["Password"].ToString();
                item.mail_server = row["Mail Server"].ToString();
                item.mail_server_port = int.Parse(row["Port"].ToString());
                item.ssl = row["SSL"].ToString() == "1";

                return item;
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
                return null;
            }
        }
    }
    public class MailServerTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            int type = (int)value;
            string conv_value = "";
            if (type == ConstEnv.MAIL_SERVER_IMAP)
                conv_value = "imap";
            else if (type == ConstEnv.MAIL_SERVER_POP3)
                conv_value = "pop3";
            else if (type == ConstEnv.MAIL_SERVER_SMTP)
                conv_value = "smtp";
            else
                throw new Exception($"Unknown mail server type : ({type})");
            writer.WriteValue(conv_value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            int type = ConstEnv.MAIL_SERVER_IMAP;

            if (reader.TokenType == JsonToken.Null)
            {
                throw new Exception($"Unknown mail server type : ({reader.TokenType})");
            }
            else if (reader.TokenType == JsonToken.String)
            {
                string value = serializer.Deserialize(reader, Type.GetType("string")) as string;
                value = value.ToLower();
                if (value == "imap")
                    type = ConstEnv.MAIL_SERVER_IMAP;
                else if (value == "pop3")
                    type = ConstEnv.MAIL_SERVER_POP3;
                else if (value == "smtp")
                    type = ConstEnv.MAIL_SERVER_SMTP;
                else
                    throw new Exception($"Unknown mail server type : ({value})");
                return type;
            }
            else
            {
                throw new Exception($"Unknown mail server type : ({reader.TokenType})");
            }
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int);
        }
    }    
}
