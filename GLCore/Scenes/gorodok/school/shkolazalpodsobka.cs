using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolazalpodsobka : BaseScene
    {
        public override void GetView()
        {
            if (Get("finish_sex_fizruk") == 1)
            {
                AddDescription("Физрук расслабленый сидит на диване");
                AddDirection(game.location.shkolazal, new { Name = "Выйти из подсобки" }, true);
                Set("finish_sex_fizruk", 0);
                game.actor.fizruk.Set("naked", 0);
            }
            else
            {

                if (game.actor.fizruk.SexAddiction > 50 && game.actor.fizruk.Get("naked") == 1)
                {
                    AddDescription("Я увидела стоящий член Физрука");
                    AddDynamicScene(new
                    {
                        Name = "Смотреть на член",
                        c = (Action)(() =>
                        {

                            AddDescription("Я с любопытсвом рассматриваю член Физрука");
                            AddDynamicScene(new
                            {
                                Name = "Взять головку в рот",
                                c = (Action)(() =>
                                {
                                    AddDescription("Я взяла головку в рот");
                                    AddDescription("Я лижу гловку члена языком");
                                    game.actor.fizruk.Excite++;
                                    AddDynamicScene(new
                                    {
                                        Name = "Сосать дальше",
                                        c = (Action)(() =>
                                        {
                                            scene.CumMouthDescription(GetPlayer(), game.actor.fizruk);
                                            AddDynamicAction(new
                                            {
                                                Name = "Держать член во рту",
                                                c = (Action)(() =>
                                                {
                                                    GetPlayer().Skills.LearnSkill("suckskill");
                                                    GetPlayer().OralSexCount++;
                                                    Set("finish_sex_fizruk", 1);
                                                })
                                            });
                                        })
                                    });

                                    AddDynamicScene(new
                                    {
                                        Name = "Отказаться от идеи",
                                        c = (Action)(() =>
                                        {
                                            AddDescription("Я бросаю член и отхожу от Физрука");
                                            AddDynamicAction(new
                                            {
                                                Name = "Выйти из подсобки",
                                                Scene = "gorodok/school/shkolazal",
                                                c = (Action)(() =>
                                                {
                                                    game.actor.fizruk.SexAddiction -= 5;
                                                    game.actor.fizruk.Relationship--;
                                                })
                                            });
                                        })
                                    });
                                })
                            });



                        })
                    });

                }
                else if (game.actor.fizruk.SexAddiction > 50 && game.actor.fizruk.Get("naked") == 0)
                {
                    AddDescription("Хочешь посмотреть на мой член - спрашивает Физрук?");
                    AddDynamicAction(new
                    {
                        Name = "Да",
                        c = (Action)(() =>
                        {
                            game.actor.fizruk.Set("naked", 1);
                        })
                    });

                    AddDynamicScene(new
                    {
                        Name = "Нет (уйти)",
                        Scene = "gorodok/school/shkolazal",
                        c = (Action)(() =>
                        {
                            game.actor.fizruk.SexAddiction--;
                        })
                    });
                }
                else
                {
                    if (Get("fizruk_podsobka_endlesson") > 0)
                    {
                        AddDescription("Я закончила индивидуальный урок в подсобке");
                        AddDynamicAction(new
                        {
                            Name = "Идти в раздевалку",
                            Scene = "gorodok/school/shkolarazdevalkafemale",
                            c = (Action)(() =>
                            {
                                game.actor.fizruk.Set("naked", 0);
                            })
                        });

                    }
                    else
                    {
                        //AddDescription("Я пришла на индивидуальные занятия по физкультуре");
                        AddDescription("Подсобка физрука");
                        AddDescription("Физрук рассказывает о пользе физичкских уаражнений для женского тела");
                        int randaction = Random(1, 3);
                        if (randaction == 1)
                        {
                            AddDescription("Физрук предлагает мне сделать отжимания перед ним");

                            AddDynamicScene(new
                            {
                                Name = "Отжиматься",
                                с = (Action)(() =>
                                 {
                                     AddDescription("Физрук преceл передомной");
                                     AddDescription("Я заметела что чтото огромное выпирает из его штанов");
                                     game.actor.fizruk.Add("saw_dick_pants", 1);
                                     AddDynamicAction(new
                                     {
                                         Name = "Закончить отжимания",
                                         c = (Action)(() =>
                                            {
                                                Add("fizruk_podsobka_endlesson", 1);
                                                AddTime(2);
                                            })
                                     });
                                 })
                            });
                        }

                        if (randaction == 2)
                        {
                            AddDescription("Физрук предлагает мне сделать присядания перед ним");
                            AddDynamicScene(new
                            {
                                Name = "Присядать",
                                с = (Action)(() =>
             {
                 AddDescription("Физрук преceл передомной");
                 AddDescription("Я заметела что чтото огромное выпирает из его штанов");
                 game.actor.fizruk.Add("saw_dick_pants", 1);
                 AddDynamicAction(new
                 {
                     Name = "Закончить присядания",
                     c = (Action)(() =>
{
    Add("fizruk_podsobka_endlesson", 1);
    AddTime(2);
})
                 });
             })
                            });
                        }

                        if (randaction == 3)
                        {
                            AddDescription("Физрук предлагает мне порытаь га скакалке перед ним");
                            AddDynamicScene(new
                            {
                                Name = "Присядать",
                                с = (Action)(() =>
             {
                 AddDescription("Физрук престоит передомной");
                 AddDescription("Я заметела что чтото огромное выпирает из его штанов");
                 game.actor.fizruk.Add("saw_dick_pants", 1);
                 AddDynamicAction(new
                 {
                     Name = "Закончить прыжки",
                     c = (Action)(() =>
{
    Add("fizruk_podsobka_endlesson", 1);
    AddTime(2);
})
                 });
             })
                            });
                        }
                    }

                    AddDynamicScene(new
                    {
                        Name = "Уйти)",
                        Scene = "gorodok/school/shkolazal",
                        c = (Action)(() =>
                        {
                            Set("fizruk_podsobka_endlesson", 0);
                            AddTime(2);
                        })
                    });


                }

            }
        }
    }
}