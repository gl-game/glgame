using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class zerkalo : BaseScene
    {
        public override void GetView()
        {
            var prichesatsja = new
            {
                Name = "Причесаться",
                c = (Action)(() =>
                {
                    ShowMessage("Я причесалась");
                    GetPlayer().UseHairBrush(null);
                    AddTime(5);
                })
            };
            if (GetPlayer().HairBrush == 0)
            {
                AddDynamicAction(prichesatsja);
            }

            var brovi = new
            {
                Name = "Выщипывать брови",
                c = (Action)(() =>
                {
                    ShowMessage("Я выщипала ненужные волоски на бровях придав им красивый контур. Правда это довольно больно.");
                    AddTime(10);
                    GetPlayer().Mana = GetPlayer().Mana / 2;
                    GetPlayer().EyeBrows = 10;
                })
            };
            if (GetPlayer().EyeBrows < 2)
            {
                AddDynamicAction(brovi);
            }

            var otojti = new
            {
                Name = "Отойти от зеркала",
                Scene = "gorodok/parentflat/koridor",
                t = 1
            };
            AddDynamicAction(otojti);

            AddDescription(@"
<center><img src='/images/imgpreview/hcol.jpg'></center>" + GetPlayer().GetActorMirror());
        }
    }
}