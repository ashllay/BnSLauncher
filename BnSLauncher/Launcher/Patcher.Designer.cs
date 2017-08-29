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
            this.cbox_naglearena = new System.Windows.Forms.CheckBox();
            this.cbox_nagle = new System.Windows.Forms.CheckBox();
            this.cbox_webl = new System.Windows.Forms.CheckBox();
            this.cbox_clause = new System.Windows.Forms.CheckBox();
            this.cbox_cgcd = new System.Windows.Forms.CheckBox();
            this.cbox_minimize = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbox_mouse = new System.Windows.Forms.GroupBox();
            this.lb_mpresstime = new System.Windows.Forms.Label();
            this.txb_mpresstime = new System.Windows.Forms.TextBox();
            this.gbox_input = new System.Windows.Forms.GroupBox();
            this.txb_presstick = new System.Windows.Forms.TextBox();
            this.txb_ptick = new System.Windows.Forms.TextBox();
            this.txb_ptime = new System.Windows.Forms.TextBox();
            this.lb_presstick = new System.Windows.Forms.Label();
            this.lb_ptimetick = new System.Windows.Forms.Label();
            this.lb_ptime = new System.Windows.Forms.Label();
            this.gbox_latency = new System.Windows.Forms.GroupBox();
            this.txb_cgct = new System.Windows.Forms.TextBox();
            this.lb_time = new System.Windows.Forms.Label();
            this.gbox_dps = new System.Windows.Forms.GroupBox();
            this.cbox_dpsjackpot = new System.Windows.Forms.CheckBox();
            this.cbox_dpsclassic = new System.Windows.Forms.CheckBox();
            this.cbox_dpsfac = new System.Windows.Forms.CheckBox();
            this.cbox_dpsfield = new System.Windows.Forms.CheckBox();
            this.cbox_dpspub = new System.Windows.Forms.CheckBox();
            this.cbox_dpssix = new System.Windows.Forms.CheckBox();
            this.gbox_msec = new System.Windows.Forms.GroupBox();
            this.txbMidmsec = new System.Windows.Forms.TextBox();
            this.lb_fast = new System.Windows.Forms.Label();
            this.txbFastmsec = new System.Windows.Forms.TextBox();
            this.lb_mid = new System.Windows.Forms.Label();
            this.cbox_perfmod = new System.Windows.Forms.CheckBox();
            this.cbox_back = new System.Windows.Forms.CheckBox();
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
            this.gbox_mouse.SuspendLayout();
            this.gbox_input.SuspendLayout();
            this.gbox_latency.SuspendLayout();
            this.gbox_dps.SuspendLayout();
            this.gbox_msec.SuspendLayout();
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
            this.tabPatcher.Size = new System.Drawing.Size(412, 171);
            this.tabPatcher.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.cbox_naglearena);
            this.tabPage1.Controls.Add(this.cbox_nagle);
            this.tabPage1.Controls.Add(this.cbox_webl);
            this.tabPage1.Controls.Add(this.cbox_clause);
            this.tabPage1.Controls.Add(this.cbox_cgcd);
            this.tabPage1.Controls.Add(this.cbox_minimize);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(398, 145);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config.dat";
            // 
            // cbox_naglearena
            // 
            this.cbox_naglearena.AutoSize = true;
            this.cbox_naglearena.Checked = true;
            this.cbox_naglearena.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_naglearena.Location = new System.Drawing.Point(7, 116);
            this.cbox_naglearena.Name = "cbox_naglearena";
            this.cbox_naglearena.Size = new System.Drawing.Size(15, 14);
            this.cbox_naglearena.TabIndex = 13;
            this.cbox_naglearena.UseVisualStyleBackColor = true;
            // 
            // cbox_nagle
            // 
            this.cbox_nagle.AutoSize = true;
            this.cbox_nagle.Location = new System.Drawing.Point(7, 96);
            this.cbox_nagle.Name = "cbox_nagle";
            this.cbox_nagle.Size = new System.Drawing.Size(15, 14);
            this.cbox_nagle.TabIndex = 12;
            this.cbox_nagle.UseVisualStyleBackColor = true;
            // 
            // cbox_webl
            // 
            this.cbox_webl.AutoSize = true;
            this.cbox_webl.ForeColor = System.Drawing.Color.Black;
            this.cbox_webl.Location = new System.Drawing.Point(7, 16);
            this.cbox_webl.Name = "cbox_webl";
            this.cbox_webl.Size = new System.Drawing.Size(15, 14);
            this.cbox_webl.TabIndex = 9;
            this.cbox_webl.UseVisualStyleBackColor = true;
            // 
            // cbox_clause
            // 
            this.cbox_clause.AutoSize = true;
            this.cbox_clause.ForeColor = System.Drawing.Color.Black;
            this.cbox_clause.Location = new System.Drawing.Point(7, 36);
            this.cbox_clause.Name = "cbox_clause";
            this.cbox_clause.Size = new System.Drawing.Size(15, 14);
            this.cbox_clause.TabIndex = 10;
            this.cbox_clause.UseVisualStyleBackColor = true;
            // 
            // cbox_cgcd
            // 
            this.cbox_cgcd.AutoSize = true;
            this.cbox_cgcd.Location = new System.Drawing.Point(7, 76);
            this.cbox_cgcd.Name = "cbox_cgcd";
            this.cbox_cgcd.Size = new System.Drawing.Size(15, 14);
            this.cbox_cgcd.TabIndex = 0;
            this.cbox_cgcd.UseVisualStyleBackColor = true;
            this.cbox_cgcd.CheckedChanged += new System.EventHandler(this.cbox_cgcd_CheckedChanged);
            // 
            // cbox_minimize
            // 
            this.cbox_minimize.AutoSize = true;
            this.cbox_minimize.Checked = true;
            this.cbox_minimize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_minimize.ForeColor = System.Drawing.Color.Black;
            this.cbox_minimize.Location = new System.Drawing.Point(7, 56);
            this.cbox_minimize.Name = "cbox_minimize";
            this.cbox_minimize.Size = new System.Drawing.Size(15, 14);
            this.cbox_minimize.TabIndex = 11;
            this.cbox_minimize.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbox_mouse);
            this.tabPage2.Controls.Add(this.gbox_input);
            this.tabPage2.Controls.Add(this.gbox_latency);
            this.tabPage2.Controls.Add(this.gbox_dps);
            this.tabPage2.Controls.Add(this.gbox_msec);
            this.tabPage2.Controls.Add(this.cbox_perfmod);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(404, 145);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xml.dat";
            // 
            // gbox_mouse
            // 
            this.gbox_mouse.Controls.Add(this.lb_mpresstime);
            this.gbox_mouse.Controls.Add(this.txb_mpresstime);
            this.gbox_mouse.Location = new System.Drawing.Point(6, 98);
            this.gbox_mouse.Name = "gbox_mouse";
            this.gbox_mouse.Size = new System.Drawing.Size(155, 41);
            this.gbox_mouse.TabIndex = 7;
            this.gbox_mouse.TabStop = false;
            // 
            // lb_mpresstime
            // 
            this.lb_mpresstime.AutoSize = true;
            this.lb_mpresstime.Location = new System.Drawing.Point(5, 16);
            this.lb_mpresstime.Name = "lb_mpresstime";
            this.lb_mpresstime.Size = new System.Drawing.Size(13, 13);
            this.lb_mpresstime.TabIndex = 7;
            this.lb_mpresstime.Text = "_";
            // 
            // txb_mpresstime
            // 
            this.txb_mpresstime.Location = new System.Drawing.Point(98, 13);
            this.txb_mpresstime.Name = "txb_mpresstime";
            this.txb_mpresstime.Size = new System.Drawing.Size(51, 20);
            this.txb_mpresstime.TabIndex = 8;
            // 
            // gbox_input
            // 
            this.gbox_input.Controls.Add(this.txb_presstick);
            this.gbox_input.Controls.Add(this.txb_ptick);
            this.gbox_input.Controls.Add(this.txb_ptime);
            this.gbox_input.Controls.Add(this.lb_presstick);
            this.gbox_input.Controls.Add(this.lb_ptimetick);
            this.gbox_input.Controls.Add(this.lb_ptime);
            this.gbox_input.Location = new System.Drawing.Point(6, 6);
            this.gbox_input.Name = "gbox_input";
            this.gbox_input.Size = new System.Drawing.Size(155, 87);
            this.gbox_input.TabIndex = 27;
            this.gbox_input.TabStop = false;
            // 
            // txb_presstick
            // 
            this.txb_presstick.Location = new System.Drawing.Point(91, 58);
            this.txb_presstick.Name = "txb_presstick";
            this.txb_presstick.Size = new System.Drawing.Size(58, 20);
            this.txb_presstick.TabIndex = 6;
            // 
            // txb_ptick
            // 
            this.txb_ptick.Location = new System.Drawing.Point(91, 35);
            this.txb_ptick.Name = "txb_ptick";
            this.txb_ptick.Size = new System.Drawing.Size(58, 20);
            this.txb_ptick.TabIndex = 5;
            // 
            // txb_ptime
            // 
            this.txb_ptime.Location = new System.Drawing.Point(91, 13);
            this.txb_ptime.Name = "txb_ptime";
            this.txb_ptime.Size = new System.Drawing.Size(58, 20);
            this.txb_ptime.TabIndex = 4;
            // 
            // lb_presstick
            // 
            this.lb_presstick.AutoSize = true;
            this.lb_presstick.Location = new System.Drawing.Point(5, 61);
            this.lb_presstick.Name = "lb_presstick";
            this.lb_presstick.Size = new System.Drawing.Size(13, 13);
            this.lb_presstick.TabIndex = 2;
            this.lb_presstick.Text = "_";
            // 
            // lb_ptimetick
            // 
            this.lb_ptimetick.AutoSize = true;
            this.lb_ptimetick.Location = new System.Drawing.Point(5, 38);
            this.lb_ptimetick.Name = "lb_ptimetick";
            this.lb_ptimetick.Size = new System.Drawing.Size(13, 13);
            this.lb_ptimetick.TabIndex = 1;
            this.lb_ptimetick.Text = "_";
            // 
            // lb_ptime
            // 
            this.lb_ptime.AutoSize = true;
            this.lb_ptime.Location = new System.Drawing.Point(5, 16);
            this.lb_ptime.Name = "lb_ptime";
            this.lb_ptime.Size = new System.Drawing.Size(13, 13);
            this.lb_ptime.TabIndex = 0;
            this.lb_ptime.Text = "_";
            // 
            // gbox_latency
            // 
            this.gbox_latency.Controls.Add(this.txb_cgct);
            this.gbox_latency.Controls.Add(this.lb_time);
            this.gbox_latency.Location = new System.Drawing.Point(166, 6);
            this.gbox_latency.Name = "gbox_latency";
            this.gbox_latency.Size = new System.Drawing.Size(91, 40);
            this.gbox_latency.TabIndex = 26;
            this.gbox_latency.TabStop = false;
            // 
            // txb_cgct
            // 
            this.txb_cgct.Location = new System.Drawing.Point(39, 13);
            this.txb_cgct.Name = "txb_cgct";
            this.txb_cgct.Size = new System.Drawing.Size(44, 20);
            this.txb_cgct.TabIndex = 2;
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Location = new System.Drawing.Point(6, 16);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(13, 13);
            this.lb_time.TabIndex = 1;
            this.lb_time.Text = "_";
            // 
            // gbox_dps
            // 
            this.gbox_dps.Controls.Add(this.cbox_dpsjackpot);
            this.gbox_dps.Controls.Add(this.cbox_dpsclassic);
            this.gbox_dps.Controls.Add(this.cbox_dpsfac);
            this.gbox_dps.Controls.Add(this.cbox_dpsfield);
            this.gbox_dps.Controls.Add(this.cbox_dpspub);
            this.gbox_dps.Controls.Add(this.cbox_dpssix);
            this.gbox_dps.Location = new System.Drawing.Point(263, 6);
            this.gbox_dps.Name = "gbox_dps";
            this.gbox_dps.Size = new System.Drawing.Size(135, 87);
            this.gbox_dps.TabIndex = 16;
            this.gbox_dps.TabStop = false;
            // 
            // cbox_dpsjackpot
            // 
            this.cbox_dpsjackpot.AutoSize = true;
            this.cbox_dpsjackpot.Location = new System.Drawing.Point(67, 60);
            this.cbox_dpsjackpot.Name = "cbox_dpsjackpot";
            this.cbox_dpsjackpot.Size = new System.Drawing.Size(15, 14);
            this.cbox_dpsjackpot.TabIndex = 14;
            this.cbox_dpsjackpot.UseVisualStyleBackColor = true;
            // 
            // cbox_dpsclassic
            // 
            this.cbox_dpsclassic.AutoSize = true;
            this.cbox_dpsclassic.Location = new System.Drawing.Point(6, 60);
            this.cbox_dpsclassic.Name = "cbox_dpsclassic";
            this.cbox_dpsclassic.Size = new System.Drawing.Size(15, 14);
            this.cbox_dpsclassic.TabIndex = 13;
            this.cbox_dpsclassic.UseVisualStyleBackColor = true;
            // 
            // cbox_dpsfac
            // 
            this.cbox_dpsfac.AutoSize = true;
            this.cbox_dpsfac.Location = new System.Drawing.Point(67, 15);
            this.cbox_dpsfac.Name = "cbox_dpsfac";
            this.cbox_dpsfac.Size = new System.Drawing.Size(15, 14);
            this.cbox_dpsfac.TabIndex = 12;
            this.cbox_dpsfac.UseVisualStyleBackColor = true;
            // 
            // cbox_dpsfield
            // 
            this.cbox_dpsfield.AutoSize = true;
            this.cbox_dpsfield.Location = new System.Drawing.Point(67, 37);
            this.cbox_dpsfield.Name = "cbox_dpsfield";
            this.cbox_dpsfield.Size = new System.Drawing.Size(15, 14);
            this.cbox_dpsfield.TabIndex = 11;
            this.cbox_dpsfield.UseVisualStyleBackColor = true;
            // 
            // cbox_dpspub
            // 
            this.cbox_dpspub.AutoSize = true;
            this.cbox_dpspub.Location = new System.Drawing.Point(6, 37);
            this.cbox_dpspub.Name = "cbox_dpspub";
            this.cbox_dpspub.Size = new System.Drawing.Size(15, 14);
            this.cbox_dpspub.TabIndex = 10;
            this.cbox_dpspub.UseVisualStyleBackColor = true;
            // 
            // cbox_dpssix
            // 
            this.cbox_dpssix.AutoSize = true;
            this.cbox_dpssix.Location = new System.Drawing.Point(6, 15);
            this.cbox_dpssix.Name = "cbox_dpssix";
            this.cbox_dpssix.Size = new System.Drawing.Size(15, 14);
            this.cbox_dpssix.TabIndex = 9;
            this.cbox_dpssix.UseVisualStyleBackColor = true;
            // 
            // gbox_msec
            // 
            this.gbox_msec.Controls.Add(this.txbMidmsec);
            this.gbox_msec.Controls.Add(this.lb_fast);
            this.gbox_msec.Controls.Add(this.txbFastmsec);
            this.gbox_msec.Controls.Add(this.lb_mid);
            this.gbox_msec.Location = new System.Drawing.Point(166, 52);
            this.gbox_msec.Name = "gbox_msec";
            this.gbox_msec.Size = new System.Drawing.Size(91, 67);
            this.gbox_msec.TabIndex = 15;
            this.gbox_msec.TabStop = false;
            // 
            // txbMidmsec
            // 
            this.txbMidmsec.Location = new System.Drawing.Point(42, 40);
            this.txbMidmsec.Name = "txbMidmsec";
            this.txbMidmsec.Size = new System.Drawing.Size(44, 20);
            this.txbMidmsec.TabIndex = 12;
            // 
            // lb_fast
            // 
            this.lb_fast.AutoSize = true;
            this.lb_fast.Location = new System.Drawing.Point(9, 20);
            this.lb_fast.Name = "lb_fast";
            this.lb_fast.Size = new System.Drawing.Size(13, 13);
            this.lb_fast.TabIndex = 14;
            this.lb_fast.Text = "_";
            // 
            // txbFastmsec
            // 
            this.txbFastmsec.Location = new System.Drawing.Point(42, 17);
            this.txbFastmsec.Name = "txbFastmsec";
            this.txbFastmsec.Size = new System.Drawing.Size(44, 20);
            this.txbFastmsec.TabIndex = 11;
            // 
            // lb_mid
            // 
            this.lb_mid.AutoSize = true;
            this.lb_mid.Location = new System.Drawing.Point(9, 43);
            this.lb_mid.Name = "lb_mid";
            this.lb_mid.Size = new System.Drawing.Size(13, 13);
            this.lb_mid.TabIndex = 13;
            this.lb_mid.Text = "_";
            // 
            // cbox_perfmod
            // 
            this.cbox_perfmod.AutoSize = true;
            this.cbox_perfmod.Location = new System.Drawing.Point(166, 124);
            this.cbox_perfmod.Name = "cbox_perfmod";
            this.cbox_perfmod.Size = new System.Drawing.Size(15, 14);
            this.cbox_perfmod.TabIndex = 10;
            this.cbox_perfmod.UseVisualStyleBackColor = true;
            // 
            // cbox_back
            // 
            this.cbox_back.AutoSize = true;
            this.cbox_back.Checked = true;
            this.cbox_back.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_back.Location = new System.Drawing.Point(171, 15);
            this.cbox_back.Name = "cbox_back";
            this.cbox_back.Size = new System.Drawing.Size(32, 17);
            this.cbox_back.TabIndex = 9;
            this.cbox_back.Text = "_";
            this.cbox_back.UseVisualStyleBackColor = true;
            // 
            // gbox_patcher
            // 
            this.gbox_patcher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_patcher.BackColor = System.Drawing.Color.Transparent;
            this.gbox_patcher.BackgroundImage = global::BnS_Launcher.Properties.Resources._2x2;
            this.gbox_patcher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gbox_patcher.Controls.Add(this.gbox_repackf);
            this.gbox_patcher.Controls.Add(this.tabPatcher);
            this.gbox_patcher.Controls.Add(this.lb_info);
            this.gbox_patcher.Controls.Add(this.btn_start);
            this.gbox_patcher.Location = new System.Drawing.Point(4, 4);
            this.gbox_patcher.Name = "gbox_patcher";
            this.gbox_patcher.Size = new System.Drawing.Size(427, 261);
            this.gbox_patcher.TabIndex = 24;
            this.gbox_patcher.TabStop = false;
            // 
            // gbox_repackf
            // 
            this.gbox_repackf.Controls.Add(this.cbox_cxml);
            this.gbox_repackf.Controls.Add(this.cbox_cconfig);
            this.gbox_repackf.Controls.Add(this.cbox_back);
            this.gbox_repackf.ForeColor = System.Drawing.Color.White;
            this.gbox_repackf.Location = new System.Drawing.Point(9, 213);
            this.gbox_repackf.Name = "gbox_repackf";
            this.gbox_repackf.Size = new System.Drawing.Size(326, 39);
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
            this.btn_start.Location = new System.Drawing.Point(341, 224);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(76, 23);
            this.btn_start.TabIndex = 4;
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // richOut
            // 
            this.richOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richOut.BackColor = System.Drawing.SystemColors.Control;
            this.richOut.ForeColor = System.Drawing.Color.Black;
            this.richOut.HideSelection = false;
            this.richOut.Location = new System.Drawing.Point(4, 285);
            this.richOut.Name = "richOut";
            this.richOut.Size = new System.Drawing.Size(427, 91);
            this.richOut.TabIndex = 22;
            this.richOut.Text = "";
            // 
            // lb_outlog
            // 
            this.lb_outlog.AutoSize = true;
            this.lb_outlog.BackColor = System.Drawing.Color.Transparent;
            this.lb_outlog.ForeColor = System.Drawing.Color.White;
            this.lb_outlog.Location = new System.Drawing.Point(3, 269);
            this.lb_outlog.Name = "lb_outlog";
            this.lb_outlog.Size = new System.Drawing.Size(13, 13);
            this.lb_outlog.TabIndex = 8;
            this.lb_outlog.Text = "_";
            // 
            // Patcher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::BnS_Launcher.Properties.Resources._3555939_huazang_pohwaran_1girl_belt_blade___soul_boots_brown_eyes_eyepatch_female_fingerless_gloves_gatling_gun_gloves;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(436, 382);
            this.Controls.Add(this.gbox_patcher);
            this.Controls.Add(this.lb_outlog);
            this.Controls.Add(this.richOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Patcher";
            this.Text = "Patcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Patcher_FormClosing);
            this.Load += new System.EventHandler(this.Patcher_Load);
            this.tabPatcher.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbox_mouse.ResumeLayout(false);
            this.gbox_mouse.PerformLayout();
            this.gbox_input.ResumeLayout(false);
            this.gbox_input.PerformLayout();
            this.gbox_latency.ResumeLayout(false);
            this.gbox_latency.PerformLayout();
            this.gbox_dps.ResumeLayout(false);
            this.gbox_dps.PerformLayout();
            this.gbox_msec.ResumeLayout(false);
            this.gbox_msec.PerformLayout();
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
        private System.Windows.Forms.CheckBox cbox_webl;
        private System.Windows.Forms.CheckBox cbox_minimize;
        private System.Windows.Forms.CheckBox cbox_clause;
        private System.Windows.Forms.Label lb_outlog;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cbox_dpssix;
        private System.Windows.Forms.CheckBox cbox_back;
        private System.Windows.Forms.GroupBox gbox_repackf;
        private System.Windows.Forms.CheckBox cbox_cxml;
        private System.Windows.Forms.CheckBox cbox_cconfig;
        private System.Windows.Forms.CheckBox cbox_perfmod;
        private System.Windows.Forms.GroupBox gbox_msec;
        private System.Windows.Forms.TextBox txbMidmsec;
        private System.Windows.Forms.Label lb_fast;
        private System.Windows.Forms.TextBox txbFastmsec;
        private System.Windows.Forms.Label lb_mid;
        private System.Windows.Forms.GroupBox gbox_dps;
        private System.Windows.Forms.CheckBox cbox_dpsfac;
        private System.Windows.Forms.CheckBox cbox_dpsfield;
        private System.Windows.Forms.CheckBox cbox_dpspub;
        private System.Windows.Forms.GroupBox gbox_latency;
        private System.Windows.Forms.TextBox txb_cgct;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.CheckBox cbox_cgcd;
        private System.Windows.Forms.GroupBox gbox_mouse;
        private System.Windows.Forms.Label lb_mpresstime;
        private System.Windows.Forms.TextBox txb_mpresstime;
        private System.Windows.Forms.GroupBox gbox_input;
        private System.Windows.Forms.TextBox txb_presstick;
        private System.Windows.Forms.TextBox txb_ptick;
        private System.Windows.Forms.TextBox txb_ptime;
        private System.Windows.Forms.Label lb_presstick;
        private System.Windows.Forms.Label lb_ptimetick;
        private System.Windows.Forms.Label lb_ptime;
        private System.Windows.Forms.CheckBox cbox_dpsjackpot;
        private System.Windows.Forms.CheckBox cbox_dpsclassic;
        private System.Windows.Forms.CheckBox cbox_naglearena;
        private System.Windows.Forms.CheckBox cbox_nagle;
    }
}