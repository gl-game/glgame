using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class mojatumbochkaroditeli : BaseScene
    {
        public override void GetView()
        {
            DrawBoxStaff(GetBox());
            AddDirection(game.location.myroom, new { Name = "Закрыть тумбочку", Description = "" });
            AddDynamicAction(new
            {
                Name = "Закрыть тумбочку",
                Scene = "gorodok/parentflat/myroom"
            });
        }
    }
}