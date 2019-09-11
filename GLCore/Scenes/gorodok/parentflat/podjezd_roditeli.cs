using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class podjezd_roditeli : BaseScene
    {
        public override void GetView()
        {
            AddDirection(game.location.koridor, new { t = 5, Name = "Идти в квартиру родителей" });
            AddDirection(game.location.rajondoma, new { t = 5, Name = "Выйти на улицу" });
            AddDescription(@"
<center><img src='/images/imgpreview/podezd.jpg'></center>
Подъезд 5ти этажного дома в котором вы живете. Замок, закрывающий дверь на технический этаж, или чердак, сломан.");

            AddDynamicAction(new
            {
                Name = "Выйти на улицу",
                Scene = "gorodok/rajondoma",
                t = 2
            });
        }
    }
}