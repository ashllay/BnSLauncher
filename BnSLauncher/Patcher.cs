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
using Ini;

namespace BnS_Launcher
{
    public partial class Patcher : Form
    {
        //OpenFileDialog OfileDat = new OpenFileDialog();
        private string BackPath = "Backup\\";
        private string ConfigOutPath;
        private string XmlOutPath;
        TextWriter _writer = null;

        string InstallPath = "";
        string DatPath = "";
        string InstallPathRegion = "";
        string ConfigFileName = "";
        string ConfigFilePath = "";
        string XmlFileName = "";
        string XmlFilePath = "";

        string pRegion = "";
        string pArchitecture = "";

        public BackgroundWorker ebnsdat;
        public BackgroundWorker cbnsdat;
        public bool PatchConfig;
        public bool PatchXml;

        IniFile pSettings = new IniFile(Environment.CurrentDirectory + "\\Settings.ini");

        public Patcher()
        {
            InitializeComponent();
        }

        private void Patcher_Load(object sender, EventArgs e)
        {
            string stRegion = "";
            string stArchitecture = "";

            pArchitecture = pSettings.IniReadValue("Settings", "Architecture");
            pRegion = pSettings.IniReadValue("Settings", "Region");

            _writer = new StreamWriter(richOut);
            Console.SetOut(_writer);

            // Find and set file paths
            // Check the registry
            if (pRegion == "JP")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_JPN", "BaseDir", null);
                InstallPathRegion = "\\contents\\Local\\NCJAPAN\\data\\";
                stRegion = "Japan";
            }
            else if (pRegion == "TW")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCTaiwan\TWBNS22", "BaseDir", null);
                InstallPathRegion = "\\contents\\Local\\NCTAIWAN\\data\\";
                stRegion = "Taiwan";
            }
            else if (pRegion == "KR")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR", "BaseDir", null);
                InstallPathRegion = "\\contents\\local\\NCSoft\\data\\";
                stRegion = "Korean";
            }
            else if (pRegion == "KR_TEST")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR_TEST", "BaseDir", null);
                InstallPathRegion = "\\contents\\local\\NCSoft\\data\\";
                stRegion = "Korean TEST";
            }
            else if (pRegion == "EN")
            {
                InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCWest\BnS", "BaseDir", null);
                InstallPathRegion = "\\contents\\Local\\NCWEST\\data\\";
                checkBox_Webl.Enabled = false;
                stRegion = "West";
            }
            if (InstallPath != null)
            {
                DatPath = InstallPath + InstallPathRegion;
            }

            if (pArchitecture == "0")
            {
                ConfigFileName = "config.dat";
                XmlFileName = "xml.dat";
                stArchitecture = "x86";
            }
            else
            {
                ConfigFileName = "config64.dat";
                XmlFileName = "xml64.dat";
                stArchitecture = "x64";
            }

            string strLabelID = String.Format("Detected Region: {0} and Architecture: {1} in Settings.", stRegion, stArchitecture);
            label1.Text = strLabelID;

            ConfigFilePath = DatPath + ConfigFileName;
            XmlFilePath = DatPath + XmlFileName;

            ConfigOutPath = ConfigFilePath + ".files"; //get full file path and add .files
            XmlOutPath = XmlFilePath + ".files";
           // Console.Write("{0}\n{1}", ConfigFilePath, XmlFilePath);
        }

        public void Extractor(string datFile)
        {
            if (datFile == null)
                return;
            cbnsdat = new BackgroundWorker();
            cbnsdat.WorkerSupportsCancellation = true;
            cbnsdat.WorkerReportsProgress = true;
            cbnsdat.DoWork += datextract_DoWork;
            cbnsdat.RunWorkerAsync();
        }

        private void datextract_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (PatchConfig == true)
            {
                Console.Write("Extracting: {0}\n", ConfigFileName);
                BNSDat.BNSDat.Extract(ConfigFilePath, ConfigFilePath.EndsWith("64.dat"));
            }

            if (PatchXml == true)
            {
                Console.Write("Extracting: {0}\n", XmlFileName);
                BNSDat.BNSDat.Extract(XmlFilePath, XmlFilePath.EndsWith("64.dat"));
            }
            GC.Collect();
            patchConfig();
        }

        
        private void button_start_Click(object sender, EventArgs e)
        {

            ControlBox = false;
            var resultconfig = MessageBox.Show(@"Do you want to patch Config.dat?", "Warning!!", MessageBoxButtons.YesNoCancel);
            switch (resultconfig)
            {
                case DialogResult.Yes:
                    PatchConfig = true;
                    break;
                case DialogResult.No:
                    PatchConfig = false;
                    break;
                default:
                    break;
            }
            var resultxml = MessageBox.Show(@"xml.dat unpack/repack process may take a longer time do you really want to continue?", "Warning!!", MessageBoxButtons.YesNoCancel);
            switch (resultxml)
            {
                case DialogResult.Yes:
                    PatchXml = true;
                    break;
                case DialogResult.No:
                    PatchXml = false;
                    break;
                default:
                    break;
            }
            //Console.Write("Patching: Wait until patch finish!\n");
            BakcUpManager();

        }
        private void BakcUpManager()
        {
            cbnsdat = new BackgroundWorker();
            cbnsdat.WorkerSupportsCancellation = true;
            cbnsdat.WorkerReportsProgress = true;
            cbnsdat.DoWork += dobakcup_DoWork;
            cbnsdat.RunWorkerAsync();
        }
        public void dobakcup_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            //get current date and time
            string date = DateTime.Now.ToString("dd-MM-yy_"); // includes leading zeros
            string time = DateTime.Now.ToString("hh.mm.ss"); // includes leading zeros
            if (cbox_BakConfig.Checked == true)
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

            if (cbox_BakXml.Checked == true)
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

                File.Copy(DatPath + XmlFileName, CurrBackPath + XmlFileName, true);
            }
            GC.Collect();
            if (PatchConfig == true)
                Extractor(ConfigFilePath);

            if (PatchXml == true)
                Extractor(XmlFilePath);
        }
        private void patchConfig()
        {
            //patch config2
            
            try
            {
                //patch only what is selected
                if (PatchConfig == true)
                {
                    Console.Write("\r\nPatching system.config2.xml\n");
                    string configFile = File.ReadAllText(ConfigOutPath + "\\system.config2.xml");
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
                    File.WriteAllText(ConfigOutPath + "\\system.config2.xml", configFile);
                }
                if (PatchXml == true)
                {
                    Console.Write("\r\nPatching client.config2.xml\n");
                    string xmlFile = File.ReadAllText(XmlOutPath + "\\client.config2.xml");
                    if (cboxDPS.Checked == true)
                    {
                        xmlFile = xmlFile.Replace("\"show-party-6-dungeon-and-cave\" value=\"n\"", "\"show-party-6-dungeon-and-cave\" value=\"y\"");
                    }
                    else
                    {
                        xmlFile = xmlFile.Replace("\"show-party-6-dungeon-and-cave\" value=\"y\"", "\"show-party-6-dungeon-and-cave\" value=\"n\"");
                    }
                    File.WriteAllText(XmlOutPath + "\\client.config2.xml", xmlFile);
                }
            }

            catch
            {
                Console.Write("Error: Failed to patch xml file\r\n");
                return;
            }
            Console.Write("Patch xml file(s) done!\r\n");
            compileDat();

        }
        public void Compiler(string repackPath)
        {
            if (repackPath == null)
                return;
            ebnsdat = new BackgroundWorker();
            ebnsdat.WorkerSupportsCancellation = true;
            ebnsdat.WorkerReportsProgress = true;
            ebnsdat.DoWork += new DoWorkEventHandler(datcompress_DoWork);
            ebnsdat.RunWorkerAsync();
        }

        private void datcompress_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            if (PatchConfig == true)
            {
                Console.Write("Repacking: {0}\n", ConfigFileName);
                BNSDat.BNSDat.Compress(ConfigOutPath, ConfigOutPath.Contains("64.dat"));
            }

            if (PatchXml == true)
            {
                Console.Write("Repacking: {0}\n", XmlFileName);
                BNSDat.BNSDat.Compress(XmlOutPath, XmlOutPath.Contains("64.dat"));
            }
            //Console.Write("Done!!\n");
            GC.Collect();
            MessageBox.Show("Patch Finished now you can close the window", "Patch.");
            ControlBox = true;
        }
        private void compileDat()
        {
            Console.Write("Compiling .dat file(s).\n");
            try
            {
                if (PatchConfig == true)
                    Compiler(ConfigOutPath);

                if (PatchXml == true)
                    Compiler(XmlOutPath);
            }
            catch
            {
                Console.Write("Error: Failed to apply patch!\r\n");
                return;
            }
        }
    }
}
