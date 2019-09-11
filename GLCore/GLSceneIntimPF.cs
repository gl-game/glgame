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
        private int HaveKuniSex { get; set; }
        private int HaveDildoSex { get; set; }
        private int HaveStraponSex { get; set; }

        private void CumFemale(Player player, IFemale partner)
        {
            ClearDescription();
            AddDescription("Я вижу как " + partner.Name + " кончает");
            if (player.Excite > 100)
            {
                AddDescription("Я кончаю вместе с ней");
                player.Excite = 0;
            }
            partner.SexAddiction += 10;
            AddDynamicAction(
                new
                {
                    Name = "Встати и одеться",
                    c = (Action)(() =>
                    {
                        partner.SetTimeout("have_sex", 1, 300);
                        partner.SexAddiction += 5;
                        partner.Relationship += 5;
                        LearnSkills(player);
                        data.time.AddTime(5);
                    })
                }
            );
            partner.Excite = 0;
        }

        private void FFPassiveHandsMyPussy(Player player, IFemale partner)
        {
            Rand r = new Rand();
            AddDynamicScene(new
            {
                Name = "Раздвинуть ножки",
                c = (Action)(() =>
                {
                    player.Excite += r.Next(10, 15);
                    if (partner.Excite < 95)
                    {
                        partner.Excite += r.Next(2, 5);
                    }
                    else
                    {
                        partner.Excite = 100;
                    }
                    AddDescription(partner.Name + " ласкает руками мою киску");
                    AddDynamicScene(new
                    {
                        Name = "....",
                        c = (Action)(() =>
                        {
                            HaveHandSex++;
                            FFStartPassivePosition(player, partner);
                        })
                    });
                })
            });
        }        

        private void FFPassiveHandsPartnerPussy(Player player, IFemale partner)
        {
            Rand r = new Rand();
            AddDynamicScene(new
            {
                Name = "Раздвинуть её ножки",
                c = (Action)(() =>
                {
                    partner.Excite += r.Next(10, 15);
                    if (player.Excite < 95)
                    {
                        player.Excite += r.Next(2, 5);
                    }
                    else
                    {
                        player.Excite = 100;
                    }
                    AddDescription("Я ласкаю руками киску " + partner.Name);
                    AddDynamicScene(new
                    {
                        Name = "....",
                        c = (Action)(() =>
                        {
                            HaveHandSex++;
                            FFStartPassivePosition(player, partner);
                        })
                    });
                })
            });
        }

        private void FFPassiveLickMyPussy(Player player, IFemale partner)
        {
            Rand r = new Rand();
            AddDynamicScene(new
            {
                Name = "Раздвинуть ноги пошире",
                c = (Action)(() =>
                {
                    if (partner.Excite < 90)
                    {
                        partner.Excite += r.Next(13, 20);
                    }
                    else
                    {
                        partner.Excite = 100;
                    }
                    player.Excite += r.Next(9, 13);
                    AddDescription(partner.Name + " делает мне киннилингус");
                    AddDynamicScene(new
                    {
                        Name = "....",
                        c = (Action)(() =>
                        {
                            HaveKuniSex++;
                            FFStartPassivePosition(player, partner);
                        })
                    });
                })
            });
        }

        private void FFPassiveLickPartnerPussy(Player player, IFemale partner)
        {
            Rand r = new Rand();
            AddDynamicScene(new
            {
                Name = "Раздвинуть её ножки",
                c = (Action)(() =>
                {
                    if (player.Excite < 93)
                    {
                        player.Excite += r.Next(5, 7);
                    }
                    else
                    {
                        player.Excite = 100;
                    }
                    partner.Excite += r.Next(13, 20);
                    AddDescription("Я лижу киску " + partner.Name);
                    AddDynamicScene(new
                    {
                        Name = "....",
                        c = (Action)(() =>
                        {
                            HaveKuniSex++;
                            FFStartPassivePosition(player, partner);
                        })
                    });
                })
            });
        }


        private void FFStartPassivePosition(Player player, IFemale partner, int Exclude = 0)
        {
            List<int> allowed = new List<int>();
            Rand r = new Rand();
            AddDescription(partner.GetActorExcite());
            int rnd = r.Next(1, 6);

            if (player.Excite > 100 && partner.Excite <= 100)
            {
                AddDescription("<b>Пока " + partner.Name + " занимается мной меня накрывает оргазм</b>");
                player.Excite = 0;
            }
            if (partner.Excite > 100)
            {
                CumFemale(player, partner);
                return;
            }
            if (partner.Excite < 20)
            {
                allowed.Add(1);
            }
            if (partner.Excite < 41)
            {
                allowed.Add(2);
            }
            if (partner.Excite > 40)
            {
                allowed.Remove(1);
                allowed.Add(3);
                allowed.Add(4);
                allowed.Add(5);
            }
            if (partner.Excite > 60)
            {
                allowed.Remove(1);
                allowed.Remove(2);
                allowed.Remove(3);
                allowed.Remove(5);
                allowed.Add(6);
            }
            if (BanVaginal == 1 && BanAnal == 1 && rnd == 3)
            {
                rnd = 2;
            }
            while (rnd == Exclude || !allowed.Any(x => x == rnd))
            {
                rnd = r.Next(1, 6);
            }
            if (rnd == 1)
            {
                AddDescription(partner.Name + " целует меня в губы");
                AddDynamicScene(new
                {
                    Name = "Целоваться",
                    c = (Action)(() =>
                    {
                        if (player.Excite < 30)
                        {
                            player.Excite += r.Next(13, 15);
                        }
                        if (partner.Excite < 30)
                        {
                            partner.Excite += r.Next(13, 15);
                        }
                        AddDescription("Мы целуемся");
                        AddDynamicScene(new
                        {
                            Name = "....",
                            c = (Action)(() =>
                            {
                                FFStartPassivePosition(player, partner);
                            })
                        });
                    })
                });
            }
            if (rnd == 2)
            {
                AddDescription(partner.Name + " целует мои груди");
                AddDynamicScene(new
                {
                    Name = "Наслаждаться",
                    c = (Action)(() =>
                    {
                        if (player.Excite < 50)
                        {
                            player.Excite += r.Next(10, 13);
                        }
                        if (partner.Excite < 50)
                        {
                            partner.Excite += r.Next(5, 7);
                        }
                        AddDescription("Мои сисечки мокрые от поцелуев");
                        AddDynamicScene(new
                        {
                            Name = "....",
                            c = (Action)(() =>
                            {
                                FFStartPassivePosition(player, partner);
                            })
                        });
                    })
                });
                //FFPassiveKissTits(player, partner);
            }
            if (rnd == 3)
            {
                AddDescription(partner.Name + " залезает ко мне ручками между ног");
                FFPassiveHandsMyPussy(player, partner);
            }
            if (rnd == 4)
            {
                AddDescription(partner.Name + " подставляет свою киску к моим рукам");
                FFPassiveHandsPartnerPussy(player, partner);
            }
            if (rnd == 5)
            {
                AddDescription(partner.Name + " раздвигает мне ноги");
                FFPassiveLickMyPussy(player, partner);
            }
            if (rnd == 6)
            {
                AddDescription(partner.Name + " раздвигает ноги");
                FFPassiveLickPartnerPussy(player, partner);
            }
            if (player.Excite < 40) { 
                AddDynamicScene(new
            {
                Name = "Прекратить",
                c = (Action)(() =>
                {
                    StopIntimFF(player, partner);
                })
            });
            }
        }

        private void FFStartActivePosition(Player player, IFemale partner, int Exclude = 0)
        {
            Rand r = new Rand();
            AddDescription(partner.GetActorExcite());
            AddDynamicScene(new
            {
                Name = " Целоваться",
                c = (Action)(() =>
                {
                    AddDescription("Мы целуемся");
                    AddDynamicScene(new
                    {
                        Name = "....",
                        c = (Action)(() =>
                        {
                            partner.Excite += r.Next(3, 5);
                            player.Excite += r.Next(3, 5);
                            FFStartActivePosition(player, partner);
                        })
                    });
                })
            });
            if (player.Skills.GetValue("handskill") > 30)
            {
                AddDynamicScene(new
                {
                    Name = "Ласкать груди",
                    c = (Action)(() =>
                    {
                        AddDescription("Я целую и трогаю груди " + partner.Name);
                        AddDynamicScene(new
                        {
                            Name = "....",
                            c = (Action)(() =>
                            {
                                partner.Excite += 1;
                                player.Excite += r.Next(2, 4);
                                FFStartActivePosition(player, partner);
                            })
                        });
                    })
                });
            }
            if (player.Skills.GetValue("handskill") > 50)
            {
                AddDynamicScene(new
                {
                    Name = "Лакасть киску",
                    c = (Action)(() =>
                    {
                        AddDescription("Я ласкаю руками киску " + partner.Name);
                        AddDynamicScene(new
                        {
                            Name = "....",
                            c = (Action)(() =>
                            {
                                partner.Excite += r.Next(7, 12);
                                player.Excite += 1;
                                HaveHandSex++;
                                FFStartActivePosition(player, partner);
                            })
                        });
                    })
                });
            }
            if (player.Skills.GetValue("kuniskill") > 50)
            {
                AddDynamicScene(new
                {
                    Name = "Сделать куни",
                    c = (Action)(() =>
                    {
                        AddDescription("Я лижу киску " + partner.Name);

                        partner.Excite += r.Next(9, 13);
                        player.Excite += 1;
                        AddDynamicScene(new
                        {
                            Name = "....",
                            c = (Action)(() =>
                            {
                                HaveKuniSex++;
                                FFStartActivePosition(player, partner);
                            })
                        });
                    })
                });
            }
        }

        public bool AddSFFAction(Player player, IFemale partner, String Description = "")
        {
            HaveHandSex = 0;
            HaveOralSex = 0;
            HaveAnalSex = 0;
            HaveVaginalSex = 0;
            BanAnal = 0;
            BanVaginal = 0;
            BanOral = 0;
            HaveKuniSex = 0;
            HaveDildoSex = 0;
            HaveStraponSex = 0;

            if (partner.Get("have_sex") != 0)
            {
                AddDescription("Я не хочу сейчас - говорит " + partner.Name);
                AddDynamicAction(new
                {
                    Name = "....",
                    c = (Action)(() =>
                    {
                        data.time.AddTime(1);
                    })
                });
                return false;
            }

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
                        FFStartPassivePosition(player, partner);
                    })
                });
            }
            else
            {
                if (player.SexualView > -10 && player.Drunk < 8 && player.TotalSexCount > 10 && player.SexualOrientation < -20)
                {
                    AddDynamicScene(new
                    {
                        Name = "Взять инициативу в свои руки",
                        c = (Action)(() =>
                        {
                            FFStartActivePosition(player, partner);
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
                            FFStartPassivePosition(player, partner);
                        })
                    });
                }
            }

            AddDynamicScene(new
            {
                Name = "Прекратить",
                c = (Action)(() =>
                {
                    StopIntimFF(player, partner, 1);
                })
            });

            return true;
        }

        private void StopIntimFF(Player player, IFemale partner, int scene = 0)
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
                partner.SetTimeout("have_sex", 1, 500);
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

    }
}
