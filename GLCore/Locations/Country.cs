using GLCore.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Locations
{
    public class Country : ILocation
    {
        public String id { get; set; }
        public String classname { get; set; }
        public String Name { get; set; }
        public String Scene { get; set; }
        public String Description { get; set; }
        public int t { get; set; }
        public String c { get; set; }
        public List<IBagObject> LocationBags { get; set; }
    }
}
