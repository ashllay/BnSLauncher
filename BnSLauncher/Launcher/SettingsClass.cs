using System;
using System.IO;
using Microsoft.Win32;
using BnS_Launcher.lib;

class SettingsClass
{
    //
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
    //
    bool KorPath;
    bool KorTestPath;
    bool WstPath;
    bool JpnPath;
    bool TwnPath;
    //
    IniFile fSettings = new IniFile(Environment.CurrentDirectory + "\\Settings.ini");
    //
    string sKorPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR", "BaseDir", null);
    string sKorTestPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR_TEST", "BaseDir", null);
    string sWstPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCWest\BnS", "BaseDir", null);
    string sTwnPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCTaiwan\TWBNS22", "BaseDir", null);
    string sJpnPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_JPN", "BaseDir", null);
    //
    string usekrcustompathlive = "";
    string usekrcustompathtest = "";
    string usewstcustompath = "";
    string usetwncustompath = "";
    string usejpncustompath = "";
    //
    string cskorlivepath = "";
    string cskortestpath = "";
    string cswstpath = "";
    string cstwnpath = "";
    string csjpnpath = "";

    public bool gKorLivePath
    {
        get
        {
            if (sKorPath != null || !string.IsNullOrEmpty(csKorLivePath))
                KorPath = true;
            //else
            //    KorPath = false;
            return KorPath;
        }
        set { KorPath = value; }
    }

    public bool gKorTestPath
    {
        get
        {
            if (sKorTestPath != null || !string.IsNullOrEmpty(csKorTestPath))
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
            if (sWstPath != null || !string.IsNullOrEmpty(csWstPath))
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
            if (sTwnPath != null || !string.IsNullOrEmpty(csTwnPath))
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
            if (sJpnPath != null || !string.IsNullOrEmpty(csJpnPath))
                JpnPath = true;
            return JpnPath;
        }
        set
        { JpnPath = value; }
    }
    public string sInstallPath
    {
        get
        {
            try
            {
                switch (sRegion)
                {
                    case "JP":
                        if (useJpnCustomPath == "true")
                        {
                            if (!string.IsNullOrEmpty(csJpnPath))
                                installpath = csJpnPath;
                            else
                                JpnPath = false;
                        }
                        else
                            installpath = sJpnPath;
                        break;
                    case "TW":
                        if (useTwnCustomPath == "true")
                        {
                            if (!string.IsNullOrEmpty(csTwnPath))
                                installpath = csTwnPath;
                            else
                                TwnPath = false;
                        }
                        else
                            installpath = sTwnPath;
                        break;
                    case "EN":
                        if (useWstCustomPath == "true")
                        {
                            if (!string.IsNullOrEmpty(csWstPath))
                                installpath = csWstPath;
                            else
                                TwnPath = false;
                        }
                        else
                            installpath = sWstPath;
                        break;
                    case "KR":
                        if (sServerType == "Live")
                        {
                            if (useKrCustomPathLive == "true")
                            {
                                if (!string.IsNullOrEmpty(csKorLivePath))
                                    installpath = csKorLivePath;
                                else
                                    KorPath = false;
                            }
                            else
                                installpath = sKorPath;
                        }
                        else if (sServerType == "Test")
                        {
                            if (useKrCustomPathTest == "true")
                            {
                                if (!string.IsNullOrEmpty(csKorTestPath))
                                    installpath = csKorTestPath;
                                else
                                KorTestPath = false;
                            }
                            else
                                installpath = sKorTestPath;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch { }
            return installpath;
        }
        set { installpath = value; }
    }

    public string sInstallPathRegion
    {
        get
        {
            switch (sRegion)
            {
                case "JP":
                    installpathregion = @"contents\Local\NCJAPAN\";
                    break;
                case "TW":
                    installpathregion = @"contents\Local\NCTAIWAN\";
                    break;
                case "EN":
                    installpathregion = @"contents\Local\NCWEST\";
                    break;
                case "KR":
                    installpathregion = @"contents\local\NCSoft\";
                    break;
                default:
                    break;
            }
            return installpathregion;
        }
        set { installpathregion = value; }
    }
    public string sModPath
    {
        get
        {
            switch (sRegion)
            {
                case "JP":
                    modpath = Path.Combine(sLocalCookedPCPath, @"mod\");
                    break;
                case "TW":
                    modpath = Path.Combine(sLocalCookedPCPath, @"mod\");
                    break;
                case "EN":
                    modpath = Path.Combine(sLocalCookedPCPath, @"mod\");
                    break;
                case "KR":
                    modpath = Path.Combine(sInstallPath, sInstallPathRegion, @"korean\CookedPC\mod\");
                    break;
                default:
                    break;
            }
            return modpath;
        }
        set { modpath = value; }
    }
    public string sLocalCookedPCPath
    {
        get
        {
            try
            {
                switch (sRegion)
                {
                    case "JP":
                        localcoockedpcpath = Path.Combine(sInstallPath, sInstallPathRegion, @"JAPANESE\CookedPC\");
                        break;
                    case "TW":
                        localcoockedpcpath = Path.Combine(sInstallPath, sInstallPathRegion, @"CHINESET\CookedPC\");
                        break;
                    case "EN":
                        localcoockedpcpath = Path.Combine(sInstallPath, sInstallPathRegion, @"ENGLISH\CookedPC\");
                        break;
                    case "KR":
                        localcoockedpcpath = Path.Combine(sInstallPath, @"contents\bns\CookedPC\");
                        break;
                    default:
                        break;
                }
            }
            catch { }
            return localcoockedpcpath;
        }
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

    public string csKorLivePath
    {
        get
        {
            cskorlivepath = fSettings.IniReadValue("Path", "KR_Live");
            return cskorlivepath;
        }
        set { cskorlivepath = value; }
    }

    public string csKorTestPath
    {
        get
        {
            cskortestpath = fSettings.IniReadValue("Path", "KR_Test");
            return cskortestpath;
        }
        set { cskortestpath = value; }
    }

    public string csWstPath
    {
        get
        {
            cswstpath = fSettings.IniReadValue("Path", "EN");
            return cswstpath;
        }
        set { cswstpath = value; }
    }

    public string csTwnPath
    {
        get
        {
            cstwnpath = fSettings.IniReadValue("Path", "TW");
            return cstwnpath;
        }
        set { cstwnpath = value; }
    }

    public string csJpnPath
    {
        get
        {
            csjpnpath = fSettings.IniReadValue("Path", "JP");
            return csjpnpath;
        }
        set { csjpnpath = value; }
    }
    public string useKrCustomPathLive
    {
        get
        {
            usekrcustompathlive = fSettings.IniReadValue("Path", "KR_Live_UseCustomPath");
            return usekrcustompathlive;
        }
        set
        { usekrcustompathlive = value; }
    }
    public string useKrCustomPathTest
    {
        get
        {
            usekrcustompathtest = fSettings.IniReadValue("Path", "KR_Test_UseCustomPath");
            return usekrcustompathtest;
        }
        set
        { usekrcustompathtest = value; }
    }

    public string useWstCustomPath
    {
        get
        {
            usewstcustompath = fSettings.IniReadValue("Path", "EN_UseCustomPath");
            return usewstcustompath;
        }
        set
        { usewstcustompath = value; }
    }

    public string useTwnCustomPath
    {
        get
        {
            usetwncustompath = fSettings.IniReadValue("Path", "TW_UseCustomPath");
            return usetwncustompath;
        }
        set
        { usetwncustompath = value; }
    }

    public string useJpnCustomPath
    {
        get
        {
            usejpncustompath = fSettings.IniReadValue("Path", "JP_UseCustomPath");
            return usejpncustompath;
        }
        set
        { usejpncustompath = value; }
    }

    public string sRegion
    {
        get
        {
            region = fSettings.IniReadValue("Settings", "Region");
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
        get
        {
            servertype = fSettings.IniReadValue("Settings", "ServerType");
            return servertype;
        }
        set { servertype = value; }
    }

    public string XmlSettings
    {
        get
        {
            try
            {
                switch (sRegion)
                {
                    case "JP":
                        xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCJAPAN\ClientConfiguration.xml";
                        break;
                    case "TW":
                        xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCTAIWAN\ClientConfiguration.xml";
                        break;
                    case "EN":
                        xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCWEST\ClientConfiguration.xml";
                        break;
                    case "KR":
                        if (sServerType == "Live")
                            xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCSOFT\ClientConfiguration.xml";
                        else if (sServerType == "Test")
                            xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCSOFT_TEST\ClientConfiguration.xml";
                        break;
                    default:
                        break;
                }
            }
            catch { }
            return xmlsettings;

        }
        set { xmlsettings = value; }
    }
}