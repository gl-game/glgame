using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.sportklub
{
    public class sportklubdvor : BaseScene
    {
        public override void GetView()
        {
            AddDirection(game.location.rajondoma, new { t = 5, Name = "Иди к подъезду", Description = "Подезд вашего дома" });
            AddDirection(game.location.shkolnijdvor, new { t = 5, Name = "Иди к школе" });
            AddDirection(game.location.centrgorodka, new { Name = "Идти в центр города", t = 5 });
            AddDescription("Двор дома культуры");
            AddDescription(@"
            <center><img src='/images/klub/dk.jpg' height='380'></center>
            По вечерам с 20.00 до 23.00 танцы. Вход 25 рублей.
            ");

            if (GetHour() >= 7 && GetHour() < 23)
            {
                AddDescription(@"У входа в ДК полно молодежи, парни просто стоят и курят, шутят и кого-то высматривают. Девочки группками по 2-3 человека, что-то обсуждают, кто-то просто бухает в кустах.");
                AddDynamicAction(new
                {
                    Name = "Местная дискотека " + ((Get("paid_gorodok_disko") == 1) ? "(за вход уже заплачено)" : "(Вход 25 рублей)"),
                    Scene = "gorodok/sportklub/gorodokdisco",
                    c = (Action)(() =>
                    {
                        if (Get("paid_gorodok_disko") == 0)
                        {
                            if (GetPlayer().Money >= 25)
                            {
                                GetPlayer().Money -= 25;
                                Set("paid_gorodok_disko", 1);
                            }
                            else
                            {
                                GoTo("gorodok/sportklub/sportklubdvor", "У меня нет 25 рублей");
                                return;
                            }
                        }
                    })
                });
            }
        }
    }
}
