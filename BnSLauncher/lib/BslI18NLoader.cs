using System;
using Newtonsoft.Json.Linq;


namespace BnS_Launcher.lib
{
    class BslI18NLoader
    {
        private static BslI18NLoader _instance;

        public static BslI18NLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BslI18NLoader();
                }
                return _instance;
            }
        }

        private JObject _i18n;

        private BslI18NLoader()
        {
            this._i18n = BslManager.Instance.DataI18N;
        }

        public string LoadI18NValue(string uiClassName, string key)
        {
            try
            {
                return (string)this._i18n[uiClassName][key];
            }
            catch (Exception ex)
            {
                //BstLogger.Instance.Log(ex.ToString());
                return null;
            }
        }
    }
}
