using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class wakeup : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"
<center><img src='/images/pics/son.jpg'></center>
Вы спите и вам ничего не снится.");
            AddDirection(game.location.podjezd_roditeli, new
            {
                Name = "Быстро одеться и выбежать в подъезд",
                Description = "15 минут",
                t = 15,
                c = (Action)(() =>
                 {

                 })
            });

            AddDynamicAction(new
            {
                Name = "Встать с кровати и одеться (15 минут)",
                Scene = "gorodok/parentflat/myroom",
                c = (Action)(() =>
         {

         })
            });
        }
    }
}

