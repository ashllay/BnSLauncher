using System;
using System.Windows.Forms;
using System.IO;
using Ini;
using System.Xml;
using System.Text;

namespace BnS_Launcher
{
    public partial class Settings : Form
    {
        bool PathsFound = false;
        bool LoadingDisabled = false;

        XmlDocument document;
        XmlNode node;
        XmlElement element;
        string str2;
        FileStream stream;
        StreamReader reader;
        string str3;
        FileStream stream2;
        StreamWriter writer;

        IniFile fSettings = new IniFile(Environment.CurrentDirectory + "\\Settings.ini");
        SettingsClass sSettings = new SettingsClass();

        public Settings()
        {
            InitializeComponent();

            sSettings.sNoTextureStreaming = fSettings.IniReadValue("Settings", "NoTextureStreaming");
            sSettings.sUnattended = fSettings.IniReadValue("Settings", "Unattended");
            sSettings.sRegion = fSettings.IniReadValue("Settings", "Region");
            sSettings.sLanguageID = fSettings.IniReadValue("Settings", "language");
            sSettings.sUseAllCores = fSettings.IniReadValue("Settings", "UseAllCores");
            sSettings.sArchitecture = fSettings.IniReadValue("Settings", "Architecture");
            sSettings.sServerType = fSettings.IniReadValue("Settings", "ServerType");

            if (string.IsNullOrEmpty(sSettings.sArchitecture))
            {
                fSettings.IniWriteValue("Settings", "Architecture", "0");
                x86_rB.Checked = true;
            }
            if (string.IsNullOrEmpty(sSettings.sArchitecture))
            {
                fSettings.IniWriteValue("Settings", "ServerType", "Live");
                rB_KRLive.Checked = true;
            }
        }

        private void FomrSettings_Load(object sender, EventArgs e)
        {
            // Find Client.exe and set file paths
            // Check the registry
            switch (sSettings.sRegion)
            {
                case "JP":
                    rB_JP.Checked = true;
                    break;
                case "TW":
                    rB_TW.Checked = true;
                    break;
                case "EN":
                    rB_EN.Checked = true;
                    break;
                case "KR":
                    rB_KR.Checked = true;
                    if (sSettings.sServerType == "Live")
                        rB_KRLive.Checked = true;
                    else if (sSettings.sServerType == "Test")
                        rB_KRTest.Checked = true;
                    break;
                default:
                    break;
            }


            if (sSettings.sInstallPath != null)
                PathsFound = true;

            if (PathsFound == true)
            {
                //--
                if (!Directory.Exists(sSettings.sModPath + "\\..\\loading"))
                    Directory.CreateDirectory(sSettings.sModPath + "\\..\\loading");

                if (File.Exists(sSettings.sModPath + "\\..\\loading\\00009368.bak"))
                {
                    LoadingDisabled = true;
                    cbx_disableImg.Checked = true;
                }

                //--
                if (sSettings.sNoTextureStreaming == "true")
                    cBtextureStr.Checked = true;

                if (sSettings.sUnattended == "true")
                    cBmsBox.Checked = true;

                if (sSettings.sUseAllCores == "true")
                    cBallCores.Checked = true;

                //--
                if (sSettings.sLanguageID == "English")
                    radioButton_Eng.Checked = true;

                if (sSettings.sLanguageID == "German")
                    radioButton_Ger.Checked = true;

                if (sSettings.sLanguageID == "French")
                    radioButton_Fre.Checked = true;

                //--
                if (rB_EN.Checked)
                    groupBox_west_lang.Show();
                else
                    groupBox_west_lang.Hide();

                if (rB_KR.Checked)
                    gbox_krserver.Show();
                else
                    gbox_krserver.Hide();
                //--
                if (sSettings.sArchitecture == "0")
                {
                    x86_rB.Checked = true;
                    x64_Rb.Checked = false;
                }
                else
                {
                    x86_rB.Checked = false;
                    x64_Rb.Checked = true;
                }
                Sts_Label.Text = "";
            }
            try
            {
                document = new XmlDocument();
                document.Load(sSettings.XmlSettings);
                node = document.SelectSingleNode("config");
                if (node != null)
                {
                    foreach (XmlNode node2 in node.ChildNodes)
                    {
                        element = (XmlElement)node2;
                        if ((element.GetAttribute("name") == "maxZoom"))
                        {
                            txb_zoom.Text = element.GetAttribute("value");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cBtextureStr_CheckedChanged(object sender, EventArgs e)
        {
            if (cBtextureStr.Checked == true)
            {
                sSettings.sNoTextureStreaming = "true";
                fSettings.IniWriteValue("Settings", "NoTextureStreaming", "true");
                Sts_Label.Text = "Texture streaming disabled.";
            }
            else
            {
                sSettings.sNoTextureStreaming = "false";
                fSettings.IniWriteValue("Settings", "NoTextureStreaming", "false");
                Sts_Label.Text = "Texture streaming enabled.";
            }
        }

        private void cBmsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cBmsBox.Checked == true)
            {
                sSettings.sUnattended = "true";
                fSettings.IniWriteValue("Settings", "Unattended", "true");
                Sts_Label.Text = "Message boxes disabled.";
            }
            else
            {
                sSettings.sUnattended = "false";
                fSettings.IniWriteValue("Settings", "Unattended", "false");
                Sts_Label.Text = "Message boxes enabled.";
            }
        }

        private void checkBox_AllCores_CheckedChanged(object sender, EventArgs e)
        {
            if (cBallCores.Checked == true)
            {
                sSettings.sUseAllCores = "true";
                fSettings.IniWriteValue("Settings", "UseAllCores", "true");
                Sts_Label.Text = "Use all cores enabled.";
            }
            else
            {
                sSettings.sUseAllCores = "false";
                fSettings.IniWriteValue("Settings", "UseAllCores", "false");
                Sts_Label.Text = "Use all cores disabled.";
            }
        }
        private void rB_JP_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_JP.Checked == true)
            {
                sSettings.sRegion = "JP";
                fSettings.IniWriteValue("Settings", "Region", "JP");
                groupBox_west_lang.Hide();
                gbox_krserver.Hide();
            }
        }

        private void rB_TW_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_TW.Checked == true)
            {
                sSettings.sRegion = "TW";
                fSettings.IniWriteValue("Settings", "Region", "TW");
                groupBox_west_lang.Hide();
                gbox_krserver.Hide();
            }
        }

        private void rB_KR_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_KR.Checked == true)
            {
                if (sSettings.sServerType == "Live")
                    rB_KRLive.Checked = true;
                if (sSettings.sServerType == "Test")
                    rB_KRTest.Checked = true;

                sSettings.sRegion = "KR";

                gbox_krserver.Show();
                groupBox_west_lang.Hide();

                fSettings.IniWriteValue("Settings", "Region", "KR");
            }
        }

        private void rB_KRLive_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_KRLive.Checked == true)
            {
                sSettings.sServerType = "Live";
                rB_KRTest.Checked = false;
                fSettings.IniWriteValue("Settings", "ServerType", "Live");
            }
        }
        private void rB_KRTest_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_KRTest.Checked == true)
            {
                sSettings.sServerType = "Test";
                rB_KRLive.Checked = false;
                fSettings.IniWriteValue("Settings", "ServerType", "Test");
            }
        }

        private void rB_EN_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_EN.Checked == true)
            {

                sSettings.sRegion = "EN";
                fSettings.IniWriteValue("Settings", "Region", "EN");
                fSettings.IniWriteValue("Settings", "language", "English");
                groupBox_west_lang.Show();
                gbox_krserver.Hide();
            }
        }

        private void radioButton_Eng_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Eng.Checked == true)
                fSettings.IniWriteValue("Settings", "language", "English");
        }

        private void radioButton_Ger_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Ger.Checked == true)
                fSettings.IniWriteValue("Settings", "language", "German");
        }

        private void radioButton_Fre_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Fre.Checked == true)
                fSettings.IniWriteValue("Settings", "language", "French");
        }

        private void x86_rB_CheckedChanged(object sender, EventArgs e)
        {
            if (x86_rB.Checked == true)
                fSettings.IniWriteValue("Settings", "Architecture", "0");
        }

        private void x64_Rb_CheckedChanged(object sender, EventArgs e)
        {
            if (x64_Rb.Checked == true)
                fSettings.IniWriteValue("Settings", "Architecture", "1");
        }

        private void cbx_disableImg_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadingDisabled == false)
            {
                LoadingDisabled = true;
                try
                {
                    File.Move(sSettings.sLocalCookedPCPath + "Loading.pkg", sSettings.sModPath + "\\..\\loading\\loading.bak");
                    File.Move(sSettings.sLocalCookedPCPath + "00009368.upk", sSettings.sModPath + "\\..\\loading\\00009368.bak");
                    Sts_Label.Text = "Loading screens disabled.";
                }
                catch
                {
                    MessageBox.Show("Error: Could not disable loading screens!");
                }
            }
            else if (LoadingDisabled == true)
            {
                LoadingDisabled = false;
                try
                {
                    File.Move(sSettings.sModPath + "\\..\\loading\\loading.bak", sSettings.sLocalCookedPCPath + "Loading.pkg");
                    File.Move(sSettings.sModPath + "\\..\\loading\\00009368.bak", sSettings.sLocalCookedPCPath + "00009368.upk");
                    Sts_Label.Text = "Loading screens enabled.";
                }
                catch
                {
                    MessageBox.Show("Error: Could not enable loading screens!");
                }
            }
        }

        private void FomrSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                document = new XmlDocument();
                document.Load(sSettings.XmlSettings);
                node = document.SelectSingleNode("config");
                if (node != null)
                {
                    foreach (XmlNode node2 in node.ChildNodes)
                    {
                        element = (XmlElement)node2;
                        if ((element.GetAttribute("name") == "maxZoom"))
                        {
                            element.SetAttribute("value", txb_zoom.Text);
                        }
                    }
                }
                document.Save(sSettings.XmlSettings);
                str2 = sSettings.XmlSettings;
                stream = new FileStream(str2, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(stream);
                str3 = reader.ReadToEnd().Replace("\"", "'");
                reader.Close();
                stream.Close();
                stream2 = new FileStream(str2, FileMode.Open, FileAccess.Write);
                writer = new StreamWriter(stream2, Encoding.Unicode);
                writer.WriteLine(str3);
                writer.Close();
                stream2.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
