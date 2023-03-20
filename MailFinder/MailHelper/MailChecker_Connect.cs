using MailFinder;
using MailKit.Net.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailHelper
{
    partial class MailChecker
    {
        public int connect()
        {
            int return_value = ConstEnv.CONNECT_FAILED;
            try
            {
                Program.log_info($"mail server connecting.... server = {m_account.mail_server}, port = {m_account.mail_server_port}, user = {m_account.mail_address}");

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                if (m_proxy != null)
                {
                    var credentials = new NetworkCredential(m_proxy.login, m_proxy.password);
                    if(m_proxy.type == ConstEnv.PROXY_TYPE_SOCKS4)
                        client.ProxyClient = new Socks4Client(m_proxy.ip, int.Parse(m_proxy.port), credentials);
                    else if(m_proxy.type == ConstEnv.PROXY_TYPE_SOCKS5)
                        client.ProxyClient = new Socks5Client(m_proxy.ip, int.Parse(m_proxy.port), credentials);

                    Program.log_info($"Proxy used. host - {m_proxy.ip}");
                }

                client.Connect(m_account.mail_server, m_account.mail_server_port, MailKit.Security.SecureSocketOptions.Auto);
                return_value = ConstEnv.CONNECT_SERVER_CON_SUCCESS;
                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(m_account.mail_address, m_account.password);
                return_value = ConstEnv.CONNECT_LOGIN_SUCCESS;

                if(m_proxy != null)
                    Program.log_info($"Connected with proxy. Host - {m_proxy.ip}, Mail - {m_account.mail_address}");
                else
                    Program.log_info($"Connected without proxy. Mail - {m_account.mail_address}");
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
            return return_value;
        }
                
        public bool disconnect()
        {
            try
            {
                client.Disconnect(true);
                Program.log_info($"disconnected : server = {m_account.mail_server}");
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
                return false;
            }
            return true;
        }

        public int connect_retry()
        {
            while(true)
            {
                int return_value = ConstEnv.CONNECT_FAILED;
                try
                {
                    Program.log_info($"mail server connecting.... server = {m_account.mail_server}, port = {m_account.mail_server_port}, user = {m_account.mail_address}");

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    if (m_proxy != null)
                    {
                        var credentials = new NetworkCredential(m_proxy.login, m_proxy.password);
                        client.ProxyClient = new Socks5Client(m_proxy.ip, int.Parse(m_proxy.port), credentials);
                        Program.log_info($"Proxy used. host - {m_proxy.ip}");
                    }

                    client.Connect(m_account.mail_server, m_account.mail_server_port, MailKit.Security.SecureSocketOptions.Auto);
                    return_value = ConstEnv.CONNECT_SERVER_CON_SUCCESS;
                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(m_account.mail_address, m_account.password);
                    return_value = ConstEnv.CONNECT_LOGIN_SUCCESS;

                    if (m_proxy != null)
                        Program.log_info($"Connected with proxy. Host - {m_proxy.ip}");
                    else
                        Program.log_info($"Connected without proxy.");
                }
                catch (Exception exception)
                {
                    Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
                }
                return return_value;
            }
        }
    }
}
