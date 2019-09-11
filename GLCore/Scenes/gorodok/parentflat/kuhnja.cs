using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class kuhnja : BaseScene
    {
        public override void GetView()
        {
            AddDirection(game.location.koridor);
            var otojti = new
            {
                Name = "Выйти в коридор",
                Scene = "gorodok/parentflat/koridor"
            };
            AddDynamicAction(otojti);


            AddDynamicAction(new
            {
                Name = "Есть",
                Scene = "gorodok/parentflat/kuhnja",
                c = (Action)(() =>
             {
                 if (GetPlayer().Energy > 25)
                 {
                     GoTo("gorodok/parentflat/kuhnja", "Я не могу больше есть");
                     return;
                 }
                 if (GetPlayer().Energy > 18)
                 {
                     ShowMessage(@"Я через силу запихала в себя пищю");
                     GetPlayer().Eat(2);

                 }
                 else
                 {
                     AddTime(20);
                     ShowMessage(@"Я вкусно покушала");
                     GetPlayer().Eat(2);
                 }
             })
            });

            AddDynamicAction(new
            {
                Name = "Перекусить",
                Scene = "gorodok/parentflat/kuhnja",
                c = (Action)(() =>
             {
                 if (GetPlayer().Energy > 25)
                 {
                     GoTo("gorodok/parentflat/kuhnja", "Я не могу больше есть");
                     return;
                 }
                 if (GetPlayer().Energy > 18)
                 {
                     ShowMessage(@"Я через силу запихала в себя пищю");
                     GetPlayer().Eat(0);

                 }
                 else
                 {
                     AddTime(20);
                     ShowMessage(@"Вы вкусно покушали");
                     GetPlayer().Eat(0);
                 }
                 AddTime(Random(2, 8));
             })
            });

            AddDynamicAction(new
            {
                Name = "Пить",
                Scene = "gorodok/parentflat/kuhnja",
                c = (Action)(() =>
             {
                 AddTime(5);
                 GetPlayer().Drink = GetPlayer().maxDrink;
             })
            });

            AddDescription(@"
<center><img src='/images/imgpreview/kuhrPar.jpg'></center>
На кухне рядом с плитой находится мойка. Большой холодильник в углу и кухонный стол со стульями находится у стены.");
        }
    }
}