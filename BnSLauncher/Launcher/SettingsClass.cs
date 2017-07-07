﻿using System;
using System.IO;
using Microsoft.Win32;
using BnS_Launcher.lib;

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
    //
    public bool KorPath = false;
    public bool KorTestPath = false;
    public bool WstPath = false;
    public bool JpnPath = false;
    public bool TwnPath = false;
    //
    IniFile fSettings = new IniFile(Environment.CurrentDirectory + "\\Settings.ini");

    string sKorPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR", "BaseDir", null);
    string sKorTestPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR_TEST", "BaseDir", null);
    string sWstPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCWest\BnS", "BaseDir", null);
    string sTwnPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCTaiwan\TWBNS22", "BaseDir", null);
    string sJpnPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_JPN", "BaseDir", null);

    string usekrcustompathlive = "";
    string usekrcustompathtest = "";
    string usewstcustompath = "";
    string usetwncustompath = "";
    string usejpncustompath = "";

    string cskorlivepath = "";
    string cskortestpath = "";
    string cswstpath = "";
    string cstwnpath = "";
    string csjpnpath = "";

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
            cswstpath = fSettings.IniReadValue("Path", "WEST");
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
            try
            {
                switch (region)
                {
                    case "JP":
                        if (usejpncustompath == "true")
                        {
                            if (!string.IsNullOrEmpty(csjpnpath))
                                installpath = csjpnpath;
                        }
                        else
                            installpath = sJpnPath;
                        installpathregion = @"contents\Local\NCJAPAN\";
                        localcoockedpcpath = Path.Combine(sInstallPath, sInstallPathRegion, @"JAPANESE\CookedPC\");
                        modpath = Path.Combine(sLocalCookedPCPath + @"mod\");
                        xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCJAPAN\ClientConfiguration.xml";
                        break;
                    case "TW":
                        if (usetwncustompath == "true")
                        {
                            if (!string.IsNullOrEmpty(cstwnpath))
                                installpath = cstwnpath;
                        }
                        else
                            installpath = sTwnPath;
                        installpathregion = @"contents\Local\NCTAIWAN\";
                        localcoockedpcpath = Path.Combine(sInstallPath, sInstallPathRegion, @"CHINESET\CookedPC\");
                        modpath = Path.Combine(sLocalCookedPCPath, @"mod\");
                        xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCTAIWAN\ClientConfiguration.xml";
                        break;
                    case "EN":
                        if (usewstcustompath == "true")
                        {
                            if (!string.IsNullOrEmpty(cstwnpath))
                                installpath = cstwnpath;
                        }
                        else
                            installpath = sWstPath;
                        installpathregion = @"contents\Local\NCWEST\";
                        localcoockedpcpath = Path.Combine(sInstallPath, sInstallPathRegion, @"ENGLISH\CookedPC\");
                        modpath = Path.Combine(localcoockedpcpath, @"mod\");
                        xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCWEST\ClientConfiguration.xml";
                        break;
                    case "KR":
                        servertype = fSettings.IniReadValue("Settings", "ServerType");
                        if (servertype == "Live")
                        {
                            if (usekrcustompathlive == "true")
                            {
                                if (!string.IsNullOrEmpty(cskorlivepath))
                                    installpath = cskorlivepath;
                            }
                            else
                                installpath = sKorPath;
                            installpathregion = @"contents\local\NCSoft\";
                            modpath = Path.Combine(sInstallPath, sInstallPathRegion, @"korean\CookedPC\mod\");
                            localcoockedpcpath = Path.Combine(sInstallPath, @"contents\bns\CookedPC\");
                            xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCSOFT\ClientConfiguration.xml";
                        }
                        else if (servertype == "Test")
                        {
                            if (usekrcustompathtest == "true")
                            {
                                if (!string.IsNullOrEmpty(cskortestpath))
                                    installpath = cskortestpath;
                            }
                            else
                                installpath = sKorTestPath;
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
            catch { }
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