using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolnijdvor : BaseScene
    {
        public override void GetView()
        {
            if (GetWeekDay() >= 1 && GetWeekDay() <= 5 && GetHour() >= 7 && GetHour() <= 20)
            {
                AddDirection(game.location.shkolamain, new
                {
                    Name = "Идти в школу",
                    t = 1,
                    c =
                        (Action)(() =>
                        {
                            if (GetPlayer().DressType != 1)
                            {
                                GoTo("gorodok/school/shkolnijdvor", "В школу нужно приходить в школьной форме");
                                return;
                            }
                        })
                });
            }
            AddDirection(game.location.centrgorodka, new { Name = "Идти в центр города", t = 5 });
            AddDirection(game.location.rajondoma, new { Name = "Идти в домой", t = 5 });
            AddDirection(game.location.sportklubdvor, new { t = 5, Name = "К Дому культуры" });
            AddDescription(@"
<center><img src='/images/school/yard.jpg' height='270'></center>
Обыкновенная школа в которой учится местная детвора.
");

            AddDescription("На футбольном поле возле школы ваш брат гоняет в футбол.");
            if (GetWeekDay() >= 1 && GetWeekDay() <= 5 && GetHour() >= 7 && GetHour() <= 20)
            {
                AddDynamicAction(new
                {
                    Name = "Идти в школу",
                    Scene = "gorodok/school/shkolamain",
                    t = 1,
                    c =
                    (Action)(() =>
             {
                 if (GetPlayer().DressType != 1)
                 {
                     GoTo("gorodok/school/shkolnijdvor", "В школу нужно приходить в школьной форме");
                     return;
                 }
             })
                });
            }
        }
    }
}