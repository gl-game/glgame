using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Actions
{
    public interface IAction
    {
        String Name
        {
            get;
            set;
        }
        String Scene
        {
            get;
            set;
        }
    }
}
