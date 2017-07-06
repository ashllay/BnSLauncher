﻿using System;
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

        XmlDocument document;
        XmlNode node;
        XmlElement element;
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
        string mbox_llangchange, lb_texturestron, lb_texturestroff, lb_noattendoff, lb_noattendon, lb_allcoreson, lb_allcoresoff, lb_loadimgoff, lb_loadimgon, mbox_disableimg, mbox_enableimg;

        public Settings()
        {
            InitializeComponent();
            InitI18N();

            cbox_llang.Items.AddRange(BslManager.Instance.LanguageNames.ToArray());
            var lang = (string)BslManager.Instance.SystemSettings["lang"];
            cbox_llang.SelectedIndex = BslManager.Instance.LanguageTypes.IndexOf(lang);
            cbox_llang.SelectedIndexChanged += new EventHandler(cbox_llang_SelectedIndexChanged);

            sSettings.sNoTextureStreaming = fSettings.IniReadValue("Settings", "NoTextureStreaming");
            sSettings.sUnattended = fSettings.IniReadValue("Settings", "Unattended");
            sSettings.sRegion = fSettings.IniReadValue("Settings", "Region");
            sSettings.sLanguageID = fSettings.IniReadValue("Settings", "language");
            sSettings.sUseAllCores = fSettings.IniReadValue("Settings", "UseAllCores");
            sSettings.sArchitecture = fSettings.IniReadValue("Settings", "Architecture");
            sSettings.sServerType = fSettings.IniReadValue("Settings", "ServerType");            
        }

        private void InitI18N()
        {
            _i18N = BslI18NLoader.Instance;
            //groupboxes
            gbox_llang.Text = _i18N.LoadI18NValue("Settings", "gbox_llang");
            gbox_region.Text = _i18N.LoadI18NValue("Settings", "gbox_region");
            gbox_arc.Text = _i18N.LoadI18NValue("Settings", "gbox_arc");
            gbox_krserver.Text = _i18N.LoadI18NValue("Settings", "gbox_krserver");
            gbox_westlang.Text = _i18N.LoadI18NValue("Settings", "gbox_westlang");
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
            //messageboxes
            mbox_llangchange = _i18N.LoadI18NValue("Settings", "mbox_llangchange");
            mbox_disableimg = _i18N.LoadI18NValue("Settings", "mbox_disableimg");
            mbox_enableimg = _i18N.LoadI18NValue("Settings", "mbox_enableimg");

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
                    //
                    case "KR":
                        cbox_Region.SelectedItem = "Korean";
                        if (sSettings.gKorTestPath == true)
                            gbox_krserver.Show();
                        break;
                    case "EN":
                        cbox_Region.SelectedItem = "West (NA-EU)";
                        gbox_westlang.Show();
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

        private void cBmsBox_CheckedChanged(object sender, EventArgs e)
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
                Sts_Label.Text =lb_noattendoff;
            }
        }

        private void checkBox_AllCores_CheckedChanged(object sender, EventArgs e)
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

        private void cbx_disableImg_CheckedChanged(object sender, EventArgs e)
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
                    if (string.IsNullOrEmpty(sSettings.sServerType))
                    {
                        fSettings.IniWriteValue("Settings", "ServerType", "Live");
                        cbox_KorServer.SelectedItem = "Live";
                    }
                    break;
                case "West (NA-EU)":
                    sRegion = "EN";
                    if (string.IsNullOrEmpty(sSettings.sLanguageID))
                    {
                        fSettings.IniWriteValue("Settings", "language", "English");
                        cbox_west_lang.SelectedItem = "English";
                    }
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
                gbox_westlang.Show();
            else
                gbox_westlang.Hide();

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

        private void cbox_llang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 重新记录语言信息，并写入配置文件
            var lang = BslManager.Instance.LanguageTypes[cbox_llang.SelectedIndex];
            BslManager.Instance.SystemSettings["lang"] = lang;
            BslManager.WriteJsonFile(BslManager.PathJsonSettings, BslManager.Instance.SystemSettings);

            // 显示重启程序提示信息
            // 这一段因为关系到语言的设定，使用双语显示，不作为配置设定
            MessageBox.Show(mbox_llangchange,"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
