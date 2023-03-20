using MailFinder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace BaseModule
{
    public class ProxyData
    {
        public string ip;
        public string port;
        public string login;
        public string password;

        public int type;

        public WebProxy Proxy { get; set; }

        public ProxyData(string host, int port, int in_type)
        {
            this.Proxy = new WebProxy(host, port);
            type = in_type;
        }

        public ProxyData(string host, int port, string username, string password, int in_type)
        {
            this.Proxy = new WebProxy(new Uri(string.Format("http://{0}:{1}", (object)host, (object)port)), true, (string[])null, (ICredentials)new NetworkCredential(username, password));
            type = in_type;
        }

        public ProxyData(WebProxy proxy, int in_type)
        {
            this.Proxy = proxy;
            this.ip = proxy.Address.Host;
            this.port = proxy.Address.Port.ToString();
            this.login = proxy.Credentials.GetCredential(new Uri(string.Format("http://{0}:{1}", (object)this.ip, (object)this.port)), "").UserName;
            this.password = proxy.Credentials.GetCredential(new Uri(string.Format("http://{0}:{1}", (object)this.ip, (object)this.port)), "").Password;
            type = in_type;
        }

        /*public static List<ProxyData> LoadProxyDataFromFile(string path)
        {
            List<ProxyData> proxyDataList = new List<ProxyData>();
            foreach (string readAllLine in System.IO.File.ReadAllLines(path))
            {
                int length = readAllLine.Split(':').Length;
                if (length == 2)
                {
                    Regex regex = new Regex("(.*):(.*)");
                    string host = regex.Match(readAllLine.Replace(" ", string.Empty)).Groups[1].Value;
                    string s = regex.Match(readAllLine.Replace(" ", string.Empty)).Groups[2].Value;
                    if (host != "" && host != null && s != "" && s != null)
                    {
                        ProxyData proxyData = new ProxyData(host, int.Parse(s), );
                        proxyDataList.Add(proxyData);
                    }
                }
                if (length == 4)
                {
                    Regex regex = new Regex("(.*):(.*):(.*):(.*)");
                    string host = regex.Match(readAllLine.Replace(" ", string.Empty)).Groups[1].Value;
                    string s = regex.Match(readAllLine.Replace(" ", string.Empty)).Groups[2].Value;
                    string username = regex.Match(readAllLine.Replace(" ", string.Empty)).Groups[3].Value;
                    string password = regex.Match(readAllLine.Replace(" ", string.Empty)).Groups[4].Value;
                    if (host != "" && host != null && s != "" && s != null)
                    {
                        ProxyData proxyData = new ProxyData(host, int.Parse(s), username, password);
                        proxyDataList.Add(proxyData);
                    }
                }
            }
            return proxyDataList;
        }*/

        /*public static List<List<ProxyData>> DivideProxyDataForThreads(List<ProxyData> inputProxyData, int threadsCount)
        {
            if (inputProxyData.Count < threadsCount)
                throw new Exception("inputProxyData.Count < threadsCount! NEED MORE inputProxyData!");
            List<List<ProxyData>> proxyDataListList = new List<List<ProxyData>>();
            for (int index = 0; index < threadsCount; ++index)
                proxyDataListList.Add(new List<ProxyData>());
            int index1 = 0;
            while (index1 != inputProxyData.Count)
            {
                foreach (List<ProxyData> proxyDataList in proxyDataListList)
                {
                    if (index1 < inputProxyData.Count)
                    {
                        proxyDataList.Add(inputProxyData[index1]);
                        ++index1;
                    }
                }
            }
            return proxyDataListList;
        }*/

        public static ProxyData GetProxyFromString(string strCurrentProxy, int in_type)
        {
            int length = strCurrentProxy.Split(':').Length;
            if (length == 2)
            {
                Regex regex = new Regex("(.*):(.*)");
                string host = regex.Match(strCurrentProxy.Replace(" ", string.Empty)).Groups[1].Value;
                string s = regex.Match(strCurrentProxy.Replace(" ", string.Empty)).Groups[2].Value;
                if (host != "" && host != null && s != "" && s != null)
                    return new ProxyData(host, int.Parse(s), in_type)
                    {
                        ip = host,
                        port = s,
                        type = in_type
                    };
            }
            if (length == 4)
            {
                Regex regex = new Regex("(.*):(.*):(.*):(.*)");
                string host = regex.Match(strCurrentProxy.Replace(" ", string.Empty)).Groups[1].Value;
                string s = regex.Match(strCurrentProxy.Replace(" ", string.Empty)).Groups[2].Value;
                string username = regex.Match(strCurrentProxy.Replace(" ", string.Empty)).Groups[3].Value;
                string password = regex.Match(strCurrentProxy.Replace(" ", string.Empty)).Groups[4].Value;
                if (host != "" && host != null && s != "" && s != null)
                    return new ProxyData(host, int.Parse(s), username, password, in_type)
                    {
                        ip = host,
                        port = s,
                        login = username,
                        password = password,
                        type = in_type
                    };
            }
            return (ProxyData)null;
        }

        public static ProxyData take_proxy_server_from_list()
        {
            ProxyData ps = null;

            lock (Program.g_clsProxy)
            {
                if (Program.g_clsProxy.Count == 0)
                    return ps;

                Program.g_last_used_proxy_idx++;
                if (Program.g_last_used_proxy_idx >= Program.g_clsProxy.Count)
                    Program.g_last_used_proxy_idx = 0;
            }

            return Program.g_clsProxy[Program.g_last_used_proxy_idx];
        }

        /*public static void remove_proxy_string(string proxy)
        {
            lock(Program.g_lstrProxy)
            {
                Program.g_lstrProxy.Remove(proxy);
            }
        }*/

        public static void remove_proxy_class(ProxyData proxy)
        {
            lock (Program.g_clsProxy)
            {
                Program.g_clsProxy.Remove(proxy);
            }
        }

        public static int load_proxies(string filename, int type)
        {
            List<string> temp_list = File.ReadAllLines(filename).ToList();
            if (temp_list.Count == 0)
            {
                Program.log_error("The file does not contain any proxies.", true);
                return 0;
            }

            int count = 0;
            foreach (string s in temp_list)
            {
                string[] x = s.Split(':');
                if (x.Length != 4)
                {
                    Program.log_error($"Proxy - {s} is not a valid type.");
                    continue;
                }

                ProxyData item = GetProxyFromString(s, type);

                if (!Program.g_clsProxy.Contains(item))
                {
                    Program.g_clsProxy.Add(item);
                    count++;
                }
            }

            Program.log_info($"{count} proxies are added.");
            return count;
        }
    }
}
