using System;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace BnS_Launcher
{
    public partial class SliderEditor : Form
    {
        private string Race, Sex;
        string sMin = "-1.00";
        string sMax = "1.00";

        string xmlFile = "";
        string XmlFilePath = "";
        string DatPath = "";
        string XmlFileName = "";

        public static bool xCompile;

        SettingsClass sSettings = new SettingsClass();

        public SliderEditor()
        {
            InitializeComponent();
        }

        private void SliderEditor_Load(object sender, EventArgs e)
        {
            if (sSettings.sArchitecture == "0")
                XmlFileName = "xml.dat";
            else
                XmlFileName = "xml64.dat";

            if (sSettings.sInstallPath != null)
                DatPath = Path.Combine(sSettings.sInstallPath, sSettings.sInstallPathRegion, @"data\");

            XmlFilePath = Path.Combine(DatPath, XmlFileName);
            xmlFile = XmlFilePath + @".files\engine\characterdefvaluedata.xml";
        }

        void txBoxSet()
        {
            //max
            TextBox[] MaxTarray = {
                txbPelvisWidMax, txbNekThicMax, txbNeckLenMax, txbShoulderHeiMax, txbShoulderWidMax,
                txbShoulderSizMax, txbArmThicMax, txbArmLenMax, txbHandSizMax, txbHandLenMax,
                txbFootSizMax, txbPelvisThickMax, txbBuildMax, txbHeigthMax, txbHeadSizMax,
                txbChestHeiMax, txbChestWidMax, txbChestSizMax, txbHeadWidMax, txbWaisThicMax,
                txbWaisLenMax, txbThigthWidMax, txbCalfWidMax, txbThighLenMax, txbCalfLenMax,
                txbTorsoSizMax
            };
            foreach (TextBox t in MaxTarray)
            {
                t.Text = sMax;
            }
            //min
            TextBox[] MinTarray = {
                txbPelvisWidMin, txbNeckLenMin, txbNekThicMin, txbShoulderHeiMin, txbShoulderWidMin,
                txbShoulderSizMin, txbArmThicMin, txbArmLenMin, txbHandSizMin, txbHandLenMin,
                txbFootSizMin, txbPelvisThickMin, txbBuildMin, txbHeigthMin, txbHeadSizMin,
                txbChestHeiMin, txbChestWidMin, txbChestSizMin, txbHeadWidMin, txbWaisThicMin,
                txbWaisLenMin, txbThigthWidMin, txbCalfWidMin, txbThighLenMin, txbCalfLenMin,
                txbTorsoSizMin
            };

            foreach (TextBox t in MinTarray)
            {
                t.Text = sMin;
            }
        }

        void XmlManager(string xFile, string xRace, string xSex, bool xWrite)
        {
            /* 1 = Pelvis Width,	2 = Pelvis Thickness
            3 = Waist Thickness,	4 = Waist Length
            5 = Thigh Width,	6 = Calf Width
            7 = Thigh Length,	8 = Calf Length
            9 = Torso Size,	10 = Neck Thickness
            11 = Neck Length,	12 = Shoulder Height
            13 = Shoulder Width,	14 = Shoulder Size
            15 = Arm Thickness,	16 = Arm Length
            17 = Hand Size,	18 = Hand Length
            19 = Foot Size,	20 = Body Build(weight)
            21 = Height,	22 = Head Size
            23 = Chest Height/separation(x)(lower or negative value = sag)
            24 = Chest Width/position(y)(distance between the breasts)
            25 = Chest Size,	26 = Head Width*/
            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//  

            XmlReader creader = XmlReader.Create(xmlFile, settings);
            xmlDoc.Load(creader);

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("table").ChildNodes;//

            foreach (XmlNode xn in nodeList)// 
            {
                XmlElement xe = (XmlElement)xn;//

                if (xe.GetAttribute("race") == xRace && xe.GetAttribute("sex") == xSex && xe.GetAttribute("table-type") == "bodycustom")// 
                {
                    try
                    {
                        if (!xWrite)
                        {
                            //max
                            txbPelvisWidMax.Text = xe.GetAttribute("body-custom-max-1");
                            txbNekThicMax.Text = xe.GetAttribute("body-custom-max-10");
                            txbNeckLenMax.Text = xe.GetAttribute("body-custom-max-11");
                            txbShoulderHeiMax.Text = xe.GetAttribute("body-custom-max-12");
                            txbShoulderWidMax.Text = xe.GetAttribute("body-custom-max-13");
                            txbShoulderSizMax.Text = xe.GetAttribute("body-custom-max-14");
                            txbArmThicMax.Text = xe.GetAttribute("body-custom-max-15");
                            txbArmLenMax.Text = xe.GetAttribute("body-custom-max-16");
                            txbHandSizMax.Text = xe.GetAttribute("body-custom-max-17");
                            txbHandLenMax.Text = xe.GetAttribute("body-custom-max-18");
                            txbFootSizMax.Text = xe.GetAttribute("body-custom-max-19");
                            txbPelvisThickMax.Text = xe.GetAttribute("body-custom-max-2");
                            txbBuildMax.Text = xe.GetAttribute("body-custom-max-20");
                            txbHeigthMax.Text = xe.GetAttribute("body-custom-max-21");
                            txbHeadSizMax.Text = xe.GetAttribute("body-custom-max-22");
                            txbChestHeiMax.Text = xe.GetAttribute("body-custom-max-23");
                            txbChestWidMax.Text = xe.GetAttribute("body-custom-max-24");
                            txbChestSizMax.Text = xe.GetAttribute("body-custom-max-25");
                            txbHeadWidMax.Text = xe.GetAttribute("body-custom-max-26");
                            txbWaisThicMax.Text = xe.GetAttribute("body-custom-max-3");
                            txbWaisLenMax.Text = xe.GetAttribute("body-custom-max-4");
                            txbThigthWidMax.Text = xe.GetAttribute("body-custom-max-5");
                            txbCalfWidMax.Text = xe.GetAttribute("body-custom-max-6");
                            txbThighLenMax.Text = xe.GetAttribute("body-custom-max-7");
                            txbCalfLenMax.Text = xe.GetAttribute("body-custom-max-8");
                            txbTorsoSizMax.Text = xe.GetAttribute("body-custom-max-9");
                            //min
                            txbPelvisWidMin.Text = xe.GetAttribute("body-custom-min-1");
                            txbNekThicMin.Text = xe.GetAttribute("body-custom-min-10");
                            txbNeckLenMin.Text = xe.GetAttribute("body-custom-min-11");
                            txbShoulderHeiMin.Text = xe.GetAttribute("body-custom-min-12");
                            txbShoulderWidMin.Text = xe.GetAttribute("body-custom-min-13");
                            txbShoulderSizMin.Text = xe.GetAttribute("body-custom-min-14");
                            txbArmThicMin.Text = xe.GetAttribute("body-custom-min-15");
                            txbArmLenMin.Text = xe.GetAttribute("body-custom-min-16");
                            txbHandSizMin.Text = xe.GetAttribute("body-custom-min-17");
                            txbHandLenMin.Text = xe.GetAttribute("body-custom-min-18");
                            txbFootSizMin.Text = xe.GetAttribute("body-custom-min-19");
                            txbPelvisThickMin.Text = xe.GetAttribute("body-custom-min-2");
                            txbBuildMin.Text = xe.GetAttribute("body-custom-min-20");
                            txbHeigthMin.Text = xe.GetAttribute("body-custom-min-21");
                            txbHeadSizMin.Text = xe.GetAttribute("body-custom-min-22");
                            txbChestHeiMin.Text = xe.GetAttribute("body-custom-min-23");
                            txbChestWidMin.Text = xe.GetAttribute("body-custom-min-24");
                            txbChestSizMin.Text = xe.GetAttribute("body-custom-min-25");
                            txbHeadWidMin.Text = xe.GetAttribute("body-custom-min-26");
                            txbWaisThicMin.Text = xe.GetAttribute("body-custom-min-3");
                            txbWaisLenMin.Text = xe.GetAttribute("body-custom-min-4");
                            txbThigthWidMin.Text = xe.GetAttribute("body-custom-min-5");
                            txbCalfWidMin.Text = xe.GetAttribute("body-custom-min-6");
                            txbThighLenMin.Text = xe.GetAttribute("body-custom-min-7");
                            txbCalfLenMin.Text = xe.GetAttribute("body-custom-min-8");
                            txbTorsoSizMin.Text = xe.GetAttribute("body-custom-min-9");
                        }
                        else
                        {  //max
                            xe.SetAttribute("body-custom-max-1", txbPelvisWidMax.Text);
                            xe.SetAttribute("body-custom-max-10", txbNekThicMax.Text);
                            xe.SetAttribute("body-custom-max-11", txbNeckLenMax.Text);
                            xe.SetAttribute("body-custom-max-12", txbShoulderHeiMax.Text);
                            xe.SetAttribute("body-custom-max-13", txbShoulderWidMax.Text);
                            xe.SetAttribute("body-custom-max-14", txbShoulderSizMax.Text);
                            xe.SetAttribute("body-custom-max-15", txbArmThicMax.Text);
                            xe.SetAttribute("body-custom-max-16", txbArmLenMax.Text);
                            xe.SetAttribute("body-custom-max-17", txbHandSizMax.Text);
                            xe.SetAttribute("body-custom-max-18", txbHandLenMax.Text);
                            xe.SetAttribute("body-custom-max-19", txbFootSizMax.Text);
                            xe.SetAttribute("body-custom-max-2", txbPelvisThickMax.Text);
                            xe.SetAttribute("body-custom-max-20", txbBuildMax.Text);
                            xe.SetAttribute("body-custom-max-21", txbHeigthMax.Text);
                            xe.SetAttribute("body-custom-max-22", txbHeadSizMax.Text);
                            xe.SetAttribute("body-custom-max-23", txbChestHeiMax.Text);
                            xe.SetAttribute("body-custom-max-24", txbChestWidMax.Text);
                            xe.SetAttribute("body-custom-max-25", txbChestSizMax.Text);
                            xe.SetAttribute("body-custom-max-26", txbHeadWidMax.Text);
                            xe.SetAttribute("body-custom-max-3", txbWaisThicMax.Text);
                            xe.SetAttribute("body-custom-max-4", txbWaisLenMax.Text);
                            xe.SetAttribute("body-custom-max-5", txbThigthWidMax.Text);
                            xe.SetAttribute("body-custom-max-6", txbCalfWidMax.Text);
                            xe.SetAttribute("body-custom-max-7", txbThighLenMax.Text);
                            xe.SetAttribute("body-custom-max-8", txbCalfLenMax.Text);
                            xe.SetAttribute("body-custom-max-9", txbTorsoSizMax.Text);
                            //min
                            xe.SetAttribute("body-custom-min-1", txbPelvisWidMin.Text);
                            xe.SetAttribute("body-custom-min-10", txbNekThicMin.Text);
                            xe.SetAttribute("body-custom-min-11", txbNeckLenMin.Text);
                            xe.SetAttribute("body-custom-min-12", txbShoulderHeiMin.Text);
                            xe.SetAttribute("body-custom-min-13", txbShoulderWidMin.Text);
                            xe.SetAttribute("body-custom-min-14", txbShoulderSizMin.Text);
                            xe.SetAttribute("body-custom-min-15", txbArmThicMin.Text);
                            xe.SetAttribute("body-custom-min-16", txbArmLenMin.Text);
                            xe.SetAttribute("body-custom-min-17", txbHandSizMin.Text);
                            xe.SetAttribute("body-custom-min-18", txbHandLenMin.Text);
                            xe.SetAttribute("body-custom-min-19", txbFootSizMin.Text);
                            xe.SetAttribute("body-custom-min-2", txbPelvisThickMin.Text);
                            xe.SetAttribute("body-custom-min-20", txbBuildMin.Text);
                            xe.SetAttribute("body-custom-min-21", txbHeigthMin.Text);
                            xe.SetAttribute("body-custom-min-22", txbHeadSizMin.Text);
                            xe.SetAttribute("body-custom-min-23", txbChestHeiMin.Text);
                            xe.SetAttribute("body-custom-min-24", txbChestWidMin.Text);
                            xe.SetAttribute("body-custom-min-25", txbChestSizMin.Text);
                            xe.SetAttribute("body-custom-min-26", txbHeadWidMin.Text);
                            xe.SetAttribute("body-custom-min-3", txbWaisThicMin.Text);
                            xe.SetAttribute("body-custom-min-4", txbWaisLenMin.Text);
                            xe.SetAttribute("body-custom-min-5", txbThigthWidMin.Text);
                            xe.SetAttribute("body-custom-min-6", txbCalfWidMin.Text);
                            xe.SetAttribute("body-custom-min-7", txbThighLenMin.Text);
                            xe.SetAttribute("body-custom-min-8", txbCalfLenMin.Text);
                            xe.SetAttribute("body-custom-min-9", txbTorsoSizMin.Text);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }

            creader.Close();

            if (xWrite == true)
            {
                xmlDoc.Save(xmlFile);
                ststripLabel.Text = "Xml File Saved!";
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //"Yun",
            //"Gon Female",
            //"Lyn Female",
            //"Jin Female",
            //"Gon Male",
            //"Lyn Male",
            //"Jin Male"
            //Yun - race = "건" sex = "여"
            //GonF - race = "곤" sex = "여"
            //JinF - race = "진" sex = "여"
            //LynF - race = "린" sex = "여"
            //GonM - race = "곤" sex = "남"
            //JinM - race = "진" sex = "남"
            //LynM - race = "린" sex = "남
            if (!string.IsNullOrEmpty(xmlFile))
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    //female
                    case "Yun":
                        Race = "건";
                        Sex = "여";
                        break;
                    case "Gon Female":
                        Race = "곤";
                        Sex = "여";
                        break;
                    case "Lyn Female":
                        Race = "린";
                        Sex = "여";
                        break;
                    case "Jin Female":
                        Race = "진";
                        Sex = "여";
                        break;
                    //male
                    case "Gon Male":
                        Race = "곤";
                        Sex = "남";
                        break;
                    case "Lyn Male":
                        Race = "린";
                        Sex = "남";
                        break;
                    case "Jin Male":
                        Race = "진";
                        Sex = "남";
                        break;
                    default:
                        break;

                }
                XmlManager(xmlFile, Race, Sex, false);
                ststripLabel.Text = Race + Sex;
            }
            else
                MessageBox.Show("Select xml file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XmlManager(xmlFile, Race, Sex, true);
        }

        private void SliderEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlManager(xmlFile, Race, Sex, true);
        }

        private void bntCloseCompile_Click(object sender, EventArgs e)
        {
            XmlManager(xmlFile, Race, Sex, true);
            xCompile = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txBoxSet();
            ststripLabel.Text = "Values reseted!";
        }
    }
}
