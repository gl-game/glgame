using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Actors
{
    public class Male : Actor, IActor, IMale
    {
        public Male()
            : base()
        {
            Gender = 1;
        }
        public int UseCondom { get; set; }
        public int DickWidth { get; set; }
        public int DickLength { get; set; }
        public int AnusWidth { get; set; }
        public int AnusLength { get; set; }

        public int AnusPlug { get; set; }
    }
}
