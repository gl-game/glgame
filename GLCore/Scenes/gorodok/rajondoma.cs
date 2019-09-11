using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok
{
    public class rajondoma : BaseScene
    {
        public override void GetView()
        {
            if (Get("podjezd_cat") < -5)
            {
                Set("podjezd_cat", -5);
            }
            if (Get("podjezd_cat") > 30)
            {
                Set("podjezd_cat", 30);
            }
            int cat = Get("podjezd_cat");
            AddDirection(game.location.koridor, new { t = 2, Name = "Поднятся в квартиру" });
            AddDirection(game.location.podjezd_roditeli, new { t = 2, Name = "Зайти в ваш подъезд" });
            AddDirection(game.location.centrgorodka, new { t = 15, Name = "Идити в центр городка" });
            AddDirection(game.location.shkolnijdvor, new { t = 5, Name = "Идти к школе" });
            AddDescription("Вход в подъезд");
            AddDescription(@"<img src='/images/pic/podjezd.jpg' height='200' />");
            if (Random(1, 20 + cat) >= 15 && Get("podjezd_cat_ready") == 0)
            {

                AddDescription("Около подезда гуляет Рыжий кот");
                AddDescription(@"<img src='/images/common/cat1.jpg' height='200' />");
                AddDynamicScene(new
                {
                    Name = "Погладить кота",
                    c = (Action)(() =>
                    {
                        cat++;
                        AddTime(3);
                        AddDescription("Довольный кот трется у вас и мурлычет");
                        AddDescription(@"<img src='/images/common/cat1_happy.jpg' width='400' />");
                        AddDynamicAction(new
                        {
                            Name = "Далее....",
                            c = (Action)(() =>
                            {
                                Set("podjezd_cat", cat);
                                Set("podjezd_cat_ready", 1);
                            })
                        });
                    })

                });

                AddDynamicScene(new
                {
                    Name = "Пнуть ногой кота",
                    c = (Action)(() =>
                    {
                        cat--;
                        AddTime(3);
                        AddDescription("Злой кот убегает");
                        AddDescription(@"<img src='/images/common/cat1_unhappy.jpg' width='400' />");
                        AddDynamicAction(new
                        {
                            Name = "Далее....",
                            c = (Action)(() =>
                            {
                                Set("podjezd_cat", cat);
                                Set("podjezd_cat_ready", 1);
                            })
                        });
                    })

                });
            }
            AddDynamicAction(new
            {
                Name = "Ждать 10 минут",
                Scene = "gorodok/rajondoma",
                c = (Action)(() =>
             {
                 AddTime(10);
                 ShowMessage(@"Вы ждали 10 минут");
             })
            });
        }
    }
}