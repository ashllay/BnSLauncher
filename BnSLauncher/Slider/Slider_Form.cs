using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace BnS_Launcher.Slider
{
    public partial class Slider_Form : Form
    {
        private string configFile = "config.xml";
        private Configuration config;
        private Memory memory;
        private IntPtr firstRecordAddress;
        private Profile currentProfile;
        private Profile defaultProfile;
        private Profile memoryDefaultProfile;
        //private IntPtr firstRecordAddress;

        public Slider_Form()
        {
            InitializeComponent();

            config = new Configuration(configFile);
            Process process = LoadProcess();
            LoadMemory(process);
            SetProcessBox(process);
            if (memory != null)
            {
                ScanForRecordAddress();
            }
            InitializeProfiles(config.DefaultProfile);
            for (int i = 0; i < currentProfile.Records.Count; i++)
            {
                selectBodyTypeBox.Items.Add(currentProfile.Records[i]);
            }
            if (memory != null)
            {
                if (firstRecordAddress != IntPtr.Zero)
                {
                    selectBodyTypeBox.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Found B&S process but got a bad address.  A patch may have changed memory addresses.\n\nTry selecting Full Scan in settings.");
                }
            }
            CreateTabs();
        }
        private void AddTextBoxEventHandlers(TextBox box, Record record, Slider slider, Slider_Form.UserValueChange function)
        {
            box.KeyDown += new KeyEventHandler((object send, KeyEventArgs ev) =>
            {
                float single;
                if (ev.KeyCode == Keys.Return)
                {
                    ev.Handled = true;
                    ev.SuppressKeyPress = true;
                    if (this.memory != null && float.TryParse(box.Text, out single))
                    {
                        try
                        {
                            function(record, single, slider);
                        }
                        catch (Exception exception) when (exception is AccessViolationException || exception is ArgumentException)
                        {
                            MessageBox.Show("Access Violation Error when trying to access the B&S process.\nMake sure B&S is running.");
                        }
                    }
                }
            });
            box.LostFocus += new EventHandler((object send, EventArgs ev) =>
            {
                float single;
                if (box.Modified && this.memory != null && float.TryParse(box.Text, out single))
                {
                    try
                    {
                        function(record, single, slider);
                    }
                    catch (Exception exception) when (exception is AccessViolationException || exception is ArgumentException)
                    {
                        MessageBox.Show("Access Violation Error when trying to access the B&S process.\nMake sure B&S is running.");
                    }
                }
                box.Modified = false;
            });
            box.TextChanged += new EventHandler((object send, EventArgs ev) => box.Modified = true);
        }

        private void ChangeMaxDelegate(Record record, float value, Slider slider)
        {
            if (this.firstRecordAddress.Equals(IntPtr.Zero))
            {
                MessageBox.Show("Address is 0");
                return;
            }
            IntPtr zero = IntPtr.Zero;
            zero = (this.firstRecordAddress + record.Offset) + 4 * (slider.Id - 1 + 27);
            this.memory.WriteFloat(zero, value);
            slider.Max = new float?(value);
        }

        private void ChangeMinDelegate(Record record, float value, Slider slider)
        {
            if (this.firstRecordAddress.Equals(IntPtr.Zero))
            {
                MessageBox.Show("Address is 0");
                return;
            }
            IntPtr zero = IntPtr.Zero;
            zero = (this.firstRecordAddress + record.Offset) + 4 * (slider.Id - 1);
            this.memory.WriteFloat(zero, value);
            slider.Min = new float?(value);
        }

        private void ClearPanel()
        {
            foreach (TabPage tabPage in this.tabControl.TabPages)
            {
                for (int i = 0; i < tabPage.Controls.Count; i++)
                {
                    tabPage.Controls[i].CausesValidation = false;
                    tabPage.Controls[i].Dispose();
                }
                tabPage.Controls.Clear();
            }
        }

        private void CreateTabs()
        {
            foreach (SliderCategory sliderGroup in this.config.SliderGroups)
            {
                TabPage tabPage = new TabPage()
                {
                    Text = sliderGroup.Description,
                    AutoScroll = true
                };
                this.tabControl.TabPages.Add(tabPage);
            }
            this.tabControl.SelectedIndexChanged += new EventHandler((object sender, EventArgs e) =>
            {
                if (this.tabControl.TabPages.Count <= 0)
                {
                    return;
                }
                if (this.tabControl.SelectedTab.Controls.Count > 0)
                {
                    this.tabControl.SelectedTab.Controls[0].Focus();
                }
            });
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.memory != null)
            {
                this.memory.Dispose();
            }
            this.memory = null;
            base.Close();
        }

        private SliderCategory GetGroup(Slider s)
        {
            SliderCategory sliderCategory;
            List<SliderCategory>.Enumerator enumerator = this.config.SliderGroups.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    SliderCategory current = enumerator.Current;
                    if (!current.Ids.Contains(s.Id))
                    {
                        continue;
                    }
                    sliderCategory = current;
                    return sliderCategory;
                }
                return null;
            }
            finally
            {
                ((IDisposable)enumerator).Dispose();
            }
            return sliderCategory;
        }

        private TabPage GetTab(SliderCategory g)
        {
            TabPage tabPage;
            IEnumerator enumerator = this.tabControl.TabPages.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    TabPage current = (TabPage)enumerator.Current;
                    if (!current.Text.Equals(g.Description))
                    {
                        continue;
                    }
                    tabPage = current;
                    return tabPage;
                }
                return null;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            return tabPage;
        }
        private void InitializeProfiles(string profileFile)
        {
            this.memoryDefaultProfile = new Profile(this.config.RecordList, config.SliderList);
            try
            {
                this.SyncMemoryWithProfile(this.memory, this.memoryDefaultProfile);
            }
            catch (Exception exception) when (exception is AccessViolationException || exception is ArgumentException)
            {
                MessageBox.Show("Error when trying to read or write from the B&S process.\n");
            }
            this.defaultProfile = new Profile(config.RecordList, config.SliderList);
            try
            {
                this.defaultProfile.Load(profileFile);
            }
            catch (Exception exception1)
            {
                MessageBox.Show("Error Loading Profile");
            }
            this.currentProfile = new Profile(this.defaultProfile);
            try
            {
                this.SyncMemoryWithProfile(this.memory, this.currentProfile);
            }
            catch (Exception exception2) when (exception2 is AccessViolationException || exception2 is ArgumentException)
            {
                MessageBox.Show("Error when trying to read or write from the B&S process.\n");
            }
        }

        private Memory LoadMemory(Process process)
        {
            if (process != null)
            {
                try
                {
                    memory = new Memory(process);
                }
                catch (InvalidOperationException invalidOperationException1)
                {
                    InvalidOperationException invalidOperationException = invalidOperationException1;
                    MessageBox.Show(string.Concat("Could not connect to B&S process memory: \n", invalidOperationException.Message));
                }
            }
            return memory;
        }

        private Process LoadProcess()
        {
            Process[] processesByName = Process.GetProcessesByName(this.config.ProcessName);
            Process process = null;
            for (int i = 0; i < (int)processesByName.Length; i++)
            {
                if (!processesByName[i].MainWindowTitle.Equals(this.config.WindowTitle))
                {
                    processesByName[i].Dispose();
                }
                else
                {
                    process = processesByName[i];
                }
            }
            return process;
        }

        private void loadProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileMenu.Title = "Select Profile file";
            this.openFileMenu.Filter = "XML|*.xml|All files|*.*";
            this.openFileMenu.InitialDirectory = Application.StartupPath;
            string fileName = "";
            if (this.openFileMenu.ShowDialog() == DialogResult.OK)
            {
                fileName = this.openFileMenu.FileName;
                int selectedIndex = this.selectBodyTypeBox.SelectedIndex;
                bool enabled = this.selectBodyTypeBox.Enabled;
                this.selectBodyTypeBox.Enabled = false;
                this.InitializeProfiles(fileName);
                this.selectBodyTypeBox.Items.Clear();
                for (int i = 0; i < this.currentProfile.Records.Count; i++)
                {
                    this.selectBodyTypeBox.Items.Add(this.currentProfile.Records[i]);
                }
                this.selectBodyTypeBox.SelectedIndex = selectedIndex;
                this.selectBodyTypeBox.Enabled = enabled;
                if (enabled)
                {
                    this.PopulatePanel();
                }
            }
        }

        private void PopulatePanel()
        {
            this.ClearPanel();
            if (this.selectBodyTypeBox.SelectedIndex == -1)
            {
                return;
            }
            Record selectedItem = (Record)this.selectBodyTypeBox.SelectedItem;
            Label label = null;
            for (int i = 0; i < selectedItem.Sliders.Count; i++)
            {
                SliderCategory group = this.GetGroup(selectedItem.Sliders[i]);
                TabPage tab = this.GetTab(group);
                int num = group.Ids.IndexOf(selectedItem.Sliders[i].Id);
                label = new Label()
                {
                    Text = selectedItem.Sliders[i].Description,
                    Location = new Point(tab.Left, 10 + (num + 1) * 30)
                };
                TextBox textBox = new TextBox()
                {
                    Location = new Point(label.Right, label.Top - 3)
                };
                float? min = selectedItem.Sliders[i].Min;
                textBox.Text = min.ToString();
                TextBox str = new TextBox()
                {
                    Location = new Point(textBox.Right, label.Top - 3)
                };
                min = selectedItem.Sliders[i].Max;
                str.Text = min.ToString();

                AddTextBoxEventHandlers(textBox, selectedItem, selectedItem.Sliders[i], new UserValueChange(ChangeMinDelegate));
                AddTextBoxEventHandlers(str, selectedItem, selectedItem.Sliders[i], new UserValueChange(ChangeMaxDelegate));
                tab.Controls.Add(label);
                tab.Controls.Add(textBox);
                tab.Controls.Add(str);
            }
            if (label != null)
            {
                foreach (TabPage tabPage in this.tabControl.TabPages)
                {
                    Label point = new Label()
                    {
                        Text = "Min"
                    };
                    Label label1 = new Label()
                    {
                        Text = "Max"
                    };
                    point.Location = new Point(label.Right, 10);
                    label1.Location = new Point(point.Right, point.Top);
                    tabPage.Controls.Add(point);
                    tabPage.Controls.Add(label1);
                }
            }
        }
        private void processRefreshButton_Click(object sender, EventArgs e)
        {
            selectBodyTypeBox.Enabled = false;
            ClearPanel();
            if (this.memory != null)
            {
                this.memory.Dispose();
            }
            this.memory = null;
            Process process = this.LoadProcess();
            this.LoadMemory(process);
            this.SetProcessBox(process);
            if (this.memory != null)
            {
                this.ScanForRecordAddress();
                this.memoryDefaultProfile = new Profile(config.RecordList, config.SliderList);
                try
                {
                    this.SyncMemoryWithProfile(this.memory, this.memoryDefaultProfile);
                }
                catch (Exception exception) when (exception is AccessViolationException || exception is ArgumentException)
                {
                    MessageBox.Show("Error when trying to read or write from the B&S process.\n");
                }
                try
                {
                    this.SyncMemoryWithProfile(this.memory, this.currentProfile);
                }
                catch (Exception exception1) when (exception1 is AccessViolationException || exception1 is ArgumentException)
                {
                    MessageBox.Show("Error when trying to read or write from the B&S process.\n");
                }
                if (this.firstRecordAddress == IntPtr.Zero)
                {
                    MessageBox.Show("Found B&S process but got a bad address.  A patch may have changed memory addresses.\n\nTry selecting Full Scan in settings.");
                    return;
                }
                selectBodyTypeBox.Enabled = true;
                PopulatePanel();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.selectBodyTypeBox.SelectedIndex;
            bool enabled = this.selectBodyTypeBox.Enabled;
            this.selectBodyTypeBox.Enabled = false;
            this.currentProfile = new Profile(this.memoryDefaultProfile);
            try
            {
                this.SyncMemoryWithProfile(this.memory, this.currentProfile);
            }
            catch (Exception exception) when (exception is AccessViolationException || exception is ArgumentException)
            {
                MessageBox.Show("Error when trying to read or write from the B&S process.\n");
            }
            this.selectBodyTypeBox.Items.Clear();
            for (int i = 0; i < this.currentProfile.Records.Count; i++)
            {
                this.selectBodyTypeBox.Items.Add(this.currentProfile.Records[i]);
            }
            this.selectBodyTypeBox.SelectedIndex = selectedIndex;
            this.selectBodyTypeBox.Enabled = enabled;
            if (enabled)
            {
                this.PopulatePanel();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileMenu.Title = "Save Profile file";
            this.saveFileMenu.Filter = "XML|*.xml|All files|*.*";
            this.saveFileMenu.InitialDirectory = Application.StartupPath;
            string fileName = "";
            if (this.saveFileMenu.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = this.saveFileMenu.FileName;
                this.currentProfile.Save(fileName);
            }
        }

        private IntPtr ScanForRecordAddress()
        {
            try
            {
                if (!config.ScanType.ToLower().Equals("offset"))
                {
                    ProgressBarForm progressBarForm = new ProgressBarForm();
                    progressBarForm.Show();
                    Point location = Location;
                    int x = location.X + Width / 2 - progressBarForm.Width / 2;
                    location = Location;
                    Point point = new Point(x, location.Y + 100);
                    progressBarForm.Location = point;
                    progressBarForm.Update();
                    Update();
                    if (config.BufferSize <= 0)
                    {
                        config.BufferSize = 1;
                    }
                    byte[] numArray = new byte[config.BufferSize * 1024];
                    firstRecordAddress = MemoryScanner.ScanRange(memory, (IntPtr)0, (IntPtr)int.MaxValue, config.ByteArray, numArray);
                    progressBarForm.Close();
                }
                else
                {
                    firstRecordAddress = MemoryScanner.ScanModule(memory, config.Module, config.BaseAddress, config.ByteArray, config.MemoryRange);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return this.firstRecordAddress;
        }

        private void selectBodyTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selectBodyTypeBox.SelectedIndex == -1 || !this.selectBodyTypeBox.Enabled)
            {
                return;
            }
            this.PopulatePanel();
            base.ActiveControl = this.tabControl.SelectedTab;
        }

        private void SetProcessBox(Process process)
        {
            processSelectBox.Items.Clear();
            if (processIcon.Image != null)
            {
                processIcon.Image.Dispose();
            }
            processIcon.Image = null;
            if (process == null)
            {
                return;
            }
            processSelectBox.Items.Add(process.MainWindowTitle);
            Icon icon = Icon.ExtractAssociatedIcon(process.MainModule.FileName);
            processSelectBox.SelectedIndex = 0;
            processIcon.Image = icon.ToBitmap();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new SettingsForm(config)).Show();
        }

        private void SyncMemoryWithProfile(Memory memory, Profile profile)
        {
            float? min;
            if (firstRecordAddress.Equals(IntPtr.Zero))
            {
                return;
            }
            if (memory != null)
            {
                foreach (Record record in profile.Records)
                {
                    for (int i = 0; i < record.Sliders.Count; i++)
                    {
                        IntPtr zero = IntPtr.Zero;
                        zero = (this.firstRecordAddress + record.Offset) + 4 * (record.Sliders[i].Id - 1);
                        if (!record.Sliders[i].Min.HasValue)
                        {
                            record.Sliders[i].Min = new float?(memory.ReadFloat(zero));
                        }
                        else
                        {
                            min = record.Sliders[i].Min;
                            memory.WriteFloat(zero, min.Value);
                        }
                        zero = (this.firstRecordAddress + record.Offset) + 4 * (record.Sliders[i].Id - 1 + 27);
                        if (!record.Sliders[i].Max.HasValue)
                        {
                            record.Sliders[i].Max = new float?(memory.ReadFloat(zero));
                        }
                        else
                        {
                            min = record.Sliders[i].Max;
                            memory.WriteFloat(zero, min.Value);
                        }
                    }
                }
            }
        }

        private delegate void UserValueChange(Record record, float value, Slider slider);

    }
}
