using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Mono.Math;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web.Security;
using BnS_Launcher.lib;

namespace BnS_Launcher
{
    public partial class Main : Form
    {
        private string LaunchPath = "";
        private string NoTextureStreaming = "";
        private string Unattended = "";
        private string UseAllCores = "";
        private string ClientReg = "";
        private string msb_clinotset, msb_clinotfound, msb_slidererror, msb_emptypass, msb_emptymail, msb_mainterror, lb_loginstsdone;

        private bool ClientFound = true;

        SettingsClass sSettings = new SettingsClass();
        IniFile Settings = new IniFile(Environment.CurrentDirectory + "\\Settings.ini");

        private BslI18NLoader _i18N;

        public Main()
        {
            InitializeComponent();
            InitI18N();

            var settingsFile = Environment.CurrentDirectory + "\\Settings.ini";
            if (!File.Exists(settingsFile))
            {
                File.Create(settingsFile).Dispose();
            }
            //Settings
            if (string.IsNullOrEmpty(sSettings.sUseAllCores))
                Settings.IniWriteValue("Settings", "UseAllCores", "false");
            if (string.IsNullOrEmpty(sSettings.sNoTextureStreaming))
                Settings.IniWriteValue("Settings", "NoTextureStreaming", "false");
            if (string.IsNullOrEmpty(sSettings.sArchitecture))
                Settings.IniWriteValue("Settings", "Architecture", "0");
            if (string.IsNullOrEmpty(sSettings.sUnattended))
                Settings.IniWriteValue("Settings", "Unattended", "false");
            if (string.IsNullOrEmpty(sSettings.sRegion))
                Settings.IniWriteValue("Settings", "Region", "");
            if (string.IsNullOrEmpty(sSettings.sServerType))
                Settings.IniWriteValue("Settings", "ServerType", "");
            if (string.IsNullOrEmpty(sSettings.sLanguageID))
                Settings.IniWriteValue("Settings", "language", "");
            //Path
            if (string.IsNullOrEmpty(sSettings.useKrCustomPathLive))
                Settings.IniWriteValue("Path", "KR_Live_UseCustomPath", "false");
            if (string.IsNullOrEmpty(sSettings.csKorLivePath))
                Settings.IniWriteValue("Path", "KR_Live", "");
            if (string.IsNullOrEmpty(sSettings.useKrCustomPathTest))
                Settings.IniWriteValue("Path", "KR_Test_UseCustomPath", "false");
            if (string.IsNullOrEmpty(sSettings.csKorTestPath))
                Settings.IniWriteValue("Path", "KR_Test", "");
            if (string.IsNullOrEmpty(sSettings.useWstCustomPath))
                Settings.IniWriteValue("Path", "EN_UseCustomPath", "false");
            if (string.IsNullOrEmpty(sSettings.csWstPath))
                Settings.IniWriteValue("Path", "WEST", "");
            if (string.IsNullOrEmpty(sSettings.useJpnCustomPath))
                Settings.IniWriteValue("Path", "JP_UseCustomPath", "false");
            if (string.IsNullOrEmpty(sSettings.csJpnPath))
                Settings.IniWriteValue("Path", "JP", "");
            if (string.IsNullOrEmpty(sSettings.useTwnCustomPath))
                Settings.IniWriteValue("Path", "TW_UseCustomPath", "false");
            if (string.IsNullOrEmpty(sSettings.csTwnPath))
                Settings.IniWriteValue("Path", "TW", "");

            switch (sSettings.sRegion)
            {
                case "KR":
                    if (sSettings.gKorLivePath == false)
                    {
                        ClientFound = false;
                        ClientReg = "BnS Korea";
                    }
                    if (sSettings.gKorTestPath == false)
                    {
                        ClientFound = false;
                        ClientReg = "BnS Korea(test)";
                    }
                    break;
                case "EN":
                    if (sSettings.gWstPath == false)
                    {
                        ClientFound = false;
                        ClientReg = "BnS West";
                    }
                    break;
                case "TW":
                    if (sSettings.gTwnPath == false)
                    {
                        ClientFound = false;
                        ClientReg = "BnS Taiwan";
                    }
                    break;
                case "JP":
                    if (sSettings.gJpnPath == false)
                    {
                        ClientFound = false;
                        ClientReg = "BnS Japan";
                    }
                    break;
                default:
                    break;
            }

            if (string.IsNullOrEmpty(sSettings.sRegion))
            {

                ClientFound = true;
                DialogResult dr = MessageBox.Show(msb_clinotset.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)
                {
                    Settings settings = new Settings();
                    settings.FormClosing += new FormClosingEventHandler(Settings_FormClosing);
                    settings.Show();
                }
            }
            if (ClientFound == false)
            {
                DialogResult dr = MessageBox.Show(ClientReg + msb_clinotfound, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)
                {
                    Settings settings = new Settings();
                    settings.FormClosing += new FormClosingEventHandler(Settings_FormClosing);
                    settings.Show();
                }
            }
        }

        private void InitI18N()
        {
            _i18N = BslI18NLoader.Instance;
            //MainFormTitle
            Text = _i18N.LoadI18NValue("Main", "title");
            //messagebox
            msb_clinotset = _i18N.LoadI18NValue("Main", "msb_clinotset");
            msb_clinotfound = _i18N.LoadI18NValue("Main", "msb_clinotfound");
            msb_slidererror = _i18N.LoadI18NValue("Main", "msb_slidererror");
            msb_emptypass = _i18N.LoadI18NValue("Main", "msb_emptypass");
            msb_emptymail = _i18N.LoadI18NValue("Main", "msb_emptymail");
            msb_mainterror = _i18N.LoadI18NValue("Main", "msb_mainterror");
            //buttons
            btn_patcher.Text = _i18N.LoadI18NValue("Main", "btn_patcher");
            btn_settings.Text = _i18N.LoadI18NValue("Main", "btn_settings");
            btn_slider.Text = _i18N.LoadI18NValue("Main", "bnt_slider");
            btn_play.Text = _i18N.LoadI18NValue("Main", "Btn_play");
            btn_Login.Text = _i18N.LoadI18NValue("Main", "Btn_login");
            //labels
            lb_mail.Text = _i18N.LoadI18NValue("Main", "lb_mail");
            lb_pass.Text = _i18N.LoadI18NValue("Main", "lb_pass");
            lb_region.Text = _i18N.LoadI18NValue("Main", "lb_region");
            lb_loginstsdone = _i18N.LoadI18NValue("Main", "lb_loginstsdone");

            //checkboxes
            cbox_Smail.Text = _i18N.LoadI18NValue("Main", "cbox_Smail");
            cbox_Spass.Text = _i18N.LoadI18NValue("Main", "cbox_Spass");
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            //NC West login
            string SavedMail = "";
            string SavedPass = "";

            switch (sSettings.sRegion)
            {
                case "EN":
                    SavedMail = Settings.IniReadValue("Account", "Mail");
                    SavedPass = Settings.IniReadValue("Account", "Password");

                    if (!LauncherInfo())//
                        Close();
                    RegionCB.DataSource = regions;
                    box_Login.Visible = true;
                    btn_play.Enabled = false;
                    lb_region.Visible = true;
                    RegionCB.Visible = true;
                    break;
                case "KR":
                    SavedMail = Settings.IniReadValue("KrAccount", "Mail");
                    SavedPass = Settings.IniReadValue("KrAccount", "Password");

                    if (!LauncherInfo())//
                        Close();
                    box_Login.Visible = true;
                    btn_play.Enabled = false;
                    lb_region.Visible = false;
                    RegionCB.Visible = false;
                    break;
                default:
                    box_Login.Visible = false;
                    btn_play.Enabled = true;
                    break;
            }


            if (string.IsNullOrWhiteSpace(SavedPass))
            {
                cbox_Smail.Checked = false;
            }
            else
            {
                txb_Mail.Text = Dec(SavedMail);
                cbox_Smail.Checked = true;
            }

            if (string.IsNullOrWhiteSpace(SavedPass))
            {
                cbox_Spass.Checked = false;
            }
            else
            {
                txb_Pass.Text = Dec(SavedPass);
                cbox_Spass.Checked = true;
            }
        }

        private void Btn_play_Click(object sender, EventArgs e)
        {
            UseAllCores = !(sSettings.sUseAllCores == "true") ? "" : " -USEALLAVAILABLECORES";
            NoTextureStreaming = !(sSettings.sNoTextureStreaming == "true") ? "" : " -NOTEXTURESTREAMING";
            Unattended = !(sSettings.sUnattended == "true") ? "" : " -UNATTENDED";

            Process proc = new Process();
            string cliargs = "";

            switch (sSettings.sRegion)
            {
                case "JP":

                    if (sSettings.sInstallPath != null)
                    {
                        if (sSettings.sArchitecture == "0")
                            LaunchPath = Path.Combine(sSettings.sInstallPath, @"bin\Client.exe");
                        else
                            LaunchPath = Path.Combine(sSettings.sInstallPath, @"bin64\Client.exe");
                    }

                    // Generated by Nc Launcher /LaunchByLauncher /Sesskey /SessKey:"" /CompanyID:"14" /ChannelGroupIndex:"-1" 
                    cliargs = "/launchbylauncher /sesskey /CompanyID:" + "14" + "/ChannelGroupIndex:" + " - 1" + " /LoginMode 2 " + "" + UseAllCores + "" + Unattended + "" + NoTextureStreaming;

                    break;
                case "TW":
                    if (sSettings.sInstallPath != null)
                    {
                        if (sSettings.sArchitecture == "0")
                            LaunchPath = Path.Combine(sSettings.sInstallPath, @"bin\Client.exe");
                        else
                            LaunchPath = Path.Combine(sSettings.sInstallPath, @"bin64\Client.exe");
                    }

                    // generated by Nc Launcher /LaunchByLauncher  /AuthnToken:"" /SessKey:"" /ServiceRegion:"15" /AuthProviderCode:"np"  /NPServerAddr:"210.64.136.126:6600" /PresenceId:"TWBNS22"
                    cliargs = "/launchbylauncher /sesskey /ServiceRegion:" + "15" + "/ChannelGroupIndex:" + " - 1" + " /PresenceId:" + "TWBNS22" + " /LoginMode 2 " + "" + UseAllCores + "" + Unattended + "" + NoTextureStreaming;
                    break;
                case "KR":
                    if (sSettings.sServerType == "Live")
                    {
                        if (sSettings.sInstallPath != null)
                        {
                            if (sSettings.sArchitecture == "0")
                                LaunchPath = Path.Combine(sSettings.sInstallPath, @"bin\Client.exe");
                            else
                                LaunchPath = Path.Combine(sSettings.sInstallPath, @"bin64\Client.exe");
                        }
                        cliargs = "/launchbylauncher /AuthnToken:\"" + token + "\" /sesskey:\"" + token + "\" /ServiceRegion:\"0\" /AuthProviderCode:\"np\" /NPServerAddr:\"112.175.209.97:6600\" -lite:8 /PresenceId:\"BNS_KOR" + "" + UseAllCores + "" + Unattended + "" + NoTextureStreaming;
                    }
                    else if (sSettings.sServerType == "Test")
                    {
                        if (sSettings.sInstallPath != null)
                        {
                            if (sSettings.sArchitecture == "0")
                                LaunchPath = Path.Combine(sSettings.sInstallPath, @"bin\Client.exe");
                            else
                                LaunchPath = Path.Combine(sSettings.sInstallPath, @"bin64\Client.exe");
                        }
                        cliargs = "/launchbylauncher /AuthnToken:\"" + token + "\" /sesskey:\"" + token + "\" /ServiceRegion:\"0\" /AuthProviderCode:\"np\" /NPServerAddr:\"112.175.209.97:6600\" -lite:8 /PresenceId:\"BNS_KOR_TEST" + "" + UseAllCores + "" + Unattended + "" + NoTextureStreaming;
                    }

                    break;

                case "EN":
                    if (sSettings.sInstallPath != null)
                    {
                        if (sSettings.sArchitecture == "0")
                            LaunchPath = Path.Combine(sSettings.sInstallPath, @"bin\Client.exe");
                        else
                            LaunchPath = Path.Combine(sSettings.sInstallPath, @"bin64\Client.exe");
                    }

                    // generated by Nc Launcher /launchbylauncher /sesskey -lang:english /CompanyID:"12" /ChannelGroupIndex:"-1" /AuthnToken:"==" /AuthProviderCode:"np"  -lang:English -lite:2 -region:0
                    cliargs = "/launchbylauncher /sesskey -lang:english /CompanyID:\"12\" /ChannelGroupIndex:\"-1\" " + "/AuthnToken:\"" + token + "\" /sesskey /AuthProviderCode:\"np\"" + "-lang:" + sSettings.sLanguageID + " -lite:2 -region:" + currentValue + Unattended + "" + NoTextureStreaming + "" + UseAllCores + "";
                    break;

                default:
                    break;
            }

            try
            {
                proc.StartInfo.FileName = LaunchPath;
                proc.StartInfo.Arguments = cliargs;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = true;
                proc.Start();

                //kill ping thread enable login button and disable play button(west)
                if (worker != null && worker.IsBusy)
                {
                    LoginServer.Close();
                    worker.CancelAsync();
                    btn_play.Enabled = false;
                    btn_Login.Enabled = true;
                    lb_loginsts.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.FormClosing += new FormClosingEventHandler(Settings_FormClosing);
            settings.Show();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            string SavedMail = "";
            string SavedPass = "";

            txb_Mail.Text = "";
            txb_Pass.Text = "";
            //check region if west enable login box
            try
            {
                if (sSettings.sRegion == "EN")
                {
                    SavedMail = Settings.IniReadValue("Account", "Mail");
                    SavedPass = Settings.IniReadValue("Account", "Password");
                    if (!LauncherInfo())
                        Close();
                    RegionCB.DataSource = regions;
                    box_Login.Visible = true;
                    lb_region.Visible = true;
                    RegionCB.Visible = true;
                    //if open settings with logged account play button stay enabled
                    if (worker != null && worker.IsBusy)
                    {
                        btn_play.Enabled = true;
                    }
                    else
                    {
                        lb_loginsts.Text = "";
                        btn_Login.Enabled = true;//if change to other region and change back to NA enable login btn
                        btn_play.Enabled = false;
                    }
                }
                else if (sSettings.sRegion == "KR")
                {
                    SavedMail = Settings.IniReadValue("KrAccount", "Mail");
                    SavedPass = Settings.IniReadValue("KrAccount", "Password");
                    if (!LauncherInfo())
                        Close();
                    //RegionCB.DataSource = regions;
                    box_Login.Visible = true;
                    lb_region.Visible = false;
                    RegionCB.Visible = false;

                    //if open settings with logged account play button stay enabled
                    if (worker != null && worker.IsBusy)
                    {
                        btn_play.Enabled = true;
                    }
                    else
                    {
                        lb_loginsts.Text = "";
                        btn_Login.Enabled = true;//if change to other region and change back to NA enable login btn
                        btn_play.Enabled = false;
                    }
                }
                else
                {
                    //if not west or change region logged kill ping thread disable west login and enable play button
                    if (worker != null && worker.IsBusy)
                    {
                        LoginServer.Close();
                        worker.CancelAsync();
                    }
                    box_Login.Visible = false;
                    btn_play.Enabled = true;
                }
                if (string.IsNullOrWhiteSpace(SavedPass))
                {
                    cbox_Smail.Checked = false;
                }
                else
                {
                    txb_Mail.Text = Dec(SavedMail);
                    cbox_Smail.Checked = true;
                }

                if (string.IsNullOrWhiteSpace(SavedPass))
                {
                    cbox_Spass.Checked = false;
                }
                else
                {
                    txb_Pass.Text = Dec(SavedPass);
                    cbox_Spass.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Slider_Click(object sender, EventArgs e)
        {
            if (sSettings.sArchitecture == "0")
                new Slider.Slider_Form().Show();
            else
                MessageBox.Show(msb_slidererror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_patcher_Click(object sender, EventArgs e)
        {
            new Patcher().Show();
        }

        // NC login
        string Protect = "Basic Enc";

        string Enc(string s)
        {
            return Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes(s), Protect));
        }

        string Dec(string s)
        {
            return Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(s), Protect));
        }
        private void cbox_Smail_CheckedChanged(object sender, EventArgs e)
        {
            if (cbox_Smail.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(txb_Mail.Text))
                {

                    MessageBox.Show(msb_emptymail, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (sSettings.sRegion == "EN")
                        Settings.IniWriteValue("Account", "Mail", Enc(txb_Mail.Text));
                    else if (sSettings.sRegion == "KR")
                        Settings.IniWriteValue("KrAccount", "Mail", Enc(txb_Mail.Text));
                }
            }
        }
        private void cbox_Spass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbox_Spass.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(txb_Pass.Text))
                {
                    MessageBox.Show(msb_emptypass, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (sSettings.sRegion == "EN")
                        Settings.IniWriteValue("Account", "Password", Enc(txb_Pass.Text));
                    else if (sSettings.sRegion == "KR")
                        Settings.IniWriteValue("KrAccount", "Password", Enc(txb_Pass.Text));
                }
            }
        }

        private void txb_Mail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txb_Pass.Focus();
                e.Handled = true;
            }
        }
        private void txb_Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(this, new EventArgs());
            }
        }

        bool Debugging = false;

        BackgroundWorker worker;
        string username, password, epoch, pid, localIP;
        string token;
        string LoginIp, LoginProgramid;
        int LoginPort, counter;
        BNSXorEncryption xor;
        List<region> regions = new List<region>();
        string currentAppId, currentValue;

        public static BigInteger N = new BigInteger("E306EBC02F1DC69F5B437683FE3851FD9AAA6E97F4CBD42FC06C72053CBCED68EC570E6666F529C58518CF7B299B5582495DB169ADF48ECEB6D65461B4D7C75DD1DA89601D5C498EE48BB950E2D8D5E0E0C692D613483B38D381EA9674DF74D67665259C4C31A29E0B3CFF7587617260E8C58FFA0AF8339CD68DB3ADB90AAFEE");
        public static BigInteger P = new BigInteger("7A39FF57BCBFAA521DCE9C7DEFAB520640AC493E1B6024B95A28390E8F05787D");
        public static byte[] staticKey = Conversions.HexStr2Bytes("AC34F3070DC0E52302C2E8DA0E3F7B3E63223697555DF54E7122A14DBC99A3E8");
        public static BigInteger Two = new BigInteger(2);

        BigInteger privateKey;
        BigInteger exchangeKey = Two;
        BigInteger exchangeKeyServer, session, validate;

        SHA256 sha = SHA256.Create();
        byte[] key;
        TcpClient LoginServer;

        class region
        {
            public string name;
            public string value;
            public string appId;

            public region(string n, string v, string a)
            {
                name = n;
                value = v;
                appId = a;
            }
            public override string ToString()
            {
                return name;
            }
        }

        BigInteger GetKeyExchange()
        {
            if (exchangeKey == Two)
                exchangeKey = Two.modPow(privateKey, N);
            return exchangeKey;
        }

        BigInteger SHA256Hash2ArrayInverse(byte[] tmp1, byte[] tmp2)
        {
            BigInteger hash;
            byte[] combine = new byte[tmp1.Length + tmp2.Length];
            tmp1.CopyTo(combine, 0);
            tmp2.CopyTo(combine, tmp1.Length);
            byte[] buf = sha.ComputeHash(combine);
            byte[] res = IntegerReverse(buf);
            hash = new BigInteger(res);
            return hash;
        }

        unsafe byte[] IntegerReverse(byte[] buf)
        {
            byte[] res = new byte[buf.Length];
            for (int i = 0; i < res.Length / 4; i++)
            {
                fixed (byte* ptr = buf)
                {
                    fixed (byte* ptr2 = res)
                    {
                        int* src = (int*)ptr;
                        int* dst = (int*)ptr2;
                        dst[i] = src[res.Length / 4 - 1 - i];
                    }
                }
            }

            return res;
        }

        byte[] GenerateEncryptionKeyRoot(byte[] src)
        {
            int firstSize = src.Length;
            int startIndex = 0;
            byte[] half;
            byte[] dst = new byte[64];
            if (src.Length > 4)
            {
                do
                {
                    if (src[startIndex] == 0)
                        break;
                    firstSize--;
                    startIndex++;
                } while (firstSize > 4);

            }
            int size = firstSize >> 1;
            half = new byte[size];
            if (size > 0)
            {
                int index = startIndex + firstSize - 1;
                for (int i = 0; i < size; i++)
                {
                    half[i] = src[index];
                    index -= 2;
                }
            }
            byte[] hash = sha.ComputeHash(half, 0, size);
            for (int i = 0; i < 32; i++)
            {
                dst[2 * i] = hash[i];
            }
            if (size > 0)
            {
                int index = startIndex + firstSize - 2;
                for (int i = 0; i < size; i++)
                {
                    half[i] = src[index];
                    index -= 2;
                }
            }
            hash = sha.ComputeHash(half, 0, size);
            for (int i = 0; i < 32; i++)
            {
                dst[2 * i + 1] = hash[i];
            }
            return dst;
        }

        byte[] CombineBuffers(params byte[][] buffers)
        {
            int len = 0;
            foreach (byte[] i in buffers)
            {
                len += i.Length;
            }
            byte[] res = new byte[len];
            int index = 0;
            foreach (byte[] i in buffers)
            {
                i.CopyTo(res, index);
                index += i.Length;
            }
            return res;
        }

        byte[] Generate256BytesKey(byte[] src)
        {
            int v7 = 1;
            byte[] res = new byte[256];
            for (int i = 0; i < 256; i++)
                res[i] = (byte)i;
            int v6 = 0;
            int counter = 0;
            for (int i = 64; i > 0; i--)
            {
                int v9 = (v6 + src[counter] + res[v7 - 1]) & 0xFF;
                int v10 = res[v7 - 1];
                res[v7 - 1] = res[v9];
                int v8 = counter + 1;
                res[v9] = (byte)v10;
                if (v8 == src.Length)
                    v8 = 0;
                int v13 = v9 + src[v8];
                int v11 = v8 + 1;
                int v14 = v13 + res[v7];
                v13 = res[v7];
                int v12 = (byte)v14;
                res[v7] = res[v12];
                res[v12] = (byte)v13;
                if (v11 == src.Length)
                    v11 = 0;
                int v16 = (v12 + src[v11] + res[v7 + 1]) & 0xFF;
                int v17 = res[v7 + 1];
                res[v7 + 1] = res[v16];
                int v15 = v11 + 1;
                res[v16] = (byte)v17;
                if (v15 == src.Length)
                    v15 = 0;
                int v18 = v16 + src[v15];
                int v19 = res[v7 + 2];
                v6 = (v18 + res[v7 + 2]) & 0xFF;
                counter = v15 + 1;
                res[v7 + 2] = res[v6];
                res[v6] = (byte)v19;
                if (counter == src.Length)
                    counter = 0;
                v7 += 4;
            }
            return res;
        }

        public byte[][] GenerateKeyClient(BigInteger exchangeKey)
        {
            byte[] passwordHash = sha.ComputeHash(Encoding.ASCII.GetBytes(username + ":" + password));

            BigInteger hash1 = SHA256Hash2ArrayInverse(this.GetKeyExchange().getBytes(), exchangeKey.getBytes());

            BigInteger hash2 = SHA256Hash2ArrayInverse(session.getBytes(), passwordHash);

            BigInteger v27 = new BigInteger(exchangeKey.getBytes());
            BigInteger v25 = Two.modPow(hash2, N);
            v25 = (v25 * P) % N;
            while (v27 < v25)
                v27 += N;
            v27 -= v25;

            BigInteger v24 = ((hash1 * hash2) + privateKey) % N;
            BigInteger v21 = v27.modPow(v24, N);

            key = GenerateEncryptionKeyRoot(v21.getBytes());
            byte[] chash1 = sha.ComputeHash(CombineBuffers(staticKey, sha.ComputeHash(Encoding.ASCII.GetBytes(username)), session.getBytes(), this.GetKeyExchange().getBytes(), exchangeKey.getBytes(), key));
            byte[] chash2 = sha.ComputeHash(CombineBuffers(this.GetKeyExchange().getBytes(), chash1, key));
            key = Generate256BytesKey(key);

            return new byte[][] { chash1, chash2 };
        }
        private bool LauncherInfo()
        {
            //Get login server for BNS Info
            try
            {
                string patch_server = "";
                string game_id = "";

                #region Get Login Server Info
                if (sSettings.sRegion == "EN")
                {
                    patch_server = "updater.nclauncher.ncsoft.com";
                    game_id = "BnS";
                }
                else if (sSettings.sRegion == "KR")
                {
                    patch_server = "up4svr.ncupdate.com";
                    game_id = "ncLauncherS";
                }
                int port = 27500;
                MemoryStream ms = new MemoryStream();
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write((short)0);//place holder for length
                bw.Write((short)8);//packet identifer, in this case login server information
                bw.Write((byte)10);//seperator character
                bw.Write((byte)game_id.Length);//write length of string
                bw.Write(Encoding.ASCII.GetBytes(game_id));//write string
                bw.BaseStream.Position = 0;//go back to start to update length
                bw.Write((short)ms.Length);

                TcpClient client = new TcpClient(patch_server, port);

                localIP = ((IPEndPoint)client.Client.LocalEndPoint).Address.ToString();
                NetworkStream ns = client.GetStream();
                ns.Write(ms.ToArray(), 0, (int)ms.Length);
                bw.Close();
                ms.Close();
                bw = null;

                ms = new MemoryStream();
                BinaryReader br = new BinaryReader(ms);
                byte[] buffer = new byte[1024];
                int bytesRec = 0;

                //Read data sent back from patch server;
                do
                {
                    bytesRec = ns.Read(buffer, 0, buffer.Length);

                    if (bytesRec > 0)
                    {
                        ms.Write(buffer, 0, bytesRec);
                    }
                }
                while (bytesRec == buffer.Length);

                //Read Login Info
                ms.Position = 9; //skip to length of string sent back
                br.ReadBytes(br.ReadByte() + 1); //read string + next byte
                string xml = Encoding.UTF8.GetString(br.ReadBytes(br.ReadByte() + (128 * (br.ReadByte() - 1))));
                ns.Close();
                br.Close();
                ms.Close();
                #endregion
                xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<Settings>" + xml.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "").Replace("  ", "\r\n") + "\r\n</Settings>";
                LoginIp = Regex.Match(xml, "ip=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value;
                LoginPort = Int32.Parse(Regex.Match(xml, "port=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value);
                LoginProgramid = Regex.Match(xml, "programid=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value;
                //LoginAppid = Regex.Match(xml, "appid=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value;

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xml);
                if (sSettings.sRegion == "EN")
                {
                    foreach (XmlElement regionEle in xmldoc.SelectNodes("//region"))
                    {
                        regions.Add(new region(regionEle.Attributes["name"].Value, regionEle.Attributes["value"].Value, regionEle.Attributes["appid"].Value));
                    }
                }
                //MessageBox.Show(String.Format("IP: {0}\nPort: {1}\nProgramID: {2}\nAppID: {3}", LoginIp, LoginPort, LoginProgramid, LoginAppid));
            }
            catch (Exception ex)
            {
                MessageBox.Show(msb_mainterror);
                if (Debugging)
                    MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }
        private string Builder(string nameSpace, string function)
        {
            counter++;
            switch (nameSpace)
            {
                case "Sts":
                    {
                        switch (function)
                        {
                            case "Connect":
                                {
                                    string data = String.Format(
                                        "<Connect>\n" +
                                        "<ConnType>400</ConnType>\n" +
                                        "<Address>{0}</Address>\n" +
                                        "<ProductType>0</ProductType>\n" +
                                        "<AppIndex>1</AppIndex>\n" +
                                        "<Epoch>{1}</Epoch>\n" +
                                        "<Program>{2}</Program>\n" +
                                        "<Build>1001</Build>\n" +
                                        "<Process>{3}</Process>\n" +
                                        "</Connect>\n",
                                        localIP,
                                        epoch,
                                        LoginProgramid,
                                        pid);
                                    return string.Format("POST /Sts/Connect STS/1.0\r\nl:{0}\r\n\r\n{1}", data.Length, data);
                                }
                                break;
                            case "Ping":
                                {
                                    return "POST /Sts/Ping STS/1.0\r\nl:0\r\n\r\n";
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case "Auth":
                    {
                        switch (function)
                        {
                            case "LoginStart":
                                {
                                    string data = String.Format(
                                        "<Request>\n" +
                                        "<LoginName>{0}</LoginName>\n" +
                                        "</Request>\n",
                                        username
                                        );

                                    return string.Format("POST /Auth/LoginStart STS/1.0\r\ns:{4}\r\np:*{0} 0 1 0 {1}\r\nl:{2}\r\n\r\n{3}", localIP, epoch, data.Length, data, counter);
                                }
                                break;
                            case "KeyData":
                                {
                                    byte[][] values = GenerateKeyClient(exchangeKeyServer);
                                    MemoryStream ms = new MemoryStream();
                                    BinaryWriter bw = new BinaryWriter(ms);

                                    bw.Write(exchangeKey.getBytes().Length);
                                    bw.Write(exchangeKey.getBytes());
                                    bw.Write(values[0].Length);
                                    bw.Write(values[0]);

                                    validate = new BigInteger(values[1]);

                                    string data = String.Format(
                                        "<Request>\n" +
                                        "<KeyData>{0}</KeyData>\n" +
                                        "</Request>\n",
                                        Convert.ToBase64String(ms.ToArray())
                                        );

                                    bw.Close();
                                    ms.Close();

                                    return string.Format("POST /Auth/KeyData STS/1.0\r\ns:{4}\r\np:*{0} 0 1 0 {1}\r\nl:{2}\r\n\r\n{3}", localIP, epoch, data.Length, data, counter);
                                }
                                break;
                            case "LoginFinish":
                                {
                                    string data = "<Request>\n<Language>1</Language>\n</Request>\n";
                                    return string.Format("POST /Auth/LoginFinish STS/1.0\r\ns:{2}\r\nl:{0}\r\n\r\n{1}", data.Length, data, counter);
                                }
                                break;
                            case "RequestToken":
                                {
                                    string data = String.Format(
                                        "<Request>\n" +
                                        "<AppId>{0}</AppId>\n" +
                                        "</Request>\n",
                                         currentAppId);
                                    return string.Format("POST /Auth/RequestToken STS/1.0\r\ns:{2}\r\nl:{0}\r\n\r\n{1}", data.Length, data, counter);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

            return null;
        }

        private void Try_Connection(object sender, DoWorkEventArgs e)
        {
            try
            {

                LoginServer = new TcpClient(LoginIp, LoginPort);
                LoginServer.ReceiveBufferSize = 1024;
                NetworkStream ns = LoginServer.GetStream();
                ns.ReadTimeout = 60000;
                ns.ReadTimeout = 60000;

                DateTime lastSent = DateTime.Now;
                int pingInterval = 30;

                string packet = Builder("Sts", "Connect");
                ns.Write(Encoding.ASCII.GetBytes(packet), 0, packet.Length);

                packet = Builder("Auth", "LoginStart");
                ns.Write(Encoding.ASCII.GetBytes(packet), 0, packet.Length);

                MemoryStream ms = new MemoryStream();
                byte[] buffer = new byte[1024];
                int bytesRec = 0;

                //Read data sent back from login server
                do
                {
                    bytesRec = ns.Read(buffer, 0, buffer.Length);

                    if (bytesRec > 0)
                    {
                        ms.Write(buffer, 0, bytesRec);
                    }
                }
                while (bytesRec == buffer.Length);
                string reply = Encoding.ASCII.GetString(ms.ToArray());
                reply = reply.Split('\r')[0].Split(' ')[2];
                switch (reply)
                {
                    case "OK":
                        break;
                    case "ErrAccountNotFound":
                        MessageBox.Show("The provided email address wasn't found");
                        return;
                    default:
                        MessageBox.Show("Invalidly formated email");
                        return;
                }
                ms.Close();
                ms = new MemoryStream();
                do
                {
                    bytesRec = ns.Read(buffer, 0, buffer.Length);

                    if (bytesRec > 0)
                    {
                        ms.Write(buffer, 0, bytesRec);
                    }
                }
                while (bytesRec == buffer.Length);

                reply = Encoding.ASCII.GetString(ms.ToArray());
                ms.Close();
                reply = Regex.Match(reply, "<KeyData>([^<]*)</KeyData>", RegexOptions.IgnoreCase).Groups[1].Value;
                ms = new MemoryStream(Convert.FromBase64String(reply));
                BinaryReader br = new BinaryReader(ms);
                session = new BigInteger(br.ReadBytes(br.ReadInt32()));
                exchangeKeyServer = new BigInteger(br.ReadBytes(br.ReadInt32()));
                br.Close();
                ms.Close();

                packet = Builder("Auth", "KeyData");
                ns.Write(Encoding.ASCII.GetBytes(packet), 0, packet.Length);

                //Read data sent back from login server
                ms = new MemoryStream();
                do
                {
                    bytesRec = ns.Read(buffer, 0, buffer.Length);

                    if (bytesRec > 0)
                    {
                        ms.Write(buffer, 0, bytesRec);
                    }
                }
                while (bytesRec == buffer.Length);
                reply = Encoding.ASCII.GetString(ms.ToArray());
                reply = reply.Split('\r')[0].Split(' ')[2];
                switch (reply)
                {
                    case "OK":
                        break;
                    case "ErrBadPasswd":
                        MessageBox.Show("Wrong Password");
                        return;
                    case "ErrRiskMgmtDeclined":
                        MessageBox.Show("You have exceeded the number of attempts allowed.\r\nFor security reasons, login is temporarily disabled.\r\nPlease try again later.");
                        return;
                    default:
                        MessageBox.Show("Unknown Error: " + reply);
                        return;
                }
                ms.Close();
                ms = new MemoryStream();
                do
                {
                    bytesRec = ns.Read(buffer, 0, buffer.Length);

                    if (bytesRec > 0)
                    {
                        ms.Write(buffer, 0, bytesRec);
                    }
                }
                while (bytesRec == buffer.Length);

                reply = Encoding.ASCII.GetString(ms.ToArray());
                ms.Close();
                reply = Regex.Match(reply, "<KeyData>([^<]*)</KeyData>", RegexOptions.IgnoreCase).Groups[1].Value;
                ms = new MemoryStream(Convert.FromBase64String(reply));
                br = new BinaryReader(ms);
                buffer = br.ReadBytes(br.ReadInt32());

                if (new BigInteger(buffer) == validate)
                {
                    xor = new BNSXorEncryption(key);

                    packet = Builder("Auth", "LoginFinish");
                    buffer = Encoding.ASCII.GetBytes(packet);
                    buffer = xor.Encrypt(buffer, 0, buffer.Length);
                    ns.Write(buffer, 0, buffer.Length);

                    buffer = new byte[1024];
                    ms = new MemoryStream();
                    do
                    {
                        bytesRec = ns.Read(buffer, 0, buffer.Length);

                        if (bytesRec > 0)
                        {
                            ms.Write(buffer, 0, bytesRec);
                        }
                    }
                    while (bytesRec == buffer.Length);
                    buffer = ms.ToArray();
                    buffer = xor.Decrypt(buffer, 0, buffer.Length);

                    packet = Encoding.ASCII.GetString(buffer);
                    if (packet.Contains("<AuthType>8</AuthType>"))
                    {
                        MessageBox.Show("This launcher doesn't support IP Verification, please do so on the website or official launcher then try again");
                        return;
                    }
                    ms.Close();

                    buffer = new byte[1024];
                    ms = new MemoryStream();
                    do
                    {
                        bytesRec = ns.Read(buffer, 0, buffer.Length);

                        if (bytesRec > 0)
                        {
                            ms.Write(buffer, 0, bytesRec);
                        }
                    }
                    while (bytesRec == buffer.Length);
                    buffer = ms.ToArray();
                    buffer = xor.Decrypt(buffer, 0, buffer.Length);
                    ms.Close();

                    packet = Builder("Auth", "RequestToken");
                    buffer = Encoding.ASCII.GetBytes(packet);
                    buffer = xor.Encrypt(buffer, 0, buffer.Length);
                    ns.Write(buffer, 0, buffer.Length);

                    buffer = new byte[1024];
                    ms = new MemoryStream();
                    do
                    {
                        bytesRec = ns.Read(buffer, 0, buffer.Length);

                        if (bytesRec > 0)
                        {
                            ms.Write(buffer, 0, bytesRec);
                        }
                    }
                    while (bytesRec == buffer.Length);
                    buffer = ms.ToArray();
                    buffer = xor.Decrypt(buffer, 0, buffer.Length);
                    ms.Close();

                    reply = Encoding.ASCII.GetString(buffer);
                    token = Regex.Match(reply, "<AuthnToken>([^<]*)</AuthnToken>", RegexOptions.IgnoreCase).Groups[1].Value;
                    Action<bool> update = login_enable;
                    Invoke(update, true);
                }
                else
                {
                    MessageBox.Show("Negotiation Failed, please try again.");
                    key = null;
                }

                while (LoginServer.Connected)
                {
                    if (DateTime.Now >= lastSent.AddSeconds(pingInterval))
                    {
                        packet = Builder("Sts", "Ping");
                        buffer = Encoding.ASCII.GetBytes(packet);
                        if (key != null)
                        {
                            buffer = xor.Encrypt(buffer, 0, buffer.Length);
                        }
                        ns.Write(buffer, 0, buffer.Length);
                        lastSent = DateTime.Now;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown Network Error");
                if (Debugging)
                    MessageBox.Show(ex.ToString());
            }
        }

        void login_enable(bool yes)
        {
            btn_play.Enabled = yes;
            lb_loginsts.Text = lb_loginstsdone;
            btn_Login.Enabled = false;
        }

        public class BNSXorEncryption
        {
            byte[] encKey, decKey;
            int encCounter, decCounter, encSum, decSum;
            byte[] key;
            public BNSXorEncryption(byte[] keyInt)
            {
                key = keyInt;
            }

            public byte[] Encrypt(byte[] src, int offset, int len)
            {
                if (encKey == null)
                {
                    if (key != null)
                    {
                        encKey = new byte[key.Length];
                        key.CopyTo(encKey, 0);
                        encCounter = 0;
                    }
                    else
                        return null;
                }
                return BlockEncrypt(src, encKey, ref encCounter, ref encSum);
            }

            public byte[] Decrypt(byte[] src, int offset, int len)
            {
                if (decKey == null)
                {
                    if (key != null)
                    {
                        decKey = new byte[key.Length];
                        key.CopyTo(decKey, 0);
                        decCounter = 0;
                    }
                    else
                        return null;
                }
                return BlockEncrypt(src, decKey, ref decCounter, ref decSum);
            }

            byte[] BlockEncrypt(byte[] src, byte[] key, ref int counter, ref int sum)
            {
                for (int i = 0; i < src.Length; i++)
                {
                    int index = (counter + 1) & 0xFF;
                    counter = index;
                    int v11 = (sum + key[index]) & 0xFF;
                    sum = v11;
                    int v12 = key[index];
                    key[index] = key[v11];
                    key[v11] = (byte)v12;
                    src[i] = (byte)(src[i] ^ key[(key[sum] + key[counter]) & 0xFF]);
                }
                return src;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            btn_play.Enabled = false;

            if (worker != null && worker.IsBusy)
            {
                LoginServer.Close();
                worker.CancelAsync();
            }
            if (sSettings.sRegion == "EN")
            {
                currentAppId = ((region)RegionCB.SelectedValue).appId;
                currentValue = ((region)RegionCB.SelectedValue).value;
            }
            else if (sSettings.sRegion == "KR")
            {
                currentAppId = "B0D42105-0CB6-BC9F-3CB2-BE28A0662340";
            }
            //Set some variables that are going to be used
            epoch = ((long)(DateTime.UtcNow - new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds).ToString();
            username = txb_Mail.Text.ToLower();
            password = txb_Pass.Text;
            pid = Process.GetCurrentProcess().Id.ToString();
            privateKey = new BigInteger(sha.ComputeHash(BigInteger.genRandom(6).getBytes()));
            exchangeKey = Two;
            counter = 0;

            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Try_Connection;
            worker.RunWorkerAsync();
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //kill login thread(west)
            if (worker != null && worker.IsBusy)
            {
                LoginServer.Close();
                worker.CancelAsync();
            }

            if (sSettings.sRegion == "EN")
            {
                if (cbox_Smail.Checked == true)
                    Settings.IniWriteValue("Account", "Mail", Enc(txb_Mail.Text));
                if (cbox_Spass.Checked == true)
                    Settings.IniWriteValue("Account", "Password", Enc(txb_Pass.Text));
            }
            else if (sSettings.sRegion == "KR")
            {
                if (cbox_Smail.Checked == true)
                    Settings.IniWriteValue("KrAccount", "Mail", Enc(txb_Mail.Text));
                if (cbox_Spass.Checked == true)
                    Settings.IniWriteValue("KrAccount", "Password", Enc(txb_Pass.Text));
            }
        }
        // NC Login
    }
}