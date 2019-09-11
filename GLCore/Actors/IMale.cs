using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Actors
{
    public interface IMale : IActor
    {
        int UseCondom { get; set; }

        int DickWidth { get; set; }
        int DickLength { get; set; }
        int AnusWidth { get; set; }
        int AnusLength { get; set; }

        int AnusPlug { get; set; }
    }
}
