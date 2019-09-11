using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.vokzal
{
    public class kafevokzal : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"
<center><img src='/images/qwest/alter/gkafe2.jpg'></center>
Маленькое задрипанное, привокзальное кафе.<br>
Так как тут работает ваша мама, то вас кормят бесплатно.<br>
В кафе за стойкой стоит ваша мама.");
            AddDirection(game.location.vokzalploshadj);

            AddDynamicAction(new
            {
                Name = "Поесть",
                Scene = "gorodok/vokzal/kafevokzal",
                c = (Action)(() =>
             {
                 if (GetPlayer().Energy > 25)
                 {
                     GoTo("gorodok/vokzal/kafevokzal", "Вы не можете больше есть");
                     return;
                 }
                 if (GetPlayer().Energy > 18)
                 {
                     AddTime(20);
                     GetPlayer().Eat(2);

                 }
                 else
                 {
                     AddTime(20);
                     ShowMessage(@"Вы вкусно покушали");
                     GetPlayer().Eat(2);
                 }
             })
            });

            AddDynamicAction(new
            {
                Name = "Выйти на привокзальную площадь",
                Scene = "gorodok/vokzal/vokzalploshadj"
            });
        }
    }
}
