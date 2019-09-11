using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.Objects
{
    [Serializable]
    public class Alcohol : GameStuff
    {
        public int Alc { get; set; }
        public int Cl { get; set; }
        public int Type { get; set; }
    }
}
