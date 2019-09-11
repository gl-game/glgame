using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.setup
{
    public class disclaimer : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Отказ от ответственности");
            AddDescription(@"Игра не предназначенна для лиц не достигших 18ти лет. Если вам нет 18ти, то немедленно выключите игру.");

            AddDynamicAction(new
            {
                Name = "Мне 18 лет.",
                Scene = "setup/disclaimer"
            });

            AddDynamicAction(new
            {
                Name = "Мне меньше 18 лет.",
                c = (Action)(() =>
                {
                    Environment.Exit(0);
                })
            });
        }
    }
}


