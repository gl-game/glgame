using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolabiology : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Кабинет биологии");
            if (Get("biology_status") == 0)
            {
                AddDirection(game.location.shkolamain, new { Name = "Выйти из класса" });
                AddDescription("<img src='/images/school/biology/kabinet.jpg'>");
                AddDynamicAction(new
                {
                    Name = "Сесть за парту и ждать начала урока",
                    c = (Action)(() =>
             {
                 Set("Lesson_start", 0);
                 Set("biology_status", 1);
             })
                });
            }
            else
            {
                game.BlockStats = 1;

                if (Get("Lesson_start") == 3)
                {
                    AddDescription(@"
		<center><img src='/images/common/endofflesson" + Random(1, 1) + @".jpg' height=""270""></center>
		Урок закончен");
                    AddDynamicAction(new
                    {
                        Name = "Встать из-за парты и выйти в коридор",
                        Scene = "gorodok/school/shkolamain",
                        c = (Action)(() =>
             {
                 AddTime(1);
                 GetPlayer().Lessons.GetById("biologija").IsVisited = 1;
                 Set("Lesson_start", 0);
                 Set("biology_status", 0);
                 Set("legs_on", 0);
                 Set("biology_see_pussy", 0);
                 Set("biology_see_tits", 0);
                 Set("ask_question", 0);
             })
                    });
                }
                else
                {

                    AddDescription("Учитель биологии обьясняет новую тему");
                    AddDescription("<img src='/images/school/biology/teacher" + Random(1, 3) + ".jpg' height='170'>");
                    if (Get("ask_question") == 0)
                    {
                        AddDynamicActorAction(game.actor.uchiteljbiologii, new
                        {
                            Name = "Поднять руку и задать ворос по биологии",
                            c = (Action)(() =>
                                {

                                    AddDescription(@"<img src='/images/me/askquestion.jpg' width='270'>");
                                    AddDescription(@"Я встаю из-за парты. Я задаю учителю вопрос по Биологии");
                                    AddDescription(@"Учитель отвечает на вопрос.");
                                    if (Random(4, 9) > 3)
                                    {
                                        AddDescription(@"<b>Учитель добавляет: А вы " + GetPlayer().Name + " любознательная девушка</b>");
                                        game.actor.uchiteljbiologii.Relationship++;
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
                                })
                        });
                    }

                    AddDynamicAction(new
                    {
                        Name = "Слушать учителя",
                        c = (Action)(() =>
             {
                 int rnd1 = Random(6, 10);
                 GetPlayer().Lessons.GetById("biologija").SuccessRate = (GetPlayer().Lessons.GetById("biologija").SuccessRate + rnd1 / 2);
                 if (rnd1 > 8)
                 {
                     GetPlayer().Skills.LearnSkill("anatomy");
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
                 GetPlayer().Lessons.GetById("biologija").SuccessRate = (GetPlayer().Lessons.GetById("biologija").SuccessRate + Random(0, 5) / 2);
                 Set("Lesson_start", Get("Lesson_start") + 1);
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
             })
                    });

                    if (GetPlayer().WearBra == 0 && Get("biology_see_tits") == 0)
                    {
                        int r2 = Random(1, 10);
                        if (r2 > 5)
                        {
                            AddDescription(@"
				<center><img src='/images/nobra/nobrashirt.jpg' height='70'></center>
				<b>Учитель биологии " + game.actor.uchiteljbiologii.NN + @" замечает что на мне нет лифчика</b>");
                            Set("biology_see_tits", 1);
                            game.actor.uchiteljbiologii.SexAddiction++;
                            if (Random(4, 9) > 7)
                            {
                                GetPlayer().Skills.LearnSkill("seductionskill");
                            }
                        }
                        else
                        {
                            AddDescription(@"<b style='color: #000096'>Я без лифчика<b>");
                        }
                    }


                }

            }
        }
    }
}
