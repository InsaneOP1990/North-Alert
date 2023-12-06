namespace NorthAlert
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.buttonSpecHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.label17 = new System.Windows.Forms.Label();
            this.Cooldown_Textbox = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.SaveButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Exclude_richTextBox = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DisWebUrlTestButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.LogFileDir_RichText = new System.Windows.Forms.RichTextBox();
            this.LogFileName_RichText = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Webhook_Textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ServerBoxname_Textbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.FileDescription_RichText = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BotPicture_Textbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.PingList_Richtext = new System.Windows.Forms.RichTextBox();
            this.Run_checkBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Keywords_Richtext = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputDisocrd_RichText = new System.Windows.Forms.RichTextBox();
            this.kryptonRibbon1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MenuItem1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.buttonSpecHeaderGroup1});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.FormMain;
            this.kryptonHeaderGroup1.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.FormMain;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            this.kryptonHeaderGroup1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label17);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.Cooldown_Textbox);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.SaveButton);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label15);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label16);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.Exclude_richTextBox);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label14);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.panel1);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.BotPicture_Textbox);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label12);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label5);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label11);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.PingList_Richtext);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.Run_checkBox);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label10);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.Keywords_Richtext);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label8);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label7);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label2);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label1);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.OutputDisocrd_RichText);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonRibbon1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(1113, 735);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "North Alert";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Check Count: 0";
            this.kryptonHeaderGroup1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.kryptonHeaderGroup1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.kryptonHeaderGroup1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // buttonSpecHeaderGroup1
            // 
            this.buttonSpecHeaderGroup1.Text = "X";
            this.buttonSpecHeaderGroup1.UniqueName = "1C5A4D9F88EE4AEA78A6086ED230B51B";
            this.buttonSpecHeaderGroup1.Click += new System.EventHandler(this.buttonSpecHeaderGroup1_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(352, 586);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(151, 13);
            this.label17.TabIndex = 70;
            this.label17.Text = "seconds between checks";
            // 
            // Cooldown_Textbox
            // 
            this.Cooldown_Textbox.Location = new System.Drawing.Point(294, 581);
            this.Cooldown_Textbox.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.Cooldown_Textbox.Name = "Cooldown_Textbox";
            this.Cooldown_Textbox.Size = new System.Drawing.Size(52, 22);
            this.Cooldown_Textbox.TabIndex = 69;
            this.Cooldown_Textbox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(301, 635);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(202, 36);
            this.SaveButton.TabIndex = 68;
            this.SaveButton.Values.Text = "Save Settings";
            this.SaveButton.Click += new System.EventHandler(this.Save_Button);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(913, 374);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(198, 13);
            this.label15.TabIndex = 67;
            this.label15.Text = "lines of text with these words are ignored";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Firebrick;
            this.label16.Location = new System.Drawing.Point(937, 358);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 16);
            this.label16.TabIndex = 66;
            this.label16.Text = "Excluded Line List";
            // 
            // Exclude_richTextBox
            // 
            this.Exclude_richTextBox.BackColor = System.Drawing.Color.RosyBrown;
            this.Exclude_richTextBox.Location = new System.Drawing.Point(925, 390);
            this.Exclude_richTextBox.Name = "Exclude_richTextBox";
            this.Exclude_richTextBox.Size = new System.Drawing.Size(173, 180);
            this.Exclude_richTextBox.TabIndex = 65;
            this.Exclude_richTextBox.Text = "Sound on different thread";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(924, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(166, 13);
            this.label14.TabIndex = 64;
            this.label14.Text = " Put && in front of the ID to do roles";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.DisWebUrlTestButton);
            this.panel1.Controls.Add(this.LogFileDir_RichText);
            this.panel1.Controls.Add(this.LogFileName_RichText);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Webhook_Textbox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ServerBoxname_Textbox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.FileDescription_RichText);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(3, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 236);
            this.panel1.TabIndex = 63;
            // 
            // DisWebUrlTestButton
            // 
            this.DisWebUrlTestButton.Location = new System.Drawing.Point(347, 86);
            this.DisWebUrlTestButton.Name = "DisWebUrlTestButton";
            this.DisWebUrlTestButton.Size = new System.Drawing.Size(90, 25);
            this.DisWebUrlTestButton.TabIndex = 45;
            this.DisWebUrlTestButton.Values.Text = "Check URL";
            this.DisWebUrlTestButton.Click += new System.EventHandler(this.Discordtestbutton_Click);
            // 
            // LogFileDir_RichText
            // 
            this.LogFileDir_RichText.Location = new System.Drawing.Point(122, 135);
            this.LogFileDir_RichText.Name = "LogFileDir_RichText";
            this.LogFileDir_RichText.Size = new System.Drawing.Size(499, 88);
            this.LogFileDir_RichText.TabIndex = 27;
            this.LogFileDir_RichText.Text = "C:\\Users\\Insane\\Desktop\\Space Engneering Stuff GG life\\Torch-Server\\Logs\nC:\\Users" +
    "\\Insane\\Desktop\\Space Engneering Stuff GG life\\Torch-Server\\Logs2";
            // 
            // LogFileName_RichText
            // 
            this.LogFileName_RichText.Location = new System.Drawing.Point(625, 135);
            this.LogFileName_RichText.Name = "LogFileName_RichText";
            this.LogFileName_RichText.Size = new System.Drawing.Size(100, 88);
            this.LogFileName_RichText.TabIndex = 44;
            this.LogFileName_RichText.Text = "Torch*.log\nKeen*.log\nAdminLog*.log";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "location description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Server log directories";
            // 
            // Webhook_Textbox
            // 
            this.Webhook_Textbox.Location = new System.Drawing.Point(9, 62);
            this.Webhook_Textbox.Name = "Webhook_Textbox";
            this.Webhook_Textbox.PasswordChar = '*';
            this.Webhook_Textbox.Size = new System.Drawing.Size(716, 20);
            this.Webhook_Textbox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Discord Webhook URL:";
            // 
            // ServerBoxname_Textbox
            // 
            this.ServerBoxname_Textbox.Location = new System.Drawing.Point(298, 21);
            this.ServerBoxname_Textbox.Name = "ServerBoxname_Textbox";
            this.ServerBoxname_Textbox.Size = new System.Drawing.Size(175, 20);
            this.ServerBoxname_Textbox.TabIndex = 16;
            this.ServerBoxname_Textbox.Text = "Box 1";
            this.ServerBoxname_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(628, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Log file extensions:";
            // 
            // FileDescription_RichText
            // 
            this.FileDescription_RichText.Location = new System.Drawing.Point(9, 135);
            this.FileDescription_RichText.Name = "FileDescription_RichText";
            this.FileDescription_RichText.Size = new System.Drawing.Size(107, 88);
            this.FileDescription_RichText.TabIndex = 30;
            this.FileDescription_RichText.Text = "Lobby\nServer 1\nServer 2\nServer 3\nServer 4\nServer 5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(358, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Box Name";
            // 
            // BotPicture_Textbox
            // 
            this.BotPicture_Textbox.Location = new System.Drawing.Point(932, 613);
            this.BotPicture_Textbox.Name = "BotPicture_Textbox";
            this.BotPicture_Textbox.Size = new System.Drawing.Size(175, 20);
            this.BotPicture_Textbox.TabIndex = 54;
            this.BotPicture_Textbox.Text = "https://cdn3.emoji.gg/emojis/1532-crybaby.png";
            this.BotPicture_Textbox.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(937, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 13);
            this.label12.TabIndex = 62;
            this.label12.Text = "Use the same line as keywords";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(1005, 595);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Bot Picture";
            this.label5.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(747, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(171, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "(1 Per Line)(Do not Repeat Words)";
            // 
            // PingList_Richtext
            // 
            this.PingList_Richtext.Location = new System.Drawing.Point(925, 159);
            this.PingList_Richtext.Name = "PingList_Richtext";
            this.PingList_Richtext.Size = new System.Drawing.Size(175, 196);
            this.PingList_Richtext.TabIndex = 60;
            this.PingList_Richtext.Text = "\n\n\n&964549461898563684";
            // 
            // Run_checkBox
            // 
            this.Run_checkBox.AccessibleDescription = " (Save while checked and program will autorun)";
            this.Run_checkBox.AutoSize = true;
            this.Run_checkBox.BackColor = System.Drawing.Color.Transparent;
            this.Run_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Run_checkBox.Location = new System.Drawing.Point(350, 613);
            this.Run_checkBox.Name = "Run_checkBox";
            this.Run_checkBox.Size = new System.Drawing.Size(109, 17);
            this.Run_checkBox.TabIndex = 10;
            this.Run_checkBox.Text = "<-- Run Button";
            this.Run_checkBox.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(948, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 16);
            this.label10.TabIndex = 59;
            this.label10.Text = "Discord Pings List";
            // 
            // Keywords_Richtext
            // 
            this.Keywords_Richtext.Location = new System.Drawing.Point(744, 159);
            this.Keywords_Richtext.Name = "Keywords_Richtext";
            this.Keywords_Richtext.Size = new System.Drawing.Size(175, 196);
            this.Keywords_Richtext.TabIndex = 58;
            this.Keywords_Richtext.Text = "[FATAL]\n[WARN]\n[ERROR]\ncheat";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(320, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(402, 15);
            this.label8.TabIndex = 57;
            this.label8.Text = "New lines with Keywords will be sent to the Discord Webhook ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(160, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(699, 18);
            this.label7.TabIndex = 56;
            this.label7.Text = "This App reads log files and checks it aganest the last time it ran while looking" +
    " for keywords";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(342, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 53;
            this.label2.Text = "NorthAlert Log";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(756, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 52;
            this.label1.Text = "Keyword list to Report ";
            // 
            // OutputDisocrd_RichText
            // 
            this.OutputDisocrd_RichText.HideSelection = false;
            this.OutputDisocrd_RichText.Location = new System.Drawing.Point(3, 390);
            this.OutputDisocrd_RichText.Name = "OutputDisocrd_RichText";
            this.OutputDisocrd_RichText.ReadOnly = true;
            this.OutputDisocrd_RichText.Size = new System.Drawing.Size(916, 180);
            this.OutputDisocrd_RichText.TabIndex = 51;
            this.OutputDisocrd_RichText.Text = "";
            this.OutputDisocrd_RichText.TextChanged += new System.EventHandler(this.OutputDisocrd_RichText_TextChanged);
            // 
            // kryptonRibbon1
            // 
            this.kryptonRibbon1.InDesignHelperMode = false;
            this.kryptonRibbon1.MinimizedMode = true;
            this.kryptonRibbon1.Name = "kryptonRibbon1";
            this.kryptonRibbon1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonRibbon1.QATLocation = ComponentFactory.Krypton.Ribbon.QATLocation.Hidden;
            this.kryptonRibbon1.QATUserChange = false;
            this.kryptonRibbon1.RibbonAppButton.AppButtonImage = ((System.Drawing.Image)(resources.GetObject("kryptonRibbon1.RibbonAppButton.AppButtonImage")));
            this.kryptonRibbon1.RibbonAppButton.AppButtonMenuItems.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.MenuItem1});
            this.kryptonRibbon1.RibbonAppButton.AppButtonShowRecentDocs = false;
            this.kryptonRibbon1.SelectedContext = null;
            this.kryptonRibbon1.SelectedTab = null;
            this.kryptonRibbon1.ShowMinimizeButton = false;
            this.kryptonRibbon1.Size = new System.Drawing.Size(1111, 143);
            this.kryptonRibbon1.TabIndex = 0;
            this.kryptonRibbon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.kryptonRibbon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.kryptonRibbon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MenuItem1
            // 
            this.MenuItem1.CheckOnClick = true;
            this.MenuItem1.Text = "Turn on Debug?";
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(1113, 735);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindowK_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbon kryptonRibbon1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RichTextBox Exclude_richTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox LogFileDir_RichText;
        private System.Windows.Forms.RichTextBox LogFileName_RichText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Webhook_Textbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ServerBoxname_Textbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox FileDescription_RichText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox Run_checkBox;
        private System.Windows.Forms.TextBox BotPicture_Textbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox PingList_Richtext;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox Keywords_Richtext;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox OutputDisocrd_RichText;
        private System.Windows.Forms.Timer timer1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton DisWebUrlTestButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton SaveButton;
        private System.Windows.Forms.Label label17;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown Cooldown_Textbox;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem MenuItem1;
    }
}