namespace BnS_Launcher
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_settings = new System.Windows.Forms.Button();
            this.btn_slider = new System.Windows.Forms.Button();
            this.btn_patcher = new System.Windows.Forms.Button();
            this.box_Login = new System.Windows.Forms.GroupBox();
            this.cbox_Spass = new System.Windows.Forms.CheckBox();
            this.cbox_Smail = new System.Windows.Forms.CheckBox();
            this.lb_region = new System.Windows.Forms.Label();
            this.RegionCB = new System.Windows.Forms.ComboBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.lb_pass = new System.Windows.Forms.Label();
            this.lb_mail = new System.Windows.Forms.Label();
            this.txb_Pass = new System.Windows.Forms.TextBox();
            this.txb_Mail = new System.Windows.Forms.TextBox();
            this.lb_loginsts = new System.Windows.Forms.Label();
            this.box_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            this.btn_play.BackColor = System.Drawing.Color.Transparent;
            this.btn_play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_play.ForeColor = System.Drawing.Color.White;
            this.btn_play.Location = new System.Drawing.Point(517, 350);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(91, 57);
            this.btn_play.TabIndex = 0;
            this.btn_play.UseVisualStyleBackColor = false;
            this.btn_play.Click += new System.EventHandler(this.Btn_play_Click);
            // 
            // btn_settings
            // 
            this.btn_settings.BackColor = System.Drawing.Color.Transparent;
            this.btn_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_settings.ForeColor = System.Drawing.Color.White;
            this.btn_settings.Location = new System.Drawing.Point(12, 3);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(75, 23);
            this.btn_settings.TabIndex = 1;
            this.btn_settings.UseVisualStyleBackColor = false;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // btn_slider
            // 
            this.btn_slider.BackColor = System.Drawing.Color.Transparent;
            this.btn_slider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_slider.ForeColor = System.Drawing.Color.White;
            this.btn_slider.Location = new System.Drawing.Point(93, 3);
            this.btn_slider.Name = "btn_slider";
            this.btn_slider.Size = new System.Drawing.Size(75, 23);
            this.btn_slider.TabIndex = 3;
            this.btn_slider.UseVisualStyleBackColor = false;
            this.btn_slider.Click += new System.EventHandler(this.btn_Slider_Click);
            // 
            // btn_patcher
            // 
            this.btn_patcher.BackColor = System.Drawing.Color.Transparent;
            this.btn_patcher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_patcher.ForeColor = System.Drawing.Color.White;
            this.btn_patcher.Location = new System.Drawing.Point(174, 3);
            this.btn_patcher.Name = "btn_patcher";
            this.btn_patcher.Size = new System.Drawing.Size(75, 23);
            this.btn_patcher.TabIndex = 4;
            this.btn_patcher.UseVisualStyleBackColor = false;
            this.btn_patcher.Click += new System.EventHandler(this.btn_patcher_Click);
            // 
            // box_Login
            // 
            this.box_Login.BackColor = System.Drawing.Color.Transparent;
            this.box_Login.BackgroundImage = global::BnS_Launcher.Properties.Resources._2x2;
            this.box_Login.Controls.Add(this.lb_loginsts);
            this.box_Login.Controls.Add(this.cbox_Spass);
            this.box_Login.Controls.Add(this.cbox_Smail);
            this.box_Login.Controls.Add(this.lb_region);
            this.box_Login.Controls.Add(this.RegionCB);
            this.box_Login.Controls.Add(this.btn_Login);
            this.box_Login.Controls.Add(this.lb_pass);
            this.box_Login.Controls.Add(this.lb_mail);
            this.box_Login.Controls.Add(this.txb_Pass);
            this.box_Login.Controls.Add(this.txb_Mail);
            this.box_Login.ForeColor = System.Drawing.Color.White;
            this.box_Login.Location = new System.Drawing.Point(12, 303);
            this.box_Login.Name = "box_Login";
            this.box_Login.Size = new System.Drawing.Size(364, 104);
            this.box_Login.TabIndex = 6;
            this.box_Login.TabStop = false;
            // 
            // cbox_Spass
            // 
            this.cbox_Spass.AutoSize = true;
            this.cbox_Spass.Location = new System.Drawing.Point(259, 74);
            this.cbox_Spass.Name = "cbox_Spass";
            this.cbox_Spass.Size = new System.Drawing.Size(32, 17);
            this.cbox_Spass.TabIndex = 11;
            this.cbox_Spass.Text = "_";
            this.cbox_Spass.UseVisualStyleBackColor = true;
            this.cbox_Spass.CheckedChanged += new System.EventHandler(this.cbox_Spass_CheckedChanged);
            // 
            // cbox_Smail
            // 
            this.cbox_Smail.AutoSize = true;
            this.cbox_Smail.Location = new System.Drawing.Point(180, 74);
            this.cbox_Smail.Name = "cbox_Smail";
            this.cbox_Smail.Size = new System.Drawing.Size(32, 17);
            this.cbox_Smail.TabIndex = 10;
            this.cbox_Smail.Text = "_";
            this.cbox_Smail.UseVisualStyleBackColor = true;
            this.cbox_Smail.CheckedChanged += new System.EventHandler(this.cbox_Smail_CheckedChanged);
            // 
            // lb_region
            // 
            this.lb_region.AutoSize = true;
            this.lb_region.Location = new System.Drawing.Point(6, 74);
            this.lb_region.Name = "lb_region";
            this.lb_region.Size = new System.Drawing.Size(13, 13);
            this.lb_region.TabIndex = 9;
            this.lb_region.Text = "_";
            // 
            // RegionCB
            // 
            this.RegionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionCB.FormattingEnabled = true;
            this.RegionCB.Location = new System.Drawing.Point(68, 71);
            this.RegionCB.Name = "RegionCB";
            this.RegionCB.Size = new System.Drawing.Size(105, 21);
            this.RegionCB.TabIndex = 8;
            // 
            // btn_Login
            // 
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(261, 19);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(97, 23);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // lb_pass
            // 
            this.lb_pass.AutoSize = true;
            this.lb_pass.Location = new System.Drawing.Point(6, 48);
            this.lb_pass.Name = "lb_pass";
            this.lb_pass.Size = new System.Drawing.Size(13, 13);
            this.lb_pass.TabIndex = 3;
            this.lb_pass.Text = "_";
            // 
            // lb_mail
            // 
            this.lb_mail.AutoSize = true;
            this.lb_mail.Location = new System.Drawing.Point(6, 22);
            this.lb_mail.Name = "lb_mail";
            this.lb_mail.Size = new System.Drawing.Size(13, 13);
            this.lb_mail.TabIndex = 2;
            this.lb_mail.Text = "_";
            // 
            // txb_Pass
            // 
            this.txb_Pass.Location = new System.Drawing.Point(68, 45);
            this.txb_Pass.Name = "txb_Pass";
            this.txb_Pass.PasswordChar = '*';
            this.txb_Pass.Size = new System.Drawing.Size(187, 20);
            this.txb_Pass.TabIndex = 1;
            this.txb_Pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_Pass_KeyDown);
            // 
            // txb_Mail
            // 
            this.txb_Mail.Location = new System.Drawing.Point(68, 19);
            this.txb_Mail.Name = "txb_Mail";
            this.txb_Mail.Size = new System.Drawing.Size(187, 20);
            this.txb_Mail.TabIndex = 0;
            this.txb_Mail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_Mail_KeyDown);
            // 
            // lb_loginsts
            // 
            this.lb_loginsts.AutoSize = true;
            this.lb_loginsts.Location = new System.Drawing.Point(261, 48);
            this.lb_loginsts.Name = "lb_loginsts";
            this.lb_loginsts.Size = new System.Drawing.Size(0, 13);
            this.lb_loginsts.TabIndex = 12;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::BnS_Launcher.Properties.Resources._5334298_1girl_animal_ears_blade__amp__soul_blush_bodysuit_boots_brown_eyes_brown_hair;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(617, 417);
            this.Controls.Add(this.box_Login);
            this.Controls.Add(this.btn_patcher);
            this.Controls.Add(this.btn_slider);
            this.Controls.Add(this.btn_settings);
            this.Controls.Add(this.btn_play);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "BnS Custom Launcher";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.box_Login.ResumeLayout(false);
            this.box_Login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.Button btn_slider;
        private System.Windows.Forms.Button btn_patcher;
        private System.Windows.Forms.GroupBox box_Login;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label lb_pass;
        private System.Windows.Forms.Label lb_mail;
        private System.Windows.Forms.TextBox txb_Pass;
        private System.Windows.Forms.TextBox txb_Mail;
        private System.Windows.Forms.Label lb_region;
        private System.Windows.Forms.ComboBox RegionCB;
        private System.Windows.Forms.CheckBox cbox_Smail;
        private System.Windows.Forms.CheckBox cbox_Spass;
        private System.Windows.Forms.Label lb_loginsts;
    }
}

