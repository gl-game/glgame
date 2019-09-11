using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolazal : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Спорт зал");
            AddDescription(@"<img src='/images/school/sportzal.jpg' width='400' />");
            Set("Lesson_number", 5);
            if (Get("sportzal_status") == 0)
            {
                AddDescription("Физрук " + game.actor.fizruk.NN + " готовится к началу урока");

                AddDirection(game.location.shkolarazdevalkafemale, new { Name = "Идти в женскую раздевалку" }, true);
                AddDirection(game.location.shkolasport, new { Name = "Выйти из зала" }, true);

                AddDynamicAction(new
                {
                    Name = "Сделать разминку и построится в линейку",
                    c = (Action)(() =>
             {
                 int tm = 30 - GetMinute();
                 if (tm > 0)
                 {
                     AddTime(tm);
                 }
                 Set("Lesson_start", 0);
                 Set("sportzal_status", 1);
             })
                });

            }
            else
            {
                if (Get("Lesson_start") > 1)
                {
                    if (GetPlayer().Beauty > 15 && game.actor.fizruk.SexAddiction > 30 && game.actor.fizruk.Get("invited_podsobka") == 1)
                    {
                        AddDirection(game.location.shkolazalpodsobka, new { Name = "Идти в подсобку" }, true);
                    }

                    if (GetPlayer().Beauty > 15 && game.actor.fizruk.SexAddiction > 30 && game.actor.fizruk.Get("invited_podsobka") == 0)
                    {
                        AddDescription(@"Я смотрю у тебя есть предласположенность к спорту. Не хочешь пройти теоретические занятия");
                        AddDynamicAction(new
                        {
                            Name = "Пойти в подсобку",
                            Scene = "gorodok/school/shkolazalpodsobka",
                            c = (Action)(() =>
             {
                 game.actor.fizruk.Set("invited_podsobka", 1);
             })
                        });
                    }
                    AddDirection(game.location.shkolarazdevalkafemale, new { Name = "Идти в женскую раздевалку" }, true);
                    AddDirection(game.location.shkolasport, new { Name = "Выйти из зала" }, true);

                }
                else
                {
                    AddDescription(@"Физрук говорит что будем делать:");
                    int r = Random(1, 5);
                    if (r == 1)
                    {
                        AddDescription(@"Отжимания");
                        AddDynamicScene(new
                        {
                            Name = "Отжиматься",
                            c = (Action)(() =>
             {
                 int r1 = Random(1, 10);
                 if (r1 > 8)
                 {
                     GetPlayer().Strength += 1;
                     AddDescription(@"Я отжималась очень усердно.");
                 }
                 else if (r1 == 1)
                 {
                     GetPlayer().Strength -= 1;
                     AddDescription(@"Я потянула мышцу во время отжиманий.");
                     AddDescription(@"Физрук предлагает мне помазать руку кремом");

                     AddDynamicScene(new
                     {
                         Name = "Согласиться",
                         с = (Action)(() =>
  {
      if (GetPlayer().Beauty > 15 && Random(1, 3) > 1)
      {
          AddDescription("Во время смазки " + game.actor.firzuk.NN + " нечаянно коснулся моей груди");
          game.actor.fizruk.SexAddiction++;
          GetPlayer().Excite += 10;
      }
      else
      {
          AddDescription("Физрук помазал мне руку кремом");
      }

      game.actor.fizruk.Relationship++;
      Add("Lesson_start", 1);
      AddDynamicAction(new
      {
          Name = "Продолжить занятие",
          c = (Action)(() =>
{
    Add("Lesson_start", 1);
})
      });
  })
                     });

                     AddDynamicAction(new
                     {
                         Name = "Отказаться",
                         c = (Action)(() =>
  {
      Add("Lesson_start", 1);
  })
                     });

                 }
                 else
                 {
                     AddDescription(@"Я отжималась в течении 15 минут.");
                 }

                 if (GetPlayer().WearPantiesSkirt == 0 && Random(1, 3) > 2)
                 {
                     AddDescription(@"Физрук замечает отсутвие трусов под моей спортивной юбкой");
                     game.actor.fizruk.SexAddiction++;

                     if ((GetPlayer().PussyShave == 1 || GetPlayer().PussyShave == 2) && Random(1, 3) > 2)
                     {
                         AddDescription(@"Физрук заметил что у меня бритая киска");
                         game.actor.fizruk.SexAddiction++;
                     }
                     //next scenes
                 }
                 Set("otzimanija", 1);
                 AddDynamicAction(new
                 {
                     Name = "Далее",
                     c = (Action)(() =>
  {
      Add("Lesson_start", 1);
  })
                 });
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
             })
                        });
                    }

                    if (r == 2)
                    {
                        AddDescription(@"Залезать на канат");
                        AddDynamicScene(new
                        {
                            Name = "Залезать",
                            c = (Action)(() =>
             {
                 int r1 = Random(1, 10);
                 if (r1 > 8)
                 {
                     GetPlayer().Strength += 1;
                     AddDescription(@"Я очень быстро залезла на канат.");
                     AddDescription(@"Физрук хвалит меня.");
                     AddDescription(@"Физрук предлагает мне помочь спуститься");
                     AddDynamicScene(new
                     {
                         Name = "Согласиться",
                         с = (Action)(() =>
  {
      if (GetPlayer().Beauty > 15 && Random(1, 3) > 1)
      {
          AddDescription(game.actor.firzuk.NN + " нечаянно коснулся моей попы");
          game.actor.fizruk.SexAddiction++;
          GetPlayer().Excite += Random(1, 6);
      }
      else
      {
          AddDescription("Физрук помог мне спуситься");
      }
      game.actor.fizruk.Relationship++;
      Add("Lesson_start", 1);
      AddDynamicAction(new
      {
          Name = "Продолжить занятие",
          c = (Action)(() =>
{
    Add("Lesson_start", 1);
})
      });
  })
                     });
                 }
                 else if (r1 == 1)
                 {
                     GetPlayer().Strength -= 1;
                     AddDescription(@"Попыталась залезь на канат но у меня не пролучилось.");
                 }
                 else
                 {
                     AddDescription(@"Я залезла на канат.");
                 }
                 AddDynamicAction(new
                 {
                     Name = "Далее",
                     c = (Action)(() =>
  {
      Add("Lesson_start", 1);
  })
                 });
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
             })
                        });
                    }

                    if (r == 3)
                    {
                        AddDescription(@"Прыжки в динну");
                        AddDynamicScene(new
                        {
                            Name = "Прыгать",
                            c = (Action)(() =>
             {
                 int r1 = Random(1, 10);
                 if (r1 > 8)
                 {
                     GetPlayer().Strength += 1;
                     AddDescription(@"Я хорошо прыгнула через козла.");
                     AddDescription(@"Физрук хвалит меня.");
                     AddDescription(@"Физрук предлагает мне подержать ногу чтобы показать как лучше прыгать через козла");
                     AddDynamicScene(new
                     {
                         Name = "Согласиться",
                         с = (Action)(() =>
  {
      if (GetPlayer().Beauty > 15 && Random(1, 3) > 1)
      {
          AddDescription(game.actor.firzuk.NN + " нечаянно коснулся моей попы");
          game.actor.fizruk.SexAddiction++;
          GetPlayer().Excite += Random(1, 6);
      }
      else
      {
          AddDescription("Физрук Показывает как правильно прыгать через козла");
      }
      game.actor.fizruk.Relationship++;
      Add("Lesson_start", 1);
      AddDynamicAction(new
      {
          Name = "Продолжить занятие",
          c = (Action)(() =>
{
    Add("Lesson_start", 1);
})
      });
  })
                     });
                 }
                 else if (r1 == 1)
                 {
                     GetPlayer().Agility -= 1;
                     AddDescription(@"Ударилась во время прыжка о козла");
                 }
                 else
                 {
                     AddDescription(@"Перепрыгнула через козла.");
                 }
                 AddDynamicAction(new
                 {
                     Name = "Прожолжить урок",
                     c = (Action)(() =>
  {
      Add("Lesson_start", 1);
  })
                 });
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
             })
                        });
                    }

                    if (r == 4)
                    {
                        AddDescription(@"Присядания");
                        AddDynamicScene(new
                        {
                            Name = "Присядать",
                            c = (Action)(() =>
             {
                 int r1 = Random(1, 10);
                 if (r1 > 8)
                 {
                     GetPlayer().Vitality += 1;
                     AddDescription(@"Я приселадала очень усердно.");
                     AddDescription(@"Физрук хвалит меня.");
                 }
                 else
                 {
                     AddDescription(@"Я выполнила присядания.");
                 }
                 AddDynamicAction(new
                 {
                     Name = "Прожолжить урок",
                     c = (Action)(() =>
  {
      Add("Lesson_start", 1);
  })
                 });
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
             })
                        });
                    }

                    if (r == 5)
                    {
                        AddDescription(@"Волейбол");
                        AddDescription(@"Девочки разделились на команды.");
                        AddDynamicScene(new
                        {
                            Name = "Играть в волейбол",
                            c = (Action)(() =>
             {
                 int r1 = Random(1, 10);
                 if (r1 > 6)
                 {
                     AddDescription(@"Моя команда выигра");
                     AddDescription(@"Физрук хвалит мою команду.");
                     if (r1 > 8)
                     {
                         AddDescription(@" - В вы " + GetPlayer().Name + " особенно хрошо играли");
                         AddDescription(@" - Хочешь послушать о прфессиональом волеболе?");
                         AddDynamicScene(new
                         {
                             Name = "Слушать консультацию тренера",
                             с = (Action)(() =>
  {
      if (GetPlayer().Beauty > 15 && Random(1, 3) > 1)
      {
          AddDescription(game.actor.firzuk.NN + " показывает как прнмать мячь на прктике");
          AddDescription("Во время упражднений фирук невзначай качается моей попы руками");
          game.actor.fizruk.SexAddiction++;
          GetPlayer().Excite += Random(1, 6);
      }
      else
      {
          AddDescription("Физрук рассказывает как правильно принимать мячь");
      }
      game.actor.fizruk.Relationship++;
      Add("Lesson_start", 1);
      AddDynamicAction(new
      {
          Name = "Продолжить занятие",
          c = (Action)(() =>
{
    Add("Lesson_start", 1);
})
      });
  })
                         });
                     }
                 }
                 else
                 {
                     AddDescription(@"Моя команда проиграла");
                 }
                 AddDynamicAction(new
                 {
                     Name = "Прожолжить урок",
                     c = (Action)(() =>
  {
      Add("Lesson_start", 1);
  })
                 });
                 AddTime(game.helpers.LessonDuration(game.time, Get("Lesson_number")));
             })
                        });
                    }

                }


            }
        }
    }
}