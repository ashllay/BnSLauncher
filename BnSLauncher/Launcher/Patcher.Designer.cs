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
            this.cbox_Cgct = new System.Windows.Forms.CheckBox();
            this.cbox_minimize = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_mpresstime = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txb_presstick = new System.Windows.Forms.TextBox();
            this.txb_ptick = new System.Windows.Forms.TextBox();
            this.txb_ptime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txb_cgct = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbox_dpsjackpot = new System.Windows.Forms.CheckBox();
            this.cbox_dpsclassic = new System.Windows.Forms.CheckBox();
            this.cbox_dpsfac = new System.Windows.Forms.CheckBox();
            this.cbox_dpsfield = new System.Windows.Forms.CheckBox();
            this.cbox_dpspub = new System.Windows.Forms.CheckBox();
            this.cbox_dpssix = new System.Windows.Forms.CheckBox();
            this.gboxLatency = new System.Windows.Forms.GroupBox();
            this.txbMidmsec = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbFastmsec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxLatency.SuspendLayout();
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
            this.tabPatcher.Size = new System.Drawing.Size(406, 171);
            this.tabPatcher.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.cbox_naglearena);
            this.tabPage1.Controls.Add(this.cbox_nagle);
            this.tabPage1.Controls.Add(this.cbox_webl);
            this.tabPage1.Controls.Add(this.cbox_clause);
            this.tabPage1.Controls.Add(this.cbox_Cgct);
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
            this.cbox_naglearena.Location = new System.Drawing.Point(6, 118);
            this.cbox_naglearena.Name = "cbox_naglearena";
            this.cbox_naglearena.Size = new System.Drawing.Size(104, 17);
            this.cbox_naglearena.TabIndex = 13;
            this.cbox_naglearena.Text = "Use nagle arena";
            this.cbox_naglearena.UseVisualStyleBackColor = true;
            // 
            // cbox_nagle
            // 
            this.cbox_nagle.AutoSize = true;
            this.cbox_nagle.Location = new System.Drawing.Point(6, 95);
            this.cbox_nagle.Name = "cbox_nagle";
            this.cbox_nagle.Size = new System.Drawing.Size(74, 17);
            this.cbox_nagle.TabIndex = 12;
            this.cbox_nagle.Text = "Use nagle";
            this.cbox_nagle.UseVisualStyleBackColor = true;
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
            // cbox_Cgct
            // 
            this.cbox_Cgct.AutoSize = true;
            this.cbox_Cgct.Location = new System.Drawing.Point(6, 72);
            this.cbox_Cgct.Name = "cbox_Cgct";
            this.cbox_Cgct.Size = new System.Drawing.Size(141, 17);
            this.cbox_Cgct.TabIndex = 0;
            this.cbox_Cgct.Text = "Use custom latency time";
            this.cbox_Cgct.UseVisualStyleBackColor = true;
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
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.gboxLatency);
            this.tabPage2.Controls.Add(this.cbox_perfmod);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(398, 145);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xml.dat";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txb_mpresstime);
            this.groupBox4.Location = new System.Drawing.Point(5, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(155, 41);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mouse";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ignore press time";
            // 
            // txb_mpresstime
            // 
            this.txb_mpresstime.Location = new System.Drawing.Point(98, 13);
            this.txb_mpresstime.Name = "txb_mpresstime";
            this.txb_mpresstime.Size = new System.Drawing.Size(53, 20);
            this.txb_mpresstime.TabIndex = 8;
            this.txb_mpresstime.Text = "1.000000";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txb_presstick);
            this.groupBox3.Controls.Add(this.txb_ptick);
            this.groupBox3.Controls.Add(this.txb_ptime);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(155, 87);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Imput";
            // 
            // txb_presstick
            // 
            this.txb_presstick.Location = new System.Drawing.Point(91, 58);
            this.txb_presstick.Name = "txb_presstick";
            this.txb_presstick.Size = new System.Drawing.Size(58, 20);
            this.txb_presstick.TabIndex = 6;
            this.txb_presstick.Text = "0.25";
            // 
            // txb_ptick
            // 
            this.txb_ptick.Location = new System.Drawing.Point(91, 35);
            this.txb_ptick.Name = "txb_ptick";
            this.txb_ptick.Size = new System.Drawing.Size(58, 20);
            this.txb_ptick.TabIndex = 5;
            this.txb_ptick.Text = "0.25";
            // 
            // txb_ptime
            // 
            this.txb_ptime.Location = new System.Drawing.Point(91, 13);
            this.txb_ptime.Name = "txb_ptime";
            this.txb_ptime.Size = new System.Drawing.Size(58, 20);
            this.txb_ptime.TabIndex = 4;
            this.txb_ptime.Text = "0.300000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Pressed tick";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Pending tick";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pending time";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txb_cgct);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(167, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 40);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Latency";
            // 
            // txb_cgct
            // 
            this.txb_cgct.Location = new System.Drawing.Point(39, 13);
            this.txb_cgct.Name = "txb_cgct";
            this.txb_cgct.Size = new System.Drawing.Size(44, 20);
            this.txb_cgct.TabIndex = 2;
            this.txb_cgct.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Time";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbox_dpsjackpot);
            this.groupBox1.Controls.Add(this.cbox_dpsclassic);
            this.groupBox1.Controls.Add(this.cbox_dpsfac);
            this.groupBox1.Controls.Add(this.cbox_dpsfield);
            this.groupBox1.Controls.Add(this.cbox_dpspub);
            this.groupBox1.Controls.Add(this.cbox_dpssix);
            this.groupBox1.Location = new System.Drawing.Point(263, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 87);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DPS meter zone";
            // 
            // cbox_dpsjackpot
            // 
            this.cbox_dpsjackpot.AutoSize = true;
            this.cbox_dpsjackpot.Location = new System.Drawing.Point(67, 60);
            this.cbox_dpsjackpot.Name = "cbox_dpsjackpot";
            this.cbox_dpsjackpot.Size = new System.Drawing.Size(61, 17);
            this.cbox_dpsjackpot.TabIndex = 14;
            this.cbox_dpsjackpot.Text = "jackpot";
            this.cbox_dpsjackpot.UseVisualStyleBackColor = true;
            // 
            // cbox_dpsclassic
            // 
            this.cbox_dpsclassic.AutoSize = true;
            this.cbox_dpsclassic.Location = new System.Drawing.Point(6, 60);
            this.cbox_dpsclassic.Name = "cbox_dpsclassic";
            this.cbox_dpsclassic.Size = new System.Drawing.Size(59, 17);
            this.cbox_dpsclassic.TabIndex = 13;
            this.cbox_dpsclassic.Text = "Classic";
            this.cbox_dpsclassic.UseVisualStyleBackColor = true;
            // 
            // cbox_dpsfac
            // 
            this.cbox_dpsfac.AutoSize = true;
            this.cbox_dpsfac.Location = new System.Drawing.Point(67, 15);
            this.cbox_dpsfac.Name = "cbox_dpsfac";
            this.cbox_dpsfac.Size = new System.Drawing.Size(61, 17);
            this.cbox_dpsfac.TabIndex = 12;
            this.cbox_dpsfac.Text = "Faction";
            this.cbox_dpsfac.UseVisualStyleBackColor = true;
            // 
            // cbox_dpsfield
            // 
            this.cbox_dpsfield.AutoSize = true;
            this.cbox_dpsfield.Location = new System.Drawing.Point(67, 37);
            this.cbox_dpsfield.Name = "cbox_dpsfield";
            this.cbox_dpsfield.Size = new System.Drawing.Size(48, 17);
            this.cbox_dpsfield.TabIndex = 11;
            this.cbox_dpsfield.Text = "Field";
            this.cbox_dpsfield.UseVisualStyleBackColor = true;
            // 
            // cbox_dpspub
            // 
            this.cbox_dpspub.AutoSize = true;
            this.cbox_dpspub.Location = new System.Drawing.Point(6, 37);
            this.cbox_dpspub.Name = "cbox_dpspub";
            this.cbox_dpspub.Size = new System.Drawing.Size(55, 17);
            this.cbox_dpspub.TabIndex = 10;
            this.cbox_dpspub.Text = "Public";
            this.cbox_dpspub.UseVisualStyleBackColor = true;
            // 
            // cbox_dpssix
            // 
            this.cbox_dpssix.AutoSize = true;
            this.cbox_dpssix.Location = new System.Drawing.Point(6, 15);
            this.cbox_dpssix.Name = "cbox_dpssix";
            this.cbox_dpssix.Size = new System.Drawing.Size(55, 17);
            this.cbox_dpssix.TabIndex = 9;
            this.cbox_dpssix.Text = "6-man";
            this.cbox_dpssix.UseVisualStyleBackColor = true;
            // 
            // gboxLatency
            // 
            this.gboxLatency.Controls.Add(this.txbMidmsec);
            this.gboxLatency.Controls.Add(this.label2);
            this.gboxLatency.Controls.Add(this.txbFastmsec);
            this.gboxLatency.Controls.Add(this.label1);
            this.gboxLatency.Location = new System.Drawing.Point(167, 52);
            this.gboxLatency.Name = "gboxLatency";
            this.gboxLatency.Size = new System.Drawing.Size(91, 63);
            this.gboxLatency.TabIndex = 15;
            this.gboxLatency.TabStop = false;
            this.gboxLatency.Text = "Latency msec";
            // 
            // txbMidmsec
            // 
            this.txbMidmsec.Location = new System.Drawing.Point(39, 36);
            this.txbMidmsec.Name = "txbMidmsec";
            this.txbMidmsec.Size = new System.Drawing.Size(44, 20);
            this.txbMidmsec.TabIndex = 12;
            this.txbMidmsec.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Fast";
            // 
            // txbFastmsec
            // 
            this.txbFastmsec.Location = new System.Drawing.Point(39, 13);
            this.txbFastmsec.Name = "txbFastmsec";
            this.txbFastmsec.Size = new System.Drawing.Size(44, 20);
            this.txbFastmsec.TabIndex = 11;
            this.txbFastmsec.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mid";
            // 
            // cbox_perfmod
            // 
            this.cbox_perfmod.AutoSize = true;
            this.cbox_perfmod.Location = new System.Drawing.Point(167, 121);
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
            this.cbox_back.Size = new System.Drawing.Size(15, 14);
            this.cbox_back.TabIndex = 9;
            this.cbox_back.UseVisualStyleBackColor = true;
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
            this.gbox_patcher.Size = new System.Drawing.Size(420, 261);
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
            this.gbox_repackf.Size = new System.Drawing.Size(316, 39);
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
            this.btn_start.Location = new System.Drawing.Point(331, 224);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(76, 23);
            this.btn_start.TabIndex = 4;
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // richOut
            // 
            this.richOut.BackColor = System.Drawing.SystemColors.Control;
            this.richOut.ForeColor = System.Drawing.Color.Black;
            this.richOut.HideSelection = false;
            this.richOut.Location = new System.Drawing.Point(4, 285);
            this.richOut.Name = "richOut";
            this.richOut.Size = new System.Drawing.Size(420, 91);
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
            this.BackgroundImage = global::BnS_Launcher.Properties.Resources._3584283_16_9_aspect_ratio_belt_black_hair_blade___soul_bodysuit_boots_breasts_brown_e;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(429, 382);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxLatency.ResumeLayout(false);
            this.gboxLatency.PerformLayout();
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
        private System.Windows.Forms.GroupBox gboxLatency;
        private System.Windows.Forms.TextBox txbMidmsec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbFastmsec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbox_dpsfac;
        private System.Windows.Forms.CheckBox cbox_dpsfield;
        private System.Windows.Forms.CheckBox cbox_dpspub;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txb_cgct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbox_Cgct;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_mpresstime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txb_presstick;
        private System.Windows.Forms.TextBox txb_ptick;
        private System.Windows.Forms.TextBox txb_ptime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbox_dpsjackpot;
        private System.Windows.Forms.CheckBox cbox_dpsclassic;
        private System.Windows.Forms.CheckBox cbox_naglearena;
        private System.Windows.Forms.CheckBox cbox_nagle;
    }
}