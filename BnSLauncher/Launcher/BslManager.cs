using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows.Forms;

namespace BnS_Launcher
{
    class BslManager
    {
        private static BslManager _instance;

        public const string PathConfig = "config/";

        public const string PathJsonSettings = PathConfig + "Settings.json";
        public const string PathI18N = PathConfig + "i18n-";


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
            Init();
        }
        private void Init()
        {
            SystemSettings = ReadJsonFile(PathJsonSettings);


            var lang = (string)SystemSettings["lang"];
            DataI18N = ReadJsonFile(PathI18N + lang + ".json");

            LanguageNames = new List<string>();
            LanguageNames.AddRange(new []
            {
                "简体中文", "English"
            });
            LanguageTypes = new List<string>();
            LanguageTypes.AddRange(new []
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

        public static void WriteJsonFile(string path, JObject json)
        {
            if (!File.Exists(path))
            {
                CreateFile(path);
            }
            try
            {
                File.WriteAllText(path, json.ToString(Formatting.Indented));
            }
            catch (IOException ex)
            {
                //BstLogger.Instance.Log(ex.ToString());
            }
        }
        public static void CreateFile(string path)
        {
            File.Create(path).Dispose();
        }
    }
}
