using System;
using System.IO;
using Microsoft.Win32;
using Ini;
using System.Windows.Forms;

class SettingsClass
{
    string installpath = "";
    string installpathregion = "";
    string modpath = "";
    string localcoockedpcpath = "";
    string notexturestreaming = "";
    string unnatended = "";
    string region = "";
    string languageid = "";
    string useallcores = "";
    string architeture = "";
    string servertype = "";
    string xmlsettings = "";

    IniFile fSettings = new IniFile(Environment.CurrentDirectory + "\\Settings.ini");

    //Declare a Name property of type string:
    public bool KorPath = false;
    public bool KorTestPath = false;
    public bool WstPath = false;
    public bool JpnPath = false;
    public bool TwnPath = false;

    string sKorPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR", "BaseDir", null);
    string sKorTestPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR_TEST", "BaseDir", null);
    string sWstPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCWest\BnS", "BaseDir", null);
    string sTwnPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCTaiwan\TWBNS22", "BaseDir", null);
    string sJpnPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_JPN", "BaseDir", null);

    public bool gKorPath
    {
        get
        {
            if (sKorPath != null)
                KorPath = true;
            return KorPath;
        }
        set { KorPath = value; }
    }

    public bool gKorTestPath
    {
        get
        {
            if (sKorTestPath != null)
                KorTestPath = true;
            return KorTestPath;
        }
        set
        { KorTestPath = value; }
    }

    public bool gWstPath
    {
        get
        {
            if (sWstPath != null)
                WstPath = true;
            return WstPath;
        }
        set
        { WstPath = value; }
    }

    public bool gTwnPath
    {
        get
        {
            if (sTwnPath != null)
                TwnPath = true;
            return TwnPath;
        }
        set
        { TwnPath = value; }
    }

    public bool gJpnPath
    {
        get
        {
            if (sJpnPath != null)
                JpnPath = true;

            return JpnPath;
        }
        set
        { JpnPath = value; }
    }
    public string sInstallPath
    {
        get { return installpath; }
        set { installpath = value; }
    }

    public string sInstallPathRegion
    {
        get { return installpathregion; }
        set { installpathregion = value; }
    }
    public string sModPath
    {
        get { return modpath; }
        set { modpath = value; }
    }
    public string sLocalCookedPCPath
    {
        get { return localcoockedpcpath; }
        set { localcoockedpcpath = value; }
    }
    public string sNoTextureStreaming
    {
        get
        {
            notexturestreaming = fSettings.IniReadValue("Settings", "NoTextureStreaming");
            return notexturestreaming;
        }
        set { notexturestreaming = value; }
    }
    public string sUnattended
    {
        get
        {
            unnatended = fSettings.IniReadValue("Settings", "Unattended");
            return unnatended;
        }
        set { unnatended = value; }
    }
    public string sRegion
    {
        get
        {
            region = fSettings.IniReadValue("Settings", "Region");
            try
            {
                switch (region)
                {
                    case "JP":
                        installpath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_JPN", "BaseDir", null);
                        installpathregion = @"contents\Local\NCJAPAN\";
                        localcoockedpcpath = Path.Combine(sInstallPath, sInstallPathRegion, @"JAPANESE\CookedPC\");
                        modpath = Path.Combine(sLocalCookedPCPath + @"mod\");
                        xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCJAPAN\ClientConfiguration.xml";
                        break;
                    case "TW":
                        installpath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCTaiwan\TWBNS22", "BaseDir", null);
                        installpathregion = @"contents\Local\NCTAIWAN\";
                        localcoockedpcpath = Path.Combine(sInstallPath, sInstallPathRegion, @"CHINESET\CookedPC\");
                        modpath = Path.Combine(sLocalCookedPCPath, @"mod\");
                        xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCTAIWAN\ClientConfiguration.xml";
                        break;
                    case "EN":
                        installpath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCWest\BnS", "BaseDir", null);
                        installpathregion = @"contents\Local\NCWEST\";
                        localcoockedpcpath = Path.Combine(sInstallPath, sInstallPathRegion, @"ENGLISH\CookedPC\");
                        modpath = Path.Combine(localcoockedpcpath, @"mod\");
                        xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCWEST\ClientConfiguration.xml";
                        break;
                    case "KR":
                        servertype = fSettings.IniReadValue("Settings", "ServerType");
                        if (servertype == "Live")
                        {
                            installpath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR", "BaseDir", null);
                            installpathregion = @"contents\local\NCSoft\";
                            modpath = Path.Combine(sInstallPath, sInstallPathRegion, @"korean\CookedPC\mod\");
                            localcoockedpcpath = Path.Combine(sInstallPath, @"contents\bns\CookedPC\");
                            xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCSOFT\ClientConfiguration.xml";
                        }
                        else if (servertype == "Test")
                        {
                            installpath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR_TEST", "BaseDir", null);
                            installpathregion = @"contents\local\NCSoft\";
                            modpath = Path.Combine(sInstallPath, sInstallPathRegion, @"korean\CookedPC\mod\");
                            localcoockedpcpath = Path.Combine(sInstallPath, @"contents\bns\CookedPC\");
                            xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCSOFT_TEST\ClientConfiguration.xml";
                        }
                        break;
                    default:
                        break;
                }
            }
            catch// (Exception ex)
            {
                // MessageBox.Show("Client not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //if(installpath != null)
            //    MessageBox.Show("Client not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return region;
        }
        set { region = value; }

    }
    public string sLanguageID
    {
        get
        {
            languageid = fSettings.IniReadValue("Settings", "language");
            return languageid;
        }
        set { languageid = value; }
    }
    public string sUseAllCores
    {
        get
        {
            useallcores = fSettings.IniReadValue("Settings", "UseAllCores");
            return useallcores;
        }
        set { useallcores = value; }
    }
    public string sArchitecture
    {
        get
        {
            architeture = fSettings.IniReadValue("Settings", "Architecture");
            return architeture;
        }
        set { architeture = value; }
    }
    public string sServerType
    {
        get { return servertype; }
        set { servertype = value; }
    }

    public string XmlSettings
    {
        get { return xmlsettings; }
        set { xmlsettings = value; }
    }
}