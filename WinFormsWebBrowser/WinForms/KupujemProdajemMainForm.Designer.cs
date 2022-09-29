namespace WinFormsWebBrowser
{
    partial class KupujemProdajemMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KupujemProdajemMainForm));
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tlpWebBrowser = new System.Windows.Forms.TableLayoutPanel();
            this.tbAddressBar = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxKupujemProdajem = new System.Windows.Forms.GroupBox();
            this.articleWebLink = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCompanyAddress = new System.Windows.Forms.TextBox();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.tbPIB = new System.Windows.Forms.TextBox();
            this.lblArticleName = new System.Windows.Forms.Label();
            this.btnLoadArticles = new System.Windows.Forms.Button();
            this.tbLoadArticles = new System.Windows.Forms.TextBox();
            this.lblArticlCount = new System.Windows.Forms.Label();
            this.btnNextArticl = new System.Windows.Forms.Button();
            this.pbArticleImage = new System.Windows.Forms.PictureBox();
            this.btnKupujemProdajemLogin = new System.Windows.Forms.Button();
            this.groupBoxOglasi = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMobilePhoneMasks = new System.Windows.Forms.ComboBox();
            this.btnMobileMaskCategory = new System.Windows.Forms.Button();
            this.btnPhoneMask = new System.Windows.Forms.Button();
            this.btnDigitalVisionMobilePhones = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.oPROGRAMUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tlpWebBrowser.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.groupBoxKupujemProdajem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticleImage)).BeginInit();
            this.groupBoxOglasi.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 29);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(1187, 368);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser_DocumentCompleted);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tlpWebBrowser);
            this.splitContainer.Panel1.Margin = new System.Windows.Forms.Padding(3);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanel);
            this.splitContainer.Size = new System.Drawing.Size(1199, 634);
            this.splitContainer.SplitterDistance = 406;
            this.splitContainer.TabIndex = 1;
            // 
            // tlpWebBrowser
            // 
            this.tlpWebBrowser.ColumnCount = 1;
            this.tlpWebBrowser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpWebBrowser.Controls.Add(this.webBrowser, 0, 1);
            this.tlpWebBrowser.Controls.Add(this.tbAddressBar, 0, 0);
            this.tlpWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpWebBrowser.Location = new System.Drawing.Point(3, 3);
            this.tlpWebBrowser.Name = "tlpWebBrowser";
            this.tlpWebBrowser.RowCount = 2;
            this.tlpWebBrowser.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpWebBrowser.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpWebBrowser.Size = new System.Drawing.Size(1193, 400);
            this.tlpWebBrowser.TabIndex = 1;
            // 
            // tbAddressBar
            // 
            this.tbAddressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddressBar.Location = new System.Drawing.Point(3, 3);
            this.tbAddressBar.Name = "tbAddressBar";
            this.tbAddressBar.ReadOnly = true;
            this.tbAddressBar.Size = new System.Drawing.Size(1187, 20);
            this.tbAddressBar.TabIndex = 1;
            this.tbAddressBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tbAddressBar_MouseMove);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.02585F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.97414F));
            this.tableLayoutPanel.Controls.Add(this.groupBoxKupujemProdajem, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.groupBoxOglasi, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1199, 224);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // groupBoxKupujemProdajem
            // 
            this.groupBoxKupujemProdajem.Controls.Add(this.articleWebLink);
            this.groupBoxKupujemProdajem.Controls.Add(this.label4);
            this.groupBoxKupujemProdajem.Controls.Add(this.label3);
            this.groupBoxKupujemProdajem.Controls.Add(this.label2);
            this.groupBoxKupujemProdajem.Controls.Add(this.label1);
            this.groupBoxKupujemProdajem.Controls.Add(this.tbCompanyAddress);
            this.groupBoxKupujemProdajem.Controls.Add(this.tbCompanyName);
            this.groupBoxKupujemProdajem.Controls.Add(this.tbPIB);
            this.groupBoxKupujemProdajem.Controls.Add(this.lblArticleName);
            this.groupBoxKupujemProdajem.Controls.Add(this.btnLoadArticles);
            this.groupBoxKupujemProdajem.Controls.Add(this.tbLoadArticles);
            this.groupBoxKupujemProdajem.Controls.Add(this.lblArticlCount);
            this.groupBoxKupujemProdajem.Controls.Add(this.btnNextArticl);
            this.groupBoxKupujemProdajem.Controls.Add(this.pbArticleImage);
            this.groupBoxKupujemProdajem.Controls.Add(this.btnKupujemProdajemLogin);
            this.groupBoxKupujemProdajem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxKupujemProdajem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxKupujemProdajem.Location = new System.Drawing.Point(375, 3);
            this.groupBoxKupujemProdajem.Name = "groupBoxKupujemProdajem";
            this.groupBoxKupujemProdajem.Size = new System.Drawing.Size(821, 218);
            this.groupBoxKupujemProdajem.TabIndex = 0;
            this.groupBoxKupujemProdajem.TabStop = false;
            this.groupBoxKupujemProdajem.Text = "KUPUJEM PRODAJEM OGLAŠAVANJE";
            // 
            // articleWebLink
            // 
            this.articleWebLink.AutoSize = true;
            this.articleWebLink.Location = new System.Drawing.Point(188, 68);
            this.articleWebLink.Name = "articleWebLink";
            this.articleWebLink.Size = new System.Drawing.Size(54, 13);
            this.articleWebLink.TabIndex = 22;
            this.articleWebLink.TabStop = true;
            this.articleWebLink.Text = "webLink";
            this.articleWebLink.Visible = false;
            this.articleWebLink.Click += new System.EventHandler(this.articleWebLink_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(517, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "ADRESA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "NAZIV:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "PIB:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(579, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "PODACI O FIRMI:";
            // 
            // tbCompanyAddress
            // 
            this.tbCompanyAddress.Location = new System.Drawing.Point(582, 182);
            this.tbCompanyAddress.Name = "tbCompanyAddress";
            this.tbCompanyAddress.Size = new System.Drawing.Size(230, 20);
            this.tbCompanyAddress.TabIndex = 17;
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(582, 156);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(230, 20);
            this.tbCompanyName.TabIndex = 16;
            // 
            // tbPIB
            // 
            this.tbPIB.Location = new System.Drawing.Point(582, 130);
            this.tbPIB.Name = "tbPIB";
            this.tbPIB.Size = new System.Drawing.Size(230, 20);
            this.tbPIB.TabIndex = 15;
            // 
            // lblArticleName
            // 
            this.lblArticleName.AutoSize = true;
            this.lblArticleName.Location = new System.Drawing.Point(188, 55);
            this.lblArticleName.Name = "lblArticleName";
            this.lblArticleName.Size = new System.Drawing.Size(156, 13);
            this.lblArticleName.TabIndex = 13;
            this.lblArticleName.Text = "NAZIV ARTIKLA ({0}/{1}):";
            // 
            // btnLoadArticles
            // 
            this.btnLoadArticles.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnLoadArticles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadArticles.Location = new System.Drawing.Point(191, 158);
            this.btnLoadArticles.Name = "btnLoadArticles";
            this.btnLoadArticles.Size = new System.Drawing.Size(136, 51);
            this.btnLoadArticles.TabIndex = 12;
            this.btnLoadArticles.Text = "UČITAJ ARTIKLE";
            this.btnLoadArticles.UseVisualStyleBackColor = false;
            this.btnLoadArticles.Click += new System.EventHandler(this.btnArticlPath_Click);
            // 
            // tbLoadArticles
            // 
            this.tbLoadArticles.Location = new System.Drawing.Point(191, 134);
            this.tbLoadArticles.Name = "tbLoadArticles";
            this.tbLoadArticles.ReadOnly = true;
            this.tbLoadArticles.Size = new System.Drawing.Size(293, 20);
            this.tbLoadArticles.TabIndex = 11;
            // 
            // lblArticlCount
            // 
            this.lblArticlCount.AutoSize = true;
            this.lblArticlCount.Location = new System.Drawing.Point(188, 114);
            this.lblArticlCount.Name = "lblArticlCount";
            this.lblArticlCount.Size = new System.Drawing.Size(148, 13);
            this.lblArticlCount.TabIndex = 10;
            this.lblArticlCount.Text = "UKUPNO ARTIKALA: {0}";
            // 
            // btnNextArticl
            // 
            this.btnNextArticl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnNextArticl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextArticl.Location = new System.Drawing.Point(333, 158);
            this.btnNextArticl.Name = "btnNextArticl";
            this.btnNextArticl.Size = new System.Drawing.Size(151, 51);
            this.btnNextArticl.TabIndex = 9;
            this.btnNextArticl.Text = "SLEDEĆI ARTIKAL >>";
            this.btnNextArticl.UseVisualStyleBackColor = false;
            this.btnNextArticl.Click += new System.EventHandler(this.btnNextArticl_Click);
            // 
            // pbArticleImage
            // 
            this.pbArticleImage.Image = global::WinFormsWebBrowser.Properties.Resources.iphone_afraid;
            this.pbArticleImage.Location = new System.Drawing.Point(9, 55);
            this.pbArticleImage.Name = "pbArticleImage";
            this.pbArticleImage.Size = new System.Drawing.Size(161, 154);
            this.pbArticleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArticleImage.TabIndex = 8;
            this.pbArticleImage.TabStop = false;
            // 
            // btnKupujemProdajemLogin
            // 
            this.btnKupujemProdajemLogin.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnKupujemProdajemLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnKupujemProdajemLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKupujemProdajemLogin.Location = new System.Drawing.Point(6, 19);
            this.btnKupujemProdajemLogin.Name = "btnKupujemProdajemLogin";
            this.btnKupujemProdajemLogin.Size = new System.Drawing.Size(129, 30);
            this.btnKupujemProdajemLogin.TabIndex = 4;
            this.btnKupujemProdajemLogin.Text = "ULOGUJ SE";
            this.btnKupujemProdajemLogin.UseVisualStyleBackColor = false;
            this.btnKupujemProdajemLogin.Click += new System.EventHandler(this.btnKupujemProdajemLogin_Click);
            // 
            // groupBoxOglasi
            // 
            this.groupBoxOglasi.Controls.Add(this.btnRefresh);
            this.groupBoxOglasi.Controls.Add(this.label5);
            this.groupBoxOglasi.Controls.Add(this.cbMobilePhoneMasks);
            this.groupBoxOglasi.Controls.Add(this.btnMobileMaskCategory);
            this.groupBoxOglasi.Controls.Add(this.btnPhoneMask);
            this.groupBoxOglasi.Controls.Add(this.btnDigitalVisionMobilePhones);
            this.groupBoxOglasi.Controls.Add(this.progressBar);
            this.groupBoxOglasi.Controls.Add(this.tbSavePath);
            this.groupBoxOglasi.Controls.Add(this.lblSavePath);
            this.groupBoxOglasi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOglasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOglasi.Location = new System.Drawing.Point(3, 3);
            this.groupBoxOglasi.Name = "groupBoxOglasi";
            this.groupBoxOglasi.Size = new System.Drawing.Size(366, 218);
            this.groupBoxOglasi.TabIndex = 1;
            this.groupBoxOglasi.TabStop = false;
            this.groupBoxOglasi.Text = "PREUZIMANJE OGLASA";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Image = global::WinFormsWebBrowser.Properties.Resources.Double_J_Design_Ravenna_3d_Reload;
            this.btnRefresh.Location = new System.Drawing.Point(178, 96);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(47, 38);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.cbMobilePhoneMasks_SelectedIndexChanged);
            this.btnRefresh.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRefresh_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "KATEGORIJA MASKI:";
            // 
            // cbMobilePhoneMasks
            // 
            this.cbMobilePhoneMasks.DisplayMember = "Name";
            this.cbMobilePhoneMasks.FormattingEnabled = true;
            this.cbMobilePhoneMasks.Location = new System.Drawing.Point(9, 113);
            this.cbMobilePhoneMasks.Name = "cbMobilePhoneMasks";
            this.cbMobilePhoneMasks.Size = new System.Drawing.Size(163, 21);
            this.cbMobilePhoneMasks.TabIndex = 6;
            this.cbMobilePhoneMasks.ValueMember = "Link";
            this.cbMobilePhoneMasks.SelectedIndexChanged += new System.EventHandler(this.cbMobilePhoneMasks_SelectedIndexChanged);
            // 
            // btnMobileMaskCategory
            // 
            this.btnMobileMaskCategory.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnMobileMaskCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMobileMaskCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMobileMaskCategory.Location = new System.Drawing.Point(6, 16);
            this.btnMobileMaskCategory.Name = "btnMobileMaskCategory";
            this.btnMobileMaskCategory.Size = new System.Drawing.Size(92, 64);
            this.btnMobileMaskCategory.TabIndex = 5;
            this.btnMobileMaskCategory.Text = "PREUZMI KATEGORIJE MOBILNIH MASKI";
            this.btnMobileMaskCategory.UseVisualStyleBackColor = false;
            this.btnMobileMaskCategory.Click += new System.EventHandler(this.btnMobileMaskCategory_Click);
            // 
            // btnPhoneMask
            // 
            this.btnPhoneMask.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnPhoneMask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPhoneMask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhoneMask.Location = new System.Drawing.Point(104, 16);
            this.btnPhoneMask.Name = "btnPhoneMask";
            this.btnPhoneMask.Size = new System.Drawing.Size(92, 64);
            this.btnPhoneMask.TabIndex = 4;
            this.btnPhoneMask.Text = "PREUZMI MOBILNE MASKE";
            this.btnPhoneMask.UseVisualStyleBackColor = false;
            this.btnPhoneMask.Click += new System.EventHandler(this.btnPhoneMask_Click);
            // 
            // btnDigitalVisionMobilePhones
            // 
            this.btnDigitalVisionMobilePhones.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnDigitalVisionMobilePhones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDigitalVisionMobilePhones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDigitalVisionMobilePhones.Location = new System.Drawing.Point(202, 16);
            this.btnDigitalVisionMobilePhones.Name = "btnDigitalVisionMobilePhones";
            this.btnDigitalVisionMobilePhones.Size = new System.Drawing.Size(92, 64);
            this.btnDigitalVisionMobilePhones.TabIndex = 0;
            this.btnDigitalVisionMobilePhones.Text = "PREUZMI MOBILNE TELEFONE";
            this.btnDigitalVisionMobilePhones.UseVisualStyleBackColor = false;
            this.btnDigitalVisionMobilePhones.Visible = false;
            this.btnDigitalVisionMobilePhones.Click += new System.EventHandler(this.btnExtractDataDigitalVisionMobilePhones_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(9, 189);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(351, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 3;
            // 
            // tbSavePath
            // 
            this.tbSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSavePath.Location = new System.Drawing.Point(9, 163);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.ReadOnly = true;
            this.tbSavePath.Size = new System.Drawing.Size(351, 20);
            this.tbSavePath.TabIndex = 1;
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavePath.Location = new System.Drawing.Point(9, 147);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(216, 13);
            this.lblSavePath.TabIndex = 2;
            this.lblSavePath.Text = "PREUZETI PODACI SE NALAZE NA:";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1199, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuStrip1";
            // 
            // about
            // 
            this.about.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oPROGRAMUToolStripMenuItem});
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(48, 20);
            this.about.Text = "MENI";
            // 
            // oPROGRAMUToolStripMenuItem
            // 
            this.oPROGRAMUToolStripMenuItem.Name = "oPROGRAMUToolStripMenuItem";
            this.oPROGRAMUToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.oPROGRAMUToolStripMenuItem.Text = "O PROGRAMU";
            this.oPROGRAMUToolStripMenuItem.Click += new System.EventHandler(this.oPROGRAMUToolStripMenuItem_Click);
            // 
            // KupujemProdajemMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 658);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "KupujemProdajemMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KUPUJEM PRODAJEM OGLASI - WEB SCRAPING UTILITY";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tlpWebBrowser.ResumeLayout(false);
            this.tlpWebBrowser.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.groupBoxKupujemProdajem.ResumeLayout(false);
            this.groupBoxKupujemProdajem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticleImage)).EndInit();
            this.groupBoxOglasi.ResumeLayout(false);
            this.groupBoxOglasi.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnDigitalVisionMobilePhones;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.TextBox tbSavePath;
        private System.Windows.Forms.Button btnKupujemProdajemLogin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox groupBoxKupujemProdajem;
        private System.Windows.Forms.GroupBox groupBoxOglasi;
        private System.Windows.Forms.Label lblArticlCount;
        private System.Windows.Forms.Button btnNextArticl;
        private System.Windows.Forms.Button btnLoadArticles;
        private System.Windows.Forms.TextBox tbLoadArticles;
        private System.Windows.Forms.Label lblArticleName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCompanyAddress;
        private System.Windows.Forms.TextBox tbCompanyName;
        private System.Windows.Forms.TextBox tbPIB;
        private System.Windows.Forms.LinkLabel articleWebLink;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.ToolStripMenuItem oPROGRAMUToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbArticleImage;
        private System.Windows.Forms.Button btnPhoneMask;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMobilePhoneMasks;
        private System.Windows.Forms.Button btnMobileMaskCategory;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TableLayoutPanel tlpWebBrowser;
        private System.Windows.Forms.TextBox tbAddressBar;
    }
}

