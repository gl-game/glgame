using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class stolovka : BaseScene
    {
        public override void GetView()
        {
            AddDescription("<center><img src='/images/school/stolovka.jpg' width='370'></center>");
            AddDirection(game.location.shkolamain, new { Name = "В главный коридор" }, true);
            AddDescription("В столовке на большой перемене очередь школьников, желающих перекусить.");

            AddDynamicAction(new
            {
                Name = "Купить еды (10 руб)",
                Scene = "gorodok/school/stolovka",
                c = (Action)(() =>
                {
                    if (GetPlayer().Energy > 25)
                    {
                        GoTo("gorodok/school/stolovka", "В меня больше не лезет");
                        return;
                    }
                    if (GetPlayer().Energy > 18)
                    {
                        ShowMessage(@"Я через силу запихала в себя еду");
                        GetPlayer().Eat(1);
                    }
                    else
                    {
                        ShowMessage(@"Я перекусила");
                        GetPlayer().Eat(1);
                    }
                    GetPlayer().Money -= 10;
                    AddTime(Random(10, 12));
                })
            });
        }
    }
}