using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

    // Declare a Name property of type string:
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
        get { return notexturestreaming; }
        set { notexturestreaming = value; }
    }
    public string sUnattended
    {
        get { return unnatended; }
        set { unnatended = value; }
    }
    public string sRegion
    {
        get { return region; }
        set { region = value; }
    }
    public string sLanguageID
    {
        get { return languageid; }
        set { languageid = value; }
    }
    public string sUseAllCores
    {
        get { return useallcores; }
        set { useallcores = value; }
    }
    public string sArchitecture
    {
        get { return architeture; }
        set { architeture = value; }
    }

    public string sServerType
    {
        get { return servertype; }
        set { servertype = value; }
    }
}
