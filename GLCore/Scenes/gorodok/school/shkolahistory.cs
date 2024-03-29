using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolahistory : BaseScene
    {
        public override void GetView()
        {
            if (Get("promise_wear_history") == 1)
            {
                GoTo("gorodok/school/shkolamain", "Я обещала не являтся на урок без нижнего белья");
                return;
            }
            AddDescription(@"Кабинет истории");
            if (Get("history_status") == 0)
            {
                AddDirection(game.location.shkolamain, new { Name = "Выйти из класса" });
                AddDescription("<img src='/images/school/history/kabinet.jpg' height='270'>");
                AddDynamicAction(new
                {
                    Name = "Сесть за парту и ждать начала урока",
                    c = (Action)(() =>
             {
                 Set("Lesson_start", 0);
                 Set("history_status", 1);
             })
                });
            }
            else
            {
                game.BlockStats = 1;
                if (game.actor.uchitelnicaistorii.Get("see_naked") > 9 && (GetPlayer().WearBra == 0 || GetPlayer().WearPantiesSkirt == 0) && Get("allow_naked_always_history") == 0)
                {
                    AddDescription(@"К вам поджодит учительница истории");
                    AddDescription(@"" + GetPlayer().Name + @", ты что себе позволяешь?<br>
		Чтобы я тебя больше не видела в подобном виде у себя на уроках
		");
                    AddDynamicAction(new
                    {
                        Name = "Я обещаю что буду носить нижнее белъе",
                        c = (Action)(() =>
                         {
                             GetPlayer().SexualView--;
                             game.actor.uchitelnicaistorii.Relationship++;
                             Set("promise_wear_history", 1);
                         })
                    });
                    if (GetPlayer().Skills.GetValue("speakingskill") > 50 || GetPlayer().Skills.GetValue("speakingskillfemale") > 30)
                    {
                        AddDynamicAction(new
                        {
                            Name = "Я просто забываю одеть лифчик иногда. Простите.",
                            c = (Action)(() =>
                                 {
                                     GetPlayer().Skills.LearnSkill("speakingskill", 2);
                                     GetPlayer().Skills.LearnSkill("speakingskillfemale", 3);
                                     GetPlayer().SexualView++;
                                     game.actor.uchitelnicaistorii.Relationship++;
                                     Set("allow_naked_always_history", 1);
                                 })
                        });
                    }

                }
                else
                {
                    if (Get("ask_question") == 1)
                    {

                        AddDescription(@"Я встаю из-за парты. Я задаю учителю вопрос по физике");
                        AddDescription(@"Учитель отвечает на вопрос.");
                        if (Random(4, 9) > 6)
                        {
                            AddDescription(@"<b>Учительница добавляет: А вы " + GetPlayer().Name + " любознательная девушка</b>");
                            game.actor.uchitelnicaistorii.Relationship++;
                            GetPlayer().Skills.LearnSkill("speakingskill");
                        }
                        AddDynamicAction(new
                        {
                            Name = "Сесть за парту",
                            c = (Action)(() =>
                             {
                                 Set("ask_question", 2);
                             })
                        });
                        return;
                    }

                    if (Get("Lesson_start") == 3)
                    {
                        AddDescription(@"
		<	center><img src='/images/common/endofflesson" + Random(1, 1) + @".jpg' height=""270""></center>
			Урок закончен");
                        AddDynamicAction(new
                        {
                            Name = "Встать из-за парты",
                            Scene = "gorodok/school/shkolamain",
                            c = (Action)(() =>
                             {
                                 AddTime(1);
                                 GetPlayer().Lessons.GetById("istorija").IsVisited = 1;
                                 Set("Lesson_start", 0);
                                 Set("history_status", 0);
                                 Set("legs_on", 0);
                                 Set("history_see_tits", 0);
                                 Set("ask_question", 0);
                             })
                        });
                    }
                    else
                    {
                        AddDescription(@"
			<center><img src='/images/school/history/teacher" + Random(1, 3) + @".jpg'></center>
			Учительница истории " + game.actor.uchitelnicaistorii.NN + @" объясняет новый материал");

                        if (Get("ask_question") == 0)
                        {
                            AddDynamicActorAction(game.actor.uchitelnicaistorii, new
                            {
                                Name = "Поднять руку и задать ворос по Истории",
                                c = (Action)(() =>
                                    {
                                        AddDescription(@"<img src='/images/me/askquestion.jpg' width='270'>");
                                        AddDescription(@"Я встаю из-за парты. Я задаю учителю вопрос по Истории");
                                        AddDescription(@"Учительница отвечает на вопрос.");
                                        if (Random(4, 9) > 3)
                                        {
                                            AddDescription(@"<b>Учительница добавляет: А вы " + GetPlayer().Name + " любознательная девушка</b>");
                                            game.actor.uchitelnicaistorii.Relationship++;
                                            GetPlayer().Skills.LearnSkill("historyskill");
                                        }
                                        AddDynamicAction(new
                                        {
                                            Name = "Сесть за парту",
                                            c = (Action)(() =>
                 {
                     Set("ask_question", 2);
                 })
                                        });
                                    })
                            });
                        }

                        if (GetPlayer().Skills.GetValue("historyskill") > 70 && Get("history_individual_lesson_agree") == 0)
                        {
                            AddDynamicActorAction(game.actor.uchitelnicaistorii, new
                            {
                                Name = "Поднять руку и задать ворос по Истории Древнего рима",
                                c =
                                (Action)(() =>
                                 {
                                     AddDescription(@"Я встаю из-за парты. Я задаю учителю вопрос по Истории Древнего рима");
                                     AddDescription(@"Учительница отвечает на вопрос.");
                                     if (Random(4, 9) > 3)
                                     {
                                         AddDescription(@"<b>Учительница добавляет: А вы " + GetPlayer().Name + " любознательная девушка. Интересуетесь древним римом</b>");
                                         game.actor.uchitelnicaistorii.Relationship++;
                                         GetPlayer().Skills.LearnSkill("historyskill");
                                         if (game.actor.uchitelnicaistorii.Relationship > 70)
                                         {
                                             AddDescription(@"Не хочешь ли прийти на дополнительные занятия после уроков в 14:00?");
                                             AddDynamicAction(new
                                             {
                                                 Name = "Я подумаю",
                                                 c = (Action)(() =>
                                                    {
                                                        Set("ask_question", 2);
                                                    })
                                             });
                                             AddDynamicAction(new
                                             {
                                                 Name = "Я обязательно приду",
                                                 c = (Action)(() =>
                                                    {
                                                        Set("history_individual_lesson_agree", 1);
                                                        Set("ask_question", 2);
                                                    })
                                             });
                                         }
                                         else
                                         {
                                             AddDynamicAction(new
                                             {
                                                 Name = "Сесть за парту",
                                                 c = (Action)(() =>
                                                    {
                                                        Set("ask_question", 2);
                                                    })
                                             });
                                         }

                                     }
                                     else
                                     {

                                         AddDynamicAction(new
                                         {
                                             Name = "Сесть за парту",
                                             c = (Action)(() =>
                                                {
                                                    Set("ask_question", 2);
                                                })
                                         });

                                     }
                                 })
                            });
                        }

                        AddDynamicAction(new
                        {
                            Name = "Слушать учителя",
                            c = (Action)(() =>
             {
                 int rnd1 = Random(6, 10);
                 GetPlayer().Lessons.GetById("istorija").SuccessRate = (GetPlayer().Lessons.GetById("istorija").SuccessRate + rnd1 / 2);
                 if (rnd1 > 8)
                 {
                     GetPlayer().Skills.LearnSkill("historyskill");
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
                 GetPlayer().Lessons.GetById("istorija").SuccessRate = (GetPlayer().Lessons.GetById("istorija").SuccessRate + Random(0, 5) / 2);
                 Set("Lesson_start", Get("Lesson_start") + 1);
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
             })
                        });
                        if (GetPlayer().WearPantiesSkirt == 0 && Get("history_see_pussy") == 0)
                        {
                            int r = Random(1, 10);
                            if (r > 8 - Get("legs_on") * 5)
                            {
                                AddDescription(@"
					<center><img src='/images/nopanties/splitlegs.jpg' height='70'></center>
					<b>Учительница истории замечает что на мне нет трусиков</b>");

                                if (Get("allow_naked_always_history") == 0)
                                {
                                    AddDescription(@"Учительница рассказыает что в раньше женщины не позволяли приходить в общественные заведения в подобном виде");
                                    AddDynamicAction(new
                                    {
                                        Name = "Прикрыть ноги юбкой"
                                    });
                                    if (Random(1, 10) > 8)
                                    {
                                        GetPlayer().SexualView--;
                                    }
                                    game.actor.uchitelnicaistorii.Add("see_naked", 1);
                                }
                                else
                                {
                                    game.actor.uchitelnicaistorii.SexAddiction++;
                                }
                                Set("history_see_pussy", 1);
                            }
                        }

                        if (GetPlayer().WearBra == 0 && Get("history_see_tits") == 0)
                        {
                            int r2 = Random(1, 10);
                            if (r2 > 5)
                            {
                                AddDescription(@"
					<center><img src='/images/nobra/nobrashirt.jpg' height='70'></center>
					<b>Учительница истории замечает что на мне нет лифчика</b>");
                                if (Get("allow_naked_always_history") == 0)
                                {
                                    AddDescription(@"Учительница рассказыает что в раньше женщины вели себя более скромно и старались прикрывать свои половые органы явно указывая на меня.");
                                    AddDescription(@"Учениеи в классе перешептываются.");
                                    GetPlayer().SexualView--;
                                    game.actor.uchitelnicaistorii.Add("see_naked", 1);
                                }
                                else
                                {
                                    game.actor.uchitelnicaistorii.SexAddiction++;
                                }
                                Set("history_see_tits", 1);
                            }
                            else
                            {
                                //AddDescription(@"<b style='color: #000096'>Я без лифчика<b>");
                            }
                        }
                    }
                }

            }
        }
    }
}