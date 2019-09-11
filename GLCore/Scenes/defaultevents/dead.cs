using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.defaultevents
{
    public class dead : BaseScene
    {
        public override void GetView()
        {
            AddDescription("Вы умерли");
            GetPlayer().Health = -1;
        }
    }
}