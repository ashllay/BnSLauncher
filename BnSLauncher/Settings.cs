using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Xml.Linq;
using Ini;
using System.Xml;
using System.Text;

namespace BnS_TwLauncher
{
    public partial class Settings : Form
    {
        //
        string InstallPath = "";
        string InstallPathRegion = "";
        string ModPath = "";
        string LocalCookedPCPath = "";
        string sNoTextureStreaming = "";
        string sUnattended = "";
        public string sRegion = "";
        string slanguageID = "";
        string sUseAllCores = "";
        string sArchitecture = "";
        string sServerType = "";

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
        string XmlSettings = "";

        IniFile fSettings = new IniFile(Environment.CurrentDirectory + "\\Settings.ini");

        public Settings()
        {
            InitializeComponent();
            sNoTextureStreaming = fSettings.IniReadValue("Settings", "NoTextureStreaming");
            sUnattended = fSettings.IniReadValue("Settings", "Unattended");
            sRegion = fSettings.IniReadValue("Settings", "Region");
            slanguageID = fSettings.IniReadValue("Settings", "language");
            sUseAllCores = fSettings.IniReadValue("Settings", "UseAllCores");
            sArchitecture = fSettings.IniReadValue("Settings", "Architecture");
            sServerType = fSettings.IniReadValue("Settings", "ServerType");

            if (string.IsNullOrEmpty(sArchitecture))
            {
                fSettings.IniWriteValue("Settings", "Architecture", "0");
                x86_rB.Checked = true;
            }
        }

        private void FomrSettings_Load(object sender, EventArgs e)
        {
            // Find Client.exe and set file paths
            // Check the registry
            if (sRegion == "JP")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_JPN", "BaseDir", null);
                InstallPathRegion = @"contents\Local\NCJAPAN\";
                LocalCookedPCPath = Path.Combine(InstallPath, InstallPathRegion, @"JAPANESE\CookedPC\");
                ModPath = Path.Combine(LocalCookedPCPath + @"mod\");
                rB_JP.Checked = true;
                XmlSettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCJAPAN\ClientConfiguration.xml";
            }
            else if (sRegion == "TW")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCTaiwan\TWBNS22", "BaseDir", null);
                InstallPathRegion = @"contents\Local\NCTAIWAN\";
                LocalCookedPCPath = Path.Combine(InstallPathRegion, @"CHINESET\CookedPC\");
                ModPath = Path.Combine(LocalCookedPCPath, @"mod\");
                rB_TW.Checked = true;
                XmlSettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCTAIWAN\ClientConfiguration.xml";
            }
            else if (sRegion == "EN")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCWest\BnS", "BaseDir", null);
                InstallPathRegion = @"contents\Local\NCWEST\";
                LocalCookedPCPath = Path.Combine(InstallPath, InstallPathRegion, @"ENGLISH\CookedPC\");
                ModPath = Path.Combine(LocalCookedPCPath, @"mod\");
                rB_EN.Checked = true;
                XmlSettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCWEST\ClientConfiguration.xml";
            }
            else if (sRegion == "KR")
            {
                rB_KR.Checked = true;

                if (sServerType == "Live")
                {
                    InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR", "BaseDir", null);
                    InstallPathRegion = @"contents\local\NCSoft\";
                    ModPath = Path.Combine(InstallPath, InstallPathRegion, @"korean\CookedPC\mod\");
                    LocalCookedPCPath = Path.Combine(InstallPath, @"contents\bns\CookedPC\");
                    rB_KRLive.Checked = true;
                    XmlSettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCSOFT\ClientConfiguration.xml";
                }
                else if (sServerType == "Test")
                {
                    InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR_TEST", "BaseDir", null);
                    InstallPathRegion = @"contents\local\NCSoft\";
                    ModPath = Path.Combine(LocalCookedPCPath, InstallPathRegion, @"korean\CookedPC\mod\");
                    LocalCookedPCPath = Path.Combine(InstallPath, @"contents\bns\CookedPC\");
                    rB_KRTest.Checked = true;
                    XmlSettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCSOFT_TEST\ClientConfiguration.xml";
                }
            }
            if (InstallPath != null)
            {
                PathsFound = true;
                // dbg_txb.Text = ModPath;
            }
            if (PathsFound == true)
            {
                //--
                if (!Directory.Exists(ModPath + "\\..\\loading"))
                    Directory.CreateDirectory(ModPath + "\\..\\loading");
                
                if (File.Exists(ModPath + "\\..\\loading\\00009368.bak"))
                {
                    LoadingDisabled = true;
                    cbx_disableImg.Checked = true;
                }

                //--
                if (sNoTextureStreaming == "true")
                    cBtextureStr.Checked = true;

                if (sUnattended == "true")
                    cBmsBox.Checked = true;

                if (sUseAllCores == "true")
                    cBallCores.Checked = true;

                //--
                if (slanguageID == "English")
                    radioButton_Eng.Checked = true;

                if (slanguageID == "German")
                    radioButton_Ger.Checked = true;

                if (slanguageID == "French")
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
                if (sArchitecture == "0")
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
                document.Load(XmlSettings);
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
                sNoTextureStreaming = "true";
                fSettings.IniWriteValue("Settings", "NoTextureStreaming", "true");
                Sts_Label.Text = "Texture streaming disabled.";
            }
            else
            {
                sNoTextureStreaming = "false";
                fSettings.IniWriteValue("Settings", "NoTextureStreaming", "false");
                Sts_Label.Text = "Texture streaming enabled.";
            }
        }

        private void cBmsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cBmsBox.Checked == true)
            {
                sUnattended = "true";
                fSettings.IniWriteValue("Settings", "Unattended", "true");
                Sts_Label.Text = "Message boxes disabled.";
            }
            else
            {
                sUnattended = "false";
                fSettings.IniWriteValue("Settings", "Unattended", "false");
                Sts_Label.Text = "Message boxes enabled.";
            }
        }

        private void checkBox_AllCores_CheckedChanged(object sender, EventArgs e)
        {
            if (cBallCores.Checked == true)
            {
                sUseAllCores = "true";
                fSettings.IniWriteValue("Settings", "UseAllCores", "true");
                Sts_Label.Text = "Use all cores enabled.";
            }
            else
            {
                sUseAllCores = "false";
                fSettings.IniWriteValue("Settings", "UseAllCores", "false");
                Sts_Label.Text = "Use all cores disabled.";
            }
        }
        private void rB_JP_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_JP.Checked == true)
            {
                sRegion = "JP";
                fSettings.IniWriteValue("Settings", "Region", "JP");
                groupBox_west_lang.Hide();
                gbox_krserver.Hide();
            }
        }

        private void rB_TW_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_TW.Checked == true)
            {
                sRegion = "TW";
                fSettings.IniWriteValue("Settings", "Region", "TW");
                groupBox_west_lang.Hide();
                gbox_krserver.Hide();
            }
        }

        private void rB_KR_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_KR.Checked == true)
            {
                if (sServerType == "Live")
                    rB_KRLive.Checked = true;
                if (sServerType == "Test")
                    rB_KRTest.Checked = true;

                sRegion = "KR";

                gbox_krserver.Show();
                groupBox_west_lang.Hide();

                fSettings.IniWriteValue("Settings", "Region", "KR");
            }
        }

        private void rB_KRLive_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_KRLive.Checked == true)
            {
                sServerType = "Live";
                rB_KRTest.Checked = false;
                fSettings.IniWriteValue("Settings", "ServerType", "Live");
            }
        }
        private void rB_KRTest_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_KRTest.Checked == true)
            {
                sServerType = "Test";
                rB_KRLive.Checked = false;
                fSettings.IniWriteValue("Settings", "ServerType", "Test");
            }
        }

        private void rB_EN_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_EN.Checked == true)
            {
                sRegion = "EN";
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
                    File.Move(LocalCookedPCPath + "Loading.pkg", ModPath + "\\..\\loading\\loading.bak");
                    File.Move(LocalCookedPCPath + "00009368.upk", ModPath + "\\..\\loading\\00009368.bak");
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
                    File.Move(ModPath + "\\..\\loading\\loading.bak", LocalCookedPCPath + "Loading.pkg");
                    File.Move(ModPath + "\\..\\loading\\00009368.bak", LocalCookedPCPath + "00009368.upk");
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
                document.Load(XmlSettings);
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
                document.Save(XmlSettings);
                str2 = XmlSettings;
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
