using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class shkafroditeli : BaseScene
    {
        public override void GetView()
        {
            AddDescription("Мой шкаф");
            DrawWadrobeStaff(GetWardrobe());
            AddDirection(game.location.myroom, new { Name = "Закрыть шкаф", Description = "" });
            AddDynamicAction(new
            {
                Name = "Закрыть шкаф",
                Scene = "gorodok/parentflat/myroom"
            });
            AddDescription("Здесь я могу спокойно переодеться");
        }
    }
}