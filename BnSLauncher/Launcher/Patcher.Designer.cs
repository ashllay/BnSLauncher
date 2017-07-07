namespace BnS_Launcher
{
    partial class Patcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patcher));
            this.tabPatcher = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbox_bakconfig = new System.Windows.Forms.CheckBox();
            this.cbox_webl = new System.Windows.Forms.CheckBox();
            this.cbox_clause = new System.Windows.Forms.CheckBox();
            this.cbox_minimize = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbox_perfmod = new System.Windows.Forms.CheckBox();
            this.cbox_bakxml = new System.Windows.Forms.CheckBox();
            this.cbox_dps = new System.Windows.Forms.CheckBox();
            this.gbox_patcher = new System.Windows.Forms.GroupBox();
            this.gbox_repackf = new System.Windows.Forms.GroupBox();
            this.cbox_cxml = new System.Windows.Forms.CheckBox();
            this.cbox_cconfig = new System.Windows.Forms.CheckBox();
            this.lb_info = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.richOut = new System.Windows.Forms.RichTextBox();
            this.lb_outlog = new System.Windows.Forms.Label();
            this.tabPatcher.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbox_patcher.SuspendLayout();
            this.gbox_repackf.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPatcher
            // 
            this.tabPatcher.Controls.Add(this.tabPage1);
            this.tabPatcher.Controls.Add(this.tabPage2);
            this.tabPatcher.Location = new System.Drawing.Point(9, 36);
            this.tabPatcher.Name = "tabPatcher";
            this.tabPatcher.SelectedIndex = 0;
            this.tabPatcher.Size = new System.Drawing.Size(276, 104);
            this.tabPatcher.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.cbox_bakconfig);
            this.tabPage1.Controls.Add(this.cbox_webl);
            this.tabPage1.Controls.Add(this.cbox_clause);
            this.tabPage1.Controls.Add(this.cbox_minimize);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(268, 78);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config.dat";
            // 
            // cbox_bakconfig
            // 
            this.cbox_bakconfig.AutoSize = true;
            this.cbox_bakconfig.Checked = true;
            this.cbox_bakconfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_bakconfig.ForeColor = System.Drawing.Color.Black;
            this.cbox_bakconfig.Location = new System.Drawing.Point(163, 6);
            this.cbox_bakconfig.Name = "cbox_bakconfig";
            this.cbox_bakconfig.Size = new System.Drawing.Size(15, 14);
            this.cbox_bakconfig.TabIndex = 12;
            this.cbox_bakconfig.UseVisualStyleBackColor = true;
            // 
            // cbox_webl
            // 
            this.cbox_webl.AutoSize = true;
            this.cbox_webl.ForeColor = System.Drawing.Color.Black;
            this.cbox_webl.Location = new System.Drawing.Point(6, 6);
            this.cbox_webl.Name = "cbox_webl";
            this.cbox_webl.Size = new System.Drawing.Size(15, 14);
            this.cbox_webl.TabIndex = 9;
            this.cbox_webl.UseVisualStyleBackColor = true;
            // 
            // cbox_clause
            // 
            this.cbox_clause.AutoSize = true;
            this.cbox_clause.ForeColor = System.Drawing.Color.Black;
            this.cbox_clause.Location = new System.Drawing.Point(6, 29);
            this.cbox_clause.Name = "cbox_clause";
            this.cbox_clause.Size = new System.Drawing.Size(15, 14);
            this.cbox_clause.TabIndex = 10;
            this.cbox_clause.UseVisualStyleBackColor = true;
            // 
            // cbox_minimize
            // 
            this.cbox_minimize.AutoSize = true;
            this.cbox_minimize.ForeColor = System.Drawing.Color.Black;
            this.cbox_minimize.Location = new System.Drawing.Point(6, 52);
            this.cbox_minimize.Name = "cbox_minimize";
            this.cbox_minimize.Size = new System.Drawing.Size(15, 14);
            this.cbox_minimize.TabIndex = 11;
            this.cbox_minimize.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbox_perfmod);
            this.tabPage2.Controls.Add(this.cbox_bakxml);
            this.tabPage2.Controls.Add(this.cbox_dps);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(268, 78);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xml.dat";
            // 
            // cbox_perfmod
            // 
            this.cbox_perfmod.AutoSize = true;
            this.cbox_perfmod.Location = new System.Drawing.Point(6, 29);
            this.cbox_perfmod.Name = "cbox_perfmod";
            this.cbox_perfmod.Size = new System.Drawing.Size(15, 14);
            this.cbox_perfmod.TabIndex = 10;
            this.cbox_perfmod.UseVisualStyleBackColor = true;
            // 
            // cbox_bakxml
            // 
            this.cbox_bakxml.AutoSize = true;
            this.cbox_bakxml.Checked = true;
            this.cbox_bakxml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_bakxml.Location = new System.Drawing.Point(163, 6);
            this.cbox_bakxml.Name = "cbox_bakxml";
            this.cbox_bakxml.Size = new System.Drawing.Size(15, 14);
            this.cbox_bakxml.TabIndex = 9;
            this.cbox_bakxml.UseVisualStyleBackColor = true;
            // 
            // cbox_dps
            // 
            this.cbox_dps.AutoSize = true;
            this.cbox_dps.Location = new System.Drawing.Point(6, 6);
            this.cbox_dps.Name = "cbox_dps";
            this.cbox_dps.Size = new System.Drawing.Size(15, 14);
            this.cbox_dps.TabIndex = 9;
            this.cbox_dps.UseVisualStyleBackColor = true;
            // 
            // gbox_patcher
            // 
            this.gbox_patcher.BackColor = System.Drawing.Color.Transparent;
            this.gbox_patcher.BackgroundImage = global::BnS_Launcher.Properties.Resources._2x2;
            this.gbox_patcher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gbox_patcher.Controls.Add(this.gbox_repackf);
            this.gbox_patcher.Controls.Add(this.tabPatcher);
            this.gbox_patcher.Controls.Add(this.lb_info);
            this.gbox_patcher.Controls.Add(this.btn_start);
            this.gbox_patcher.Location = new System.Drawing.Point(4, 4);
            this.gbox_patcher.Name = "gbox_patcher";
            this.gbox_patcher.Size = new System.Drawing.Size(372, 190);
            this.gbox_patcher.TabIndex = 24;
            this.gbox_patcher.TabStop = false;
            // 
            // gbox_repackf
            // 
            this.gbox_repackf.Controls.Add(this.cbox_cxml);
            this.gbox_repackf.Controls.Add(this.cbox_cconfig);
            this.gbox_repackf.ForeColor = System.Drawing.Color.White;
            this.gbox_repackf.Location = new System.Drawing.Point(9, 142);
            this.gbox_repackf.Name = "gbox_repackf";
            this.gbox_repackf.Size = new System.Drawing.Size(172, 39);
            this.gbox_repackf.TabIndex = 25;
            this.gbox_repackf.TabStop = false;
            // 
            // cbox_cxml
            // 
            this.cbox_cxml.AutoSize = true;
            this.cbox_cxml.Location = new System.Drawing.Point(96, 15);
            this.cbox_cxml.Name = "cbox_cxml";
            this.cbox_cxml.Size = new System.Drawing.Size(32, 17);
            this.cbox_cxml.TabIndex = 1;
            this.cbox_cxml.Text = "_";
            this.cbox_cxml.UseVisualStyleBackColor = true;
            // 
            // cbox_cconfig
            // 
            this.cbox_cconfig.AutoSize = true;
            this.cbox_cconfig.Location = new System.Drawing.Point(10, 15);
            this.cbox_cconfig.Name = "cbox_cconfig";
            this.cbox_cconfig.Size = new System.Drawing.Size(32, 17);
            this.cbox_cconfig.TabIndex = 0;
            this.cbox_cconfig.Text = "_";
            this.cbox_cconfig.UseVisualStyleBackColor = true;
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.ForeColor = System.Drawing.Color.White;
            this.lb_info.Location = new System.Drawing.Point(15, 14);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(13, 13);
            this.lb_info.TabIndex = 23;
            this.lb_info.Text = "_";
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.Transparent;
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Location = new System.Drawing.Point(291, 36);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 104);
            this.btn_start.TabIndex = 4;
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // richOut
            // 
            this.richOut.BackColor = System.Drawing.SystemColors.Control;
            this.richOut.ForeColor = System.Drawing.Color.Black;
            this.richOut.HideSelection = false;
            this.richOut.Location = new System.Drawing.Point(11, 213);
            this.richOut.Name = "richOut";
            this.richOut.Size = new System.Drawing.Size(357, 91);
            this.richOut.TabIndex = 22;
            this.richOut.Text = "";
            // 
            // lb_outlog
            // 
            this.lb_outlog.AutoSize = true;
            this.lb_outlog.BackColor = System.Drawing.Color.Transparent;
            this.lb_outlog.ForeColor = System.Drawing.Color.White;
            this.lb_outlog.Location = new System.Drawing.Point(10, 197);
            this.lb_outlog.Name = "lb_outlog";
            this.lb_outlog.Size = new System.Drawing.Size(13, 13);
            this.lb_outlog.TabIndex = 8;
            this.lb_outlog.Text = "_";
            // 
            // Patcher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::BnS_Launcher.Properties.Resources._3584283_16_9_aspect_ratio_belt_black_hair_blade___soul_bodysuit_boots_breasts_brown_e;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(379, 310);
            this.Controls.Add(this.gbox_patcher);
            this.Controls.Add(this.lb_outlog);
            this.Controls.Add(this.richOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Patcher";
            this.Text = "Patcher";
            this.Load += new System.EventHandler(this.Patcher_Load);
            this.tabPatcher.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbox_patcher.ResumeLayout(false);
            this.gbox_patcher.PerformLayout();
            this.gbox_repackf.ResumeLayout(false);
            this.gbox_repackf.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabPatcher;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbox_patcher;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.RichTextBox richOut;
        private System.Windows.Forms.CheckBox cbox_bakconfig;
        private System.Windows.Forms.CheckBox cbox_webl;
        private System.Windows.Forms.CheckBox cbox_minimize;
        private System.Windows.Forms.CheckBox cbox_clause;
        private System.Windows.Forms.Label lb_outlog;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cbox_dps;
        private System.Windows.Forms.CheckBox cbox_bakxml;
        private System.Windows.Forms.GroupBox gbox_repackf;
        private System.Windows.Forms.CheckBox cbox_cxml;
        private System.Windows.Forms.CheckBox cbox_cconfig;
        private System.Windows.Forms.CheckBox cbox_perfmod;
    }
}