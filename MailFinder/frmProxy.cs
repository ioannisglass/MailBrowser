using BaseModule;
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

namespace MailFinder
{
    public partial class frmProxy : Form
    {
        public frmProxy()
        {
            InitializeComponent();

            lbProxyCount.Text = Program.g_clsProxy.Count.ToString();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if(rbtnSocks4.Checked == false && rbtnSocks5.Checked == false)
            {
                MessageBox.Show("Select type.", "Warning");
                return;
            }

            if(tbxProxyPath.Text == null || tbxProxyPath.Text == string.Empty)
            {
                MessageBox.Show("Choose proxy file.", "Warning");
                return;
            }

            int proxy_type = 0;
            if (rbtnSocks4.Checked)
                proxy_type = ConstEnv.PROXY_TYPE_SOCKS4;
            else if(rbtnSocks5.Checked)
                proxy_type = ConstEnv.PROXY_TYPE_SOCKS5;

            int added_count = ProxyData.load_proxies(tbxProxyPath.Text, proxy_type);

            lbProxyCount.Text = Program.g_clsProxy.Count.ToString();
            MessageBox.Show($"{added_count} proxies added.", "Info");
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            tbxProxyPath.Clear();

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Open a text file containing proxies";
                dlg.Filter = "TXT files|*.txt|All files|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Program.log_info($"Proxy file selected: {dlg.FileName}");
                    tbxProxyPath.Text = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                Program.log_error(ex.Message + "\n" + ex.StackTrace, true);
            }
        }

        
    }
}
