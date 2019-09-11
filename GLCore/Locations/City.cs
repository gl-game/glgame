using GLCore.SupportObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Locations
{
    public class City : Country, ICity
    {
        public int reputation { get; set; }
        public int TimeZone { get; set; }
        public Weather weather { get; set; }
    }
}
