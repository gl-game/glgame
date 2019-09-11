using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.Objects
{
    [Serializable]
    public class Skirt: Wear, IBottomDress
    {
        public new int ConflictSlot
        {
            get
            {
                return 2;
            }
        }
    }
}
