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
        string fix1 = @"// 격사 전용 pitch min 값";
        string fix2 = @"// 격사 전용 pitch max 값";

        public BackgroundWorker ebnsdat;
        public BackgroundWorker cbnsdat;
        public bool PatchConfig, PatchXml, BackConfig, BackXml;

        SettingsClass sSettings = new SettingsClass();

        string strlb_info, str_extract, str_repackerror, str_patching, str_patcherror, str_pathdone, str_repack, str_patchdone, str_compiledat, str_errordat, gcd_string;

        public bool pbrackup, pweb_launcher, pclause, pminize, pgcd, pnagle, pnaglearena, xpublick, xsixman, xfield, xfaction, xjackpot, xclassic, xoptimal, xftcdt, xcslider;

        private void cbox_slider_CheckedChanged(object sender, EventArgs e)
        {
            if (cbox_slider.Checked)
                btn_Slider.Enabled = true;
            else
                btn_Slider.Enabled = false;
        }

        private BslI18NLoader _i18N;

        private void cbox_cgcd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbox_cgcd.Checked == true)
            {
                richOut.Clear();
                Console.Write(gcd_string);
            }
            else
                richOut.Clear();
        }

        public Patcher()
        {
            InitializeComponent();
            InitI18N();
            PatcherSettingsManager(Environment.CurrentDirectory + "\\Config\\Patcher.xml");
        }


        private void Patcher_Load(object sender, EventArgs e)
        {
            string stRegion = "";
            string stArchitecture = "";

            _writer = new StrWriter(richOut);
            Console.SetOut(_writer);

            cbox_back.Checked = pbrackup;
            cbox_webl.Checked = pweb_launcher;
            cbox_clause.Checked = pclause;
            cbox_minimize.Checked = pminize;
            cbox_cgcd.Checked = pgcd;
            cbox_nagle.Checked = pnagle;
            cbox_naglearena.Checked = pnaglearena;
            cbox_dpspub.Checked = xpublick;
            cbox_dpssix.Checked = xsixman;
            cbox_dpsfield.Checked = xfield;
            cbox_dpsfac.Checked = xfaction;
            cbox_dpsjackpot.Checked = xjackpot;
            cbox_dpsclassic.Checked = xclassic;
            cbox_perfmod.Checked = xoptimal;
            cbox_skdt.Checked = xftcdt;
            cbox_slider.Checked = xcslider;

            if (cbox_slider.Checked)
                btn_Slider.Enabled = true;
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
                    cbox_cgcd.Enabled = false;
                    stRegion = "West";
                    break;
                case "KR":
                    cbox_webl.Enabled = false;
                    cbox_cgcd.Enabled = false;
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
            //Console.Write("{0}", DatPath);

        }

        private void Patcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            PatcherSettingsManager(Environment.CurrentDirectory + "\\Config\\Patcher.xml", true);
        }

        void PatcherSettingsManager(string sPfile, bool save = false)
        {
            string[] returnBool = new string[16];
            string[] returnValue = new string[4];

            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//
            XmlReader mReader = XmlReader.Create(sPfile);
            xmlDoc.Load(mReader);

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("config").ChildNodes;//

            foreach (XmlNode xn in nodeList)// 
            {
                XmlElement xe = (XmlElement)xn;// 
                //configxml
                if (xe.GetAttribute("name") == "backup-original-file")
                {
                    try
                    {
                        if (save == true)
                        {
                            if (cbox_back.Checked == true) { xe.SetAttribute("value", "true"); }  //
                            else { xe.SetAttribute("value", "false"); }
                        }
                        else
                            returnBool[0] = xe.GetAttribute("value"); //
                    }
                    catch { }
                }
                #region configdat
                if (xe.GetAttribute("name") == "configdat")//
                {
                    XmlNodeList nls = xe.ChildNodes;// 
                    foreach (XmlNode xn1 in nls)// 
                    {
                        XmlElement xe2 = (XmlElement)xn1;// 
                        if (xe2.GetAttribute("name") == "use-web-launching")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_webl.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[1] = xe2.GetAttribute("value"); //

                            }
                            catch { }
                        }

                        if (xe2.GetAttribute("name") == "disable-clause")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_clause.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[2] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }

                        if (xe2.GetAttribute("name") == "disable-minimize")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_minimize.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[3] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }

                        if (xe2.GetAttribute("name") == "use-custom-gcd")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_cgcd.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[4] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }

                        if (xe2.GetAttribute("name") == "use-nagle")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_nagle.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[5] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }

                        if (xe2.GetAttribute("name") == "use-nagle-arena")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_naglearena.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[6] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }
                    }

                }
                #endregion
                #region xmldat
                if (xe.GetAttribute("name") == "xmldat")//
                {
                    XmlNodeList nls = xe.ChildNodes;// 
                    foreach (XmlNode xn1 in nls)// 
                    {
                        XmlElement xe2 = (XmlElement)xn1;// 
                        if (xe2.GetAttribute("name") == "pending-time")// 
                        {
                            try
                            {
                                if (save == true)

                                    xe2.SetAttribute("value", txb_ptime.Text); //

                                else
                                    txb_ptime.Text = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }

                        if (xe2.GetAttribute("name") == "pending-key-tick-time")// 
                        {
                            try
                            {
                                if (save == true)
                                    xe2.SetAttribute("value", txb_ptick.Text); //
                                else
                                    txb_ptick.Text = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }

                        if (xe2.GetAttribute("name") == "pressed-key-tick-time")// 
                        {
                            try
                            {
                                if (save == true)
                                    xe2.SetAttribute("value", txb_presstick.Text); //
                                else
                                    txb_presstick.Text = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }

                        if (xe2.GetAttribute("name") == "ignore-mouse-press-time")// 
                        {
                            try
                            {
                                if (save == true)
                                    xe2.SetAttribute("value", txb_mpresstime.Text); //
                                else
                                    txb_mpresstime.Text = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }
                        if (xe2.GetAttribute("name") == "skill-global-cool-latency-time")// 
                        {
                            try
                            {
                                if (save == true)
                                    xe2.SetAttribute("value", txb_cgct.Text); //
                                else
                                    txb_cgct.Text = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }

                        if (xe2.GetAttribute("name") == "fast-msec")// 
                        {
                            try
                            {
                                if (save == true)
                                    xe2.SetAttribute("value", txbFastmsec.Text); //
                                else
                                    txbFastmsec.Text = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }

                        if (xe2.GetAttribute("name") == "mid-msec")// 
                        {
                            try
                            {
                                if (save == true)
                                    xe2.SetAttribute("value", txbMidmsec.Text); //
                                else
                                    txbMidmsec.Text = xe2.GetAttribute("value"); //

                            }
                            catch { }
                        }
                        if (xe2.GetAttribute("name") == "show-public-zone")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_dpspub.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[7] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }
                        if (xe2.GetAttribute("name") == "show-party-6-dungeon-and-cave")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_dpssix.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[8] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }
                        if (xe2.GetAttribute("name") == "show-field-zone")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_dpsfield.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[9] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }
                        if (xe2.GetAttribute("name") == "show-faction-battle-field-zone")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_dpsfac.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[10] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }
                        if (xe2.GetAttribute("name") == "show-jackpot-boss-zone")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_dpsjackpot.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[11] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }
                        if (xe2.GetAttribute("name") == "show-classic-field-zone")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_dpsclassic.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[12] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }
                        if (xe2.GetAttribute("name") == "use-optimal-performance-mode-option")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_perfmod.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[13] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }

                        if (xe2.GetAttribute("name") == "fix-train-complete-delay-time")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_skdt.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[14] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }

                        if (xe2.GetAttribute("name") == "use-custom-slider")// 
                        {
                            try
                            {
                                if (save == true)
                                {
                                    if (cbox_slider.Checked == true) { xe2.SetAttribute("value", "true"); }  //
                                    else { xe2.SetAttribute("value", "false"); }
                                }
                                else
                                    returnBool[15] = xe2.GetAttribute("value"); //
                            }
                            catch { }
                        }
                    }
                }
                #endregion
            }//foreach 
            // public bool pbrackup, pweb_launcher, pclause, pminize, pgcd, pnagle, pnaglearena, xpublick, xsixman, xfield, xfaction, xjackpot, xclassic, xoptimal, xcslider;

            if (returnBool[0] == "false") { pbrackup = false; }
            else { pbrackup = true; }
            if (sSettings.sRegion == "EN" || sSettings.sRegion == "KR")
            {
                pweb_launcher = true;
            }
            else
            {
                if (returnBool[1] == "false") { pweb_launcher = false; }
                else { pweb_launcher = true; }
            }
            if (returnBool[2] == "false") { pclause = false; }
            else { pclause = true; }
            if (returnBool[3] == "false") { pminize = false; }
            else { pminize = true; }
            if (returnBool[4] == "false") { pgcd = false; }
            else { pgcd = true; }
            if (returnBool[5] == "false") { pnagle = false; }
            else { pnagle = true; }
            if (returnBool[6] == "false") { pnaglearena = false; }
            else { pnaglearena = true; }

            if (returnBool[7] == "false") { xpublick = false; }
            else { xpublick = true; }
            if (returnBool[8] == "false") { xsixman = false; }
            else { xsixman = true; }
            if (returnBool[9] == "false") { xfield = false; }
            else { xfield = true; }
            if (returnBool[10] == "false") { xfaction = false; }
            else { xfaction = true; }
            if (returnBool[11] == "false") { xjackpot = false; }
            else { xjackpot = true; }
            if (returnBool[12] == "false") { xclassic = false; }
            else { xclassic = true; }
            if (returnBool[13] == "false") { xoptimal = false; }
            else { xoptimal = true; }
            if (returnBool[14] == "false") { xftcdt = false; }
            else { xftcdt = true; }
            if (returnBool[15] == "false") { xcslider = false; }
            else { xcslider = true; }
            mReader.Close();

            if (save == true)
                xmlDoc.Save(sPfile);
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
            lb_fast.Text = _i18N.LoadI18NValue("Patcher", "lb_fast");
            lb_mid.Text = _i18N.LoadI18NValue("Patcher", "lb_mid");
            lb_mpresstime.Text = _i18N.LoadI18NValue("Patcher", "lb_mpresstime");
            lb_presstick.Text = _i18N.LoadI18NValue("Patcher", "lb_presstick");
            lb_ptime.Text = _i18N.LoadI18NValue("Patcher", "lb_ptime");
            lb_ptimetick.Text = _i18N.LoadI18NValue("Patcher", "lb_ptimetick");
            lb_time.Text = _i18N.LoadI18NValue("Patcher", "lb_time");

            //strings
            strlb_info = _i18N.LoadI18NValue("Patcher", "strlb_info");
            gcd_string = _i18N.LoadI18NValue("Patcher", "gcd_string");
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
            gbox_dps.Text = _i18N.LoadI18NValue("Patcher", "gbox_dps");
            gbox_input.Text = _i18N.LoadI18NValue("Patcher", "gbox_input");
            gbox_latency.Text = _i18N.LoadI18NValue("Patcher", "gbox_latency");
            gbox_mouse.Text = _i18N.LoadI18NValue("Patcher", "gbox_mouse");
            gbox_msec.Text = _i18N.LoadI18NValue("Patcher", "gbox_msec");

            //checkboxes
            cbox_webl.Text = _i18N.LoadI18NValue("Patcher", "cbox_webl");
            cbox_clause.Text = _i18N.LoadI18NValue("Patcher", "cbox_clause");
            cbox_minimize.Text = _i18N.LoadI18NValue("Patcher", "cbox_minimize");
            cbox_back.Text = _i18N.LoadI18NValue("Patcher", "cbox_back");
            cbox_cgcd.Text = _i18N.LoadI18NValue("Patcher", "cbox_Cgct");
            cbox_nagle.Text = _i18N.LoadI18NValue("Patcher", "cbox_nagle");
            cbox_naglearena.Text = _i18N.LoadI18NValue("Patcher", "cbox_naglearena");
            cbox_dpsclassic.Text = _i18N.LoadI18NValue("Patcher", "cbox_dpsclassic");
            cbox_dpsfac.Text = _i18N.LoadI18NValue("Patcher", "cbox_dpsfac");
            cbox_dpsfield.Text = _i18N.LoadI18NValue("Patcher", "cbox_dpsfield");
            cbox_dpsjackpot.Text = _i18N.LoadI18NValue("Patcher", "cbox_dpsjackpot");
            cbox_dpspub.Text = _i18N.LoadI18NValue("Patcher", "cbox_dpspub");
            cbox_dpssix.Text = _i18N.LoadI18NValue("Patcher", "cbox_dpssix");
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
                //BNSDat.BNSDat.Extract(ConfigFilePath, ConfigFilePath.EndsWith("64.dat"));

                new BNSDat.BNSDat().Extract(ConfigFilePath, (number, of) =>
                {
                    richOut.Text = "Extracting Files: " + number + "/" + of;
                }, ConfigFilePath.EndsWith("64.dat"));
            }

            if (PatchXml == true)
            {
                Console.Write(str_extract, XmlFileName);
                //BNSDat.BNSDat.Extract(XmlFilePath, XmlFilePath.EndsWith("64.dat"));
                new BNSDat.BNSDat().Extract(XmlFilePath, (number, of) =>
                {
                    richOut.Text = "Extracting Files: " + number + "/" + of;
                }, XmlFilePath.EndsWith("64.dat"));
            }
            // GC.Collect();
            XmlWrite();
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
                //BNSDat.BNSDat.Compress(ConfigOutPath, ConfigOutPath.Contains("64.dat"));

                new BNSDat.BNSDat().Compress(ConfigOutPath, (number, of) =>
                {
                    richOut.Text = "Compressing Files: " + number + "/" + of;
                }, ConfigOutPath.Contains("64.dat"), 9);
            }

            if (PatchXml == true)
            {
                Console.Write(str_repack, XmlFileName);
                // BNSDat.BNSDat.Compress(XmlOutPath, XmlOutPath.Contains("64.dat"));

                new BNSDat.BNSDat().Compress(XmlOutPath, (number, of) =>
                {
                    richOut.Text = "Compressing Files: " + number + "/" + of;
                }, XmlOutPath.Contains("64.dat"), 9);
            }

            // GC.Collect();
            MessageBox.Show(str_patchdone, Text);
            gbox_patcher.Enabled = true;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {

            //gbox_patcher.Enabled = false;

            if (!cbox_cconfig.Checked && !cbox_cxml.Checked)
            {
                MessageBox.Show(str_repackerror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gbox_patcher.Enabled = true;
            }

            if (cbox_cconfig.Checked == true)
            {
                PatchConfig = true;
                if (cbox_back.Checked == true)
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
            ////Console.Write("Patching: Wait until patch finish!\n");
            BakcUpManager();
            // XmlWrite();

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
            // GC.Collect();
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
                                if (cbox_webl.Checked == true) { xe.SetAttribute("value", "true"); }  //
                                else { xe.SetAttribute("value", "false"); }
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
                                if (cbox_clause.Checked == true) { xe.SetAttribute("value", "false"); }  //
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
                                if (cbox_cgcd.Checked == true) { xe.SetAttribute("value", "false"); }  //
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
                                if (cbox_nagle.Checked == true) { xe.SetAttribute("value", "true"); }  //
                                else { xe.SetAttribute("value", "false"); }
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

                    if (!string.IsNullOrEmpty(fix1) && !string.IsNullOrEmpty(fix2))
                    {
                        try
                        {
                            string configFile = File.ReadAllText(XmlOutPath + "\\client.config2.xml");
                            configFile = configFile.Replace(fix1, "");
                            configFile = configFile.Replace(fix2, "");
                            File.WriteAllText(XmlOutPath + "\\client.config2.xml", configFile);
                        }
                        catch
                        {
                            Console.Write(str_patcherror);
                        }
                    }

                    Console.Write(str_patching + "client.config2.xml\n");
                    XmlReader xreader = XmlReader.Create(XmlOutPath + "\\client.config2.xml", settings);
                    xmlDoc.Load(xreader);

                    XmlNodeList nodeList = xmlDoc.SelectSingleNode("config").ChildNodes;//

                    foreach (XmlNode xn in nodeList)// 
                    {
                        XmlElement xe = (XmlElement)xn;//
                        if (xe.GetAttribute("name") == "skill")// 
                        {
                            XmlNodeList nls = xe.ChildNodes;//
                            foreach (XmlNode xn1 in nls)// 
                            {
                                XmlElement xe2 = (XmlElement)xn1;// 

                                if (xe2.GetAttribute("name") == "train-complete-delay-time")// 
                                {
                                    try
                                    {
                                        if (cbox_skdt.Checked == true) { xe2.SetAttribute("value", "0.500000"); }
                                        else { xe2.SetAttribute("value", "1.500000"); }
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                            }
                        }

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

                                if (xe2.GetAttribute("name") == "show-jackpot-boss-zone")// 
                                {
                                    try
                                    {
                                        if (cbox_dpsjackpot.Checked == true) { xe2.SetAttribute("value", "y"); }  //
                                        else { xe2.SetAttribute("value", "n"); }
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }

                                if (xe2.GetAttribute("name") == "show-classic-field-zone")// 
                                {
                                    try
                                    {
                                        if (cbox_dpsclassic.Checked == true) { xe2.SetAttribute("value", "y"); }  //
                                        else { xe2.SetAttribute("value", "n"); }
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show(e.ToString());
                                    }
                                }
                            }

                        }//DPS meter

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
                                        xe2.SetAttribute("value", txb_ptime.Text);
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
            if (!cbox_slider.Checked)
                compileDat();
            else
                Console.Write("Please edit slider vallues to continue patching process!");
        }

        private void btn_Slider_Click(object sender, EventArgs e)
        {
            SliderEditor slidereditor = new SliderEditor();
            slidereditor.FormClosing += new FormClosingEventHandler(SliderEditor_FormClosing);
            slidereditor.Show();
        }

        private void SliderEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //compileDat();
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
