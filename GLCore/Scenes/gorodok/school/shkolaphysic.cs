using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolaphysic : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Кабинет физики");
            if (Get("physics_status") == 0)
            {
                AddDirection(game.location.shkolamain, new { Name = "Выйти из класса" });
                AddDescription(@"<img src='/images/teacher/physics/kabinetfiziki.jpg' width='470px'>");
                AddDynamicAction(new
                {
                    Name = "Сесть за парту и ждать начала урока",
                    c = (Action)(() =>
             {
                 Set("Lesson_start", 0);
                 Set("physics_status", 1);
             })
                });
            }
            else
            {
                game.BlockStats = 1;
                if (Get("ask_question") == 1)
                {

                    AddDescription(@"Я встаю из-за парты. Я задаю учителю вопрос по физике");
                    AddDescription(@"<img src='/images/me/askquestion.jpg' width='270'>");
                    AddDescription(@"Учитель отвечает на вопрос.");
                    if (Random(4, 9) > 6)
                    {
                        AddDescription(@"<b>Учитель добавляет: А вы " + GetPlayer().Name + " любознательная девушка</b>");
                        game.actor.uchiteljfiziki.Relationship++;
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
		<center><img src='/images/common/endofflesson" + Random(1, 1) + @".jpg' height=""270""></center>
		Урок закончен");
                    AddDynamicAction(new
                    {
                        Name = "Встать из-за парты",
                        Scene = "gorodok/school/shkolamain",
                        c = (Action)(() =>
             {
                 AddTime(1);
                 GetPlayer().Lessons.GetById("fizika").IsVisited = 1;
                 Set("Lesson_start", 0);
                 Set("physics_status", 0);
                 Set("legs_on", 0);
                 Set("physic_see_pussy", 0);
                 Set("physic_see_tits", 0);
                 Set("ask_question", 0);
             })
                    });
                }
                else
                {
                    if (Get("ask_question") == 0)
                    {
                        AddActorAction(game.actor.uchiteljfiziki, new
                        {
                            Name = "Поднять руку и задать ворос по физике",
                            c = (Action)(() =>
                                {
                                    Set("ask_question", 1);
                                })
                        });
                    }
                    AddDescription(@"
		<center><img src='/images/teacher/physics/teacher" + Random(1, 3) + @".jpg'></center>
		Учитель физики " + game.actor.uchiteljfiziki.NN + @" обясняет новый материал");

                    AddDynamicAction(new
                    {
                        Name = "Слушать учителя",
                        c = (Action)(() =>
             {
                 int rnd1 = Random(6, 10);
                 GetPlayer().Lessons.GetById("fizika").SuccessRate = (GetPlayer().Lessons.GetById("fizika").SuccessRate + rnd1 / 2);
                 if (rnd1 > 8)
                 {
                     GetPlayer().Skills.LearnSkill("physicskill");
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
                 GetPlayer().Lessons.GetById("fizika").SuccessRate = (GetPlayer().Lessons.GetById("fizika").SuccessRate + Random(0, 5) / 2);
                 Set("Lesson_start", Get("Lesson_start") + 1);
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
             })
                    });
                    if (GetPlayer().WearPantiesSkirt == 0 && Get("physic_see_pussy") == 0)
                    {
                        int r = Random(1, 10);
                        if (r > 8 - Get("legs_on") * 5)
                        {
                            AddDescription(@"
				<center><img src='/images/nopanties/splitlegs.jpg' height='70'></center>
				<b>Учитель физики замечает что на мне нет трусиков</b>");
                            Set("physic_see_pussy", 1);
                            Set("legs_on", 1);
                            game.actor.uchiteljfiziki.SexAddiction++;
                            if (Random(4, 9) > 7)
                            {
                                GetPlayer().Skills.LearnSkill("seductionskill");
                            }
                        }
                        else
                        {
                            //AddDescription(@"<b style='color: #000096'>Надо держать ноги вместе. Я же без трусиков<b>");
                        }
                        if (Get("legs_on") == 0 && game.actor.uchiteljfiziki.SexAddiction < 15 && GetPlayer().Skills.GetValue("seductionskill") > 10)
                        {
                            AddDynamicAction(new
                            {
                                Name = "Раздвинуть ноги и слушать учителя",
                                c = (Action)(() =>
             {
                 Set("legs_on", 1);
                 Set("Lesson_start", Get("Lesson_start") + 1);
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
                 int rnd2 = Random(4, 9);
                 GetPlayer().Lessons.GetById("fizika").SuccessRate = (GetPlayer().Lessons.GetById("fizika").SuccessRate + rnd2 / 2);
                 if (rnd2 > 7)
                 {
                     GetPlayer().Skills.LearnSkill("physicskill");
                 }
             })
                            });
                        }
                    }

                    if (GetPlayer().WearBra == 0 && Get("physic_see_tits") == 0)
                    {
                        int r2 = Random(1, 10);
                        if (r2 > 5)
                        {
                            AddDescription(@"
				<center><img src='/images/nobra/nobrashirt.jpg' height='70'></center>
				<b>Учитель физики замечает что на мне нет лифчика</b>");
                            Set("physic_see_tits", 1);
                            game.actor.uchiteljfiziki.SexAddiction++;
                            if (Random(4, 9) > 7)
                            {
                                GetPlayer().Skills.LearnSkill("seductionskill");
                            }
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