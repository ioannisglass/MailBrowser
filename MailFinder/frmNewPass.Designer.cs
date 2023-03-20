namespace MailFinder
{
    partial class frmNewPass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewPass));
            this.txt_new_pass = new System.Windows.Forms.TextBox();
            this.txt_new_pass_confirm = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_new_pass
            // 
            this.txt_new_pass.Location = new System.Drawing.Point(12, 12);
            this.txt_new_pass.Name = "txt_new_pass";
            this.txt_new_pass.PasswordChar = '*';
            this.txt_new_pass.Size = new System.Drawing.Size(167, 20);
            this.txt_new_pass.TabIndex = 0;
            this.txt_new_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_new_pass_KeyDown);
            // 
            // txt_new_pass_confirm
            // 
            this.txt_new_pass_confirm.Location = new System.Drawing.Point(12, 49);
            this.txt_new_pass_confirm.Name = "txt_new_pass_confirm";
            this.txt_new_pass_confirm.PasswordChar = '*';
            this.txt_new_pass_confirm.Size = new System.Drawing.Size(167, 20);
            this.txt_new_pass_confirm.TabIndex = 1;
            this.txt_new_pass_confirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_new_pass_confirm_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(104, 82);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmNewPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 117);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txt_new_pass_confirm);
            this.Controls.Add(this.txt_new_pass);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_new_pass;
        private System.Windows.Forms.TextBox txt_new_pass_confirm;
        private System.Windows.Forms.Button btnOk;
    }
}