using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace BnS_Launcher
{
    class BslManager
    {
        private static BslManager _instance;

        public const string PathConfig = "config/";

        public const string PathJsonSettings = BslManager.PathConfig + "setting.json";
        public const string PathI18N = BslManager.PathConfig + "i18n-";


        public JObject SystemSettings { get; set; }
        public JObject DataI18N { get; set; }
        public List<string> LanguageNames { get; set; }
        public List<string> LanguageTypes { get; set; }

        public static BslManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BslManager();
                }
                return _instance;
            }
        }

        private BslManager()
        {
            this.Init();
        }
        private void Init()
        {
            this.SystemSettings = BslManager.ReadJsonFile(BslManager.PathJsonSettings);


            var lang = (string)this.SystemSettings["lang"];
            this.DataI18N = BslManager.ReadJsonFile(BslManager.PathI18N + lang + ".json");

            this.LanguageNames = new List<string>();
            this.LanguageNames.AddRange(new String[]
            {
                "简体中文", "English"
            });
            this.LanguageTypes = new List<string>();
            this.LanguageTypes.AddRange(new String[]
            {
                "zh_CN", "en_US"
            });
        }

        public static JObject ReadJsonFile(string path)
        {
            var content = (JObject)JToken.ReadFrom(new JsonTextReader(File.OpenText(path)));
            //BstLogger.Instance.Log("Json file loaded: " + path);

            return content;
        }
    }
}
