using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.Objects
{
    public interface IBagObject : IWear
    {
        int MaxWeight { get; set; }
        List<IStuff> Things { get; set; }
    }
}
