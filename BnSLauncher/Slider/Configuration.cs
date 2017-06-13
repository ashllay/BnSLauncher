using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BnS_Launcher.Slider
{
    public class Configuration
    {
        public List<SliderCategory> SliderGroups;

        public int BaseAddress { get; set; }
        public int BufferSize { get; set; } = 512;
        public byte[] ByteArray { get; set; }
        public string DefaultProfile { get; set; }
        public string Filename { get; set; }
        public int MemoryRange { get; set; }
        public string Module { get; set; }
        public List<int> Offsets { get; set; }
        public string ProcessName { get; set; }
        public List<Record> RecordList { get; set; }
        public string ScanType { get; set; }
        public List<Slider> SliderList { get; set; }
        public string WindowTitle { get; set; }

        public Configuration()
        {
        }

        public Configuration(string configFileName)
        {
            Filename = configFileName;
            Load();
        }

        private static int HexStringToInt(string str)
        {
            if (str.Equals(""))
            {
                return 0;
            }
            if (str.StartsWith("0x"))
            {
                str = str.Substring(2);
            }
            return Convert.ToInt32(str, 16);
        }

        public void Load()
        {
            Load(Filename);
        }

        public void Load(string filename)
        {
            int num;
            Offsets = new List<int>();
            XElement xElement = XElement.Load(filename);
            LoadProcessData(xElement);
            LoadSliders(xElement);
            LoadRecords(xElement);
            DefaultProfile = xElement.Element("DefaultProfile").Value;
            LoadByteArray(xElement);
            MemoryRange = HexStringToInt(xElement.Element("MemoryRange").Value);
            LoadSliderGroups(xElement);
            ScanType = xElement.Element("DefaultScan").Value;
            BufferSize = (int.TryParse(xElement.Element("BufferSize").Value, out num) ? num : BufferSize);
        }

        private void LoadByteArray(XElement xelem)
        {
            string value = xelem.Element("ByteArray").Value;
            byte[] num = new byte[value.Length / 2];
            for (int i = 0; i < num.Length; i++)
            {
                num[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
            }
            ByteArray = num;
        }

        private void LoadProcessData(XElement xelem)
        {
            ProcessName = xelem.Element("ProcessName").Value;
            Module = xelem.Element("Module").Value;
            BaseAddress = HexStringToInt(xelem.Element("BaseAddress").Value);
            WindowTitle = xelem.Element("WindowTitle").Value;
            try
            {
                foreach (XElement xElement in xelem.Element("OffsetList").Elements("Offset"))
                {
                    Offsets.Add(HexStringToInt(xElement.Value));
                }
            }
            catch (NullReferenceException nullReferenceException)
            {
            }
        }

        private void LoadRecords(XElement xelem)
        {
            RecordList = new List<Record>();
            foreach (XElement xElement in xelem.Element("Records").Elements("Record"))
            {
                string value = xElement.Element("Race").Value;
                string str = xElement.Element("Gender").Value;
                int num = HexStringToInt(xElement.Element("Offset").Value);
                RecordList.Add(new Record(value, str, num));
            }
        }

        private void LoadSliderGroups(XElement xelem)
        {
            SliderGroups = new List<SliderCategory>();
            foreach (XElement xElement in xelem.Element("Groups").Elements("Group"))
            {
                SliderCategory sliderCategory = new SliderCategory(xElement.Attribute("description").Value)
                {
                    Ids = new List<int>()
                };
                foreach (XElement xElement1 in xElement.Elements("Value"))
                {
                    sliderCategory.Ids.Add(int.Parse(xElement1.Attribute("id").Value));
                }
                SliderGroups.Add(sliderCategory);
            }
        }

        private void LoadSliders(XElement xelem)
        {
            SliderList = new List<Slider>();
            foreach (XElement xElement in xelem.Element("Values").Elements("Value"))
            {
                int num = Convert.ToInt32(xElement.Attribute("id").Value);
                string value = xElement.Attribute("description").Value;
                SliderList.Add(new Slider(value, num));
            }
        }

        public bool Save(string filename)
        {
            XElement scanType = XElement.Load(filename);
            scanType.Element("DefaultScan").Value = ScanType;
            scanType.Element("BufferSize").Value = BufferSize.ToString();
            scanType.Element("DefaultProfile").Value = DefaultProfile;
            scanType.Save(Filename);
            return true;
        }
    }
}
