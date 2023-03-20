using CustomControl;

namespace MailFinder
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.base_panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewPass = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnProxy = new System.Windows.Forms.Button();
            this.grpSearchBox = new System.Windows.Forms.GroupBox();
            this.btnLog = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chkboxAllFolders = new System.Windows.Forms.CheckBox();
            this.chkboxSent = new System.Windows.Forms.CheckBox();
            this.chkboxInbox = new System.Windows.Forms.CheckBox();
            this.rchtbxBody = new System.Windows.Forms.RichTextBox();
            this.lbBody = new System.Windows.Forms.Label();
            this.rchtbxSubject = new System.Windows.Forms.RichTextBox();
            this.lbSubject = new System.Windows.Forms.Label();
            this.lbAfter = new System.Windows.Forms.Label();
            this.dteBeforePicker = new System.Windows.Forms.DateTimePicker();
            this.dteFromPicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkbSearchAll = new System.Windows.Forms.CheckBox();
            this.grpMailBox = new System.Windows.Forms.GroupBox();
            this.lvMails = new System.Windows.Forms.ListView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCheckValid = new System.Windows.Forms.Button();
            this.btnLoadMail = new System.Windows.Forms.Button();
            this.chkbMailSelAll = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lvSearchResult = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.picbxLast = new CustomControl.SimpleImageButton();
            this.lbTotal = new System.Windows.Forms.Label();
            this.picbxNext = new CustomControl.SimpleImageButton();
            this.picbxPrevious = new CustomControl.SimpleImageButton();
            this.picbxFirst = new CustomControl.SimpleImageButton();
            this.lbTotalNum = new System.Windows.Forms.Label();
            this.lbRange = new System.Windows.Forms.Label();
            this.prgbSearchStatus = new CustomControl.TextProgressBar();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.emlBrowser = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbFrom = new System.Windows.Forms.Label();
            this.lbSubj = new System.Windows.Forms.Label();
            this.lbTo = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.base_panel2 = new System.Windows.Forms.Panel();
            this.txt_last_log = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.base_panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpSearchBox.SuspendLayout();
            this.grpMailBox.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbxLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxFirst)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.base_panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.base_panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.base_panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1084, 714);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // base_panel1
            // 
            this.base_panel1.Controls.Add(this.tableLayoutPanel2);
            this.base_panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.base_panel1.Location = new System.Drawing.Point(3, 3);
            this.base_panel1.Name = "base_panel1";
            this.base_panel1.Size = new System.Drawing.Size(1078, 683);
            this.base_panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.5F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1078, 683);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnNewPass);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnProxy);
            this.panel1.Controls.Add(this.grpSearchBox);
            this.panel1.Controls.Add(this.grpMailBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 677);
            this.panel1.TabIndex = 0;
            // 
            // btnNewPass
            // 
            this.btnNewPass.Location = new System.Drawing.Point(10, 635);
            this.btnNewPass.Name = "btnNewPass";
            this.btnNewPass.Size = new System.Drawing.Size(75, 23);
            this.btnNewPass.TabIndex = 4;
            this.btnNewPass.Text = "New Pass";
            this.btnNewPass.UseVisualStyleBackColor = true;
            this.btnNewPass.Click += new System.EventHandler(this.btnNewPass_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(208, 635);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnProxy
            // 
            this.btnProxy.Location = new System.Drawing.Point(110, 635);
            this.btnProxy.Name = "btnProxy";
            this.btnProxy.Size = new System.Drawing.Size(75, 23);
            this.btnProxy.TabIndex = 2;
            this.btnProxy.Text = "Proxy...";
            this.btnProxy.UseVisualStyleBackColor = true;
            this.btnProxy.Click += new System.EventHandler(this.BtnProxy_Click);
            // 
            // grpSearchBox
            // 
            this.grpSearchBox.Controls.Add(this.btnLog);
            this.grpSearchBox.Controls.Add(this.label3);
            this.grpSearchBox.Controls.Add(this.chkboxAllFolders);
            this.grpSearchBox.Controls.Add(this.chkboxSent);
            this.grpSearchBox.Controls.Add(this.chkboxInbox);
            this.grpSearchBox.Controls.Add(this.rchtbxBody);
            this.grpSearchBox.Controls.Add(this.lbBody);
            this.grpSearchBox.Controls.Add(this.rchtbxSubject);
            this.grpSearchBox.Controls.Add(this.lbSubject);
            this.grpSearchBox.Controls.Add(this.lbAfter);
            this.grpSearchBox.Controls.Add(this.dteBeforePicker);
            this.grpSearchBox.Controls.Add(this.dteFromPicker);
            this.grpSearchBox.Controls.Add(this.label1);
            this.grpSearchBox.Controls.Add(this.chkbSearchAll);
            this.grpSearchBox.Location = new System.Drawing.Point(8, 245);
            this.grpSearchBox.Name = "grpSearchBox";
            this.grpSearchBox.Size = new System.Drawing.Size(275, 379);
            this.grpSearchBox.TabIndex = 1;
            this.grpSearchBox.TabStop = false;
            this.grpSearchBox.Text = "Search Box";
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(188, 19);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(75, 23);
            this.btnLog.TabIndex = 4;
            this.btnLog.Text = "View Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.BtnLog_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkboxAllFolders
            // 
            this.chkboxAllFolders.AutoSize = true;
            this.chkboxAllFolders.Location = new System.Drawing.Point(7, 343);
            this.chkboxAllFolders.Name = "chkboxAllFolders";
            this.chkboxAllFolders.Size = new System.Drawing.Size(74, 17);
            this.chkboxAllFolders.TabIndex = 14;
            this.chkboxAllFolders.Text = "All Folders";
            this.chkboxAllFolders.UseVisualStyleBackColor = true;
            this.chkboxAllFolders.Click += new System.EventHandler(this.ChkboxAllFolders_CheckedChanged);
            // 
            // chkboxSent
            // 
            this.chkboxSent.AutoSize = true;
            this.chkboxSent.Location = new System.Drawing.Point(191, 343);
            this.chkboxSent.Name = "chkboxSent";
            this.chkboxSent.Size = new System.Drawing.Size(72, 17);
            this.chkboxSent.TabIndex = 13;
            this.chkboxSent.Text = "Sent Only";
            this.chkboxSent.UseVisualStyleBackColor = true;
            // 
            // chkboxInbox
            // 
            this.chkboxInbox.AutoSize = true;
            this.chkboxInbox.Location = new System.Drawing.Point(96, 343);
            this.chkboxInbox.Name = "chkboxInbox";
            this.chkboxInbox.Size = new System.Drawing.Size(76, 17);
            this.chkboxInbox.TabIndex = 12;
            this.chkboxInbox.Text = "Inbox Only";
            this.chkboxInbox.UseVisualStyleBackColor = true;
            // 
            // rchtbxBody
            // 
            this.rchtbxBody.Location = new System.Drawing.Point(7, 247);
            this.rchtbxBody.Name = "rchtbxBody";
            this.rchtbxBody.Size = new System.Drawing.Size(262, 80);
            this.rchtbxBody.TabIndex = 9;
            this.rchtbxBody.Text = "";
            // 
            // lbBody
            // 
            this.lbBody.AutoSize = true;
            this.lbBody.Location = new System.Drawing.Point(10, 230);
            this.lbBody.Name = "lbBody";
            this.lbBody.Size = new System.Drawing.Size(31, 13);
            this.lbBody.TabIndex = 8;
            this.lbBody.Text = "Body";
            // 
            // rchtbxSubject
            // 
            this.rchtbxSubject.Location = new System.Drawing.Point(6, 139);
            this.rchtbxSubject.Name = "rchtbxSubject";
            this.rchtbxSubject.Size = new System.Drawing.Size(262, 80);
            this.rchtbxSubject.TabIndex = 7;
            this.rchtbxSubject.Text = "";
            // 
            // lbSubject
            // 
            this.lbSubject.AutoSize = true;
            this.lbSubject.Location = new System.Drawing.Point(10, 122);
            this.lbSubject.Name = "lbSubject";
            this.lbSubject.Size = new System.Drawing.Size(43, 13);
            this.lbSubject.TabIndex = 6;
            this.lbSubject.Text = "Subject";
            // 
            // lbAfter
            // 
            this.lbAfter.AutoSize = true;
            this.lbAfter.Location = new System.Drawing.Point(7, 71);
            this.lbAfter.Name = "lbAfter";
            this.lbAfter.Size = new System.Drawing.Size(30, 13);
            this.lbAfter.TabIndex = 4;
            this.lbAfter.Text = "Date";
            // 
            // dteBeforePicker
            // 
            this.dteBeforePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteBeforePicker.Location = new System.Drawing.Point(162, 91);
            this.dteBeforePicker.Name = "dteBeforePicker";
            this.dteBeforePicker.Size = new System.Drawing.Size(103, 20);
            this.dteBeforePicker.TabIndex = 3;
            // 
            // dteFromPicker
            // 
            this.dteFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFromPicker.Location = new System.Drawing.Point(10, 91);
            this.dteFromPicker.MaximumSize = new System.Drawing.Size(124, 20);
            this.dteFromPicker.Name = "dteFromPicker";
            this.dteFromPicker.Size = new System.Drawing.Size(103, 20);
            this.dteFromPicker.TabIndex = 2;
            this.dteFromPicker.Tag = "";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(7, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 2);
            this.label1.TabIndex = 1;
            // 
            // chkbSearchAll
            // 
            this.chkbSearchAll.AutoSize = true;
            this.chkbSearchAll.Location = new System.Drawing.Point(7, 30);
            this.chkbSearchAll.Name = "chkbSearchAll";
            this.chkbSearchAll.Size = new System.Drawing.Size(70, 17);
            this.chkbSearchAll.TabIndex = 0;
            this.chkbSearchAll.Text = "All Emails";
            this.chkbSearchAll.UseVisualStyleBackColor = true;
            this.chkbSearchAll.Click += new System.EventHandler(this.ChkbSearchAll_CheckedChanged);
            // 
            // grpMailBox
            // 
            this.grpMailBox.Controls.Add(this.lvMails);
            this.grpMailBox.Controls.Add(this.btnSave);
            this.grpMailBox.Controls.Add(this.btnCheckValid);
            this.grpMailBox.Controls.Add(this.btnLoadMail);
            this.grpMailBox.Controls.Add(this.chkbMailSelAll);
            this.grpMailBox.Location = new System.Drawing.Point(8, 8);
            this.grpMailBox.Name = "grpMailBox";
            this.grpMailBox.Size = new System.Drawing.Size(275, 231);
            this.grpMailBox.TabIndex = 0;
            this.grpMailBox.TabStop = false;
            this.grpMailBox.Text = "Mail Box";
            // 
            // lvMails
            // 
            this.lvMails.CheckBoxes = true;
            this.lvMails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvMails.HideSelection = false;
            this.lvMails.Location = new System.Drawing.Point(7, 19);
            this.lvMails.Name = "lvMails";
            this.lvMails.Size = new System.Drawing.Size(262, 165);
            this.lvMails.TabIndex = 5;
            this.lvMails.UseCompatibleStateImageBehavior = false;
            this.lvMails.View = System.Windows.Forms.View.Details;
            this.lvMails.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LvMails_MouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(210, 193);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCheckValid
            // 
            this.btnCheckValid.Location = new System.Drawing.Point(143, 193);
            this.btnCheckValid.Name = "btnCheckValid";
            this.btnCheckValid.Size = new System.Drawing.Size(55, 23);
            this.btnCheckValid.TabIndex = 3;
            this.btnCheckValid.Text = "Check";
            this.btnCheckValid.UseVisualStyleBackColor = true;
            this.btnCheckValid.Click += new System.EventHandler(this.BtnCheckValid_Click);
            // 
            // btnLoadMail
            // 
            this.btnLoadMail.Location = new System.Drawing.Point(78, 193);
            this.btnLoadMail.Name = "btnLoadMail";
            this.btnLoadMail.Size = new System.Drawing.Size(55, 23);
            this.btnLoadMail.TabIndex = 2;
            this.btnLoadMail.Text = "Load";
            this.btnLoadMail.UseVisualStyleBackColor = true;
            this.btnLoadMail.Click += new System.EventHandler(this.BtnLoadMail_Click);
            // 
            // chkbMailSelAll
            // 
            this.chkbMailSelAll.AutoSize = true;
            this.chkbMailSelAll.Location = new System.Drawing.Point(6, 198);
            this.chkbMailSelAll.Name = "chkbMailSelAll";
            this.chkbMailSelAll.Size = new System.Drawing.Size(70, 17);
            this.chkbMailSelAll.TabIndex = 1;
            this.chkbMailSelAll.Text = "Select All";
            this.chkbMailSelAll.UseVisualStyleBackColor = true;
            this.chkbMailSelAll.Click += new System.EventHandler(this.ChkbMailSelAll_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(303, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 677);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel5);
            this.splitContainer1.Size = new System.Drawing.Size(772, 677);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lvSearchResult, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(770, 298);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // lvSearchResult
            // 
            this.lvSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSearchResult.FullRowSelect = true;
            this.lvSearchResult.GridLines = true;
            this.lvSearchResult.HideSelection = false;
            this.lvSearchResult.Location = new System.Drawing.Point(3, 3);
            this.lvSearchResult.MultiSelect = false;
            this.lvSearchResult.Name = "lvSearchResult";
            this.lvSearchResult.Size = new System.Drawing.Size(764, 262);
            this.lvSearchResult.TabIndex = 0;
            this.lvSearchResult.UseCompatibleStateImageBehavior = false;
            this.lvSearchResult.View = System.Windows.Forms.View.Details;
            this.lvSearchResult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LvSearchResult_MouseClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 271);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(764, 24);
            this.panel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.prgbSearchStatus, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(764, 24);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.picbxLast);
            this.panel4.Controls.Add(this.lbTotal);
            this.panel4.Controls.Add(this.picbxNext);
            this.panel4.Controls.Add(this.picbxPrevious);
            this.panel4.Controls.Add(this.picbxFirst);
            this.panel4.Controls.Add(this.lbTotalNum);
            this.panel4.Controls.Add(this.lbRange);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(397, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(344, 18);
            this.panel4.TabIndex = 0;
            // 
            // picbxLast
            // 
            this.picbxLast.BackColor = System.Drawing.Color.Transparent;
            this.picbxLast.Image = global::MailFinder.Properties.Resources.last;
            this.picbxLast.Location = new System.Drawing.Point(284, 0);
            this.picbxLast.Name = "picbxLast";
            this.picbxLast.Size = new System.Drawing.Size(17, 17);
            this.picbxLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picbxLast.TabIndex = 6;
            this.picbxLast.TabStop = false;
            this.picbxLast.EnabledChanged += new System.EventHandler(this.PicbxLast_EnabledChanged);
            this.picbxLast.Click += new System.EventHandler(this.PicbxLast_Click);
            this.picbxLast.MouseLeave += new System.EventHandler(this.PicbxLast_MouseLeave);
            this.picbxLast.MouseHover += new System.EventHandler(this.PicbxLast_MouseHover);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbTotal.Location = new System.Drawing.Point(3, 3);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(40, 13);
            this.lbTotal.TabIndex = 0;
            this.lbTotal.Text = "Total : ";
            // 
            // picbxNext
            // 
            this.picbxNext.BackColor = System.Drawing.Color.Transparent;
            this.picbxNext.Image = global::MailFinder.Properties.Resources.next;
            this.picbxNext.Location = new System.Drawing.Point(254, 0);
            this.picbxNext.Name = "picbxNext";
            this.picbxNext.Size = new System.Drawing.Size(17, 17);
            this.picbxNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picbxNext.TabIndex = 5;
            this.picbxNext.TabStop = false;
            this.picbxNext.EnabledChanged += new System.EventHandler(this.PicbxNext_EnabledChanged);
            this.picbxNext.Click += new System.EventHandler(this.PicbxNext_Click);
            this.picbxNext.MouseLeave += new System.EventHandler(this.PicbxNext_MouseLeave);
            this.picbxNext.MouseHover += new System.EventHandler(this.PicbxNext_MouseHover);
            // 
            // picbxPrevious
            // 
            this.picbxPrevious.BackColor = System.Drawing.Color.Transparent;
            this.picbxPrevious.Image = global::MailFinder.Properties.Resources.previous;
            this.picbxPrevious.Location = new System.Drawing.Point(224, 0);
            this.picbxPrevious.Name = "picbxPrevious";
            this.picbxPrevious.Size = new System.Drawing.Size(17, 17);
            this.picbxPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picbxPrevious.TabIndex = 4;
            this.picbxPrevious.TabStop = false;
            this.picbxPrevious.EnabledChanged += new System.EventHandler(this.PicbxPrevious_EnabledChanged);
            this.picbxPrevious.Click += new System.EventHandler(this.PicbxPrevious_Click);
            this.picbxPrevious.MouseLeave += new System.EventHandler(this.PicbxPrevious_MouseLeave);
            this.picbxPrevious.MouseHover += new System.EventHandler(this.PicbxPrevious_MouseHover);
            // 
            // picbxFirst
            // 
            this.picbxFirst.BackColor = System.Drawing.Color.Transparent;
            this.picbxFirst.Image = global::MailFinder.Properties.Resources.first;
            this.picbxFirst.Location = new System.Drawing.Point(194, 0);
            this.picbxFirst.Name = "picbxFirst";
            this.picbxFirst.Size = new System.Drawing.Size(17, 17);
            this.picbxFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picbxFirst.TabIndex = 3;
            this.picbxFirst.TabStop = false;
            this.picbxFirst.EnabledChanged += new System.EventHandler(this.PicbxFirst_EnabledChanged);
            this.picbxFirst.Click += new System.EventHandler(this.PicbxFirst_Click);
            this.picbxFirst.MouseLeave += new System.EventHandler(this.PicbxFirst_MouseLeave);
            this.picbxFirst.MouseHover += new System.EventHandler(this.PicbxFirst_MouseHover);
            // 
            // lbTotalNum
            // 
            this.lbTotalNum.AutoSize = true;
            this.lbTotalNum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbTotalNum.Location = new System.Drawing.Point(43, 3);
            this.lbTotalNum.Name = "lbTotalNum";
            this.lbTotalNum.Size = new System.Drawing.Size(0, 13);
            this.lbTotalNum.TabIndex = 1;
            // 
            // lbRange
            // 
            this.lbRange.AutoSize = true;
            this.lbRange.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbRange.Location = new System.Drawing.Point(88, 3);
            this.lbRange.Name = "lbRange";
            this.lbRange.Size = new System.Drawing.Size(12, 13);
            this.lbRange.TabIndex = 2;
            this.lbRange.Text = "/";
            // 
            // prgbSearchStatus
            // 
            this.prgbSearchStatus.CustomText = "";
            this.prgbSearchStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgbSearchStatus.Location = new System.Drawing.Point(1, 1);
            this.prgbSearchStatus.Margin = new System.Windows.Forms.Padding(1);
            this.prgbSearchStatus.Name = "prgbSearchStatus";
            this.prgbSearchStatus.ProgressColor = System.Drawing.Color.LightGreen;
            this.prgbSearchStatus.Size = new System.Drawing.Size(392, 22);
            this.prgbSearchStatus.TabIndex = 1;
            this.prgbSearchStatus.TextColor = System.Drawing.Color.Black;
            this.prgbSearchStatus.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prgbSearchStatus.VisualMode = CustomControl.ProgressBarDisplayMode.TextAndPercentage;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(770, 371);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.emlBrowser);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 83);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(764, 285);
            this.panel5.TabIndex = 0;
            // 
            // emlBrowser
            // 
            this.emlBrowser.AllowNavigation = false;
            this.emlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emlBrowser.Location = new System.Drawing.Point(0, 0);
            this.emlBrowser.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.emlBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.emlBrowser.Name = "emlBrowser";
            this.emlBrowser.Size = new System.Drawing.Size(764, 285);
            this.emlBrowser.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.lbFrom, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.lbSubj, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.lbTo, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.lbDate, 1, 3);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(764, 80);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "    From";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Subject ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "        To ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "     Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFrom.Location = new System.Drawing.Point(58, 0);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(703, 20);
            this.lbFrom.TabIndex = 4;
            this.lbFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSubj
            // 
            this.lbSubj.AutoSize = true;
            this.lbSubj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSubj.Location = new System.Drawing.Point(58, 20);
            this.lbSubj.Name = "lbSubj";
            this.lbSubj.Size = new System.Drawing.Size(703, 20);
            this.lbSubj.TabIndex = 5;
            this.lbSubj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTo.Location = new System.Drawing.Point(58, 40);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(703, 20);
            this.lbTo.TabIndex = 6;
            this.lbTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDate.Location = new System.Drawing.Point(58, 60);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(703, 20);
            this.lbDate.TabIndex = 7;
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // base_panel2
            // 
            this.base_panel2.Controls.Add(this.txt_last_log);
            this.base_panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.base_panel2.Location = new System.Drawing.Point(3, 689);
            this.base_panel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.base_panel2.Name = "base_panel2";
            this.base_panel2.Size = new System.Drawing.Size(1078, 25);
            this.base_panel2.TabIndex = 1;
            // 
            // txt_last_log
            // 
            this.txt_last_log.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txt_last_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_last_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_last_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_last_log.Location = new System.Drawing.Point(0, 0);
            this.txt_last_log.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txt_last_log.Name = "txt_last_log";
            this.txt_last_log.ReadOnly = true;
            this.txt_last_log.Size = new System.Drawing.Size(1078, 13);
            this.txt_last_log.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 714);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1100, 753);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mail Finder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.base_panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grpSearchBox.ResumeLayout(false);
            this.grpSearchBox.PerformLayout();
            this.grpMailBox.ResumeLayout(false);
            this.grpMailBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbxLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxFirst)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.base_panel2.ResumeLayout(false);
            this.base_panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel base_panel1;
        private System.Windows.Forms.Panel base_panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnProxy;
        private System.Windows.Forms.GroupBox grpSearchBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkboxAllFolders;
        private System.Windows.Forms.CheckBox chkboxSent;
        private System.Windows.Forms.CheckBox chkboxInbox;
        private System.Windows.Forms.RichTextBox rchtbxBody;
        private System.Windows.Forms.Label lbBody;
        private System.Windows.Forms.RichTextBox rchtbxSubject;
        private System.Windows.Forms.Label lbSubject;
        private System.Windows.Forms.Label lbAfter;
        private System.Windows.Forms.DateTimePicker dteBeforePicker;
        private System.Windows.Forms.DateTimePicker dteFromPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkbSearchAll;
        private System.Windows.Forms.GroupBox grpMailBox;
        private System.Windows.Forms.ListView lvMails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCheckValid;
        private System.Windows.Forms.Button btnLoadMail;
        private System.Windows.Forms.CheckBox chkbMailSelAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListView lvSearchResult;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel4;
        private SimpleImageButton picbxLast;
        private System.Windows.Forms.Label lbTotal;
        private SimpleImageButton picbxNext;
        private SimpleImageButton picbxPrevious;
        private SimpleImageButton picbxFirst;
        private System.Windows.Forms.Label lbTotalNum;
        private System.Windows.Forms.Label lbRange;
        private TextProgressBar prgbSearchStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.WebBrowser emlBrowser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label lbSubj;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.TextBox txt_last_log;
        private System.Windows.Forms.Button btnNewPass;
    }
}

