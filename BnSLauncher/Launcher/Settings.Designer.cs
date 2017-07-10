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
            this.tpage_client = new System.Windows.Forms.TabPage();
            this.gbox_cpath = new System.Windows.Forms.GroupBox();
            this.btn_disable = new System.Windows.Forms.Button();
            this.btn_enable = new System.Windows.Forms.Button();
            this.lb_cpath = new System.Windows.Forms.Label();
            this.btn_scpath = new System.Windows.Forms.Button();
            this.txb_cpath = new System.Windows.Forms.TextBox();
            this.gbox_krserver = new System.Windows.Forms.GroupBox();
            this.cbox_KorServer = new System.Windows.Forms.ComboBox();
            this.gbox_region = new System.Windows.Forms.GroupBox();
            this.cbox_Region = new System.Windows.Forms.ComboBox();
            this.gbox_westlang = new System.Windows.Forms.GroupBox();
            this.cbox_west_lang = new System.Windows.Forms.ComboBox();
            this.gbox_arc = new System.Windows.Forms.GroupBox();
            this.cbox_Arch = new System.Windows.Forms.ComboBox();
            this.tpage_others = new System.Windows.Forms.TabPage();
            this.lb_zoom = new System.Windows.Forms.Label();
            this.txb_zoom = new System.Windows.Forms.TextBox();
            this.cbox_disableimg = new System.Windows.Forms.CheckBox();
            this.cbox_allcores = new System.Windows.Forms.CheckBox();
            this.cbox_mboxes = new System.Windows.Forms.CheckBox();
            this.cbox_texstr = new System.Windows.Forms.CheckBox();
            this.tpage_lsettings = new System.Windows.Forms.TabPage();
            this.gbox_llang = new System.Windows.Forms.GroupBox();
            this.cbox_llang = new System.Windows.Forms.ComboBox();
            this.sts_ = new System.Windows.Forms.StatusStrip();
            this.Sts_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.SettingsTab.SuspendLayout();
            this.tpage_client.SuspendLayout();
            this.gbox_cpath.SuspendLayout();
            this.gbox_krserver.SuspendLayout();
            this.gbox_region.SuspendLayout();
            this.gbox_westlang.SuspendLayout();
            this.gbox_arc.SuspendLayout();
            this.tpage_others.SuspendLayout();
            this.tpage_lsettings.SuspendLayout();
            this.gbox_llang.SuspendLayout();
            this.sts_.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsTab
            // 
            this.SettingsTab.AccessibleName = "SettingsTab";
            this.SettingsTab.Controls.Add(this.tpage_client);
            this.SettingsTab.Controls.Add(this.tpage_others);
            this.SettingsTab.Controls.Add(this.tpage_lsettings);
            this.SettingsTab.Location = new System.Drawing.Point(7, 7);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.SelectedIndex = 0;
            this.SettingsTab.Size = new System.Drawing.Size(368, 129);
            this.SettingsTab.TabIndex = 0;
            // 
            // tpage_client
            // 
            this.tpage_client.BackColor = System.Drawing.Color.Transparent;
            this.tpage_client.Controls.Add(this.gbox_cpath);
            this.tpage_client.Controls.Add(this.gbox_krserver);
            this.tpage_client.Controls.Add(this.gbox_region);
            this.tpage_client.Controls.Add(this.gbox_westlang);
            this.tpage_client.Controls.Add(this.gbox_arc);
            this.tpage_client.Location = new System.Drawing.Point(4, 22);
            this.tpage_client.Name = "tpage_client";
            this.tpage_client.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_client.Size = new System.Drawing.Size(360, 103);
            this.tpage_client.TabIndex = 1;
            this.tpage_client.UseVisualStyleBackColor = true;
            // 
            // gbox_cpath
            // 
            this.gbox_cpath.Controls.Add(this.btn_disable);
            this.gbox_cpath.Controls.Add(this.btn_enable);
            this.gbox_cpath.Controls.Add(this.lb_cpath);
            this.gbox_cpath.Controls.Add(this.btn_scpath);
            this.gbox_cpath.Controls.Add(this.txb_cpath);
            this.gbox_cpath.Location = new System.Drawing.Point(5, 55);
            this.gbox_cpath.Name = "gbox_cpath";
            this.gbox_cpath.Size = new System.Drawing.Size(351, 41);
            this.gbox_cpath.TabIndex = 26;
            this.gbox_cpath.TabStop = false;
            // 
            // btn_disable
            // 
            this.btn_disable.Location = new System.Drawing.Point(295, 11);
            this.btn_disable.Name = "btn_disable";
            this.btn_disable.Size = new System.Drawing.Size(50, 23);
            this.btn_disable.TabIndex = 28;
            this.btn_disable.UseVisualStyleBackColor = true;
            this.btn_disable.Click += new System.EventHandler(this.btn_disable_Click);
            // 
            // btn_enable
            // 
            this.btn_enable.Location = new System.Drawing.Point(295, 11);
            this.btn_enable.Name = "btn_enable";
            this.btn_enable.Size = new System.Drawing.Size(50, 23);
            this.btn_enable.TabIndex = 27;
            this.btn_enable.UseVisualStyleBackColor = true;
            this.btn_enable.Click += new System.EventHandler(this.btn_enable_Click);
            // 
            // lb_cpath
            // 
            this.lb_cpath.AutoSize = true;
            this.lb_cpath.Location = new System.Drawing.Point(6, 16);
            this.lb_cpath.Name = "lb_cpath";
            this.lb_cpath.Size = new System.Drawing.Size(13, 13);
            this.lb_cpath.TabIndex = 26;
            this.lb_cpath.Text = "_";
            // 
            // btn_scpath
            // 
            this.btn_scpath.Location = new System.Drawing.Point(236, 11);
            this.btn_scpath.Name = "btn_scpath";
            this.btn_scpath.Size = new System.Drawing.Size(57, 23);
            this.btn_scpath.TabIndex = 25;
            this.btn_scpath.UseVisualStyleBackColor = true;
            this.btn_scpath.Click += new System.EventHandler(this.btn_scpath_Click);
            // 
            // txb_cpath
            // 
            this.txb_cpath.Location = new System.Drawing.Point(56, 13);
            this.txb_cpath.Name = "txb_cpath";
            this.txb_cpath.Size = new System.Drawing.Size(177, 20);
            this.txb_cpath.TabIndex = 24;
            // 
            // gbox_krserver
            // 
            this.gbox_krserver.Controls.Add(this.cbox_KorServer);
            this.gbox_krserver.Location = new System.Drawing.Point(123, 6);
            this.gbox_krserver.Name = "gbox_krserver";
            this.gbox_krserver.Size = new System.Drawing.Size(115, 43);
            this.gbox_krserver.TabIndex = 17;
            this.gbox_krserver.TabStop = false;
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
            this.cbox_KorServer.Location = new System.Drawing.Point(6, 14);
            this.cbox_KorServer.Name = "cbox_KorServer";
            this.cbox_KorServer.Size = new System.Drawing.Size(102, 21);
            this.cbox_KorServer.TabIndex = 19;
            this.cbox_KorServer.SelectedIndexChanged += new System.EventHandler(this.cbox_KorServer_SelectedIndexChanged);
            // 
            // gbox_region
            // 
            this.gbox_region.Controls.Add(this.cbox_Region);
            this.gbox_region.Location = new System.Drawing.Point(5, 6);
            this.gbox_region.Name = "gbox_region";
            this.gbox_region.Size = new System.Drawing.Size(115, 43);
            this.gbox_region.TabIndex = 22;
            this.gbox_region.TabStop = false;
            // 
            // cbox_Region
            // 
            this.cbox_Region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Region.FormattingEnabled = true;
            this.cbox_Region.Location = new System.Drawing.Point(7, 13);
            this.cbox_Region.Name = "cbox_Region";
            this.cbox_Region.Size = new System.Drawing.Size(102, 21);
            this.cbox_Region.TabIndex = 18;
            this.cbox_Region.SelectedIndexChanged += new System.EventHandler(this.cbox_Region_SelectedIndexChanged);
            // 
            // gbox_westlang
            // 
            this.gbox_westlang.Controls.Add(this.cbox_west_lang);
            this.gbox_westlang.Location = new System.Drawing.Point(123, 6);
            this.gbox_westlang.Name = "gbox_westlang";
            this.gbox_westlang.Size = new System.Drawing.Size(115, 43);
            this.gbox_westlang.TabIndex = 14;
            this.gbox_westlang.TabStop = false;
            // 
            // cbox_west_lang
            // 
            this.cbox_west_lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_west_lang.FormattingEnabled = true;
            this.cbox_west_lang.Items.AddRange(new object[] {
            "English",
            "German",
            "French"});
            this.cbox_west_lang.Location = new System.Drawing.Point(6, 14);
            this.cbox_west_lang.Name = "cbox_west_lang";
            this.cbox_west_lang.Size = new System.Drawing.Size(102, 21);
            this.cbox_west_lang.TabIndex = 20;
            this.cbox_west_lang.SelectedIndexChanged += new System.EventHandler(this.cbox_west_lang_SelectedIndexChanged);
            // 
            // gbox_arc
            // 
            this.gbox_arc.Controls.Add(this.cbox_Arch);
            this.gbox_arc.Location = new System.Drawing.Point(241, 6);
            this.gbox_arc.Name = "gbox_arc";
            this.gbox_arc.Size = new System.Drawing.Size(115, 43);
            this.gbox_arc.TabIndex = 15;
            this.gbox_arc.TabStop = false;
            // 
            // cbox_Arch
            // 
            this.cbox_Arch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Arch.FormattingEnabled = true;
            this.cbox_Arch.Items.AddRange(new object[] {
            "x86",
            "x64"});
            this.cbox_Arch.Location = new System.Drawing.Point(6, 14);
            this.cbox_Arch.Name = "cbox_Arch";
            this.cbox_Arch.Size = new System.Drawing.Size(102, 21);
            this.cbox_Arch.TabIndex = 21;
            this.cbox_Arch.SelectedIndexChanged += new System.EventHandler(this.cbox_Arch_SelectedIndexChanged);
            // 
            // tpage_others
            // 
            this.tpage_others.Controls.Add(this.lb_zoom);
            this.tpage_others.Controls.Add(this.txb_zoom);
            this.tpage_others.Controls.Add(this.cbox_disableimg);
            this.tpage_others.Controls.Add(this.cbox_allcores);
            this.tpage_others.Controls.Add(this.cbox_mboxes);
            this.tpage_others.Controls.Add(this.cbox_texstr);
            this.tpage_others.Location = new System.Drawing.Point(4, 22);
            this.tpage_others.Name = "tpage_others";
            this.tpage_others.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_others.Size = new System.Drawing.Size(360, 103);
            this.tpage_others.TabIndex = 0;
            this.tpage_others.UseVisualStyleBackColor = true;
            // 
            // lb_zoom
            // 
            this.lb_zoom.AutoSize = true;
            this.lb_zoom.Location = new System.Drawing.Point(8, 74);
            this.lb_zoom.Name = "lb_zoom";
            this.lb_zoom.Size = new System.Drawing.Size(13, 13);
            this.lb_zoom.TabIndex = 9;
            this.lb_zoom.Text = "_";
            // 
            // txb_zoom
            // 
            this.txb_zoom.Location = new System.Drawing.Point(70, 71);
            this.txb_zoom.Name = "txb_zoom";
            this.txb_zoom.Size = new System.Drawing.Size(100, 20);
            this.txb_zoom.TabIndex = 8;
            // 
            // cbox_disableimg
            // 
            this.cbox_disableimg.AutoSize = true;
            this.cbox_disableimg.Location = new System.Drawing.Point(191, 14);
            this.cbox_disableimg.Name = "cbox_disableimg";
            this.cbox_disableimg.Size = new System.Drawing.Size(15, 14);
            this.cbox_disableimg.TabIndex = 7;
            this.cbox_disableimg.UseVisualStyleBackColor = true;
            this.cbox_disableimg.CheckedChanged += new System.EventHandler(this.cbox_disableImg_CheckedChanged);
            // 
            // cbox_allcores
            // 
            this.cbox_allcores.AutoSize = true;
            this.cbox_allcores.Location = new System.Drawing.Point(191, 37);
            this.cbox_allcores.Name = "cbox_allcores";
            this.cbox_allcores.Size = new System.Drawing.Size(15, 14);
            this.cbox_allcores.TabIndex = 4;
            this.cbox_allcores.UseVisualStyleBackColor = true;
            this.cbox_allcores.CheckedChanged += new System.EventHandler(this.cbox_AllCores_CheckedChanged);
            // 
            // cbox_mboxes
            // 
            this.cbox_mboxes.AutoSize = true;
            this.cbox_mboxes.Location = new System.Drawing.Point(11, 37);
            this.cbox_mboxes.Name = "cbox_mboxes";
            this.cbox_mboxes.Size = new System.Drawing.Size(15, 14);
            this.cbox_mboxes.TabIndex = 3;
            this.cbox_mboxes.UseVisualStyleBackColor = true;
            this.cbox_mboxes.CheckedChanged += new System.EventHandler(this.cbox_CheckedChanged);
            // 
            // cbox_texstr
            // 
            this.cbox_texstr.AutoSize = true;
            this.cbox_texstr.Location = new System.Drawing.Point(11, 14);
            this.cbox_texstr.Name = "cbox_texstr";
            this.cbox_texstr.Size = new System.Drawing.Size(15, 14);
            this.cbox_texstr.TabIndex = 2;
            this.cbox_texstr.UseVisualStyleBackColor = true;
            this.cbox_texstr.CheckedChanged += new System.EventHandler(this.cbox_textureStrCheckedChanged);
            // 
            // tpage_lsettings
            // 
            this.tpage_lsettings.Controls.Add(this.gbox_llang);
            this.tpage_lsettings.Location = new System.Drawing.Point(4, 22);
            this.tpage_lsettings.Name = "tpage_lsettings";
            this.tpage_lsettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_lsettings.Size = new System.Drawing.Size(360, 103);
            this.tpage_lsettings.TabIndex = 2;
            this.tpage_lsettings.UseVisualStyleBackColor = true;
            // 
            // gbox_llang
            // 
            this.gbox_llang.Controls.Add(this.cbox_llang);
            this.gbox_llang.Location = new System.Drawing.Point(94, 28);
            this.gbox_llang.Name = "gbox_llang";
            this.gbox_llang.Size = new System.Drawing.Size(177, 49);
            this.gbox_llang.TabIndex = 2;
            this.gbox_llang.TabStop = false;
            // 
            // cbox_llang
            // 
            this.cbox_llang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_llang.FormattingEnabled = true;
            this.cbox_llang.Location = new System.Drawing.Point(6, 19);
            this.cbox_llang.Name = "cbox_llang";
            this.cbox_llang.Size = new System.Drawing.Size(165, 21);
            this.cbox_llang.TabIndex = 1;
            // 
            // sts_
            // 
            this.sts_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sts_Label});
            this.sts_.Location = new System.Drawing.Point(0, 139);
            this.sts_.Name = "sts_";
            this.sts_.Size = new System.Drawing.Size(381, 22);
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
            this.ClientSize = new System.Drawing.Size(381, 161);
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
            this.tpage_client.ResumeLayout(false);
            this.gbox_cpath.ResumeLayout(false);
            this.gbox_cpath.PerformLayout();
            this.gbox_krserver.ResumeLayout(false);
            this.gbox_region.ResumeLayout(false);
            this.gbox_westlang.ResumeLayout(false);
            this.gbox_arc.ResumeLayout(false);
            this.tpage_others.ResumeLayout(false);
            this.tpage_others.PerformLayout();
            this.tpage_lsettings.ResumeLayout(false);
            this.gbox_llang.ResumeLayout(false);
            this.sts_.ResumeLayout(false);
            this.sts_.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage tpage_client;
        private System.Windows.Forms.CheckBox cbox_texstr;
        private System.Windows.Forms.TabPage tpage_others;
        private System.Windows.Forms.CheckBox cbox_mboxes;
        private System.Windows.Forms.CheckBox cbox_allcores;
        private System.Windows.Forms.GroupBox gbox_westlang;
        private System.Windows.Forms.GroupBox gbox_arc;
        private System.Windows.Forms.TabControl SettingsTab;
        private System.Windows.Forms.CheckBox cbox_disableimg;
        private System.Windows.Forms.StatusStrip sts_;
        private System.Windows.Forms.ToolStripStatusLabel Sts_Label;
        private System.Windows.Forms.Label lb_zoom;
        private System.Windows.Forms.TextBox txb_zoom;
        private System.Windows.Forms.GroupBox gbox_krserver;
        private System.Windows.Forms.GroupBox gbox_region;
        private System.Windows.Forms.ComboBox cbox_Region;
        private System.Windows.Forms.ComboBox cbox_KorServer;
        private System.Windows.Forms.ComboBox cbox_Arch;
        private System.Windows.Forms.ComboBox cbox_west_lang;
        private System.Windows.Forms.TabPage tpage_lsettings;
        private System.Windows.Forms.ComboBox cbox_llang;
        private System.Windows.Forms.GroupBox gbox_llang;
        private System.Windows.Forms.Button btn_scpath;
        private System.Windows.Forms.TextBox txb_cpath;
        private System.Windows.Forms.GroupBox gbox_cpath;
        private System.Windows.Forms.Label lb_cpath;
        private System.Windows.Forms.Button btn_enable;
        private System.Windows.Forms.Button btn_disable;
    }
}