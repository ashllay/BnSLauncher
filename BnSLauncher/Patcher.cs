using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.Win32;

namespace BnS_Launcher
{
    public partial class Patcher : Form
    {
        //OpenFileDialog OfileDat = new OpenFileDialog();
        private string BackPath = "Backup\\";
        private string OutPath;
        TextWriter _writer = null;

        string InstallPath = "";
        string DatPath = "";
        string InstallPathRegion = "";
        string ConfigFileName = "";
        string ConfigFilePath = "";

        string RegionBool = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Region", "");
        string ArchitectureBool = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EDW_Works\BnS", "Architecture", "");

        public Patcher()
        {
            InitializeComponent();
        }

        private void Tools_Load(object sender, EventArgs e)
        {
            _writer = new StreamWriter(richOut);
            Console.SetOut(_writer);
            // Find Client.exe and set file paths
            // Check the registry
            if (RegionBool == "JP")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_JPN", "BaseDir", null);
                InstallPathRegion = "\\contents\\Local\\NCJAPAN\\data\\";
            }
            else if (RegionBool == "TW")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCTaiwan\TWBNS22", "BaseDir", null);
                InstallPathRegion = "\\contents\\Local\\CHINESES\\data\\";
            }
            else if (RegionBool == "KR")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR", "BaseDir", null);
                InstallPathRegion = "\\contents\\local\\NCSoft\\data\\";
            }
            else if (RegionBool == "KR_TEST")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR_TEST", "BaseDir", null);
                InstallPathRegion = "\\contents\\local\\NCSoft\\data\\";
            }
            else if (RegionBool == "EN")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCWest\BnS", "BaseDir", null);
                InstallPathRegion = "\\contents\\Local\\NCWEST\\data\\";
            }
            if (InstallPath != null)
            {
                DatPath = InstallPath + InstallPathRegion;
            }

            if (ArchitectureBool == "0")
            {
                ConfigFileName = "config.dat";
            }
            else
            {
                ConfigFileName = "config64.dat";
            }

            ConfigFilePath = DatPath + ConfigFileName;
            OutPath = ConfigFilePath + ".files"; //get full file path and add .files

        }


        private void button_start_Click(object sender, EventArgs e)
        {
            //get current date and time
            string date = DateTime.Now.ToString("dd-MM-yy_"); // includes leading zeros
            string time = DateTime.Now.ToString("hh.mm.ss"); // includes leading zeros
            ControlBox = false;
            if (checkBox_Bak.Checked == true)
            {
                var BackDir = DatPath + BackPath;  // folder location

                if (!Directory.Exists(BackDir))  // if it doesn't exist, create
                    Directory.CreateDirectory(BackDir);
                //Create a new subfolder under the current active folder
                string newPath = Path.Combine(BackDir, date + time);

                // Create the subfolder
                Directory.CreateDirectory(newPath);
                // Copy file to backup folder
                var CurrBackPath = newPath + "\\";

                File.Copy(DatPath + ConfigFileName, CurrBackPath + ConfigFileName, true);
            }
            Console.Write("");
            Console.Write("Patching: Wait until patch finish!\r\n");

            BNSDat.BNSDat.Extract(ConfigFilePath, ConfigFilePath.EndsWith("64.dat"));
            patchConfig();


        }
        private void patchConfig()
        {
            //patch config2
            Console.Write("Patching system.config2.xml");
            try
            {
                //patch only what is selected
                string configFile = File.ReadAllText(OutPath + "\\system.config2.xml");
                if (checkBox_Webl.Checked == true)
                {
                    configFile = configFile.Replace("\"use-web-launching\" value=\"true\"", "\"use-web-launching\" value=\"false\"");
                }
                else
                {
                    configFile = configFile.Replace("\"use-web-launching\" value=\"false\"", "\"use-web-launching\" value=\"true\"");
                }
                if (checkBox_minimize.Checked == true)
                {
                    configFile = configFile.Replace("\"minimize-window\" value=\"true\"", "\"minimize-window\" value=\"false\"");
                }
                else
                {
                    configFile = configFile.Replace("\"minimize-window\" value=\"false\"", "\"minimize-window\" value=\"true\"");
                }
                if (checkBox_clause.Checked == true)
                {
                    configFile = configFile.Replace("\"show-clause\" value=\"true\"", "\"show-clause\" value=\"false\"");
                }
                else
                {
                    configFile = configFile.Replace("\"show-clause\" value=\"false\"", "\"show-clause\" value=\"true\"");
                }
                File.WriteAllText(OutPath + "\\system.config2.xml", configFile);
            }

            catch
            {
                Console.Write("Error: Failed to patch system.config2.xml\r\n");
                return;
            }
            Console.Write("Patched system.config2.xml\r\n");
            compileDat();

        }
        private void compileDat()
        {
            Console.Write("Compiling .dat file\r\n");
            try
            {
                BNSDat.BNSDat.Compress(OutPath, OutPath.Contains("64.dat"));
            }
            catch
            {
                Console.Write("Error: Failed to apply patch!\r\n");
                return;
            }
            if (File.Exists(OutPath))
            {
                File.Delete(OutPath);
            }
            MessageBox.Show("Patch Finished now you can close the window", "Patch.");
            ControlBox = true;
        }
    }
}
