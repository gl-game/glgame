using GLCore.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Locations
{
    public interface ILocation
    {
        String id { get; set; }
        String classname { get; set; }
        String Name { get; set; }
        String Scene { get; set; }
        String Description { get; set; }
        int t { get; set; }
        String c { get; set; }
        List<IBagObject> LocationBags { get; set; }
    }
}
