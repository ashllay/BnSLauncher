using System;
using System.Windows.Forms;
using System.IO;
using Ini;
using System.Xml;
using System.Text;
using Microsoft.Win32;

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

        //string KorPath = "";
        //string KorTestPath = "";
        //string WstPath = "";
        //string JpnPath = "";
        //string TwnPath = "";

        string sRegion = "";
        string sServerType = "";
        string sArchteture = "";
        string sLanguage = "";

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
            }
            if (string.IsNullOrEmpty(sSettings.sArchitecture))
            {
                fSettings.IniWriteValue("Settings", "ServerType", "Live");
            }
        }

        private void FomrSettings_Load(object sender, EventArgs e)
        {

            //populate region combox
            if (sSettings.gKorPath == true || sSettings.gKorTestPath == true)
                cbox_Region.Items.AddRange(new object[] { "Korean" });
            if (sSettings.gWstPath == true)
                cbox_Region.Items.AddRange(new object[] { "West (NA-EU)" });
            if (sSettings.gTwnPath == true)
                cbox_Region.Items.AddRange(new object[] { "Taiwan" });
            if (sSettings.gJpnPath == true)
                cbox_Region.Items.AddRange(new object[] { "Japan" });
           
            // Find Client.exe and set file paths
            // Check the registry

            if (sSettings.sInstallPath != null)
                PathsFound = true;
            //--
            gbox_krserver.Hide();
            groupBox_west_lang.Hide();

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
                switch (sSettings.sRegion)
                {
                    //
                    case "KR":
                        cbox_Region.SelectedItem = "Korean";
                        if (sSettings.gKorTestPath == true)
                            gbox_krserver.Show();
                        break;
                    case "EN":
                        cbox_Region.SelectedItem = "West (NA-EU)";
                        groupBox_west_lang.Show();
                        break;
                    case "TW":
                        cbox_Region.SelectedItem = "Taiwan";
                        break;
                    case "JP":
                        cbox_Region.SelectedItem = "Japan";
                        break;
                    default:
                        break;
                }

                if (sSettings.sArchitecture == "0")
                    cbox_Arch.SelectedItem = "x86";
                else
                    cbox_Arch.SelectedItem = "x64";

                if (sSettings.sServerType == "Live")
                    cbox_KorServer.SelectedItem = "Live";
                else if (sSettings.sServerType == "Test")
                    cbox_KorServer.SelectedItem = "Test";

                switch (sSettings.sLanguageID)
                {
                    //
                    case "English":
                        cbox_west_lang.SelectedItem = "English";
                        break;
                    case "German":
                        cbox_west_lang.SelectedItem = "German";
                        break;
                    case "French":
                        cbox_west_lang.SelectedItem = "French";
                        break;
                    default:
                        break;
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
            catch// (Exception exception)
            {
                //MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch// (Exception exception)
            {
                //MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbox_Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbox_Region.SelectedItem.ToString())
            {
                //
                case "Korean":
                    sRegion = "KR";
                    break;
                case "West (NA-EU)":
                    sRegion = "EN";
                    break;
                case "Taiwan":
                    sRegion = "TW";
                    break;
                case "Japan":
                    sRegion = "JP";
                    break;
                default:
                    break;
            }

            if (cbox_Region.SelectedItem.ToString() == "West (NA-EU)")
                groupBox_west_lang.Show();
            else
                groupBox_west_lang.Hide();

            if (cbox_Region.SelectedItem.ToString() == "Korean" && sSettings.gKorTestPath == true)
                gbox_krserver.Show();
            else
                gbox_krserver.Hide();

            fSettings.IniWriteValue("Settings", "Region", sRegion);
        }

        private void cbox_Arch_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbox_Arch.SelectedItem.ToString())
            {
                //
                case "x86":
                    sArchteture = "0";
                    break;
                case "x64":
                    sArchteture = "1";
                    break;
                default:
                    break;
            }
            fSettings.IniWriteValue("Settings", "Architecture", sArchteture);
        }

        private void cbox_KorServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbox_KorServer.SelectedItem.ToString())
            {
                //
                case "Live":
                    sServerType = "Live";
                    break;
                case "Test":
                    sServerType = "Test";
                    break;
                default:
                    break;
            }
            fSettings.IniWriteValue("Settings", "ServerType", sServerType);
        }

        private void cbox_west_lang_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbox_west_lang.SelectedItem.ToString())
            {
                //
                case "English":
                    sLanguage = "English";
                    break;
                case "German":
                    sLanguage = "German";
                    break;
                case "French":
                    sLanguage = "French";
                    break;
                default:
                    break;
            }
            fSettings.IniWriteValue("Settings", "language", sLanguage);
            
        }
    }
}
