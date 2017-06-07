namespace BnS_Launcher.Slider
{
    partial class SettingsForm
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
            this.bufferSizeTextBox = new System.Windows.Forms.TextBox();
            this.defaultProfileButton = new System.Windows.Forms.Button();
            this.defaultProfileTextBox = new System.Windows.Forms.TextBox();
            this.defaultProfileLabel = new System.Windows.Forms.Label();
            this.bufferSizeLabel = new System.Windows.Forms.Label();
            this.kbLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scanFullCheckBox = new System.Windows.Forms.CheckBox();
            this.scanOffsetCheckBox = new System.Windows.Forms.CheckBox();
            this.openFileMenu = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bufferSizeTextBox
            // 
            this.bufferSizeTextBox.Location = new System.Drawing.Point(118, 43);
            this.bufferSizeTextBox.Name = "bufferSizeTextBox";
            this.bufferSizeTextBox.Size = new System.Drawing.Size(87, 20);
            this.bufferSizeTextBox.TabIndex = 13;
            // 
            // defaultProfileButton
            // 
            this.defaultProfileButton.Location = new System.Drawing.Point(188, 100);
            this.defaultProfileButton.Name = "defaultProfileButton";
            this.defaultProfileButton.Size = new System.Drawing.Size(59, 23);
            this.defaultProfileButton.TabIndex = 23;
            this.defaultProfileButton.Text = "Browse";
            this.defaultProfileButton.UseVisualStyleBackColor = true;
            // 
            // defaultProfileTextBox
            // 
            this.defaultProfileTextBox.Location = new System.Drawing.Point(12, 103);
            this.defaultProfileTextBox.Name = "defaultProfileTextBox";
            this.defaultProfileTextBox.Size = new System.Drawing.Size(170, 20);
            this.defaultProfileTextBox.TabIndex = 22;
            // 
            // defaultProfileLabel
            // 
            this.defaultProfileLabel.AutoSize = true;
            this.defaultProfileLabel.Location = new System.Drawing.Point(12, 87);
            this.defaultProfileLabel.Name = "defaultProfileLabel";
            this.defaultProfileLabel.Size = new System.Drawing.Size(76, 13);
            this.defaultProfileLabel.TabIndex = 21;
            this.defaultProfileLabel.Text = "Default Profile:";
            // 
            // bufferSizeLabel
            // 
            this.bufferSizeLabel.AutoSize = true;
            this.bufferSizeLabel.Location = new System.Drawing.Point(115, 21);
            this.bufferSizeLabel.Name = "bufferSizeLabel";
            this.bufferSizeLabel.Size = new System.Drawing.Size(61, 13);
            this.bufferSizeLabel.TabIndex = 12;
            this.bufferSizeLabel.Text = "Buffer Size:";
            // 
            // kbLabel
            // 
            this.kbLabel.AutoSize = true;
            this.kbLabel.Location = new System.Drawing.Point(211, 46);
            this.kbLabel.Name = "kbLabel";
            this.kbLabel.Size = new System.Drawing.Size(21, 13);
            this.kbLabel.TabIndex = 14;
            this.kbLabel.Text = "KB";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(175, 129);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 20;
            this.closeButton.Text = "Cancel";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(94, 129);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Ok";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.scanFullCheckBox);
            this.groupBox1.Controls.Add(this.scanOffsetCheckBox);
            this.groupBox1.Controls.Add(this.bufferSizeTextBox);
            this.groupBox1.Controls.Add(this.bufferSizeLabel);
            this.groupBox1.Controls.Add(this.kbLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 72);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scan Method";
            // 
            // scanFullCheckBox
            // 
            this.scanFullCheckBox.AutoSize = true;
            this.scanFullCheckBox.Location = new System.Drawing.Point(7, 46);
            this.scanFullCheckBox.Name = "scanFullCheckBox";
            this.scanFullCheckBox.Size = new System.Drawing.Size(70, 17);
            this.scanFullCheckBox.TabIndex = 1;
            this.scanFullCheckBox.Text = "Full Scan";
            this.scanFullCheckBox.UseVisualStyleBackColor = true;
            // 
            // scanOffsetCheckBox
            // 
            this.scanOffsetCheckBox.AutoSize = true;
            this.scanOffsetCheckBox.Location = new System.Drawing.Point(7, 20);
            this.scanOffsetCheckBox.Name = "scanOffsetCheckBox";
            this.scanOffsetCheckBox.Size = new System.Drawing.Size(54, 17);
            this.scanOffsetCheckBox.TabIndex = 0;
            this.scanOffsetCheckBox.Text = "Offset";
            this.scanOffsetCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(260, 159);
            this.Controls.Add(this.defaultProfileButton);
            this.Controls.Add(this.defaultProfileTextBox);
            this.Controls.Add(this.defaultProfileLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileMenu;
        private System.Windows.Forms.CheckBox scanOffsetCheckBox;
        private System.Windows.Forms.CheckBox scanFullCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label kbLabel;
        private System.Windows.Forms.Label bufferSizeLabel;
        private System.Windows.Forms.Label defaultProfileLabel;
        private System.Windows.Forms.TextBox defaultProfileTextBox;
        private System.Windows.Forms.Button defaultProfileButton;
        private System.Windows.Forms.TextBox bufferSizeTextBox;
    }
}