using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class bedparent : BaseScene
    {
        public override void GetView()
        {
            AddDescription("<center><img src='/images/pics/bed.jpg'></center>");
            AddDescription(@"Вы лежите на диване");
            var WakeUp = new
            {
                Name = "Встать и одеться",
                Scene = "gorodok/parentflat/myroom",
                c = (Action)(() =>
             {
                 GetBed().Dress(GetPlayer());
                 AddTime(5);
             })
            };
            var WakeUpDrunk = new
            {
                Name = "Встать и одеться",
                Scene = "gorodok/parentflat/myroom",
                c = (Action)(() =>
             {
                 AddTime(5);
             })
            };
            if (GetPlayer().Drunk > 10)
            {
                AddDynamicScene(new
                {
                    Name = "Завалиться на кровать и спать",
                    c = (Action)(() =>
             {
                 game.BlockWear = 1;
                 GetBed().Undress(GetPlayer());
                 int time = 1;
                 while (true)
                 {
                     AddTime(1);
                     if (time % 60 == 0)
                     {
                         GetPlayer().Sleep += 2;
                     }
                     if (GetPlayer().Drunk < 5)
                     {
                         GetPlayer().WakeUp();
                         AddDescription("Наконец я протрезвела");
                         AddDynamicAction(WakeUpDrunk);
                         break;
                     }
                     time++;
                 }
             })
                });

            }
            else
            {
                if (GetPlayer().Sleep < 10)
                {
                    AddDynamicScene(new
                    {
                        Name = "Раздеться и лечь спать",
                        c = (Action)(() =>
             {
                 game.BlockWear = 1;
                 GetBed().Undress(GetPlayer());
                 int time = 1;
                 while (true)
                 {
                     AddTime(1);
                     if (time % 60 == 0)
                     {
                         GetPlayer().Sleep += 4;
                     }
                     if (GetPlayer().Sleep > 23)
                     {
                         GetPlayer().WakeUp();
                         AddDescription("Вы проснулись от того, что выспались");
                         AddDynamicAction(WakeUp);
                         break;
                     }
                     if (GetHour() == 8 && GetMinute() == 0)
                     {
                         GetPlayer().WakeUp();
                         AddDescription("Звонит будильник. Пора вставать");
                         AddDynamicAction(WakeUp);
                         break;
                     }
                     time++;
                 }
             })
                    });
                }
                else if (GetPlayer().Sleep < 30)
                {
                    AddDescription(@"Вы не хотите спать");
                    AddDynamicScene(new
                    {
                        Name = "Раздеться, принять снотворное и заснуть",
                        c = (Action)(() =>
             {
                 game.BlockWear = 1;
                 GetBed().Undress(GetPlayer());
                 int time = 1;
                 while (true)
                 {
                     AddTime(1);
                     if (time % 60 == 0)
                     {
                         GetPlayer().Sleep += 4;
                     }
                     if (GetPlayer().Sleep > 30)
                     {
                         GetPlayer().WakeUp();
                         AddDescription("Вы проснулись от того, что выспались");
                         AddDynamicAction(WakeUp);
                         break;
                     }
                     time++;
                 }
             })
                    });
                }

                AddDirection(game.location.myroom, new { Name = "Встать с кровати" }, true);
                AddDynamicAction(new
                {
                    Name = "Лежать 10 минут",
                    t = 10,
                    c = (Action)(() =>
             {
                 ShowMessage("Я лежу 10 минут");
             })
                });
            }
        }
    }
}