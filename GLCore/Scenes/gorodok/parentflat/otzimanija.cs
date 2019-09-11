using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class otzimanija : BaseScene
    {
        public override void GetView()
        {
            var otojti = new
            {
                Name = "Закончить",
                Scene = "gorodok/parentflat/myroom"
            };
            AddDynamicAction(otojti);
            AddDescription(@"
<center><img src='/images/imgpreview/push.jpg'></center>
Я отжималась от пола в течении пятнадцати минут развивая силу.
");
        }
    }
}