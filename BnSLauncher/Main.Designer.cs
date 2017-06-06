namespace BnS_TwLauncher
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
            this.Btn_play = new System.Windows.Forms.Button();
            this.btn_settings = new System.Windows.Forms.Button();
            this.btn_Slider = new System.Windows.Forms.Button();
            this.btn_patcher = new System.Windows.Forms.Button();
            this.box_WestLogin = new System.Windows.Forms.GroupBox();
            this.cbox_Spass = new System.Windows.Forms.CheckBox();
            this.cbox_Smail = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RegionCB = new System.Windows.Forms.ComboBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_Pass = new System.Windows.Forms.TextBox();
            this.txb_Mail = new System.Windows.Forms.TextBox();
            this.box_WestLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_play
            // 
            this.Btn_play.BackColor = System.Drawing.Color.Transparent;
            this.Btn_play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Btn_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_play.ForeColor = System.Drawing.Color.White;
            this.Btn_play.Location = new System.Drawing.Point(517, 350);
            this.Btn_play.Name = "Btn_play";
            this.Btn_play.Size = new System.Drawing.Size(91, 57);
            this.Btn_play.TabIndex = 0;
            this.Btn_play.Text = "Play";
            this.Btn_play.UseVisualStyleBackColor = false;
            this.Btn_play.Click += new System.EventHandler(this.Btn_play_Click);
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
            this.btn_settings.Text = "Settings";
            this.btn_settings.UseVisualStyleBackColor = false;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // btn_Slider
            // 
            this.btn_Slider.BackColor = System.Drawing.Color.Transparent;
            this.btn_Slider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Slider.ForeColor = System.Drawing.Color.White;
            this.btn_Slider.Location = new System.Drawing.Point(93, 3);
            this.btn_Slider.Name = "btn_Slider";
            this.btn_Slider.Size = new System.Drawing.Size(75, 23);
            this.btn_Slider.TabIndex = 3;
            this.btn_Slider.Text = "Slider";
            this.btn_Slider.UseVisualStyleBackColor = false;
            this.btn_Slider.Click += new System.EventHandler(this.btn_Slider_Click);
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
            this.btn_patcher.Text = "Patcher";
            this.btn_patcher.UseVisualStyleBackColor = false;
            this.btn_patcher.Click += new System.EventHandler(this.btn_patcher_Click);
            // 
            // box_WestLogin
            // 
            this.box_WestLogin.BackColor = System.Drawing.Color.Transparent;
            this.box_WestLogin.BackgroundImage = global::BnS_Launcher.Properties.Resources._2x2;
            this.box_WestLogin.Controls.Add(this.cbox_Spass);
            this.box_WestLogin.Controls.Add(this.cbox_Smail);
            this.box_WestLogin.Controls.Add(this.label3);
            this.box_WestLogin.Controls.Add(this.RegionCB);
            this.box_WestLogin.Controls.Add(this.btn_Login);
            this.box_WestLogin.Controls.Add(this.label2);
            this.box_WestLogin.Controls.Add(this.label1);
            this.box_WestLogin.Controls.Add(this.txb_Pass);
            this.box_WestLogin.Controls.Add(this.txb_Mail);
            this.box_WestLogin.ForeColor = System.Drawing.Color.White;
            this.box_WestLogin.Location = new System.Drawing.Point(12, 303);
            this.box_WestLogin.Name = "box_WestLogin";
            this.box_WestLogin.Size = new System.Drawing.Size(345, 104);
            this.box_WestLogin.TabIndex = 6;
            this.box_WestLogin.TabStop = false;
            this.box_WestLogin.Text = "West login form";
            // 
            // cbox_Spass
            // 
            this.cbox_Spass.AutoSize = true;
            this.cbox_Spass.Location = new System.Drawing.Point(259, 74);
            this.cbox_Spass.Name = "cbox_Spass";
            this.cbox_Spass.Size = new System.Drawing.Size(77, 17);
            this.cbox_Spass.TabIndex = 11;
            this.cbox_Spass.Text = "Save Pass";
            this.cbox_Spass.UseVisualStyleBackColor = true;
            this.cbox_Spass.CheckedChanged += new System.EventHandler(this.cbox_Spass_CheckedChanged);
            // 
            // cbox_Smail
            // 
            this.cbox_Smail.AutoSize = true;
            this.cbox_Smail.Location = new System.Drawing.Point(180, 74);
            this.cbox_Smail.Name = "cbox_Smail";
            this.cbox_Smail.Size = new System.Drawing.Size(79, 17);
            this.cbox_Smail.TabIndex = 10;
            this.cbox_Smail.Text = "Save Email";
            this.cbox_Smail.UseVisualStyleBackColor = true;
            this.cbox_Smail.CheckedChanged += new System.EventHandler(this.cbox_Smail_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Region:";
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
            this.btn_Login.Size = new System.Drawing.Size(75, 46);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email:";
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
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::BnS_Launcher.Properties.Resources._5334298_1girl_animal_ears_blade__amp__soul_blush_bodysuit_boots_brown_eyes_brown_hair;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(617, 417);
            this.Controls.Add(this.box_WestLogin);
            this.Controls.Add(this.btn_patcher);
            this.Controls.Add(this.btn_Slider);
            this.Controls.Add(this.btn_settings);
            this.Controls.Add(this.Btn_play);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "BnS Custom Launcher";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.box_WestLogin.ResumeLayout(false);
            this.box_WestLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_play;
        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.Button btn_Slider;
        private System.Windows.Forms.Button btn_patcher;
        private System.Windows.Forms.GroupBox box_WestLogin;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_Pass;
        private System.Windows.Forms.TextBox txb_Mail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox RegionCB;
        private System.Windows.Forms.CheckBox cbox_Smail;
        private System.Windows.Forms.CheckBox cbox_Spass;
    }
}

