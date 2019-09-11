using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.vokzal
{
    public class vokzalgorodok : BaseScene
    {
        public override void GetView()
        {
            AddDirection(game.location.vokzalploshadj);
        }
    }
}