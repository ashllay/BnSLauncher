namespace BnS_Launcher
{
    partial class Settings
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
            this.SettingsTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbox_Region = new System.Windows.Forms.ComboBox();
            this.gbox_krserver = new System.Windows.Forms.GroupBox();
            this.cbox_KorServer = new System.Windows.Forms.ComboBox();
            this.gBox_Arc = new System.Windows.Forms.GroupBox();
            this.cbox_Arch = new System.Windows.Forms.ComboBox();
            this.groupBox_west_lang = new System.Windows.Forms.GroupBox();
            this.cbox_west_lang = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_zoom = new System.Windows.Forms.TextBox();
            this.cbx_disableImg = new System.Windows.Forms.CheckBox();
            this.cBallCores = new System.Windows.Forms.CheckBox();
            this.cBmsBox = new System.Windows.Forms.CheckBox();
            this.cBtextureStr = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbox_llang = new System.Windows.Forms.ComboBox();
            this.lb_llang = new System.Windows.Forms.Label();
            this.sts_ = new System.Windows.Forms.StatusStrip();
            this.Sts_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.SettingsTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbox_krserver.SuspendLayout();
            this.gBox_Arc.SuspendLayout();
            this.groupBox_west_lang.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.sts_.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsTab
            // 
            this.SettingsTab.AccessibleName = "SettingsTab";
            this.SettingsTab.Controls.Add(this.tabPage1);
            this.SettingsTab.Controls.Add(this.tabPage2);
            this.SettingsTab.Controls.Add(this.tabPage3);
            this.SettingsTab.Location = new System.Drawing.Point(7, 7);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.SelectedIndex = 0;
            this.SettingsTab.Size = new System.Drawing.Size(197, 178);
            this.SettingsTab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.gbox_krserver);
            this.tabPage1.Controls.Add(this.gBox_Arc);
            this.tabPage1.Controls.Add(this.groupBox_west_lang);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(189, 152);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Region";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbox_Region);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 43);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Region";
            // 
            // cbox_Region
            // 
            this.cbox_Region.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cbox_Region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Region.FormattingEnabled = true;
            this.cbox_Region.Location = new System.Drawing.Point(7, 13);
            this.cbox_Region.Name = "cbox_Region";
            this.cbox_Region.Size = new System.Drawing.Size(161, 21);
            this.cbox_Region.TabIndex = 18;
            this.cbox_Region.SelectedIndexChanged += new System.EventHandler(this.cbox_Region_SelectedIndexChanged);
            // 
            // gbox_krserver
            // 
            this.gbox_krserver.Controls.Add(this.cbox_KorServer);
            this.gbox_krserver.Location = new System.Drawing.Point(97, 54);
            this.gbox_krserver.Name = "gbox_krserver";
            this.gbox_krserver.Size = new System.Drawing.Size(85, 43);
            this.gbox_krserver.TabIndex = 17;
            this.gbox_krserver.TabStop = false;
            this.gbox_krserver.Text = "Server";
            // 
            // cbox_KorServer
            // 
            this.cbox_KorServer.AutoCompleteCustomSource.AddRange(new string[] {
            "Live",
            "Test"});
            this.cbox_KorServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_KorServer.FormattingEnabled = true;
            this.cbox_KorServer.Items.AddRange(new object[] {
            "Live",
            "Test"});
            this.cbox_KorServer.Location = new System.Drawing.Point(7, 15);
            this.cbox_KorServer.Name = "cbox_KorServer";
            this.cbox_KorServer.Size = new System.Drawing.Size(70, 21);
            this.cbox_KorServer.TabIndex = 19;
            this.cbox_KorServer.SelectedIndexChanged += new System.EventHandler(this.cbox_KorServer_SelectedIndexChanged);
            // 
            // gBox_Arc
            // 
            this.gBox_Arc.Controls.Add(this.cbox_Arch);
            this.gBox_Arc.Location = new System.Drawing.Point(6, 54);
            this.gBox_Arc.Name = "gBox_Arc";
            this.gBox_Arc.Size = new System.Drawing.Size(85, 43);
            this.gBox_Arc.TabIndex = 15;
            this.gBox_Arc.TabStop = false;
            this.gBox_Arc.Text = "Architecture";
            // 
            // cbox_Arch
            // 
            this.cbox_Arch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Arch.FormattingEnabled = true;
            this.cbox_Arch.Items.AddRange(new object[] {
            "x86",
            "x64"});
            this.cbox_Arch.Location = new System.Drawing.Point(6, 15);
            this.cbox_Arch.Name = "cbox_Arch";
            this.cbox_Arch.Size = new System.Drawing.Size(70, 21);
            this.cbox_Arch.TabIndex = 21;
            this.cbox_Arch.SelectedIndexChanged += new System.EventHandler(this.cbox_Arch_SelectedIndexChanged);
            // 
            // groupBox_west_lang
            // 
            this.groupBox_west_lang.Controls.Add(this.cbox_west_lang);
            this.groupBox_west_lang.Location = new System.Drawing.Point(6, 103);
            this.groupBox_west_lang.Name = "groupBox_west_lang";
            this.groupBox_west_lang.Size = new System.Drawing.Size(176, 43);
            this.groupBox_west_lang.TabIndex = 14;
            this.groupBox_west_lang.TabStop = false;
            this.groupBox_west_lang.Text = "West Language";
            // 
            // cbox_west_lang
            // 
            this.cbox_west_lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_west_lang.FormattingEnabled = true;
            this.cbox_west_lang.Items.AddRange(new object[] {
            "English",
            "German",
            "French"});
            this.cbox_west_lang.Location = new System.Drawing.Point(7, 16);
            this.cbox_west_lang.Name = "cbox_west_lang";
            this.cbox_west_lang.Size = new System.Drawing.Size(162, 21);
            this.cbox_west_lang.TabIndex = 20;
            this.cbox_west_lang.SelectedIndexChanged += new System.EventHandler(this.cbox_west_lang_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txb_zoom);
            this.tabPage2.Controls.Add(this.cbx_disableImg);
            this.tabPage2.Controls.Add(this.cBallCores);
            this.tabPage2.Controls.Add(this.cBmsBox);
            this.tabPage2.Controls.Add(this.cBtextureStr);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(189, 152);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Others";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Zoom-out";
            // 
            // txb_zoom
            // 
            this.txb_zoom.Location = new System.Drawing.Point(66, 110);
            this.txb_zoom.Name = "txb_zoom";
            this.txb_zoom.Size = new System.Drawing.Size(100, 20);
            this.txb_zoom.TabIndex = 8;
            // 
            // cbx_disableImg
            // 
            this.cbx_disableImg.AutoSize = true;
            this.cbx_disableImg.Location = new System.Drawing.Point(11, 60);
            this.cbx_disableImg.Name = "cbx_disableImg";
            this.cbx_disableImg.Size = new System.Drawing.Size(134, 17);
            this.cbx_disableImg.TabIndex = 7;
            this.cbx_disableImg.Text = "Disable loading images";
            this.cbx_disableImg.UseVisualStyleBackColor = true;
            this.cbx_disableImg.CheckedChanged += new System.EventHandler(this.cbx_disableImg_CheckedChanged);
            // 
            // cBallCores
            // 
            this.cBallCores.AutoSize = true;
            this.cBallCores.Location = new System.Drawing.Point(11, 83);
            this.cBallCores.Name = "cBallCores";
            this.cBallCores.Size = new System.Drawing.Size(89, 17);
            this.cBallCores.TabIndex = 4;
            this.cBallCores.Text = "Use All Cores";
            this.cBallCores.UseVisualStyleBackColor = true;
            this.cBallCores.CheckedChanged += new System.EventHandler(this.checkBox_AllCores_CheckedChanged);
            // 
            // cBmsBox
            // 
            this.cBmsBox.AutoSize = true;
            this.cBmsBox.Location = new System.Drawing.Point(11, 37);
            this.cBmsBox.Name = "cBmsBox";
            this.cBmsBox.Size = new System.Drawing.Size(139, 17);
            this.cBmsBox.TabIndex = 3;
            this.cBmsBox.Text = "Disable Message Boxes";
            this.cBmsBox.UseVisualStyleBackColor = true;
            this.cBmsBox.CheckedChanged += new System.EventHandler(this.cBmsBox_CheckedChanged);
            // 
            // cBtextureStr
            // 
            this.cBtextureStr.AutoSize = true;
            this.cBtextureStr.Location = new System.Drawing.Point(11, 14);
            this.cBtextureStr.Name = "cBtextureStr";
            this.cBtextureStr.Size = new System.Drawing.Size(150, 17);
            this.cBtextureStr.TabIndex = 2;
            this.cBtextureStr.Text = "Disable Texture Streaming";
            this.cBtextureStr.UseVisualStyleBackColor = true;
            this.cBtextureStr.CheckedChanged += new System.EventHandler(this.cBtextureStr_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbox_llang);
            this.tabPage3.Controls.Add(this.lb_llang);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(189, 152);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Launcher settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbox_llang
            // 
            this.cbox_llang.FormattingEnabled = true;
            this.cbox_llang.Location = new System.Drawing.Point(62, 6);
            this.cbox_llang.Name = "cbox_llang";
            this.cbox_llang.Size = new System.Drawing.Size(121, 21);
            this.cbox_llang.TabIndex = 1;
            this.cbox_llang.SelectedIndexChanged += new System.EventHandler(this.cbox_llang_SelectedIndexChanged);
            // 
            // lb_llang
            // 
            this.lb_llang.AutoSize = true;
            this.lb_llang.Location = new System.Drawing.Point(6, 9);
            this.lb_llang.Name = "lb_llang";
            this.lb_llang.Size = new System.Drawing.Size(35, 13);
            this.lb_llang.TabIndex = 0;
            this.lb_llang.Text = "label2";
            // 
            // sts_
            // 
            this.sts_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sts_Label});
            this.sts_.Location = new System.Drawing.Point(0, 188);
            this.sts_.Name = "sts_";
            this.sts_.Size = new System.Drawing.Size(213, 22);
            this.sts_.TabIndex = 1;
            this.sts_.Text = "statusStrip1";
            // 
            // Sts_Label
            // 
            this.Sts_Label.Name = "Sts_Label";
            this.Sts_Label.Size = new System.Drawing.Size(0, 17);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 210);
            this.Controls.Add(this.sts_);
            this.Controls.Add(this.SettingsTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FomrSettings_FormClosing);
            this.Load += new System.EventHandler(this.FomrSettings_Load);
            this.SettingsTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbox_krserver.ResumeLayout(false);
            this.gBox_Arc.ResumeLayout(false);
            this.groupBox_west_lang.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.sts_.ResumeLayout(false);
            this.sts_.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox cBtextureStr;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cBmsBox;
        private System.Windows.Forms.CheckBox cBallCores;
        private System.Windows.Forms.GroupBox groupBox_west_lang;
        private System.Windows.Forms.GroupBox gBox_Arc;
        private System.Windows.Forms.TabControl SettingsTab;
        private System.Windows.Forms.CheckBox cbx_disableImg;
        private System.Windows.Forms.StatusStrip sts_;
        private System.Windows.Forms.ToolStripStatusLabel Sts_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_zoom;
        private System.Windows.Forms.GroupBox gbox_krserver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbox_Region;
        private System.Windows.Forms.ComboBox cbox_KorServer;
        private System.Windows.Forms.ComboBox cbox_Arch;
        private System.Windows.Forms.ComboBox cbox_west_lang;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cbox_llang;
        private System.Windows.Forms.Label lb_llang;
    }
}