using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.setup
{
    public class gamestart : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Начало игры");
            AddDescription(@"Меня завут : " + GetPlayer().Name + " " + GetPlayer().LastName);
            AddDescription(@"Я учусь в 10б в небольшом городке");

            AddDynamicAction(new
            {
                Name = "Далее....",
                Scene = "gorodok/parentflat/myroom"
            });
        }
    }
}
