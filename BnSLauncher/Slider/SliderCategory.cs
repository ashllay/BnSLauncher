using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnS_Launcher.Slider
{
    public class SliderCategory
    {
        public string Description
        {
            get;
            set;
        }

        public List<int> Ids
        {
            get;
            set;
        }

        public SliderCategory(string description)
        {
            this.Description = description;
            this.Ids = new List<int>();
        }
    }
}
