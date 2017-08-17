using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text;
using BnS_Launcher.lib;

namespace BnS_Launcher
{
    public partial class Settings : Form
    {
        bool PathsFound = false;
        bool LoadingDisabled = false;

        string str2, str3;
        FileStream stream;
        StreamReader reader;
        FileStream stream2;
        StreamWriter writer;

        IniFile fSettings = new IniFile(Environment.CurrentDirectory + "\\Settings.ini");
        SettingsClass sSettings = new SettingsClass();

        string sRegion = "";
        string sServerType = "";
        string sArchteture = "";
        string sLanguage = "";

        private BslI18NLoader _i18N;
        string mbox_llangchange, lb_texturestron, lb_texturestroff, lb_noattendoff, lb_noattendon, lb_allcoreson, lb_allcoresoff, lb_loadimgoff, lb_loadimgon, mbox_disableimg, mbox_enableimg, mbox_pathclierror, lb_cpathon, lb_cpathoff;

        FolderBrowserDialog OfolderDat = new FolderBrowserDialog();

        bool ShowHidebtn;
        bool bCustomPath;
        bool ShowHidebtnk;

        public Settings()
        {
            InitializeComponent();
            InitI18N();

            cbox_llang.Items.AddRange(BslManager.Instance.LanguageNames.ToArray());
            var lang = (string)BslManager.Instance.SystemSettings["lang"];
            cbox_llang.SelectedIndex = BslManager.Instance.LanguageTypes.IndexOf(lang);
            //moved from Settings.Designer
            cbox_llang.SelectedIndexChanged += new EventHandler(cbox_llang_SelectedIndexChanged);
        }

        private void InitI18N()
        {
            _i18N = BslI18NLoader.Instance;
            //FormTitle
            Text = _i18N.LoadI18NValue("Settings", "title");
            //groupboxes
            gbox_llang.Text = _i18N.LoadI18NValue("Settings", "gbox_llang");
            gbox_region.Text = _i18N.LoadI18NValue("Settings", "gbox_region");
            gbox_arc.Text = _i18N.LoadI18NValue("Settings", "gbox_arc");
            gbox_krserver.Text = _i18N.LoadI18NValue("Settings", "gbox_krserver");
            gbox_westlang.Text = _i18N.LoadI18NValue("Settings", "gbox_westlang");
            gbox_cpath.Text = _i18N.LoadI18NValue("Settings", "gbox_cpath");
            //tabpages
            tpage_client.Text = _i18N.LoadI18NValue("Settings", "tpage_client");
            tpage_lsettings.Text = _i18N.LoadI18NValue("Settings", "tpage_lsettings");
            tpage_others.Text = _i18N.LoadI18NValue("Settings", "tpage_others");
            //checkboxes
            cbox_texstr.Text = _i18N.LoadI18NValue("Settings", "cbox_texstr");
            cbox_mboxes.Text = _i18N.LoadI18NValue("Settings", "cbox_mboxes");
            cbox_disableimg.Text = _i18N.LoadI18NValue("Settings", "cbox_disableimg");
            cbox_allcores.Text = _i18N.LoadI18NValue("Settings", "cbox_allcores");
            //labels
            lb_zoom.Text = _i18N.LoadI18NValue("Settings", "lb_zoom");
            lb_texturestron = _i18N.LoadI18NValue("Settings", "lb_texturestron");
            lb_texturestroff = _i18N.LoadI18NValue("Settings", "lb_texturestroff");
            lb_noattendon = _i18N.LoadI18NValue("Settings", "lb_noattendon");
            lb_noattendoff = _i18N.LoadI18NValue("Settings", "lb_noattendoff");
            lb_allcoreson = _i18N.LoadI18NValue("Settings", "lb_allcoreson");
            lb_allcoresoff = _i18N.LoadI18NValue("Settings", "lb_allcoresoff");
            lb_loadimgoff = _i18N.LoadI18NValue("Settings", "lb_loadimgoff");
            lb_loadimgon = _i18N.LoadI18NValue("Settings", "lb_loadimgon");
            lb_cpathon = _i18N.LoadI18NValue("Settings", "lb_cpathon");
            lb_cpathoff = _i18N.LoadI18NValue("Settings", "lb_cpathoff");
            //messageboxes
            mbox_llangchange = _i18N.LoadI18NValue("Settings", "mbox_llangchange");
            mbox_disableimg = _i18N.LoadI18NValue("Settings", "mbox_disableimg");
            mbox_enableimg = _i18N.LoadI18NValue("Settings", "mbox_enableimg");
            mbox_pathclierror = _i18N.LoadI18NValue("Settings", "mbox_pathclierror");
            //buttons
            btn_scpath.Text = _i18N.LoadI18NValue("Settings", "btn_scpath");
            btn_enable.Text = _i18N.LoadI18NValue("Settings", "btn_enable");
            btn_disable.Text = _i18N.LoadI18NValue("Settings", "btn_disable");
        }

        private void FomrSettings_Load(object sender, EventArgs e)
        {
            //populate region combox
            if (sSettings.gKorLivePath == true || sSettings.gKorTestPath == true)
                cbox_Region.Items.AddRange(new object[] { "Korean" });
            if (sSettings.gWstPath == true)
                cbox_Region.Items.AddRange(new object[] { "West(NA-EU)" });
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
            gbox_westlang.Hide();

            if (PathsFound == true)
            {
                //--
                if (!Directory.Exists(sSettings.sModPath + "\\..\\loading"))
                    Directory.CreateDirectory(sSettings.sModPath + "\\..\\loading");

                if (File.Exists(sSettings.sModPath + "\\..\\loading\\00009368.bak"))
                {
                    LoadingDisabled = true;
                    cbox_disableimg.Checked = true;
                }
                //--
                if (sSettings.sNoTextureStreaming == "true")
                    cbox_texstr.Checked = true;

                if (sSettings.sUnattended == "true")
                    cbox_mboxes.Checked = true;

                if (sSettings.sUseAllCores == "true")
                    cbox_allcores.Checked = true;
                //--
                switch (sSettings.sRegion)
                {
                    case "KR":
                        gbox_krserver.Show();
                        cbox_Region.SelectedItem = "Korean";
                        if (string.IsNullOrEmpty(sSettings.sServerType))
                        {
                            fSettings.IniWriteValue("Settings", "ServerType", "Live");
                            cbox_KorServer.SelectedItem = "Live";
                        }
                        if (sSettings.sServerType == "Live")
                        {
                            txb_cpath.Text = sSettings.csKorLivePath;

                            if (sSettings.useKrCustomPathLive == "true")
                            {
                                ShowHidebtn = false;
                                lb_cpath.Text = lb_cpathon;
                            }
                            else
                            {
                                ShowHidebtn = true;
                                lb_cpath.Text = lb_cpathoff;
                            }
                        }
                        else if (sSettings.sServerType == "Test")
                        {
                            txb_cpath.Text = sSettings.csKorTestPath;
                            if (sSettings.useKrCustomPathTest == "true")
                            {
                                ShowHidebtn = false;
                                lb_cpath.Text = lb_cpathon;
                            }

                            else
                            {
                                ShowHidebtn = true;
                                lb_cpath.Text = lb_cpathoff;
                            }
                        }
                        break;
                    case "EN":
                        gbox_westlang.Show();
                        cbox_Region.SelectedItem = "West(NA-EU)";
                        txb_cpath.Text = sSettings.csWstPath;
                        if (string.IsNullOrEmpty(sSettings.sLanguageID))
                        {
                            fSettings.IniWriteValue("Settings", "language", "English");
                            cbox_west_lang.SelectedItem = "English";
                        }
                        if (sSettings.useWstCustomPath == "true")
                        {
                            ShowHidebtn = false;
                            lb_cpath.Text = lb_cpathon;
                        }
                        else
                        {
                            ShowHidebtn = true;
                            lb_cpath.Text = lb_cpathoff;
                        }
                        break;
                    case "TW":
                        cbox_Region.SelectedItem = "Taiwan";
                        txb_cpath.Text = sSettings.csTwnPath;
                        if (sSettings.useTwnCustomPath == "true")
                        {
                            ShowHidebtn = false;
                            lb_cpath.Text = lb_cpathon;
                        }
                        else
                        {
                            ShowHidebtn = true;
                            lb_cpath.Text = lb_cpathoff;
                        }
                        break;
                    case "JP":
                        cbox_Region.SelectedItem = "Japan";
                        txb_cpath.Text = sSettings.csJpnPath;
                        if (sSettings.useJpnCustomPath == "true")
                        {
                            ShowHidebtn = false;
                            lb_cpath.Text = lb_cpathon;
                        }
                        else
                        {
                            ShowHidebtn = true;
                            lb_cpath.Text = lb_cpathoff;
                        }
                        break;
                    default:
                        break;
                }

                if (ShowHidebtn == true)
                {
                    btn_enable.Show();
                    btn_disable.Hide();
                }
                else
                {
                    btn_enable.Hide();
                    btn_disable.Show();
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
            LoadXml();
        }

        void LoadXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlReader xreader = XmlReader.Create(sSettings.XmlSettings);
            xmlDoc.Load(xreader);

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("config").ChildNodes;

            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.GetAttribute("name") == "maxZoom")
                {
                    try
                    {
                        txb_zoom.Text = xe.GetAttribute("value");
                    }
                    catch //(Exception e)
                    {
                       // MessageBox.Show(e.ToString());
                    }
                }
            }
            xreader.Close();
        }

        void xmlWrite()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlReader xreader = XmlReader.Create(sSettings.XmlSettings);
            xmlDoc.Load(xreader);

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("config").ChildNodes;

            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.GetAttribute("name") == "maxZoom")
                {
                    try
                    {
                        xe.SetAttribute("value", txb_zoom.Text);
                    }
                    catch //(Exception e)
                    {
                        //MessageBox.Show(e.ToString());
                    }
                }
            }
            xreader.Close();
            xmlDoc.Save(sSettings.XmlSettings);

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

        void SetCustomPath()
        {
            if (bCustomPath == true)
            {
                btn_enable.Hide();
                btn_disable.Show();
                lb_cpath.Text = lb_cpathon;
                if (sSettings.sRegion == "KR")
                {
                    if (sSettings.sServerType == "Live")
                        fSettings.IniWriteValue("Path", "KR_Live_UseCustomPath", "true");
                    else if (sSettings.sServerType == "Test")
                        fSettings.IniWriteValue("Path", "KR_Test_UseCustomPath", "true");
                }
                else
                    fSettings.IniWriteValue("Path", sSettings.sRegion + "_UseCustomPath", "true");
            }
            else
            {
                if (sSettings.sRegion == "KR")
                {
                    if (sSettings.sServerType == "Live")
                        fSettings.IniWriteValue("Path", "KR_Live_UseCustomPath", "false");
                    else if (sSettings.sServerType == "Test")
                        fSettings.IniWriteValue("Path", "KR_Test_UseCustomPath", "false");
                }
                else
                    fSettings.IniWriteValue("Path", sSettings.sRegion + "_UseCustomPath", "false");
            }
        }

        private void btn_scpath_Click(object sender, EventArgs e)
        {
            if (OfolderDat.ShowDialog() != DialogResult.OK)
                return;
            txb_cpath.Text = OfolderDat.SelectedPath;
            if (sSettings.sRegion == "KR")
            {
                if (sSettings.sServerType == "Live")
                    fSettings.IniWriteValue("Path", "KR_Live", txb_cpath.Text);
                else if (sSettings.sServerType == "Test")
                    fSettings.IniWriteValue("Path", "KR_Test", txb_cpath.Text);
            }
            else
                fSettings.IniWriteValue("Path", sSettings.sRegion, txb_cpath.Text);
        }

        private void btn_enable_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_cpath.Text))
            {
                bCustomPath = true;
            }
            else
            {
                var merr = MessageBox.Show(mbox_pathclierror, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (merr == DialogResult.OK)
                {
                    if (OfolderDat.ShowDialog() != DialogResult.OK)
                        return;
                    txb_cpath.Text = OfolderDat.SelectedPath;
                    if (sSettings.sRegion == "KR")
                    {
                        if (sSettings.sServerType == "Live")
                            fSettings.IniWriteValue("Path", "KR_Live", txb_cpath.Text);
                        else if (sSettings.sServerType == "Test")
                            fSettings.IniWriteValue("Path", "KR_Test", txb_cpath.Text);
                    }
                    else
                        fSettings.IniWriteValue("Path", sSettings.sRegion, txb_cpath.Text);
                }
                else
                    bCustomPath = false;
            }
            SetCustomPath();
        }

        private void btn_disable_Click(object sender, EventArgs e)
        {
            btn_disable.Hide();
            btn_enable.Show();
            lb_cpath.Text = lb_cpathoff;
            bCustomPath = false;
            SetCustomPath();
        }
        private void cbox_textureStrCheckedChanged(object sender, EventArgs e)
        {
            if (cbox_texstr.Checked == true)
            {
                sSettings.sNoTextureStreaming = "true";
                fSettings.IniWriteValue("Settings", "NoTextureStreaming", "true");
                Sts_Label.Text = lb_texturestron;
            }
            else
            {
                sSettings.sNoTextureStreaming = "false";
                fSettings.IniWriteValue("Settings", "NoTextureStreaming", "false");
                Sts_Label.Text = lb_texturestroff;
            }
        }

        private void cbox_CheckedChanged(object sender, EventArgs e)
        {
            if (cbox_mboxes.Checked == true)
            {
                sSettings.sUnattended = "true";
                fSettings.IniWriteValue("Settings", "Unattended", "true");
                Sts_Label.Text = lb_noattendon;
            }
            else
            {
                sSettings.sUnattended = "false";
                fSettings.IniWriteValue("Settings", "Unattended", "false");
                Sts_Label.Text = lb_noattendoff;
            }
        }

        private void cbox_AllCores_CheckedChanged(object sender, EventArgs e)
        {
            if (cbox_allcores.Checked == true)
            {
                sSettings.sUseAllCores = "true";
                fSettings.IniWriteValue("Settings", "UseAllCores", "true");
                Sts_Label.Text = lb_allcoreson;
            }
            else
            {
                sSettings.sUseAllCores = "false";
                fSettings.IniWriteValue("Settings", "UseAllCores", "false");
                Sts_Label.Text = lb_allcoresoff;
            }
        }

        private void cbox_disableImg_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadingDisabled == false)
            {
                LoadingDisabled = true;
                try
                {
                    File.Move(sSettings.sLocalCookedPCPath + "Loading.pkg", sSettings.sModPath + "\\..\\loading\\loading.bak");
                    File.Move(sSettings.sLocalCookedPCPath + "00009368.upk", sSettings.sModPath + "\\..\\loading\\00009368.bak");
                    Sts_Label.Text = lb_loadimgoff;
                }
                catch
                {
                    MessageBox.Show(mbox_disableimg);
                }
            }
            else if (LoadingDisabled == true)
            {
                LoadingDisabled = false;
                try
                {
                    File.Move(sSettings.sModPath + "\\..\\loading\\loading.bak", sSettings.sLocalCookedPCPath + "Loading.pkg");
                    File.Move(sSettings.sModPath + "\\..\\loading\\00009368.bak", sSettings.sLocalCookedPCPath + "00009368.upk");
                    Sts_Label.Text = lb_loadimgon;
                }
                catch
                {
                    MessageBox.Show(mbox_enableimg);
                }
            }
        }

        private void cbox_Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbox_Region.SelectedItem.ToString())
            {
                //
                case "Korean":
                    sRegion = "KR";
                    if (string.IsNullOrEmpty(sSettings.sServerType))
                    {
                        fSettings.IniWriteValue("Settings", "ServerType", "Live");
                        cbox_KorServer.SelectedItem = "Live";
                    }
                    if (sSettings.sServerType == "Live")
                    {
                        txb_cpath.Text = sSettings.csKorLivePath;
                        if (sSettings.useKrCustomPathLive == "true")
                        {
                            ShowHidebtn = false;
                            lb_cpath.Text = lb_cpathon;
                        }
                        else
                        {
                            ShowHidebtn = true;
                            lb_cpath.Text = lb_cpathoff;
                        }
                    }
                    else if (sSettings.sServerType == "Test")
                    {
                        txb_cpath.Text = sSettings.csKorTestPath;
                        if (sSettings.useKrCustomPathTest == "true")
                        {
                            ShowHidebtn = false;
                            lb_cpath.Text = lb_cpathon;
                        }
                        else
                        {
                            ShowHidebtn = true;
                            lb_cpath.Text = lb_cpathoff;
                        }
                    }
                    break;
                case "West(NA-EU)":
                    sRegion = "EN";

                    if (string.IsNullOrEmpty(sSettings.sLanguageID))
                    {
                        fSettings.IniWriteValue("Settings", "language", "English");
                        cbox_west_lang.SelectedItem = "English";
                    }
                    txb_cpath.Text = sSettings.csWstPath;
                    if (sSettings.useTwnCustomPath == "true")
                    {
                        ShowHidebtn = false;
                        lb_cpath.Text = lb_cpathon;
                    }
                    else
                    {
                        ShowHidebtn = true;
                        lb_cpath.Text = lb_cpathoff;
                    }
                    break;
                case "Taiwan":
                    sRegion = "TW";

                    txb_cpath.Text = sSettings.csTwnPath;
                    if (sSettings.useTwnCustomPath == "true")
                    {
                        ShowHidebtn = false;
                        lb_cpath.Text = lb_cpathon;
                    }
                    else
                    {
                        ShowHidebtn = true;
                        lb_cpath.Text = lb_cpathoff;
                    }
                    break;
                case "Japan":
                    sRegion = "JP";
                    txb_cpath.Text = sSettings.csJpnPath;
                    if (sSettings.useJpnCustomPath == "true")
                    {
                        ShowHidebtn = false;
                        lb_cpath.Text = lb_cpathon;
                    }
                    else
                    {
                        ShowHidebtn = true;
                        lb_cpath.Text = lb_cpathoff;
                    }
                    break;
                default:
                    break;
            }

            if (ShowHidebtn == true)
            {
                btn_enable.Show();
                btn_disable.Hide();
            }
            else
            {
                btn_enable.Hide();
                btn_disable.Show();
            }

            if (cbox_Region.SelectedItem.ToString() == "West(NA-EU)")
                gbox_westlang.Show();
            else
                gbox_westlang.Hide();

            if (cbox_Region.SelectedItem.ToString() == "Korean" && sSettings.gKorTestPath == true)
                gbox_krserver.Show();
            else
                gbox_krserver.Hide();

            fSettings.IniWriteValue("Settings", "Region", sRegion);
            LoadXml();
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
                    if (sSettings.sRegion == "KR")
                    {
                        txb_cpath.Text = sSettings.csKorLivePath;
                        if (sSettings.useKrCustomPathLive == "true")
                        {
                            ShowHidebtnk = false;
                            lb_cpath.Text = lb_cpathon;
                        }
                        else
                        {
                            ShowHidebtnk = true;
                            lb_cpath.Text = lb_cpathoff;
                        }
                    }
                    break;
                case "Test":
                    sServerType = "Test";
                    if (sSettings.sRegion == "KR")
                    {
                        txb_cpath.Text = sSettings.csKorTestPath;
                        if (sSettings.useKrCustomPathTest == "true")
                        {
                            ShowHidebtnk = false;
                            lb_cpath.Text = lb_cpathon;
                        }
                        else
                        {
                            ShowHidebtnk = true;
                            lb_cpath.Text = lb_cpathoff;
                        }
                    }
                    break;
                default:
                    break;
            }
            if (ShowHidebtnk == true)
            {
                btn_enable.Show();
                btn_disable.Hide();
            }
            else
            {
                btn_enable.Hide();
                btn_disable.Show();
            }
            fSettings.IniWriteValue("Settings", "ServerType", sServerType);
            LoadXml();
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

        private void cbox_llang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lang = BslManager.Instance.LanguageTypes[cbox_llang.SelectedIndex];
            BslManager.Instance.SystemSettings["lang"] = lang;
            BslManager.WriteJsonFile(BslManager.PathJsonSettings, BslManager.Instance.SystemSettings);

            MessageBox.Show(mbox_llangchange, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FomrSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            xmlWrite();
        }
    }
}
