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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabPatcher = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbox_BakConfig = new System.Windows.Forms.CheckBox();
            this.checkBox_Webl = new System.Windows.Forms.CheckBox();
            this.checkBox_clause = new System.Windows.Forms.CheckBox();
            this.checkBox_minimize = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbox_BakXml = new System.Windows.Forms.CheckBox();
            this.cboxDPS = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.richOut = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPatcher.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPatcher
            // 
            this.tabPatcher.Controls.Add(this.tabPage1);
            this.tabPatcher.Controls.Add(this.tabPage2);
            this.tabPatcher.Location = new System.Drawing.Point(9, 42);
            this.tabPatcher.Name = "tabPatcher";
            this.tabPatcher.SelectedIndex = 0;
            this.tabPatcher.Size = new System.Drawing.Size(276, 104);
            this.tabPatcher.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.cbox_BakConfig);
            this.tabPage1.Controls.Add(this.checkBox_Webl);
            this.tabPage1.Controls.Add(this.checkBox_clause);
            this.tabPage1.Controls.Add(this.checkBox_minimize);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(268, 78);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config.dat";
            // 
            // cbox_BakConfig
            // 
            this.cbox_BakConfig.AutoSize = true;
            this.cbox_BakConfig.Checked = true;
            this.cbox_BakConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_BakConfig.ForeColor = System.Drawing.Color.Black;
            this.cbox_BakConfig.Location = new System.Drawing.Point(163, 6);
            this.cbox_BakConfig.Name = "cbox_BakConfig";
            this.cbox_BakConfig.Size = new System.Drawing.Size(101, 17);
            this.cbox_BakConfig.TabIndex = 12;
            this.cbox_BakConfig.Text = "Backup Original";
            this.cbox_BakConfig.UseVisualStyleBackColor = true;
            // 
            // checkBox_Webl
            // 
            this.checkBox_Webl.AutoSize = true;
            this.checkBox_Webl.ForeColor = System.Drawing.Color.Black;
            this.checkBox_Webl.Location = new System.Drawing.Point(6, 6);
            this.checkBox_Webl.Name = "checkBox_Webl";
            this.checkBox_Webl.Size = new System.Drawing.Size(135, 17);
            this.checkBox_Webl.TabIndex = 9;
            this.checkBox_Webl.Text = "Disable Web Launcher";
            this.checkBox_Webl.UseVisualStyleBackColor = true;
            // 
            // checkBox_clause
            // 
            this.checkBox_clause.AutoSize = true;
            this.checkBox_clause.ForeColor = System.Drawing.Color.Black;
            this.checkBox_clause.Location = new System.Drawing.Point(6, 29);
            this.checkBox_clause.Name = "checkBox_clause";
            this.checkBox_clause.Size = new System.Drawing.Size(96, 17);
            this.checkBox_clause.TabIndex = 10;
            this.checkBox_clause.Text = "Disable Clause";
            this.checkBox_clause.UseVisualStyleBackColor = true;
            // 
            // checkBox_minimize
            // 
            this.checkBox_minimize.AutoSize = true;
            this.checkBox_minimize.ForeColor = System.Drawing.Color.Black;
            this.checkBox_minimize.Location = new System.Drawing.Point(6, 52);
            this.checkBox_minimize.Name = "checkBox_minimize";
            this.checkBox_minimize.Size = new System.Drawing.Size(104, 17);
            this.checkBox_minimize.TabIndex = 11;
            this.checkBox_minimize.Text = "Disable Minimise";
            this.checkBox_minimize.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbox_BakXml);
            this.tabPage2.Controls.Add(this.cboxDPS);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(268, 78);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xml.dat";
            // 
            // cbox_BakXml
            // 
            this.cbox_BakXml.AutoSize = true;
            this.cbox_BakXml.Checked = true;
            this.cbox_BakXml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_BakXml.Location = new System.Drawing.Point(163, 6);
            this.cbox_BakXml.Name = "cbox_BakXml";
            this.cbox_BakXml.Size = new System.Drawing.Size(101, 17);
            this.cbox_BakXml.TabIndex = 9;
            this.cbox_BakXml.Text = "Backup Original";
            this.cbox_BakXml.UseVisualStyleBackColor = true;
            // 
            // cboxDPS
            // 
            this.cboxDPS.AutoSize = true;
            this.cboxDPS.Location = new System.Drawing.Point(6, 6);
            this.cboxDPS.Name = "cboxDPS";
            this.cboxDPS.Size = new System.Drawing.Size(148, 17);
            this.cboxDPS.TabIndex = 9;
            this.cboxDPS.Text = "Enable DPS metter 6 man";
            this.cboxDPS.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.BackgroundImage = global::BnS_Launcher.Properties.Resources._2x2;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Controls.Add(this.tabPatcher);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button_start);
            this.groupBox2.Controls.Add(this.richOut);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(4, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 270);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "_";
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.Transparent;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.ForeColor = System.Drawing.Color.White;
            this.button_start.Location = new System.Drawing.Point(289, 52);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 94);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "Start!";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // richOut
            // 
            this.richOut.BackColor = System.Drawing.SystemColors.Control;
            this.richOut.ForeColor = System.Drawing.Color.Black;
            this.richOut.HideSelection = false;
            this.richOut.Location = new System.Drawing.Point(7, 165);
            this.richOut.Name = "richOut";
            this.richOut.Size = new System.Drawing.Size(357, 95);
            this.richOut.TabIndex = 22;
            this.richOut.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output Log:";
            // 
            // Patcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BnS_Launcher.Properties.Resources._3584283_16_9_aspect_ratio_belt_black_hair_blade___soul_bodysuit_boots_breasts_brown_e;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(379, 288);
            this.Controls.Add(this.groupBox2);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl tabPatcher;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.RichTextBox richOut;
        private System.Windows.Forms.CheckBox cbox_BakConfig;
        private System.Windows.Forms.CheckBox checkBox_Webl;
        private System.Windows.Forms.CheckBox checkBox_minimize;
        private System.Windows.Forms.CheckBox checkBox_clause;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cboxDPS;
        private System.Windows.Forms.CheckBox cbox_BakXml;
    }
}