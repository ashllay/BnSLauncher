using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BnS_Launcher.Slider
{
    public partial class SettingsForm : Form
    {
        private CheckBox checkedScan;

        private Configuration Config
        {
            get;
            set;
        }

        public SettingsForm(Configuration cfg)
        {
            InitializeComponent();
            this.Config = cfg;
            if (this.Config != null)
            {
                this.SetCheckBoxes();
                this.bufferSizeTextBox.Text = this.Config.BufferSize.ToString();
                this.defaultProfileTextBox.Text = this.Config.DefaultProfile;
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void defaultProfilebtn_Click(object sender, EventArgs e)
        {
            this.openFileMenu.Title = "Select Default Profile file";
            this.openFileMenu.Filter = "XML|*.xml|All files|*.*";
            this.openFileMenu.InitialDirectory = Application.StartupPath;
            string defaultProfile = this.Config.DefaultProfile;
            if (this.openFileMenu.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.defaultProfileTextBox.Text = this.openFileMenu.FileName;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            int num;
            if (this.checkedScan != null)
            {
                this.Config.ScanType = this.checkedScan.Text;
            }
            if (int.TryParse(this.bufferSizeTextBox.Text, out num) && num > 0)
            {
                this.Config.BufferSize = num;
            }
            this.Config.DefaultProfile = this.defaultProfileTextBox.Text;
            this.Config.Save(this.Config.Filename);
            base.Close();
        }
        private void SetCheckBoxes()
        {
            if (!this.Config.ScanType.ToLower().Equals("Full Scan".ToLower()))
            {
                this.scanOffsetCheckBox.Checked = true;
            }
            else
            {
                this.scanFullCheckBox.Checked = true;
            }
            this.scanOffsetCheckBox.CheckStateChanged += new EventHandler((object send, EventArgs ev) => {
                if (this.scanOffsetCheckBox.CheckState == CheckState.Checked)
                {
                    this.checkedScan = this.scanOffsetCheckBox;
                    this.scanFullCheckBox.CheckState = CheckState.Unchecked;
                    this.scanOffsetCheckBox.AutoCheck = false;
                    this.scanFullCheckBox.AutoCheck = true;
                }
            });
            this.scanFullCheckBox.CheckStateChanged += new EventHandler((object send, EventArgs ev) => {
                if (this.scanFullCheckBox.CheckState == CheckState.Checked)
                {
                    this.checkedScan = this.scanFullCheckBox;
                    this.scanOffsetCheckBox.CheckState = CheckState.Unchecked;
                    this.scanOffsetCheckBox.AutoCheck = true;
                    this.scanFullCheckBox.AutoCheck = false;
                }
            });
        }
    }
}
