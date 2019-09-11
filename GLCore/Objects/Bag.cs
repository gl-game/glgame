using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.Objects
{
    [Serializable]
    public class Bag : Wear, IBagObject
    {
        public int MaxWeight { get; set; }
        public List<IStuff> Things { get; set; }
        public Bag()
        {
            Things = new List<IStuff>();
        }
    }
}
