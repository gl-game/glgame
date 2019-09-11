using GLCore.Actors;
using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolamain : BaseScene
    {

        private void TalkNpc(IActor actor)
        {
            if (actor.Relationship < 20)
            {
                AddDescription("Вы болтаете о всякой ерунде и " + actor.Name + " слушает вас в пол уха.");
            }
            else if (actor.Relationship < 80)
            {
                AddDescription("Вы болтаете о всякой ерунде и " + actor.Name + " охотно поддакивает вам.");
            }
            else
            {
                AddDescription("Вы болтаете о всякое ерунде и " + actor.Name + " с улыбкой общается с вами, тоже рассказывая всякие истории.");
            }
        }
        private void JilijaMilovaSchool()
        {
            AddDynamicActorAction(GetFemale("julijamilova"), new
            {
                Description = "Стоит у с окна в школьном коридоре",
                c = (Action)(() =>
                {
                    AddDescription("<img src='/images/pic/u_okna.jpg' height=400>");
                    AddDescription(@"" + GetFemale("julijamilova").Name + " cтоит у с окна");
                    if (GetFemale("julijamilova").Get("talk_school") == 0)
                    {
                        AddDynamicScene(new
                        {
                            Name = "Болтать",
                            c = (Action)(() =>
                            {
                                AddTime(Random(5, 7));
                                GetFemale("julijamilova").Set("talk_school", 1); 
                                TalkNpc(GetFemale("julijamilova"));
                                AddDynamicAction(new
                                {
                                    Name = "Отойти",
                                    c = (Action)(() =>
                                    {
                                        AddTime(1);
                                    })
                                });

                                AddDynamicScene(new
                                {
                                    Name = "Продолжить",
                                    c = GetAction("JilijaMilovaSchoolTalk")
                                });

                            })
                        });
                    }
                    AddDynamicAction(new
                    {
                        Name = "Отойти",
                        c = (Action)(() =>
                        {
                            AddTime(1);
                        })
                    });
                })
            }, "JilijaMilovaSchoolTalk");
        }

        private void _lessonLearnStatus()
        {
            if (Get("Learn_lessons_need") == 1)
            {
                GetPlayer().SchoolLessonsUnlearned++;
                Set("Learn_lessons_need", 0);
            }
        }
        public override void GetView()
        {
            int ideturok = 0;
            int Opazdivaju = 0;

            int MinutesNow = GetHour() * 60 + GetMinute();
            if ((MinutesNow >= 480 && MinutesNow <= 520)
            || (MinutesNow >= 530 && MinutesNow <= 570)
            || (MinutesNow >= 580 && MinutesNow <= 620)
            || (MinutesNow >= 640 && MinutesNow <= 680)
            )
            {
                ideturok = 1;
            }
            else if (MinutesNow < 480 || MinutesNow > 700)
            {
                ideturok = 2;
            }
            int BigBreak = 0;

            if (GetPlayer().Drunk > 5 && Random(1, 5) > 1)
            {
                AddDescription("<img src='/images/me/drunk1.jpg'>");
                AddDescription("Завуч поймала меня в пьяном виде в школе");
                AddDynamicAction(new
                {
                    Name = "В кабинет зауча",
                    Scene = "gorodok/school/kabinetzaucha",
                    t = 1,
                    c = (Action)(() =>
             {
                 Set("drunk_zauch", 1);
             })
                });
                return;
            }

            if ((GetHour() == 7 && GetMinute() >= 50) || (GetHour() == 8 && GetMinute() <= 10))
            {
                _lessonLearnStatus();
                switch (GetWeekDay())
                {
                    case 1:
                        AddDirection(game.location.shkolamath, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 1); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 2:
                        AddDirection(game.location.shkolageography, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 1); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 3:
                        AddDirection(game.location.shkolacomputer, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 1); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 4:
                        AddDirection(game.location.shkolaphysic, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 1); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 5:
                        AddDirection(game.location.shkolaruss, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 1); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                }
                if (ideturok == 1)
                {
                    Opazdivaju = 1;
                }
            }
            //2
            if (GetHour() == 8 && GetMinute() >= 40 && GetMinute() <= 59)
            {
                switch (GetWeekDay())
                {
                    case 1:
                        AddDirection(game.location.shkolacomputer, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 2); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 2:
                        AddDirection(game.location.shkolamath, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 2); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 3:
                        AddDirection(game.location.shkolageography, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 2); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 4:
                        AddDirection(game.location.shkolabiology, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 2); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 5:
                        AddDirection(game.location.shkolachemistry, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 2); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                }
                if (ideturok == 1)
                {
                    Opazdivaju = 1;
                }

            }
            //3
            if (GetHour() == 9 && GetMinute() >= 30 && GetMinute() <= 50)
            {
                switch (GetWeekDay())
                {
                    case 1:
                        AddDirection(game.location.shkolaruss, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 3); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 2:
                        AddDirection(game.location.shkolachemistry, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 3); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 3:
                        AddDirection(game.location.shkolaphysic, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 3); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 4:
                        AddDirection(game.location.shkolahistory, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 3); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 5:
                        AddDirection(game.location.shkolamath, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 3); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                }
                if (ideturok == 1)
                {
                    Opazdivaju = 1;
                }

            }
            //4
            if (GetHour() == 10 && GetMinute() >= 30 && GetMinute() <= 50)
            {
                switch (GetWeekDay())
                {
                    case 1:
                        AddDirection(game.location.shkolahistory, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 4); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 2:
                        AddDirection(game.location.shkolahistory, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 4); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 3:
                        AddDirection(game.location.shkolaruss, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 4); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 4:
                        AddDirection(game.location.shkolamath, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 4); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                    case 5:
                        AddDirection(game.location.shkolacomputer, new
                        {
                            c = (Action)(() =>
                                { Set("Lesson_number", 4); Set("Learn_lessons_need", 1); })
                        }, true);
                        break;
                }
                if (ideturok == 1)
                {
                    Opazdivaju = 1;
                }
            }
            if (GetHour() == 10 && GetMinute() >= 20 && GetMinute() <= 50)
            {
                BigBreak = 1;
            }
            //5
            if (GetHour() == 11 && GetMinute() > 20 && GetMinute() <= 40)
            {
                AddDirection(game.location.shkolasport, new
                {
                    c = (Action)(() =>
                        { Set("Lesson_number", 5); })
                }, true);
                if (ideturok == 1)
                {
                    Opazdivaju = 1;
                }
            }

            AddDescription(@"
<center><b><font color = maroon>Школа</font></b></center>
<center><img src='/images/qwest/alter/gschool2.jpg'></center>
Вы учитесь в 10б классе<br>
На стене висит рассписание уроков<br>
Расписание 10б класса можно посмотреть <a href='scene:" + game.location.shkolarasspisanije.Scene + @"'>тут</a>
");
            if (ideturok == 0)
            {
                AddDescription(@"Сейчас перемена. Мелкие бегают кругом. Старшие стоят в сторонке");
                if (Get("walking_school") == 0)
                {
                    AddDynamicAction(new
                    {
                        Name = "Пройтись по школе",
                        Scene = "gorodok/school/shkolamaindynamic",
                        t = 2,
                        c = (Action)(() =>
                         {
                             Set("walking_school", 1);
                         })
                    });
                }
                if (Random(0, 3) > -1)
                {
                    JilijaMilovaSchool();
                }
            }
            else if (ideturok == 1)
            {
                AddDescription(@"Сейчас идет урок в Школе тихио.");
            }
            else
            {
                AddDescription(@"Сейчас в школе не учебное время");
            }

            int dir_rand = 0;
            if (GetHour() >= 8 && GetHour() < 13)
            {

                if (ideturok == 1)
                {
                    if (Opazdivaju == 1)
                    {
                        AddDescription("Я опаздываю на урок. надо поторопиться.");
                    }
                    else
                    {
                        AddDescription("Я опаздала на урок надо ждать следеющего.");
                        AddDynamicAction(new
                        {
                            Name = "Ждать 5 минут",
                            t = 5
                        });
                    }
                }
                dir_rand = Random(1, 5);
                if (dir_rand > 3 && ideturok == 0)
                {
                    AddDescription(@"Зауч школы " + game.actor.zauchshkoli.NN + " идет в учительскую");
                }
                else
                {
                    if (ideturok == 2)
                    {
                        AddDirection(game.location.shkolnijdvor, new { Name = "Выйти из школы", Description = "В школьный двор", t = 1 });
                        AddDynamicAction(new
                        {
                            Name = "Выйти из школы",
                            Scene = "gorodok/school/shkolnijdvor",
                            t = 1
                        });
                    }
                    else
                    {
                        AddDirection(game.location.shkolnijdvor, new { Name = "Убежать с уроков", Description = "В школьный двор", t = 1 });
                        AddDynamicAction(new
                        {
                            Name = "Убежать с уроков",
                            Scene = "gorodok/school/shkolnijdvor",
                            t = 1
                        });
                    }
                }
            }
            else
            {
                AddDirection(game.location.shkolnijdvor, new { Name = "Выйти из школы", Description = "В школьный двор", t = 1 });
                AddDynamicAction(new
                {
                    Name = "Выйти из школы",
                    Scene = "gorodok/school/shkolnijdvor",
                    t = 1
                });
            }

            if (GetHour() == 7 && GetMinute() < 50)
            {
                AddDynamicAction(new
                {
                    Name = "Ждать начало уроков",
                    Scene = "gorodok/school/shkolamain",
                    c = (Action)(() =>
             {
                 AddTime(51 - GetMinute());
             })
                });
            }

            if (BigBreak == 1)
            {
                AddDescription("Большая перемена");
                if (GetMinute() < 30)
                {
                    AddDirection(game.location.stolovka, new { Name = "Идти в столовую" }, true);
                    AddDynamicAction(new
                    {
                        Name = "Ждать начало следующего урока " + (30 - GetMinute()) + " мин.",
                        Scene = "gorodok/school/shkolamain",
                        c = (Action)(() =>
             {
                 AddTime(30 - GetMinute());
             })
                    });
                }
            }

            if (Get("history_individual_lesson_agree") == 1)
            {
                //Individualnije uroki istorii
            }
        }
    }
}
