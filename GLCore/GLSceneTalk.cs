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
        public int TalkTime { get; set; }
        public void StartTalkingFF(Player player, IFemale partner)
        {
            AddDynamicScene(new
            {
                Name = "....",
                c = (Action)(() =>
                {
                    TalkTime++;
                    AddFFTalk(player, partner, "");
                })
            });
        }

        public bool AddFFTalk(Player player, IFemale partner, String Description = "")
        {
            if (TalkTime > 2) {
                partner.SetTimeout("tired_talk", 1, 300);
            }
            if (partner.Get("tired_talk") == 1) {
                AddDescription(partner.Name + " слишком устала чтобы говорить");
                AddDynamicAction(new
                {
                    Name = "Закончить",
                    c = (Action)(() =>
                    {
                        Rand rn1 = new Rand();
                        if (TalkTime > 0)
                        {
                            int sk = (TalkTime > 3) ? 3 : TalkTime;
                            partner.Relationship += rn1.Next(0, TalkTime - 2);
                            GetPlayer().Skills.LearnSkill("speakingskillfemale", rn1.Next(0, sk));
                            data.time.AddTime(2);
                        }
                        TalkTime = 0;
                    })
                });
                return false;
            }
            AddDynamicScene(new
            {
                Name = "Болтать о разном",
                c = (Action)(() =>
                {
                    AddDescription("Я болтаю с " + partner.Name + " на разные темы");
                    StartTalkingFF(player, partner);
                })
            });
            if (partner.Relationship > 10)
            {
                AddDynamicScene(new
                {
                    Name = "Болтать о моде",
                    c = (Action)(() =>
                    {
                        AddDescription("Я болтаю с " + partner.Name + " о моде");
                        StartTalkingFF(player, partner);
                    })
                });
            }
            if (partner.Relationship > 15)
            {
                AddDynamicScene(new
                {
                    Name = "Болтать о красоте",
                    c = (Action)(() =>
                    {
                        AddDescription("Я болтаю с " + partner.Name + " о красоте");
                        StartTalkingFF(player, partner);
                    })
                });
            }
            if (partner.Relationship > 20)
            {
                AddDynamicScene(new
                {
                    Name = "Болтать о развлечениях",
                    c = (Action)(() =>
                    {
                        AddDescription("Я болтаю с " + partner.Name + " о развлечениях");
                        StartTalkingFF(player, partner);
                    })
                });
            }
            if (partner.Relationship > 30)
            {
                AddDynamicScene(new
                {
                    Name = "Болтать о мужчинах",
                    c = (Action)(() =>
                    {
                        Rand rn1 = new Rand();
                        player.SexualOrientation += rn1.Next(0, 1);
                        partner.SexualOrientation += rn1.Next(0, 1);
                        AddDescription("Я болтаю с " + partner.Name + " о мужчинах");
                        StartTalkingFF(player, partner);
                    })
                });
            }
            if (partner.Relationship > 50)
            {
                AddDynamicScene(new
                {
                    Name = "Болтать о женщинах",
                    c = (Action)(() =>
                    {
                        Rand rn1 = new Rand();
                        player.SexualOrientation -= rn1.Next(0, 1);
                        partner.SexualOrientation -= rn1.Next(0, 1);
                        AddDescription("Я болтаю с " + partner.Name + " о женщинах");
                        StartTalkingFF(player, partner);
                    })
                });
            }
            if (partner.Relationship > 70)
            {
                AddDynamicScene(new
                {
                    Name = "Болтать о сексе",
                    c = (Action)(() =>
                    {
                        player.Excite++;
                        partner.Excite++;
                        AddDescription("Я болтаю с " + partner.Name + " о сексе");
                        StartTalkingFF(player, partner);
                    })
                });
            }

            if (partner.Relationship > 90 && GetPlayer().Skills.GetValue("speakingskillfemale") > 90 && player.SexualOrientation > -70)
            {
                AddDynamicScene(new
                {
                    Name = "Болтать о сексе с мужчинами",
                    c = (Action)(() =>
                    {
                        player.Excite++;
                        partner.Excite++;
                        player.SexualOrientation++;
                        partner.SexualOrientation++;
                        AddDescription("Я болтаю с " + partner.Name + " о сексе с мужчинами");
                        StartTalkingFF(player, partner);
                    })
                });
            }

            if (partner.Relationship > 90 && GetPlayer().Skills.GetValue("speakingskillfemale") > 90 && player.SexualOrientation < 70)
            {
                AddDynamicScene(new
                {
                    Name = "Болтать о лесбийсвом сексе",
                    c = (Action)(() =>
                    {
                        player.Excite++;
                        partner.Excite++;
                        player.SexualOrientation--;
                        partner.SexualOrientation--;
                        AddDescription("Я болтаю с " + partner.Name + " о лесбийсвом сексе");
                        StartTalkingFF(player, partner);
                    })
                });
            }
            AddDynamicAction(new
            {
                Name = "Закончить болтать",
                c = (Action)(() =>
                {
                    Rand rn1 = new Rand();
                    if (TalkTime > 0)
                    {
                        int sk = (TalkTime > 3) ? 3 : TalkTime;
                        partner.Relationship += rn1.Next(0, TalkTime - 2);
                        GetPlayer().Skills.LearnSkill("speakingskillfemale", rn1.Next(0, sk));
                    }
                    TalkTime = 0;
                    partner.SetTimeout("tired_talk", 1, 300);
                    data.time.AddTime(1);
                })
            });

            return true;
        }

    }
}
