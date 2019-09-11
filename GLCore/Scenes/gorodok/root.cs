using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok
{
    public class root : BaseScene
    {
        public override void GetView()
        {
            AddDescription("Городок");
            AddDirection(game.location.rajondoma, new { t = 5, Name = "Иди к подъезду", Description = "Подезд вашего дома" });
            AddDirection(game.location.shkolnijdvor, new { t = 5, Name = "Иди к школе" });
        }
    }
}

