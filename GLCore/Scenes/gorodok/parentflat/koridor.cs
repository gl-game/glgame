using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class koridor : BaseScene
    {
        public override void GetView()
        {
            AddDirection(game.location.myroom, new { t = 2, Name = "Идти в вашу комнату" });
            AddDirection(game.location.zal, new { t = 2 });
            AddDirection(game.location.vannaja, new { t = 2 });
            AddDirection(game.location.kuhnja, new { t = 2 });
            AddDirection(game.location.podjezd_roditeli, new
            {
                t = 5,
                c =
                    (Action)(() =>
                    {
                        if (GetPlayer().DressedComplitely == 0)
                        {
                            GoTo("gorodok/parentflat/koridor", "Я не могу идти на улицу в такой одежде");
                            return;
                        }
                    })
            });
            AddDirection(game.location.rajondoma, new
            {
                t = 5,
                Name = "Выйти на улицу",
                c =
                    (Action)(() =>
                    {
                        if (GetPlayer().DressedComplitely == 0)
                        {
                            GoTo("gorodok/parentflat/koridor", "Я не могу идти на улицу в такой одежде");
                            return;
                        }
                    })
            });
            AddDescription("<center><img src='/images/imgpreview/korrPar.jpg'></center>");
            AddDescription("На стене возле входной двери висит <a href='scene:" + game.location.zerkalo_roditeli.Scene + "'>зеркало</a>.");
            AddDescription("На крючке висит китайский пуховик");

            var otojti = new
            {
                Name = "Выйти на улицу",
                Scene = "gorodok/rajondoma",
                t = 5,
                c =
            (Action)(() =>
             {
                 if (GetPlayer().DressedComplitely == 0)
                 {
                     GoTo("gorodok/parentflat/koridor", "Я не могу идти на улицу в такой одежде");
                     return;
                 }
             })
            };
            AddDynamicAction(otojti);
        }
    }
}
