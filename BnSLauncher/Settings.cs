using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace BnS_TwLauncher
{
    public partial class Settings : Form
    {
        //
        string InstallPath = "";
        string DatPath = "";
        string InstallPathRegion = "";
        string NoTextureStreamingBool = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "NoTextureStreaming", "false");
        string UnattendedBool = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Unattended", "false");
        string RegionBool = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Region", "");
        string RegionIDBool = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "RegionID", "");
        string languageIDBool = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "language", "");
        private string UseAllCoresBool = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "UseAllCores", "false");

        string ArchitectureBool = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Architecture", "");

        bool NoTextureStreamingInit = false;
        bool UnattendedInit = false;
        bool PathsFound = false;
        private bool UseAllCoresInit;

        public Settings()
        {
            InitializeComponent();
            var key = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Architecture", null);
            if (key == null)
            {
                // Key does not exist
                MessageBox.Show("Error: Game Architecture not set defalt is x86!!");
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Architecture", "0");
                x86_rB.Checked = true;
            }
        }

        private void FomrSettings_Load(object sender, EventArgs e)
        {
            // Find Client.exe and set file paths
            // Check the registry
            if (RegionBool == "JP")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_JPN", "BaseDir", null);
                InstallPathRegion = "\\contents\\Local\\NCJAPAN\\data\\";
                radioButton_JP.Checked = true;
            }
            else if (RegionBool == "TW")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCTaiwan\TWBNS22", "BaseDir", null);
                InstallPathRegion = "\\contents\\Local\\CHINESES\\data\\";
                radioButton_TW.Checked = true;
            }
            else if (RegionBool == "KR")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR", "BaseDir", null);
                InstallPathRegion = "\\contents\\local\\NCSoft\\data\\";
                radioButton_KR.Checked = true;
            }
            else if (RegionBool == "KR_TEST")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR_TEST", "BaseDir", null);
                InstallPathRegion = "\\contents\\local\\NCSoft\\data\\";
                radioButton_KR.Checked = true;
            }
            else if (RegionBool == "EN")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCWest\BnS", "BaseDir", null);
                InstallPathRegion = "\\contents\\Local\\NCWEST\\data\\";
                radioButton_EN.Checked = true;
            }
            if (InstallPath != null)
            {
                //ModPath = InstallPath + "\\contents\\Local\\NCWEST\\ENGLISH\\CookedPC\\mod";
                //SplashPath = InstallPath + "\\contents\\Local\\NCWEST\\ENGLISH\\Splash\\";
                DatPath = InstallPath + InstallPathRegion;
                PathsFound = true;
            }
            if (PathsFound == true)
            {
                if (NoTextureStreamingBool == "true")
                {
                    cBtextureStr.Checked = true;
                }
                NoTextureStreamingInit = true;
                if (UnattendedBool == "true")
                {
                    cBmsBox.Checked = true;
                }
                UnattendedInit = true;

                if (radioButton_EN.Checked)
                {
                    groupBox_west_lang.Show();
                    Size = new Size(254, 220);
                }
                else
                {
                    groupBox_west_lang.Hide();
                    Size = new Size(254, 178);
                }
                if (UseAllCoresBool == "true")
                {
                    cBallCores.Checked = true;
                }
                UseAllCoresInit = true;
                if (languageIDBool == "English")
                {
                    radioButton_Eng.Checked = true;
                }
                if (languageIDBool == "German")
                {
                    radioButton_Ger.Checked = true;
                }
                if (languageIDBool == "French")
                {
                    radioButton_Fre.Checked = true;
                }
                if (ArchitectureBool == "0")
                {
                    x86_rB.Checked = true;
                    x64_Rb.Checked = false;
                }
                else
                {
                    x86_rB.Checked = false;
                    x64_Rb.Checked = true;
                }
            }
        }

        private void cBtextureStr_CheckedChanged(object sender, EventArgs e)
        {
            if (NoTextureStreamingInit == false)
            {
                return;
            }
            else
            {
                if (NoTextureStreamingBool == "false")
                {
                    NoTextureStreamingBool = "true";
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "NoTextureStreaming", "true", RegistryValueKind.String);
                }
                else
                {
                    NoTextureStreamingBool = "false";
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "NoTextureStreaming", "false", RegistryValueKind.String);
                }
            }
        }

        private void cBmsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UnattendedInit == false)
            {
                return;
            }
            else
            {
                if (UnattendedBool == "false")
                {
                    UnattendedBool = "true";
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Unattended", "true", RegistryValueKind.String);
                }
                else
                {
                    UnattendedBool = "false";
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Unattended", "false", RegistryValueKind.String);
                }
            }
        }

        private void radioButton_JP_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_JP.Checked == true)
            {
                radioButton_TW.Checked = false;
                radioButton_KR.Checked = false;
                radioButton_EN.Checked = false;
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Architecture", "0", RegistryValueKind.String);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Region", "JP", RegistryValueKind.String);
                groupBox_west_lang.Hide();
                Size = new Size(254, 178);
            }
        }

        private void radioButton_TW_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_TW.Checked == true)
            {
                radioButton_JP.Checked = false;
                radioButton_KR.Checked = false;
                radioButton_EN.Checked = false;
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Architecture", "0", RegistryValueKind.String);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Region", "TW", RegistryValueKind.String);
                groupBox_west_lang.Hide();
                Size = new Size(254, 178);
            }
        }

        private void radioButton_KR_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_KR.Checked == true)
            {
                radioButton_JP.Checked = false;
                radioButton_TW.Checked = false;
                radioButton_EN.Checked = false;
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Region", "KR", RegistryValueKind.String);
                groupBox_west_lang.Hide();
                Size = new Size(254, 178);
            }
        }

        private void radioButton_EN_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton_EN.Checked == true)
            {
                radioButton_JP.Checked = false;
                radioButton_TW.Checked = false;
                radioButton_KR.Checked = false;
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Region", "EN", RegistryValueKind.String);
                groupBox_west_lang.Show();
                Size = new Size(254, 220);
            }
        }

        private void checkBox_AllCores_CheckedChanged(object sender, EventArgs e)
        {
            if (!UseAllCoresInit)
                return;
            if (UseAllCoresBool == "false")
            {
                UseAllCoresBool = "true";
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "UseAllCores", "true", RegistryValueKind.String);
            }
            else
            {
                UseAllCoresBool = "false";
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "UseAllCores", "false", RegistryValueKind.String);
            }
        }

        private void radioButton_KR_TEST_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_KR_TEST.Checked == true)
            {
                radioButton_JP.Checked = false;
                radioButton_TW.Checked = false;
                radioButton_EN.Checked = false;
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Region", "KR_TEST", RegistryValueKind.String);
                groupBox_west_lang.Hide();
                Size = new Size(254, 178);
            }
        }

        private void radioButton_Eng_CheckedChanged(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "language", "English", RegistryValueKind.String);
        }

        private void radioButton_Ger_CheckedChanged(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "language", "German", RegistryValueKind.String);
        }

        private void radioButton_Fre_CheckedChanged(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "language", "French", RegistryValueKind.String);
        }

        private void x86_rB_CheckedChanged(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Architecture", "0", RegistryValueKind.String);
        }

        private void x64_Rb_CheckedChanged(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Architecture", "1", RegistryValueKind.String);
        }

    }
}
