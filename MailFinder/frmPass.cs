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

namespace MailFinder
{
    public partial class frmPass : Form
    {
        public frmPass()
        {
            InitializeComponent();
        }

        private void CheckPass()
        {
            if (txt_pass.Text == string.Empty)
            {
                MessageBox.Show("Input password correctly.");
                return;
            }

            FileCipher.DecryptFile("base.dat", "base0.dat");
            string decrypted = StringCipher.Decrypt(File.ReadAllText("base0.dat"), "sugh");
            File.Delete("base0.dat");

            if (decrypted != txt_pass.Text)
            {
                MessageBox.Show("Invalid password.");
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CheckPass();
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CheckPass();
        }
    }
}
