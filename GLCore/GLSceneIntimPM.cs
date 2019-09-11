using GLCore.Actors;
using GLCore.Objects;
using GLHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GLCore
{
    public partial class GLScene : IDisposable
    {
        private Action StartPosition { get; set; }
        private bool ActorFinished { get; set; }
        private int HaveVaginalSex { get; set; }
        private int HaveAnalSex { get; set; }
        private int HaveOralSex { get; set; }
        private int HaveHandSex { get; set; }
        private int BanAnal { get; set; }
        private int BanVaginal { get; set; }
        private int BanOral { get; set; }

        private void NextSceneSuck(Player player, IMale partner)
        {
            AddDynamicScene(new
            {
                Name = "Сосать дальше",
                c = (Action)(() =>
                {
                    ActiveSuck(player, partner);
                })
            });
            AddDynamicScene(new
            {
                Name = "Другая позиция",
                c = StartPosition
            });
        }

        private void NextSceneHand(Player player, IMale partner)
        {
            HaveHandSex++;
            AddDynamicScene(new
            {
                Name = "Работать руками дальше",
                c = (Action)(() =>
                {
                    ActiveHandsFuck(player, partner);
                })
            });
            AddDynamicScene(new
            {
                Name = "Другая позиция",
                c = StartPosition
            });
        }


        private void PassiveSuckDick(Player player, IMale partner)
        {
            AddDynamicScene(new
            {
                Name = "Сосать",
                c = (Action)(() =>
                {
                    AddDescription("Я сосу член");
                    AddDescription("Я беру головку члена в рот и ласкаю ее губками и язычком.");
                    AddDynamicScene(new
                    {
                        Name = "Ждать следующего действия",
                        c = (Action)(() =>
                        {
                            StartPassivePosition(player, partner);
                        })
                    });
                })
            });
            if (player.Skills.GetValue("suckskill") >= 50)
            {
                AddDynamicScene(new
                {
                    Name = "Лизать",
                    c = (Action)(() =>
                    {
                        AddDescription("Я лижу член");
                        AddDescription("Я вожу языком вдоль члена, стараясь облизать его весь.");
                        AddDynamicScene(new
                        {
                            Name = "Ждать следующего действия",
                            c = (Action)(() =>
                            {
                                StartPassivePosition(player, partner);
                            })
                        });
                    })
                });
            }
            if (player.SexualView > 50 && player.Drink < 5)
            {
                AddDynamicScene(new
                {
                    Name = "Прекратить",
                    Scene = data.CurrentScene,
                    c = (Action)(() =>
                    {
                        StopIntim(player, partner);
                    })
                });
            }
        }

        private void CumAss(Player player, IMale partner)
        {
            ClearDescription();
            if (partner.UseCondom == 0)
            {
                AddDescription(partner.Name + " кончает мне в попку. Я чувствую как струя спермы ударяет в меня");
            }
            else
            {
                partner.UseCondom = 0;
                AddDescription(partner.Name + " кончает в презерватив двигаясь в моей попке");
            }
            if (player.Excite > 100)
            {
                AddDescription("<b>Струя спермы ударяет в мою поппу и от этого ощющения я кончаю.</b>");
                player.Excite = 0;
            }
            partner.SexAddiction += 10;
            AddDynamicAction(
                new
                {
                    Name = "Встати и одеться",
                    c = (Action)(() =>
                    {
                        partner.Relationship += 5;
                        partner.SexAddiction += 5;

                        LearnSkills(player);
                        data.time.AddTime(5);
                    })
                }
            );
            partner.Excite = 0;
        }

        public void CumMouthDescription(Player player, IMale partner)
        {
            ClearDescription();
            if (partner.UseCondom == 0)
            {
                AddDescription(partner.Name + " кончает мне в вот.");
            }
            else
            {
                partner.UseCondom = 0;
                AddDescription(partner.Name + " кончает в презерватив двигаясь в моей киске");
            }
            /*
            if (player.Excite > 100)
            {
                AddDescription("<b>Струя спермы ударяет в меня и от этого ощющения я кончаю.</b>");
                player.Excite = 0;
            }
             */ 
            partner.SexAddiction += 10;
            partner.Excite = 0;
        }

        private void CumPussy(Player player, IMale partner)
        {
            ClearDescription();
            if (partner.UseCondom == 0)
            {
                AddDescription(partner.Name + " кончает мне в пизду. Я чувствую как струя спермы ударяет в меня");
            }
            else
            {
                partner.UseCondom = 0;
                AddDescription(partner.Name + " кончает в презерватив двигаясь в моей киске");
            }
            if (player.Excite > 100)
            {
                AddDescription("<b>Струя спермы ударяет в меня и от этого ощющения я кончаю.</b>");
                player.Excite = 0;
            }
            partner.SexAddiction += 10;
            AddDynamicAction(
                new
                {
                    Name = "Встати и одеться",
                    c = (Action)(() =>
                    {
                        partner.SexAddiction += 5;
                        partner.Relationship += 5;
                        LearnSkills(player);
                        data.time.AddTime(5);
                        //Dress
                    })
                }
            );
            partner.Excite = 0;
        }

        private int callPassiveFuckAnal;
        private void PassiveFuckAnal(Player player, IMale partner)
        {
            Rand r = new Rand();
            if (callPassiveFuckAnal == 1)
            {
                partner.Excite += r.Next(8, 10);
                player.Excite += r.Next(2, 3);
                AddDescription(partner.Name + " трахает меня в мою попу быстро");

            }
            else if (callPassiveFuckAnal == 2)
            {
                partner.Excite += r.Next(11, 13);
                player.Excite += r.Next(3, 4);
                AddDescription(partner.Name + " трахает меня в попу. Я двигаюсь ему на встречу.");
            }
            else
            {
                partner.Excite += r.Next(5, 8);
                player.Excite += r.Next(1, 2);
                AddDescription(partner.Name + " трахает меня в попу.");
            }
            HaveAnalSex++;
            AddDynamicScene(new
            {
                Name = "Лежать неподвижно",
                c = (Action)(() =>
                {
                    if (r.Next(1, 3) > 2)
                    {
                        AddDescription(partner.Name + " вынимает член из моей попы.");
                        StartPassivePosition(player, partner, 3);
                    }
                    else
                    {
                        callPassiveFuckAnal = r.Next(0, 1);
                        PassiveFuckAnal(player, partner);
                    }
                })
            });
            if (player.Skills.GetValue("analskill") > 30 && player.Excite > 10)
            {
                AddDynamicScene(new
                {
                    Name = "Попросить усилить темп",
                    c = (Action)(() =>
                    {
                        callPassiveFuckAnal = 1;
                        PassiveFuckAnal(player, partner);
                    })
                });
            }
            if (player.Skills.GetValue("analskill") > 50 && player.Excite > 20)
            {
                AddDynamicScene(new
                {
                    Name = "Двигаться быстрее навтсречу",
                    c = (Action)(() =>
                    {
                        callPassiveFuckAnal = 2;
                        PassiveFuckAnal(player, partner);
                    })
                });
            }

            if (player.Excite > 100 && partner.Excite <= 100)
            {
                AddDescription("<b>Пока " + partner.Name + " трахает меня в поппу меня накрывает огразм</b>");
                player.Excite = 0;
            }
            if (partner.Excite > 100)
            {
                CumAss(player, partner);
                return;
            }

            callPassiveFuckAnal = 0;
        }

        private int callPassiveFuckVaginal;
        private void PassiveFuckVaginal(Player player, IMale partner)
        {
            HaveVaginalSex++;
            Rand r = new Rand();
            if (callPassiveFuckVaginal == 1)
            {
                partner.Excite += r.Next(8, 10);
                player.Excite += r.Next(8, 10);
                AddDescription(partner.Name + " трахает меня в мою мокрую щелку быстро");

            }
            else if (callPassiveFuckVaginal == 2)
            {
                partner.Excite += r.Next(11, 13);
                player.Excite += r.Next(11, 13);
                AddDescription(partner.Name + " трахает меня в мою мокрую щелку быстро. Я двигаюсь ему на встречу.");

            }
            else if (callPassiveFuckVaginal == 3)
            {
                partner.Excite += r.Next(11, 13);
                player.Excite += r.Next(11, 13);
                AddDescription(partner.Name + " трахает меня в мою мокрую щелку. Я стону от удовольствия.");
            }
            else if (callPassiveFuckVaginal == 4)
            {
                partner.Excite += r.Next(11, 13);
                player.Excite += r.Next(11, 13);
                AddDescription(partner.Name + " медленно трахает меня в пизду. Член входит на всю длинну и я очень хорошо чувствую член.");
            }
            else if (callPassiveFuckVaginal == 5)
            {
                partner.Excite += r.Next(30, 40);
                player.Excite += r.Next(11, 13);
                AddDescription(partner.Name + " трахает меня в пизду. Я сжимаю свою киску застляя его кончать как можно скорее");
            }
            else
            {
                partner.Excite += r.Next(5, 8);
                player.Excite += r.Next(5, 8);
                AddDescription(partner.Name + " трахает меня в пизду.");

            }
            if (player.Excite > 100 && partner.Excite <= 100)
            {
                AddDescription("<b>Пока " + partner.Name + " трахает меня в пизду меня накрывает огразм</b>");
                player.Excite = 0;
            }
            if (partner.Excite > 100)
            {
                CumPussy(player, partner);
                return;
            }
            AddDynamicScene(new
            {
                Name = "Лежать неподвижно",
                c = (Action)(() =>
                {
                    if (r.Next(1, 3) > 2)
                    {
                        AddDescription(partner.Name + " вынимает член из моей пизды.");
                        StartPassivePosition(player, partner, 3);
                    }
                    else
                    {
                        callPassiveFuckVaginal = r.Next(0, 1);
                        PassiveFuckVaginal(player, partner);
                    }
                })
            });
            if (player.Skills.GetValue("vaginalskill") > 30 && player.Excite > 10)
            {
                AddDynamicScene(new
                {
                    Name = "Попросить усилить темп",
                    c = (Action)(() =>
                    {
                        callPassiveFuckVaginal = 1;
                        PassiveFuckVaginal(player, partner);
                    })
                });
            }
            if (player.Skills.GetValue("vaginalskill") > 50 && player.Excite > 20)
            {
                AddDynamicScene(new
                {
                    Name = "Двигаться быстрее навтсречу",
                    c = (Action)(() =>
                    {
                        callPassiveFuckVaginal = 2;
                        PassiveFuckVaginal(player, partner);
                    })
                });
            }
            if (player.Skills.GetValue("vaginalskill") > 70 && player.Excite > 30)
            {
                AddDynamicScene(new
                {
                    Name = "Наслаждаться движением члена в моем теле",
                    c = (Action)(() =>
                    {
                        callPassiveFuckVaginal = 3;
                        PassiveFuckVaginal(player, partner);
                    })
                });
            }

            if (player.Skills.GetValue("vaginalskill") > 90 && player.Excite > 40)
            {
                AddDynamicScene(new
                {
                    Name = "Попросить трахать медленно но вгонять на всю длинну",
                    c = (Action)(() =>
                    {
                        callPassiveFuckVaginal = 4;
                        PassiveFuckVaginal(player, partner);
                    })
                });
            }

            if (player.Skills.GetValue("vaginalskill") > 95 && player.Excite > 45)
            {
                AddDynamicScene(new
                {
                    Name = "Сжимать мышцы влагалища",
                    c = (Action)(() =>
                    {
                        callPassiveFuckVaginal = 5;
                        PassiveFuckVaginal(player, partner);
                    })
                });
            }
            if (player.Skills.GetValue("analskill") > 70 && player.Excite > 50)
            {
                AddDynamicScene(new
                {
                    Name = "Попросить в попку",
                    c = (Action)(() =>
                    {
                        callPassiveFuckVaginal = 0;
                        StartPassivePosition(player, partner);
                    })
                });
            }
            callPassiveFuckVaginal = 0;

        }

        private void StartPassivePosition(Player player, IMale partner, int Exclude = 0)
        {
            Rand r = new Rand();
            int rnd = r.Next(1, 3);
            if (BanVaginal == 1 && BanAnal == 1 && rnd == 3)
            {
                rnd = 2;
            }
            while (rnd == Exclude)
            {
                rnd = r.Next(1, 3);
            }
            if (rnd == 1)
            {
                AddDescription(partner.Name + " Ложит член ко мне в руки");
                PassiveHandJob(player, partner);

            }
            if (rnd == 2)
            {
                AddDescription(partner.Name + " подносит свой член к моему рту");
                PassiveSuckDick(player, partner);
            }
            if (rnd == 3 && (BanVaginal == 0 || BanAnal == 0))
            {
                AddDescription(partner.Name + " ложит меня на спину");
                PassiveFuckStart(player, partner);
            }

        }

        private void PassiveFuckStart(Player player, IMale partner)
        {
            Rand r = new Rand();
            int rnd = r.Next(1, 2);
            if (BanAnal == 1)
            {
                rnd = 2;
            }
            if (BanVaginal == 1)
            {
                rnd = 1;
            }
            if (rnd == 1 && BanAnal == 0)
            {
                AddDescription(partner.Name + " Подносит член к моей попке");
                if (player.AnalSexCount == 0)
                {
                    AddDescription("- Это мой первый раз в попу");
                    AddDescription("Ты точно этого хочешь? - спросил "+ partner.Name);
                    AddDynamicScene(new
                    {
                        Name = "Да",
                        c = (Action)(() =>
                        {
                            HaveAnalSex++;
                            AddDescription(partner.Name + " вставляет мне в попу");
                            AddDescription("От резкой боли у меня летят искры из глаз");
                            player.SetProperty("AnalPain", 1);
                            StopIntimPainAnal(player, partner);
                        })
                    });

                    AddDynamicScene(new
                    {
                        Name = "Нет прекратим сейчас-же",
                        c = (Action)(() =>
                        {
                            StopIntim(player, partner);
                        })
                    });

                    AddDynamicScene(new
                    {
                        Name = "Давай я лучше пососу?",
                        c = (Action)(() =>
                        {
                            PassiveSuckDick(player, partner);
                        })
                    });
                }
                else
                {
                    AddDynamicScene(new
                    {
                        Name = "Ничего не делать",
                        c = (Action)(() =>
                        {
                            AddDescription(partner.Name + " вставляет мне в попу");
                            AddDynamicScene(new
                            {
                                Name = "Ждать следующего действия",
                                c = (Action)(() =>
                                {
                                    PassiveFuckAnal(player, partner);
                                })
                            });
                        })
                    });
                }
            }
            else
            {
                AddDescription(partner.Name + " Подносит член к моей киске");

                AddDynamicScene(new
                {
                    Name = "Ничего не делать",
                    c = (Action)(() =>
                    {
                        AddDescription(partner.Name + " вставляет мне в киску член");
                        AddDynamicScene(new
                        {
                            Name = "Ждать следующего действия",
                            c = (Action)(() =>
                            {
                                PassiveFuckVaginal(player, partner);
                            })
                        });
                    })
                });

                if (player.SmallBag != null && player.GetStuffByIdSmallBag(data.stuff.condom) != null)
                {
                    AddDynamicScene(new
                    {
                        Name = "Просить одеть презеватив",
                        c = (Action)(() =>
                        {
                            Condom cd = player.GetStuffByIdSmallBag(data.stuff.condom);
                            if (!player.UseCondom(cd))
                            {
                                player.RemoveStaff(cd, player.SmallBag);
                            }
                            AddDescription(partner.Name + " Одевает презерватив");
                            partner.UseCondom = 1;
                            PassiveFuckVaginal(player, partner);

                        })
                    });
                }

                if (player.Skills.GetValue("vaginalskill") > 30)
                {

                    AddDynamicScene(new
                    {
                        Name = "Раздвинуть ноги шире",
                        c = (Action)(() =>
                        {
                            AddDescription("Я раздвинула ноги шире");
                            AddDynamicScene(new
                            {
                                Name = "Приготовится к вхождению",
                                c = (Action)(() =>
                                {
                                    PassiveFuckVaginal(player, partner);
                                })
                            });
                        })
                    });
                }

                if (player.Skills.GetValue("vaginalskill") > 60)
                {

                    AddDynamicScene(new
                    {
                        Name = "Лечь так чтобы ему было удобно зайти",
                        c = (Action)(() =>
                        {
                            AddDescription("Я поставляю свою мокрую киску под его член");
                            AddDynamicScene(new
                            {
                                Name = "Приготовится к вхождению",
                                c = (Action)(() =>
                                {
                                    PassiveFuckVaginal(player, partner);
                                })
                            });
                        })
                    });
                }
            }

            if (player.SexualView > 50 && player.Drink < 5)
            {
                AddDynamicAction(new
                {
                    Name = "Прекратить",
                    Scene = data.CurrentScene,
                    c = (Action)(() =>
                    {
                        partner.SexAddiction -= 4;
                        partner.Relationship -= 4;
                    })
                });
            }

        }

        private void PassiveHandJob(Player player, IMale partner)
        {
            AddDynamicScene(new
            {
                Name = "Дрочить",
                c = (Action)(() =>
                {
                    AddDescription("Я дрочу " + partner.Name);
                    AddDescription("Я вожу своей рукой вдоль члена вверх и вниз.");
                    AddDynamicScene(new
                    {
                        Name = "Ждать реакции " + partner.Name,
                        c = (Action)(() =>
                        {
                            StartPassivePosition(player, partner);
                        })
                    });
                })
            });
            if (player.Skills.GetValue("suckskill") >= 50)
            {
                AddDynamicScene(new
                {
                    Name = "Гладить головку",
                    c = (Action)(() =>
                    {
                        AddDescription("Я глажу головку члена");
                        AddDescription("Я ложу ладошку на головку члена и начинаю ее полировать.");
                        AddDynamicScene(new
                        {
                            Name = "Ждать партнера " + partner.Name,
                            c = (Action)(() =>
                            {
                                StartPassivePosition(player, partner);
                            })
                        });
                    })
                });
            }
            if (player.SexualView > 50 && player.Drink < 5)
            {
                AddDynamicScene(new
                {
                    Name = "Прекратить",
                    Scene = data.CurrentScene,
                    c = (Action)(() =>
                    {
                        StopIntim(player, partner);
                    })
                });
            }
        }

        private void StopIntim(Player player, IMale partner, int scene = 0)
        {
            if (scene == 1)
            {
                AddDescription("- ой ничего я передумала");
                AddDynamicAction(new
                {
                    Name = "Отойти",
                    Scene = data.CurrentScene,
                    c = (Action)(() =>
                    {
                        data.time.AddTime(5);
                    })
                });
            }
            else
            {
                AddDescription("- Подожди я не хочу сейчас");
                if (ActorFinished == false)
                {
                    partner.SexAddiction--;
                }
                if (ActorFinished == false && partner.Excite > 50)
                {
                    partner.SexAddiction -= 4;
                    partner.Relationship -= 1;
                }
                if (ActorFinished == false && partner.Excite > 100)
                {
                    partner.SexAddiction -= 5;
                    partner.Relationship -= 4;
                }

                LearnSkills(player);

                AddDynamicAction(new
                {
                    Name = "Отойти",
                    Scene = data.CurrentScene,
                    c = (Action)(() =>
                    {
                        data.time.AddTime(5);
                    })
                });
            }
        }

        private void LearnSkills(Player player)
        {
            if (HaveAnalSex > 0)
            {
                player.Skills.LearnSkill("analskill");
                player.AnalSexCount++;
                HaveAnalSex = 0;
            }
            if (HaveVaginalSex > 0)
            {
                player.Skills.LearnSkill("vaginalskill");
                player.VaginalSexCount++;
                HaveAnalSex = 0;
            }
            if (HaveHandSex > 0)
            {
                player.Skills.LearnSkill("handskill");
                player.HandSexCount++;
                HaveAnalSex = 0;
            }
            if (HaveOralSex > 0)
            {
                player.Skills.LearnSkill("suckskill");
                player.OralSexCount++;
                HaveAnalSex = 0;
            }
            if (HaveDildoSex > 0)
            {
                player.Skills.LearnSkill("didloskill");
                HaveDildoSex = 0;
            }
            if (HaveStraponSex > 0)
            {
                player.Skills.LearnSkill("straponskill");
                HaveAnalSex = 0;
            }
            if (HaveKuniSex > 0)
            {
                player.Skills.LearnSkill("kuniskill");
                HaveKuniSex = 0;
            }
        }

        private void StopIntimPainAnal(Player player, IMale partner)
        {
            
            AddDescription(partner.Name + " трахал меня в попу и теперт она болит");
            player.Excite = 0;
            LearnSkills(player);
            AddDynamicAction(new
            {
                Name = "Одеться и отойти",
                Scene = data.CurrentScene,
                c = (Action)(() =>
                {
                    data.time.AddTime(5);
                })
            });
    }

        private void ActiveSuck(Player player, IMale partner)
        {
            Rand r = new Rand();
            AddDescription(partner.GetActorExcite());
            AddDescription("Я опустилась к члену " + partner.Name + "");
            if (player.Skills.GetValue("suckskill") >= 0)
            {
                AddDynamicScene(new
                {
                    Name = "Полизать головку",
                    c = (Action)(() =>
                    {
                        AddDescription("Я лижу головку " + partner.Name);
                        AddDescription("Я вожу языком по головке члена, облизывая ее со всех сторон как мороженку");
                        partner.Excite += r.Next(1, 7);
                        partner.SexAddiction++;
                        HaveOralSex++;
                        NextSceneSuck(player, partner);

                    })
                });
            }

            if (player.Skills.GetValue("suckskill") > 20 && partner.Excite > 10)
            {
                AddDynamicScene(new
                {
                    Name = "Пососать головку",
                    c = (Action)(() =>
                    {
                        AddDescription("Я сосу головку " + partner.Name);
                        AddDescription("Я беру головку члена в рот и ласкаю ее губками и язычком.");
                        partner.Excite += r.Next(1, 5);
                        HaveOralSex++;
                        NextSceneSuck(player, partner);

                    })
                });
            }

            if (player.Skills.GetValue("suckskill") > 40 && partner.Excite > 20)
            {
                AddDynamicScene(new
                {
                    Name = "Полизать яйца",
                    c = (Action)(() =>
                    {
                        AddDescription("Я лижу яица " + partner.Name);
                        AddDescription("Я нежно вожу языком по яичкам.");
                        HaveOralSex++;
                        partner.Excite += r.Next(1, 5);
                        player.Excite += r.Next(-1, 1);
                        NextSceneSuck(player, partner);
                    })
                });
            }

            if (player.Skills.GetValue("suckskill") > 60 && partner.Excite > 25)
            {
                AddDynamicScene(new
                {
                    Name = "Пососать яйца",
                    c = (Action)(() =>
                    {
                        AddDescription("Я сосу яица " + partner.Name);
                        AddDescription("Я аккуратно беру мошонку в рот и старательно обсасываю яички.");
                        HaveOralSex++;
                        partner.Excite += r.Next(1, 5);
                        player.Excite += r.Next(-1, 1);
                        NextSceneSuck(player, partner);
                    })
                });
            }

            if (player.Skills.GetValue("suckskill") > 80 && partner.Excite > 30)
            {
                AddDynamicScene(new
                {
                    Name = "Полизать член",
                    c = (Action)(() =>
                    {
                        AddDescription("Я лижу член " + partner.Name);
                        AddDescription("Я вожу языком вдоль члена, стараясь облизать его весь.");
                        partner.Excite += r.Next(1, 5);
                        player.Excite += r.Next(-1, 1);
                        HaveOralSex++;
                        NextSceneSuck(player, partner);

                    })
                });
            }

            if (player.Skills.GetValue("suckskill") > 90 && partner.Excite > 40)
            {
                AddDynamicScene(new
                {
                    Name = "Пососать член",
                    c = (Action)(() =>
                    {
                        AddDescription("Я сосу член " + partner.Name);
                        AddDescription("Я беру член в рот и старательно его обсасываю. Постепенно я начинаю двигаться все быстрее и быстрее, и вот я уже в бешенном темпе насаживаю свой рот на торчащий кол.");
                        HaveOralSex++;
                        partner.Excite += r.Next(1, 8);
                        player.Excite += r.Next(-1, 1);
                        NextSceneSuck(player, partner);

                    })
                });
            }


            if (player.Skills.GetValue("suckskill") > 99 && partner.Excite > 60)
            {
                AddDynamicScene(new
                {
                    Name = "Заглотить",
                    c = (Action)(() =>
                    {
                        if (player.MouthSize < partner.DickLength - 5)
                        {
                            AddDescription("я не могу заглотить такой  большой член");
                            AddDynamicScene(new
                            {
                                Name = "Пробывать другое",
                                c = (Action)(() =>
                                {
                                    ActiveSuck(player, partner);
                                })
                            });
                        }
                        else if (player.MouthSize < partner.DickLength)
                        {
                            AddDescription("Вот это член. Я попробую его зашлотить");
                            HaveOralSex++;
                            AddDynamicScene(new
                            {
                                Name = "Заглотить",
                                c = (Action)(() =>
                                {
                                    if (r.Next(1, 2) > 1)
                                    {
                                        partner.Excite -= 10;
                                        player.Excite -= 8;
                                        partner.SexAddiction--;
                                        AddDescription("Я стараюсь протолкнуть член себе в горло, но у меня нет в этом опыта и ничего не получается. Как только головка упирается мне в горло, меня скручавает рвотный рефлекс, и я кашляю и из последнийх сил сдерживаю рвотные позывы.");
                                    }
                                    else
                                    {
                                        partner.Excite += 10;
                                        player.Excite -= 5;
                                        AddDescription("Я с трудом заглоитла такой огромный член");
                                    }
                                    NextSceneSuck(player, partner);
                                })
                            });
                        }
                        else
                        {
                            AddDescription("Член что надо.");
                            HaveOralSex++;
                            AddDynamicScene(new
                            {
                                Name = "Открыть широко рот и заглоить",
                                c = (Action)(() =>
                                {
                                    partner.Excite += 10;
                                    player.Excite -= 1;
                                    AddDescription("Я заглоитла член");
                                    AddDescription("Я привычным движением заглатываю член до основания, полностью контролируя свои рвотные рефдексы. Затем отвожу голову немного назад, и снова резко вперед, раз за разом насаживая свое горло на пенис.");
                                    NextSceneSuck(player, partner);
                                })
                            });

                        }
                    })
                });
            }
            AddDynamicScene(new
            {
                Name = "Отказаться",
                c = StartPosition
            });
        }

        #region ActivePussyFuck
        public void ActivePussyFuck(Player player, IMale partner)
        {
            Action a1 = null, a2 = null, a3 = null, a4 = null, a5 = null, a6 = null, a7 = null;
            Rand r = new Rand();
            if (player.VaginalSexCount == 0 && (
                    partner.Excite < 100 || player.Skills.GetValue("handskill") < 60 || player.Skills.GetValue("suckskill") < 60
                    ))
            {
                AddDescription("Я ещё девственница и не готова к этому");
                AddDynamicScene(new
                {
                    Name = "Другая позиция",
                    c = StartPosition
                });
            }
            else
            {
                if (player.Drunk < 5 && player.VaginalSexCount == 0)
                {
                    AddDescription("Я продумала что надо бы выпить");
                    AddDynamicScene(new
                    {
                        Name = "Другая позиция",
                        c = StartPosition
                    });
                }
                else
                {  /*
                    AddDescription("Я подумала, что сегодня не удачный день для этого");
                    AddDynamicScene(new
                    {
                        Name = "Другая позиция",
                        c = StartPosition
                    }); */

                    AddDynamicScene(new
                    {
                        Name = "Лечь и раздвинуть ноги",
                        c = (Action)(a1 = () =>
                        {
                            AddDescription(partner.Name + " лег на меня и трахает в миссионерской позе.");
                            player.Excite += r.Next(3, 7);
                            partner.Excite += r.Next(2, 5);
                            AddDescription(partner.GetActorExcite());
                            AddDynamicScene(new
                            {
                                Name = "Продолжать",
                                c = a1
                            });
                            AddDynamicScene(new
                            {
                                Name = "Сменить позу",
                                c = (Action)(() =>
                                {
                                    ActivePussyFuck(player, partner);
                                })
                            });
                        })
                    });
                    if (player.Skills.GetValue("vaginalskill") > 20)
                    {
                        AddDynamicScene(new
                        {
                            Name = "Лечь и раздвинуть ноги широко",
                            c = (Action)(a2 = () =>
                            {
                                AddDescription(partner.Name + " лег на меня и трахает в миссионерской позе. Мои ноги широко раздвинуты");
                                player.Excite += r.Next(3, 7);
                                partner.Excite += r.Next(2, 5);
                                AddDescription(partner.GetActorExcite());
                                AddDynamicScene(new
                                {
                                    Name = "Продолжать",
                                    c = a2
                                });
                                AddDynamicScene(new
                                {
                                    Name = "Сменить позу",
                                    c = (Action)(() =>
                                    {
                                        ActivePussyFuck(player, partner);
                                    })
                                });
                            })
                        });
                    }
                    if (player.Skills.GetValue("vaginalskill") > 30)
                    {
                        AddDynamicScene(new
                        {
                            Name = "Наклониться вперед",
                            c = (Action)(a3 = () =>
                            {
                                AddDescription("Я нагибаюсь вперед. " + partner.Name + " трахает меня в пизду сзади");
                                player.Excite += r.Next(2, 4);
                                partner.Excite += r.Next(2, 5);
                                AddDescription(partner.GetActorExcite());
                                AddDynamicScene(new
                                {
                                    Name = "Продолжать",
                                    c = a3
                                });
                                AddDynamicScene(new
                                {
                                    Name = "Сменить позу",
                                    c = (Action)(() =>
                                    {
                                        ActivePussyFuck(player, partner);
                                    })
                                });
                            })
                        });
                    }
                    if (player.Skills.GetValue("vaginalskill") > 50)
                    {
                        AddDynamicScene(new
                        {
                            Name = "Встать раком",
                            c = (Action)(a4 = () =>
                            {
                                AddDescription("Я стою раком. Моя попка оттопырена вверх а " + partner.Name + " трахает меня в пизду сзади");
                                player.Excite += r.Next(2, 4);
                                partner.Excite += r.Next(4, 6);
                                AddDescription(partner.GetActorExcite());
                                AddDynamicScene(new
                                {
                                    Name = "Продолжать",
                                    c = a4
                                });
                                AddDynamicScene(new
                                {
                                    Name = "Сменить позу",
                                    c = (Action)(() =>
                                    {
                                        ActivePussyFuck(player, partner);
                                    })
                                });
                            })
                        });
                    }

                    if (player.Skills.GetValue("vaginalskill") > 70)
                    {
                        AddDynamicScene(new
                        {
                            Name = "Сесть сверху передом",
                            c = (Action)(a5 = () =>
                            {
                                AddDescription("Я сижу на нем. Я двигаю бедрами и насаживаюсь на всю глубину члена.");
                                AddDescription(partner.GetActorExcite());
                                player.Excite += r.Next(2, 6);
                                partner.Excite += r.Next(5, 7);
                                AddDynamicScene(new
                                {
                                    Name = "Продолжать",
                                    c = a5
                                });
                                AddDynamicScene(new
                                {
                                    Name = "Сменить позу",
                                    c = (Action)(() =>
                                    {
                                        ActivePussyFuck(player, partner);
                                    })
                                });
                            })
                        });
                    }

                    if (player.Skills.GetValue("vaginalskill") > 80)
                    {
                        AddDynamicScene(new
                        {
                            Name = "Сесть сверху сзади",
                            c = (Action)(a6 = () =>
                            {
                                AddDescription("Я сижу на нем попое к его лицу. Его член входит в меня.");
                                player.Excite += r.Next(3, 7);
                                partner.Excite += r.Next(5, 8);
                                AddDescription(partner.GetActorExcite());
                                AddDynamicScene(new
                                {
                                    Name = "Продолжать",
                                    c = a6
                                });
                                AddDynamicScene(new
                                {
                                    Name = "Сменить позу",
                                    c = (Action)(() =>
                                    {
                                        ActivePussyFuck(player, partner);
                                    })
                                });
                            })
                        });
                    }
                    if (player.Skills.GetValue("vaginalskill") > 90)
                    {
                        AddDynamicScene(new
                        {
                            Name = "Закинуть ноги на плечи",
                            c = (Action)(a7 = () =>
                            {
                                AddDescription("Я закидываю ноги на плечи. " + partner.Name + " долбит меня на всю глубину. Это глубокое проникновение.");
                                player.Excite += r.Next(3, 7);
                                partner.Excite += r.Next(10, 15);
                                AddDescription(partner.GetActorExcite());
                                AddDynamicScene(new
                                {
                                    Name = "Продолжать",
                                    c = a7
                                });
                                AddDynamicScene(new
                                {
                                    Name = "Сменить позу",
                                    c = (Action)(() =>
                                    {
                                        ActivePussyFuck(player, partner);
                                    })
                                });
                            })
                        });
                    }
                }

            }
        }

        #endregion
        public void StartActivePosition(Player player, IMale partner)
        {
            AddDescription(partner.GetActorExcite());
            AddDynamicScene(new
            {
                Name = "Работать ртом",
                c = (Action)(() =>
                {
                    ActiveSuck(player, partner);
                })
            });
            AddDynamicScene(new
            {
                Name = "Работать руками",
                c = (Action)(() =>
                {
                    ActiveHandsFuck(player, partner);
                })
            });
            if ((player.Drunk > 5 && player.Drunk < 10 && player.VaginalSexCount == 0) || player.VaginalSexCount > 0)
            {
                AddDynamicScene(new
                {
                    Name = "Дать в киску",
                    c = (Action)(() =>
                    {
                        ActivePussyFuck(player, partner);
                    })
                });
            }
            if ((player.Drunk > 5 && player.Drunk < 10) || player.AnalSexCount > 0)
            {
                AddDynamicScene(new
                {
                    Name = "Дать в попку",
                    c = (Action)(() =>
                    {
                        //ActiveAnalFuck(player, partner);
                    })
                });
            }
        }

        #region ActiveHandsFuck
        private void ActiveHandsFuck(Player player, IMale partner)
        {
            Rand r = new Rand();
            AddDescription(partner.GetActorExcite());
            AddDescription("Я взяла в руки член " + partner.Name + "");
            if (player.Skills.GetValue("handskill") >= 0)
            {
                AddDynamicScene(new
                {
                    Name = "Дрочить",
                    c = (Action)(() =>
                    {
                        AddDescription("Я дрочу " + partner.Name);
                        AddDescription("Я вожу своей рукой вдоль члена вверх и вниз.");
                        partner.Excite += r.Next(1, 7);
                        player.Excite -= r.Next(-1, 1);
                        HaveHandSex++;
                        NextSceneHand(player, partner);
                    })
                });
            }

            if (player.Skills.GetValue("handskill") >= 30)
            {
                AddDynamicScene(new
                {
                    Name = "Гладить головку",
                    c = (Action)(() =>
                    {
                        AddDescription("Я глажу головку " + partner.Name);
                        AddDescription("Я ложу ладошку на головку члена и начинаю ее полировать.");
                        partner.Excite += r.Next(1, 7);
                        player.Excite -= r.Next(-1, 1);
                        HaveHandSex++;
                        NextSceneHand(player, partner);
                    })
                });
            }

            if (player.Skills.GetValue("handskill") >= 60)
            {
                AddDynamicScene(new
                {
                    Name = "Ласкать яйца",
                    c = (Action)(() =>
                    {
                        AddDescription("Я ласкаю яйца " + partner.Name);
                        AddDescription("Я аккуратно беру мошонку рукой и нежно массирую яички.");
                        partner.Excite += r.Next(1, 7);
                        player.Excite -= r.Next(-1, 1);
                        HaveHandSex++;
                        NextSceneHand(player, partner);
                    })
                });
            }

            if (player.Skills.GetValue("handskill") >= 60)
            {
                AddDynamicScene(new
                {
                    Name = "Жесткая дрочка",
                    c = (Action)(() =>
                    {
                        AddDescription("Я дрочу член " + partner.Name + " двумя руками");
                        AddDescription("Я крепко хватаю член двумя руками и наинаю быстро надрачивать.");
                        partner.Excite += r.Next(1, 7);
                        player.Excite -= r.Next(-1, 1);
                        HaveHandSex++;
                        NextSceneHand(player, partner);
                    })
                });
            }
        }
        #endregion

        public bool AddSFMAction(Player player, IMale partner, String Description = "")
        {
            /*
            if (Description == "")
            {
                AddDescription("Я подхожу к " + partner.Name + " со смущеным взглядом");
            }
            else
            {
                AddDescription(Description);
            }
             */ 
            HaveHandSex = 0;
            HaveOralSex = 0;
            HaveAnalSex = 0;
            HaveVaginalSex = 0;
            BanAnal = 0;
            BanVaginal = 0;
            BanOral = 0;
            if (player.GetProperty("AnalPain") != null)
            {
                BanAnal = 1;
            }
            if (player.GetProperty("VaginalPain") != null)
            {
                BanVaginal = 1;
            }
            if (player.GetProperty("OralPain") != null)
            {
                BanOral = 1;
            }
            if (player.Drunk > 15)
            {
                AddDynamicScene(new
                {
                    Name = "ММММ....(Мычу пьяная)",
                    c = (Action)(() =>
                    {
                        StartPassivePosition(player, partner);
                    })
                });
            }
            else
            {
                if (player.SexualView > -10 && player.Drunk < 8)
                {
                    AddDynamicScene(new
                    {
                        Name = "Взять инициативу в свои руки",
                        c = (Action)(() =>
                        {
                            StartActivePosition(player, partner);
                        })
                    });
                }
                if (player.SexualView < 50 && player.Drunk < 8)
                {

                    AddDynamicScene(new
                    {
                        Name = "Предоставить партнеру инициативу",
                        c = (Action)(() =>
                        {
                            StartPassivePosition(player, partner);
                        })
                    });
                }
            }

            AddDynamicScene(new
            {
                Name = "Прекратить",
                c = (Action)(() =>
                {
                    StopIntim(player, partner, 1);
                })
            });

            return true;
        }

    }
}
