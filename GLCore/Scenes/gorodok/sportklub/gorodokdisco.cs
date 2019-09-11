using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.sportklub
{
    public class gorodokdisco : BaseScene
    {
        public override void GetView()
        {
            AddDirection(game.location.sportklubdvor, new { t = 1, Name = "Выйти наружу" });
            AddDescription("Дискотека");


            AddDynamicScene(new
            {
                Name = "Танцевать одной",
                c = (Action)(() =>
                {
                    AddDescription("Я танцую по среди зала");
                    AddDescription("Никто не обращает внимание");
                    if (GetPlayer().Skills.GetValue("dance") < 30)
                    {
                        int rnd1 = Random(1, 10);
                        if (rnd1 > 8)
                        {
                            AddDescription("Кажется я научилась лучше танцевать");
                            GetPlayer().Skills.LearnSkill("geographyskill");
                        }
                    }

                    AddTime(15);
                    AddDynamicAction(new
                    {
                        Name = "Далее...",
                        Scene = "gorodok/sportklub/gorodokdisco"
                    });
                })
            });

            AddDynamicScene(new
            {
                Name = "Стоять у стенки",
                c = (Action)(() =>
                {
                    AddDescription("Я скромно стоию у стеночки наблюдая за танцующими.");
                    AddDescription("Никто не обращает внимание");
                    AddTime(15);
                    AddDynamicAction(new
                    {
                        Name = "Далее...",
                        Scene = "gorodok/sportklub/gorodokdisco"
                    });
                })
            });

            AddDynamicAction(new
            {
                Name = "Выйти наружу",
                Scene = "gorodok/sportklub/sportklubdvor",
                t = 5
            });
        }
    }
}

