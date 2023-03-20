namespace MailFinder
{
    partial class frmProxy
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnSocks5 = new System.Windows.Forms.RadioButton();
            this.rbtnSocks4 = new System.Windows.Forms.RadioButton();
            this.tbxProxyPath = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbProxyCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnSocks5);
            this.groupBox1.Controls.Add(this.rbtnSocks4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proxy Type";
            // 
            // rbtnSocks5
            // 
            this.rbtnSocks5.AutoSize = true;
            this.rbtnSocks5.Location = new System.Drawing.Point(226, 37);
            this.rbtnSocks5.Name = "rbtnSocks5";
            this.rbtnSocks5.Size = new System.Drawing.Size(90, 17);
            this.rbtnSocks5.TabIndex = 1;
            this.rbtnSocks5.TabStop = true;
            this.rbtnSocks5.Text = "Socks5 Proxy";
            this.rbtnSocks5.UseVisualStyleBackColor = true;
            // 
            // rbtnSocks4
            // 
            this.rbtnSocks4.AutoSize = true;
            this.rbtnSocks4.Location = new System.Drawing.Point(34, 37);
            this.rbtnSocks4.Name = "rbtnSocks4";
            this.rbtnSocks4.Size = new System.Drawing.Size(90, 17);
            this.rbtnSocks4.TabIndex = 0;
            this.rbtnSocks4.TabStop = true;
            this.rbtnSocks4.Text = "Socks4 Proxy";
            this.rbtnSocks4.UseVisualStyleBackColor = true;
            // 
            // tbxProxyPath
            // 
            this.tbxProxyPath.Location = new System.Drawing.Point(6, 29);
            this.tbxProxyPath.Name = "tbxProxyPath";
            this.tbxProxyPath.Size = new System.Drawing.Size(318, 20);
            this.tbxProxyPath.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Image = global::MailFinder.Properties.Resources.Google_Noto_Emoji_Objects_62917_open_file_folder;
            this.btnOpenFile.Location = new System.Drawing.Point(329, 28);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(20, 20);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(293, 191);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxProxyPath);
            this.groupBox2.Controls.Add(this.btnOpenFile);
            this.groupBox2.Location = new System.Drawing.Point(12, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 70);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proxy File Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current Proxy Count :";
            // 
            // lbProxyCount
            // 
            this.lbProxyCount.AutoSize = true;
            this.lbProxyCount.Location = new System.Drawing.Point(126, 196);
            this.lbProxyCount.Name = "lbProxyCount";
            this.lbProxyCount.Size = new System.Drawing.Size(0, 13);
            this.lbProxyCount.TabIndex = 7;
            // 
            // frmProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 230);
            this.Controls.Add(this.lbProxyCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.groupBox1);
            this.Icon = global::MailFinder.Properties.Resources.iconfinder_preferences_system_network_proxy_118822_4vR_icon;
            this.MaximumSize = new System.Drawing.Size(395, 269);
            this.MinimumSize = new System.Drawing.Size(395, 269);
            this.Name = "frmProxy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProxy";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxProxyPath;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.RadioButton rbtnSocks4;
        private System.Windows.Forms.RadioButton rbtnSocks5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbProxyCount;
    }
}