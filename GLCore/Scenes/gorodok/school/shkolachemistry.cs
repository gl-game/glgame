using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolachemistry : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Кабинет Химии");
            if (Get("himija_status") == 0)
            {
                AddDirection(game.location.shkolamain, new { Name = "Выйти из класса" });
                AddDescription(@"<img src='/images/teacher/chemistry/kabinethimii.jpg' width='470px'>");
                AddDynamicAction(new
                {
                    Name = "Сесть за парту и ждать начала урока",
                    c = (Action)(() =>
             {
                 Set("Lesson_start", 0);
                 Set("himija_status", 1);
             })
                });
            }
            else
            {
                if (Get("Lesson_start") == 3)
                {
                    AddDescription(@"
		<center><img src='/images/common/endofflesson" + Random(1, 1) + @".jpg' height=""270""></center>
		Урок закончен");
                    AddDynamicAction(new
                    {
                        Name = "Встать из-за парты",
                        Scene = "gorodok/school/shkolamain",
                        c = (Action)(() =>
             {
                 AddTime(1);
                 GetPlayer().Lessons.GetById("himija").IsVisited = 1;
                 Set("Lesson_start", 0);
                 Set("himija_status", 0);
                 Set("legs_on", 0);
                 Set("himija_see_pussy", 0);
                 Set("himija_see_tits", 0);
                 Set("ask_question", 0);
             })
                    });
                }
                else
                {
                    AddDynamicAction(new
                    {
                        Name = "Слушать учителя",
                        c = (Action)(() =>
             {
                 int rnd1 = Random(6, 10);
                 GetPlayer().Lessons.GetById("himija").SuccessRate = (GetPlayer().Lessons.GetById("himija").SuccessRate + rnd1 / 2);
                 if (rnd1 > 8)
                 {
                     GetPlayer().Skills.LearnSkill("chemistryskill");
                 }
                 Set("Lesson_start", Get("Lesson_start") + 1);
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
             })
                    });

                    AddDynamicAction(new
                    {
                        Name = "Смотреть по сторонам",
                        c = (Action)(() =>
             {
                 GetPlayer().Lessons.GetById("himija").SuccessRate = (GetPlayer().Lessons.GetById("himija").SuccessRate + Random(0, 5) / 2);
                 Set("Lesson_start", Get("Lesson_start") + 1);
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
             })
                    });
                }

            }
        }
    }
}