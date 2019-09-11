using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class bedparenttable : BaseScene
    {
        public override void GetView()
        {
            AddDirection(game.location.myroom, new { Name = "Встать из-за стола", Description = "" });
            AddDescription("<img src='/images/common/my_room_table.jpg' width='400'>");


            if (Get("Learn_lessons_need") == 1)
            {
                AddDynamicScene(new
                {
                    Name = "Учить уроки 2 часа",
                    c = (Action)(() =>
                    {
                        Set("Learn_lessons_need", 0); 
                        AddTime(120);
                        GetPlayer().SchoolLessonsLearned++;
                        AddDescription("Я учила уроки 2 часа");
                        AddDescription("<img src='/images/common/learn_lessons.jpg'>");
                        AddDynamicScene(new
                        {
                            Name = "Закончить с уроками"
                        });
                    })
                });
                Set("Learn_lessons_need", 0);
            }

            AddDynamicAction(new
            {
                Name = "Встать из-за стола",
                Scene = "gorodok/parentflat/myroom"
            });

            if (game.player.SmallBag != null)
            {
                AddDynamicAction(new
                {
                    Name = "Положить " + game.player.SmallBag.Name + " у стола",
                    Scene = "gorodok/parentflat/bedparenttable",
                    c = (Action)(() =>
                     {
                         DropBag(game.player.SmallBag);
                     })
                });
            }

            if (game.player.Bag != null)
            {
                AddDynamicAction(new
                {
                    Name = "Положить " + game.player.Bag.Name + " у стола",
                    Scene = "gorodok/parentflat/bedparenttable",
                    c = (Action)(() =>
                     {
                         DropBag(game.player.Bag);
                     })
                });
            }

            AddDescription("Мой стол где я могу заниматься");
        }
    }
}
