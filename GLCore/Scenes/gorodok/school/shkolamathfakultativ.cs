using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolamathfakultativ : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Факультативное индивидуальное занятие");


            AddDescription("Начнем урок " + GetPlayer().Name + "?");
            if (Get("math_status") == 0)
            {
                AddDirection(game.location.shkolamain, new { Name = "Выйти из класса" });
                AddDescription(@"<img src='/images/school/matematika/kabinet.jpg' width='470px'>");
                AddDynamicAction(new
                {
                    Name = "Сесть за парту",
                    c = (Action)(() =>
             {
                 Set("Lesson_start", 0);
                 Set("math_status", 1);
             })
                });
            }
            else
            {
                if (game.actor.uchitelnicamatematiki.SexAddiction > 30 && Get("math_endlesson") > 0)
                {
                    if (game.actor.uchitelnicamatematiki.Get("tired_talk") == 0)
                    {
                        AddDynamicScene(new
                        {
                            Name = "Поговорить",
                            c = (Action)(() =>
                            {
                                scene.AddFFTalk(GetPlayer(), game.actor.uchitelnicamatematiki, "Болтать на разные темы");
                            })
                        });

                    }
                    if (game.actor.uchitelnicamatematiki.SexAddiction > 50 && GetPlayer().Beauty > 15 && game.actor.uchitelnicamatematiki.Get("first_time") == 0)
                    {
                        AddDynamicScene(new
                        {
                            Name = "Прикоснуться к груди учительницы",
                            c = (Action)(() =>
                            {
                                AddDescription("Я трогаю её груди");
                                AddDescription(game.actor.uchitelnicamatematiki.Name + " целует меня в губы");
                                scene.AddSFFAction(GetPlayer(), game.actor.uchitelnicamatematiki);

                            })
                        });
                    }
                    else if (GetPlayer().Beauty > 15 && game.actor.uchitelnicamatematiki.Get("first_time") > 0)
                    {
                        AddDynamicAction(new
                        {
                            Name = "Перейти к интиму",
                            Scene = "gorodok/school/shkolamain",
                            c = (Action)(() =>
                            {
                                AddDescription("Я поджожу к учительтнице");
                                scene.AddSFFAction(GetPlayer(), game.actor.uchitelnicamatematiki);
                            })
                        });
                    }
                    AddDynamicAction(new
                    {
                        Name = "Выйти из класса",
                        Scene = "gorodok/school/shkolamain",
                        c = (Action)(() =>
                        {
                            game.actor.uchitelnicamatematiki.Set("naked", 0);
                            Set("math_status", 0);
                            Set("math_endlesson", 0);
                        })
                    });
                }
                else if (Get("math_endlesson") > 0)
                {
                    AddDescription("Я закончила индивидуальный урок по математике");
                    AddDynamicAction(new
                    {
                        Name = "Выйти из класса",
                        Scene = "gorodok/school/shkolamain",
                        c = (Action)(() =>
                        {
                            game.actor.uchitelnicamatematiki.Set("naked", 0);
                            Set("math_status", 0);
                            Set("math_endlesson", 0);
                        })
                    });
                }
                else
                {
                    AddDescription("- " + game.actor.uchitelnicamatematiki.NN + " садится к вам");
                    int r = Random(1, 3);
                    if (r == 1)
                    {
                        AddDescription("Учительница предлагает мне решить задачу по алгебре");
                        AddDynamicScene(new
                        {
                            Name = "Решать",
                            с = (Action)(() =>
             {
                 AddDescription(game.actor.uchitelnicamatematiki.NN + " сидит рядом со мной прижимаясь ко мне");
                 AddDescription("Я заметела что на учительнице нет лифчика");
                 game.actor.uchitelnicamatematiki.Add("saw_math_tits", 1);
                 AddDynamicScene(new
                 {
                     Name = "Нечаянно прикоснуться к руке учительницы",
                     c = (Action)(() =>
{
    AddDescription("Я какбы невзначай прикоснуласть к её руке");
    game.actor.uchitelnicamatematiki.SexAddiction++;
    game.actor.uchitelnicamatematiki.Relationship++;
    AddDynamicAction(new
    {
        Name = "Закончить решать",
        c = (Action)(() =>
{
    Add("math_endlesson", 1);
    AddTime(2);
})
    });
})
                 });
                 AddDynamicAction(new
                 {
                     Name = "Закончить решать",
                     c = (Action)(() =>
{
    Add("math_endlesson", 1);
    AddTime(2);
})
                 });
             })
                        });

                    }
                    if (r == 2)
                    {


                    }
                    if (r == 3)
                    {


                    }
                }
            }
        }
    }
}