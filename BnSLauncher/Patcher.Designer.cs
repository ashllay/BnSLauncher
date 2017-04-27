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
            this.button_start = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_Webl = new System.Windows.Forms.CheckBox();
            this.checkBox_clause = new System.Windows.Forms.CheckBox();
            this.checkBox_minimize = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_Bak = new System.Windows.Forms.CheckBox();
            this.richOut = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.Transparent;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.ForeColor = System.Drawing.Color.White;
            this.button_start.Location = new System.Drawing.Point(289, 43);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 94);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "Start!";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output Log:";
            // 
            // checkBox_Webl
            // 
            this.checkBox_Webl.AutoSize = true;
            this.checkBox_Webl.Location = new System.Drawing.Point(14, 23);
            this.checkBox_Webl.Name = "checkBox_Webl";
            this.checkBox_Webl.Size = new System.Drawing.Size(135, 17);
            this.checkBox_Webl.TabIndex = 9;
            this.checkBox_Webl.Text = "Disable Web Launcher";
            this.checkBox_Webl.UseVisualStyleBackColor = true;
            // 
            // checkBox_clause
            // 
            this.checkBox_clause.AutoSize = true;
            this.checkBox_clause.Location = new System.Drawing.Point(14, 46);
            this.checkBox_clause.Name = "checkBox_clause";
            this.checkBox_clause.Size = new System.Drawing.Size(96, 17);
            this.checkBox_clause.TabIndex = 10;
            this.checkBox_clause.Text = "Disable Clause";
            this.checkBox_clause.UseVisualStyleBackColor = true;
            // 
            // checkBox_minimize
            // 
            this.checkBox_minimize.AutoSize = true;
            this.checkBox_minimize.Location = new System.Drawing.Point(14, 69);
            this.checkBox_minimize.Name = "checkBox_minimize";
            this.checkBox_minimize.Size = new System.Drawing.Size(104, 17);
            this.checkBox_minimize.TabIndex = 11;
            this.checkBox_minimize.Text = "Disable Minimise";
            this.checkBox_minimize.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkBox_Bak);
            this.groupBox1.Controls.Add(this.checkBox_Webl);
            this.groupBox1.Controls.Add(this.checkBox_minimize);
            this.groupBox1.Controls.Add(this.checkBox_clause);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(7, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 101);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patcher Options";
            // 
            // checkBox_Bak
            // 
            this.checkBox_Bak.AutoSize = true;
            this.checkBox_Bak.Checked = true;
            this.checkBox_Bak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Bak.Location = new System.Drawing.Point(155, 23);
            this.checkBox_Bak.Name = "checkBox_Bak";
            this.checkBox_Bak.Size = new System.Drawing.Size(99, 17);
            this.checkBox_Bak.TabIndex = 12;
            this.checkBox_Bak.Text = "Backup original";
            this.checkBox_Bak.UseVisualStyleBackColor = true;
            // 
            // richOut
            // 
            this.richOut.BackColor = System.Drawing.SystemColors.Control;
            this.richOut.ForeColor = System.Drawing.Color.Black;
            this.richOut.HideSelection = false;
            this.richOut.Location = new System.Drawing.Point(7, 156);
            this.richOut.Name = "richOut";
            this.richOut.Size = new System.Drawing.Size(357, 95);
            this.richOut.TabIndex = 22;
            this.richOut.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.BackgroundImage = global::BnS_Launcher.Properties.Resources._2x2;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button_start);
            this.groupBox2.Controls.Add(this.richOut);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(4, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 261);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Config.dat will be automatically found by the selected region in settings.";
            // 
            // Patcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(380, 265);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Patcher";
            this.Text = "Patcher";
            this.Load += new System.EventHandler(this.Tools_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_Webl;
        private System.Windows.Forms.CheckBox checkBox_clause;
        private System.Windows.Forms.CheckBox checkBox_minimize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_Bak;
        private System.Windows.Forms.RichTextBox richOut;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}