using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.Objects
{
    public interface IStuff
    {
        String id { get; set; }
        String classname { get; set; }
        String classtype { get; set; }
        String Name { get; set; }
        String Description { get; set; }
        Decimal Price { get; set; }
        String Image { get; set; }
        int Weight { get; set; }
        int UseCount { get; set; }
        bool Nobag { get; set; }
        int BagType { get; set; }       
    }
}
