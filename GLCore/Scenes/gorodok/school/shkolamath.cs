using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolamath : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Кабинет математики");

            if (Get("math_status") == 0)
            {
                AddDirection(game.location.shkolamain, new { Name = "Выйти из класса" });
                AddDescription(@"<img src='/images/school/matematika/kabinet.jpg' width='470px'>");
                AddDynamicAction(new
                {
                    Name = "Сесть за парту и ждать начала урока",
                    c = (Action)(() =>
             {
                 Set("Lesson_start", 0);
                 Set("math_status", 1);
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

                    if (GetPlayer().Beauty > 15 && game.actor.uchitelnicamatematiki.Get("answer_question") > 10 && game.actor.uchitelnicamatematiki.Get("agree_fakultativ") == 0)
                    {

                        AddDescription("- " + GetPlayer().Name + " Не хочешь прийти ко мне на индивидуальный факультатив?");

                        AddDynamicScene(new
                        {
                            Name = "Согласиться",
                            c = (Action)(() =>
             {
                 AddDescription("Приходи на факультатив ко мне в понедельник в 15:00");
                 AddDescription("Я соглашаюсь прийти на факультатив");
                 AddDynamicAction(new
                 {
                     Name = "Выйти в коридор",
                     Scene = "gorodok/school/shkolamain",
                     c = (Action)(() =>
{

    AddTime(1);
    GetPlayer().Lessons.GetById("matematika").IsVisited = 1;
    Set("Lesson_start", 0);
    Set("math_status", 0);
    Set("legs_on", 0);
    Set("math_see_pussy", 0);
    Set("math_see_tits", 0);
    Set("ask_question", 0);
    game.actor.uchitelnicamatematiki.Set("agree_fakultativ", 1);

})
                 });
             })
                        });

                        AddDynamicAction(new
                        {
                            Name = "Отказаться",
                            Scene = "gorodok/school/shkolamain",
                            c = (Action)(() =>
             {
                 AddTime(1);
                 GetPlayer().Lessons.GetById("matematika").IsVisited = 1;
                 Set("Lesson_start", 0);
                 Set("math_status", 0);
                 Set("legs_on", 0);
                 Set("math_see_pussy", 0);
                 Set("math_see_tits", 0);
                 Set("ask_question", 0);
             })
                        });

                    }
                    else
                    {
                        AddDynamicAction(new
                        {
                            Name = "Встать из-за парты и выйти в коридор",
                            Scene = "gorodok/school/shkolamain",
                            c = (Action)(() =>
             {
                 AddTime(1);
                 GetPlayer().Lessons.GetById("matematika").IsVisited = 1;
                 Set("Lesson_start", 0);
                 Set("math_status", 0);
                 Set("legs_on", 0);
                 Set("math_see_pussy", 0);
                 Set("math_see_tits", 0);
                 Set("ask_question", 0);
             })
                        });
                    }
                }
                else
                {
                    if (Get("Lesson_start") == 2)
                    {
                        AddDescription("Учительница математики " + game.actor.uchitelnicamatematiki.NN + " задает вопрос");
                        if (GetPlayer().Skills.GetValue("mathskill") > Random(1, 80))
                        {
                            AddDynamicScene(new
                            {
                                Name = "Поднять руку",
                                c = (Action)(() =>
             {
                 if (Random(1, 2) > 1)
                 {
                     AddDescription("Учительница математики спрашивает меня");
                     AddDynamicScene(new
                     {
                         Name = "Ответить на вопрос",
                         c = (Action)(() =>
{
    AddDescription("Я ответила на вопрос по математике");
    game.actor.uchitelnicamatematiki.Add("answer_question", 1);
    AddDynamicAction(new
    {
        Name = "Сесть за парту",
        c = (Action)(() =>
{
    AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
    Add("Lesson_start", 1);
})
    });
})
                     });

                 }
                 else
                 {
                     AddDescription("Учительница математики спрашивает однокласницу");
                     AddDynamicAction(new
                     {
                         Name = "Сидеть за партой",
                         c = (Action)(() =>
{
    AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
    Add("Lesson_start", 1);
})
                     });
                 }
             })
                            });
                        }
                        else
                        {

                            AddDynamicAction(new
                            {
                                Name = "Сидеть за партой",
                                c = (Action)(() =>
             {
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
                 Add("Lesson_start", 1);
             })
                            });
                        }

                    }
                    else
                    {
                        AddDescription("Учительница математики " + game.actor.uchitelnicamatematiki.NN + " обьясняет новую тему");
                        AddDescription("<img src='/images/school/matematika/teacher" + Random(1, 3) + ".jpg' height='270'>");

                        AddDynamicAction(new
                        {
                            Name = "Слушать учителя",
                            c = (Action)(() =>
             {
                 int rnd1 = Random(6, 10);
                 GetPlayer().Lessons.GetById("matematika").SuccessRate = (GetPlayer().Lessons.GetById("matematika").SuccessRate + rnd1 / 2);
                 if (rnd1 > 8)
                 {
                     GetPlayer().Skills.LearnSkill("mathskill");
                 }
                 Add("Lesson_start", 1);
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
             })
                        });

                        AddDynamicAction(new
                        {
                            Name = "Смотреть по сторонам",
                            c = (Action)(() =>
             {
                 GetPlayer().Lessons.GetById("matematika").SuccessRate = (GetPlayer().Lessons.GetById("matematika").SuccessRate + Random(0, 10) / 2);
                 Add("Lesson_start", 1);
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
             })
                        });
                    }

                }

            }
        }
    }
}

