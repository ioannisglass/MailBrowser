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
    public partial class frmNewPass : Form
    {
        public frmNewPass()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txt_new_pass.Text == string.Empty)
            {
                MessageBox.Show("Input username correctly.");
                return;
            }

            if (txt_new_pass.Text != txt_new_pass_confirm.Text)
            {
                MessageBox.Show("Unmatched two inputs.");
                return;
            }

            Generate(txt_new_pass.Text);

            MessageBox.Show("Password changed.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void Generate(string password)
        {
            File.Delete("base.dat");
            string encrypted = StringCipher.Encrypt(password, "sugh");
            File.WriteAllText("base0.dat", encrypted);

            FileCipher.EncryptFile("base0.dat", "base.dat");
            File.Delete("base0.dat");
        }

        private void txt_new_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_new_pass.Text == string.Empty)
                {
                    MessageBox.Show("Input username correctly.");
                    return;
                }

                if (txt_new_pass.Text != txt_new_pass_confirm.Text)
                {
                    MessageBox.Show("Unmatched two inputs.");
                    return;
                }

                Generate(txt_new_pass.Text);

                MessageBox.Show("Password changed.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txt_new_pass_confirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_new_pass.Text == string.Empty)
                {
                    MessageBox.Show("Input username correctly.");
                    return;
                }

                if (txt_new_pass.Text != txt_new_pass_confirm.Text)
                {
                    MessageBox.Show("Unmatched two inputs.");
                    return;
                }

                Generate(txt_new_pass.Text);

                MessageBox.Show("Password changed.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
