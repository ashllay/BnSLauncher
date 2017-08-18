using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using BnS_Launcher.lib;
using System.Xml;

namespace BnS_Launcher
{
    public partial class Patcher : Form
    {
        private string BackPath = "Backup\\";
        private string ConfigOutPath;
        private string XmlOutPath;
        TextWriter _writer = null;

        string DatPath = "";
        string ConfigFileName = "";
        string ConfigFilePath = "";
        string XmlFileName = "";
        string XmlFilePath = "";

        public BackgroundWorker ebnsdat;
        public BackgroundWorker cbnsdat;
        public bool PatchConfig, PatchXml, BackConfig, BackXml;

        SettingsClass sSettings = new SettingsClass();

        string strlb_info, str_extract, str_repackerror, str_patching, str_patcherror, str_pathdone, str_repack, str_patchdone, str_compiledat, str_errordat;

        private BslI18NLoader _i18N;

        public Patcher()
        {
            InitializeComponent();
            InitI18N();
        }

        private void Patcher_Load(object sender, EventArgs e)
        {
            string stRegion = "";
            string stArchitecture = "";

            _writer = new StrWriter(richOut);
            Console.SetOut(_writer);

            // Find and set file paths
            // Check the registry

            switch (sSettings.sRegion)
            {
                case "JP":
                    stRegion = "Japan";
                    break;
                case "TW":
                    stRegion = "Taiwan";
                    break;
                case "EN":
                    cbox_webl.Enabled = false;
                    stRegion = "West";
                    break;
                case "KR":
                    cbox_webl.Enabled = false;
                    if (sSettings.sServerType == "Live")
                        stRegion = "Korean";
                    else if (sSettings.sServerType == "Test")
                        stRegion = "Korean TEST";
                    break;
                default:
                    break;
            }

            if (sSettings.sInstallPath != null)
                DatPath = Path.Combine(sSettings.sInstallPath, sSettings.sInstallPathRegion, @"data\");

            if (sSettings.sArchitecture == "0")
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

            string strLabelID = String.Format(strlb_info, stRegion, stArchitecture);
            lb_info.Text = strLabelID;
            cbox_cconfig.Text = ConfigFileName;
            cbox_cxml.Text = XmlFileName;
            ConfigFilePath = Path.Combine(DatPath, ConfigFileName);
            XmlFilePath = Path.Combine(DatPath, XmlFileName);

            ConfigOutPath = ConfigFilePath + ".files"; //get full file path and add .files
            XmlOutPath = XmlFilePath + ".files";
            // Console.Write("{0}", DatPath);
        }
        private void InitI18N()
        {
            _i18N = BslI18NLoader.Instance;
            //FormTitle
            Text = _i18N.LoadI18NValue("Patcher", "title");
            //buttons
            btn_start.Text = _i18N.LoadI18NValue("Patcher", "btn_start");
            //labels
            lb_outlog.Text = _i18N.LoadI18NValue("Patcher", "lb_outlog");
            //strings
            strlb_info = _i18N.LoadI18NValue("Patcher", "strlb_info");
            str_extract = _i18N.LoadI18NValue("Patcher", "str_extract");
            str_repackerror = _i18N.LoadI18NValue("Patcher", "str_repackerror");
            str_patching = _i18N.LoadI18NValue("Patcher", "str_patching");
            str_patcherror = _i18N.LoadI18NValue("Patcher", "str_patcherror");
            str_pathdone = _i18N.LoadI18NValue("Patcher", "str_pathdone");
            str_repack = _i18N.LoadI18NValue("Patcher", "str_repack");
            str_patchdone = _i18N.LoadI18NValue("Patcher", "str_patchdone");
            str_compiledat = _i18N.LoadI18NValue("Patcher", "str_compiledat");
            str_errordat = _i18N.LoadI18NValue("Patcher", "str_errordat");
            //groupboxes
            gbox_repackf.Text = _i18N.LoadI18NValue("Patcher", "gbox_repackf");
            //checkboxes
            cbox_webl.Text = _i18N.LoadI18NValue("Patcher", "cbox_webl");
            cbox_clause.Text = _i18N.LoadI18NValue("Patcher", "cbox_clause");
            cbox_minimize.Text = _i18N.LoadI18NValue("Patcher", "cbox_minimize");
            cbox_back.Text = _i18N.LoadI18NValue("Patcher", "cbox_back");

            cbox_dpssix.Text = _i18N.LoadI18NValue("Patcher", "cbox_dps");
            cbox_perfmod.Text = _i18N.LoadI18NValue("Patcher", "cbox_perfmod");
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
                Console.Write(str_extract, ConfigFileName);
                BNSDat.BNSDat.Extract(ConfigFilePath, ConfigFilePath.EndsWith("64.dat"));
            }

            if (PatchXml == true)
            {
                Console.Write(str_errordat, XmlFileName);
                BNSDat.BNSDat.Extract(XmlFilePath, XmlFilePath.EndsWith("64.dat"));
            }
            GC.Collect();
            XmlWrite();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            gbox_patcher.Enabled = false;

            if (!cbox_cconfig.Checked && !cbox_cxml.Checked)
            {
                MessageBox.Show(str_repackerror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gbox_patcher.Enabled = true;
            }

            if (cbox_cconfig.Checked == true)
            {
                PatchConfig = true;
                if (cbox_back.Checked ==true)
                    BackConfig = true;
            }
            else
            {
                PatchConfig = false;
                BackConfig = false;
            }

            if (cbox_cxml.Checked == true)
            {
                PatchXml = true;
                if (cbox_back.Checked == true)
                    BackXml = true;
            }
            else
            {
                PatchXml = false;
                BackXml = false;
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
            if (BackConfig == true)
            {
                var BackDir = Path.Combine(DatPath, BackPath);  // folder location

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

            if (BackXml == true)
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
       
        void XmlWrite()
        {            
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;//  
                if (PatchConfig == true)
                {
                    Console.Write(str_patching + "system.config2.xml\n");
                    XmlReader creader = XmlReader.Create(ConfigOutPath + "\\system.config2.xml", settings);
                    xmlDoc.Load(creader);

                    XmlNodeList nodeList = xmlDoc.SelectSingleNode("config").ChildNodes;//

                    foreach (XmlNode xn in nodeList)// 
                    {
                        XmlElement xe = (XmlElement)xn;//

                        if (xe.GetAttribute("name") == "use-web-launching")// 
                        {
                            try
                            {
                                if (cbox_webl.Checked == true) { xe.SetAttribute("value", "false"); }  //
                                else { xe.SetAttribute("value", "true"); }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString());
                            }
                        }

                        if (xe.GetAttribute("name") == "minimize-window")// 
                        {
                            try
                            {
                                if (cbox_minimize.Checked == true) { xe.SetAttribute("value", "false"); }  //
                                else { xe.SetAttribute("value", "true"); }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString());
                            }
                        }

                        if (xe.GetAttribute("name") == "show-clause")// 
                        {
                            try
                            {
                                if (cbox_minimize.Checked == true) { xe.SetAttribute("value", "false"); }  //
                                else { xe.SetAttribute("value", "true"); }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString());
                            }
                        }

                        if (xe.GetAttribute("name") == "use-auto-bias-global-cool-time")// 
                        {
                            try
                            {
                                if (cbox_webl.Checked == true) { xe.SetAttribute("value", "false"); }  //
                                else { xe.SetAttribute("value", "true"); }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString());
                            }
                        }

                        if (xe.GetAttribute("name") == "use-nagle")// 
                        {
                            try
                            {
                                if (cbox_nagle.Checked == true) { xe.SetAttribute("value", "false"); }  //
                                else { xe.SetAttribute("value", "true"); }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString());
                            }
                        }

                        if (xe.GetAttribute("name") == "use-nagle-arena")// 
                        {
                            try
                            {
                                if (cbox_naglearena.Checked == true) { xe.SetAttribute("value", "true"); }  //
                                else { xe.SetAttribute("value", "false"); }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString());
                            }
                        }
                    }//foreach 
                    creader.Close();
                    xmlDoc.Save(ConfigOutPath + "\\system.config2.xml");
                }

                /*  client.config2.xml */
                if (PatchXml == true)
                {
                    Console.Write(str_patching + "client.config2.xml\n");
                    XmlReader xreader = XmlReader.Create(XmlOutPath + "\\client.config2.xml", settings);
                    xmlDoc.Load(xreader);

                    XmlNodeList nodeList = xmlDoc.SelectSingleNode("config").ChildNodes;//

                    foreach (XmlNode xn in nodeList)// 
                    {
                        XmlElement xe = (XmlElement)xn;//

                        if (xe.GetAttribute("name") == "latency")// 
                        {
                            XmlNodeList nls = xe.ChildNodes;//
                            foreach (XmlNode xn1 in nls)//
                            {
                                XmlElement xe2 = (XmlElement)xn1;// 

                                if (xe2.GetAttribute("name") == "fast-msec")// 
                                {
                                    try
                                    {
                                        xe2.SetAttribute("value", txbFastmsec.Text);
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }

                                if (xe2.GetAttribute("name") == "mid-msec")// 
                                {
                                    try
                                    {
                                        xe2.SetAttribute("value", txbMidmsec.Text);
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                            }
                        }//latency

                        #region DPS
                        if (xe.GetAttribute("name") == "damage-meter")//
                        {
                            XmlNodeList nls = xe.ChildNodes;// 
                            foreach (XmlNode xn1 in nls)// 
                            {
                                XmlElement xe2 = (XmlElement)xn1;// 
                                if (xe2.GetAttribute("name") == "show-public-zone")// 
                                {
                                    try
                                    {
                                        if (cbox_dpspub.Checked == true) { xe2.SetAttribute("value", "y"); }  //
                                        else { xe2.SetAttribute("value", "n"); }
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                                if (xe2.GetAttribute("name") == "show-party-6-dungeon-and-cave")// 
                                {
                                    try
                                    {
                                        if (cbox_dpssix.Checked == true) { xe2.SetAttribute("value", "y"); }  //
                                        else { xe2.SetAttribute("value", "n"); }
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                                if (xe2.GetAttribute("name") == "show-field-zone")// 
                                {
                                    try
                                    {
                                        if (cbox_dpsfield.Checked == true) { xe2.SetAttribute("value", "y"); }  //
                                        else { xe2.SetAttribute("value", "n"); }
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                                if (xe2.GetAttribute("name") == "show-faction-battle-field-zone")// 
                                {
                                    try
                                    {
                                        if (cbox_dpsfac.Checked == true) { xe2.SetAttribute("value", "y"); }  //
                                        else { xe2.SetAttribute("value", "n"); }
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                            }

                        }//DPS meter

                        if(cbox_Cgct.Checked == true)
                        if (xe.GetAttribute("name") == "skill")// 
                        {
                            XmlNodeList nls = xe.ChildNodes;//
                            foreach (XmlNode xn1 in nls)//
                            {
                                XmlElement xe2 = (XmlElement)xn1;// 

                                if (xe2.GetAttribute("name") == "skill-global-cool-latency-time")// 
                                {
                                    try
                                    {
                                        xe2.SetAttribute("value", txb_cgct.Text);
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                            }
                        }//skill

                        if (xe.GetAttribute("name") == "option")
                        {
                            XmlNodeList nls = xe.ChildNodes;// 
                            foreach (XmlNode xn1 in nls)// 
                            {
                                XmlElement xe2 = (XmlElement)xn1;// 
                                if (xe2.GetAttribute("name") == "use-optimal-performance-mode-option")// 
                                {
                                    try
                                    {
                                        if (cbox_perfmod.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                        else { xe2.SetAttribute("value", "false"); }
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                            }
                        }//option

                        if (xe.GetAttribute("name") == "input")
                        {
                            XmlNodeList nls = xe.ChildNodes;// 
                            foreach (XmlNode xn1 in nls)// 
                            {
                                XmlElement xe2 = (XmlElement)xn1;// 
                                if (xe2.GetAttribute("name") == "pending-time")// 
                                {
                                    try
                                    {
                                        xe2.SetAttribute("value", txb_mpresstime.Text);
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                                if (xe2.GetAttribute("name") == "pending-key-tick-time")// 
                                {
                                    try
                                    {
                                        xe2.SetAttribute("value", txb_ptick.Text);
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                                if (xe2.GetAttribute("name") == "pressed-key-tick-time")// 
                                {
                                    try
                                    {
                                        xe2.SetAttribute("value", txb_presstick.Text);
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                            }
                        }//input

                        if (xe.GetAttribute("name") == "mouse")
                        {
                            XmlNodeList nls = xe.ChildNodes;// 
                            foreach (XmlNode xn1 in nls)// 
                            {
                                XmlElement xe2 = (XmlElement)xn1;// 
                                if (xe2.GetAttribute("name") == "ignore-mouse-press-time")// 
                                {
                                    try
                                    {
                                        xe2.SetAttribute("value", txb_mpresstime.Text);
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                            }
                        }//mouse
                        #endregion
                    }//foreach 

                    xreader.Close();
                    xmlDoc.Save(XmlOutPath + "\\client.config2.xml");
                    
                }
            }
            catch
            {
                Console.Write(str_patcherror);
                return;
            }
            Console.Write(str_pathdone);
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
                Console.Write(str_repack, ConfigFileName);
                BNSDat.BNSDat.Compress(ConfigOutPath, ConfigOutPath.Contains("64.dat"));
            }

            if (PatchXml == true)
            {
                Console.Write(str_repack, XmlFileName);
                BNSDat.BNSDat.Compress(XmlOutPath, XmlOutPath.Contains("64.dat"));
            }

            GC.Collect();
            MessageBox.Show(str_patchdone, Text);
            gbox_patcher.Enabled = true;
        }

        private void compileDat()
        {
            Console.Write(str_compiledat);
            try
            {
                if (PatchConfig == true)
                    Compiler(ConfigOutPath);

                if (PatchXml == true)
                    Compiler(XmlOutPath);
            }
            catch
            {
                Console.Write(str_errordat);
                return;
            }
        }
    }
}
