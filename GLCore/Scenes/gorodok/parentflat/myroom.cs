using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class myroom : BaseScene
    {
        public void TalkSister1()
        {
            AddDescription("Вы пытаетесь поговорить с сестрой, но она отказывается с вами говорить.");
            AddDescription(@"<center><img src='/images/qwest/alter/sister.jpg' height='400'></center>");
            AddDynamicAction(new {
                Name = "Отойти",
                t = 1
            });
            if (Get("sistersorryday") == 0) {
                AddDynamicScene(new {
                    Name = "Просить прощения",
                    t = 1,
                    c = (Action)(() => {
                        AddDescription("Вы извиняетесь перед сестрой и она, кажется, вас прощает.");
                        Set("sistersorryday", 1);
                        GetFamilyFemale("sistervera").Relationship += (GetPlayer().Intellect / 10) + (GetPlayer().Beauty / 5);
                        AddDynamicAction(new
                        {
                            Name = "Отойти",
                            t = 1
                        });
                    })
                });                
            }
        }

        public void TalkSister2()
        {
            AddDescription("Вы пытаетесь поговорить с сестрой, но она разговаривает с вами сухо.");
            AddDescription(@"<center><img src='/images/qwest/alter/sister.jpg' height='400'></center>");
            AddDynamicAction(new
            {
                Name = "Отойти",
                t = 1
            });
            if (Get("sistersorryday") == 0)
            {
                AddDynamicScene(new
                {
                    Name = "Пытаться сгладить отношения",
                    t = 1,
                    c = (Action)(() =>
                    {
                        AddDescription("Вы подлизываетесь к сестре и она, кажется, начинает к вам лучше относиться.");
                        Set("sistersorryday", 1);
                        GetFamilyFemale("sistervera").Relationship += (GetPlayer().Intellect / 10) + (GetPlayer().Beauty / 5);
                        AddDynamicAction(new
                        {
                            Name = "Отойти",
                            t = 1
                        });
                    })
                });
            }
        }



        public void TalkSister3()
        {
            AddDescription("Вы решили поболтать с сестрой.");

	        var sisterTalk = Random(1,18);
	        if (sisterTalk == 1) {
		        AddDescription("Вы болтаете с сестрой и она говорит, что можно снять квартиру в городе и жить, работать там, но её пока в Павлово всё устраивает.");
            }
	        if (sisterTalk == 2) {
                AddDescription("Вы спросили у " + GetFamilyFemale("sistervera").DeclinationName[1] + " про настоящего отца. Она ухмыльнулась: " + GetPlayer().Name + ", мне было 4 года когда они расстались. Я его не помню и никогда не видела. Мамка не любит рассказывать подробностей. Но вроде как наш с тобой настоящий отец уехал куда-то в другой город. Еще помню, что он работал дальнобойщиком на больших фурах, может быть проезжает иногда мимо нашего Павлово.");
	        }
	        if (sisterTalk == 3) {
                AddDescription("Вы спросили у " + GetFamilyFemale("sistervera").DeclinationName[1] + " про университет. Она ухмыльнулась: \"Я почти поступила, недобрала баллов. Сейчас забила, на фига он нужен весь университет. Что мне даст эта бумажка?\"");
	        }
	        if (sisterTalk == 4) {
                AddDescription("Вы спросили у " + GetFamilyFemale("sistervera").DeclinationName[1] + " про ее парня. Она заулыбалась: \"Ну, у меня есть парень. Хотя ничего серьезного. Он мне больше друг.\"");
	        }
	        if (sisterTalk == 5) {
                AddDescription("Вы завели разговор с " + GetFamilyFemale("sistervera").DeclinationName[4] + ", она вам рассказывает о мальчиках, с которыми она познакомилась, о вечеринках, о косметике.");
	        }
	        if (sisterTalk == 6) {
		        AddDescription("Вы болтаете с сестрой, она вам рассказывает про новые платья, которые привезли сегодня в магазин.");
	        }
	        if (sisterTalk == 7) {
		        AddDescription("Вы болтаете с сестрой, обсуждая кинозвезд и делясь фантазиями по поводу того, с кем из них хотели бы заняться сексом.");
	        }
	        if (sisterTalk == 8) {
                AddDescription("" + GetFamilyFemale("sistervera").DeclinationName[0] + " болтает про спортивные секции в доме культуры, и признается, что спорт хорошо сказывается на фигуре, но ей лень туда ходить.");
	        }
	        if (sisterTalk == 9) {
                AddDescription("" + GetFamilyFemale("sistervera").DeclinationName[0] + " рассказывает, что одна из ее подруг залетела от парня, который не успел вытащить из нее. И говорит, что надо быть умнее, а потому признается тебе, что покупает в аптеке противозачаточные таблетки.");
	        }
	        if (sisterTalk == 10) {
                AddDescription("" + GetFamilyFemale("sistervera").DeclinationName[0] + " рассказывает, как она зимой однажды вышла на улицу без пальто и сильно простудилась.");
	        }
	        if (sisterTalk == 11) {
		        AddDescription("Вы болтаете с сестрой, обсуждая последние тенденции в моде.");
	        }
	        if (sisterTalk == 12) {
                AddDescription("" + GetFamilyFemale("sistervera").DeclinationName[0] + " признается, что раньше она увлекалась диетами, но от них испортилась кожа и пошли прыши, да и болеть начала, так что теперь она трескает за троих и становится только красивей.");
	        }
	        if (sisterTalk == 13) {
		        AddDescription("Вы болтаете с сестрой и она рассказывает вам, что ходила раньше на танцы, но ей это быстро надоело.");
	        }
	        if (sisterTalk == 14) {
		        AddDescription("Вы болтаете с сестрой и она советует вам где-нибудь подрабатывать.");
	        }
	        if (sisterTalk == 15) {
		        AddDescription("Вы болтаете с сестрой и она говорит вам, что если побродить по рынку, то можно найти много чего интересного и дешевого.");
	        }
	        if (sisterTalk == 16) {
                AddDescription("" + GetFamilyFemale("sistervera").DeclinationName[0] + " рассказывает вам страшилку о том, как одна симпатичная девушка не мылась и не брила ноги, и потом стала настолько страшной, что ее за километр все оббегали, и советует вам ухаживать за телом.");
	        }
	        if (sisterTalk == 17) {
		        AddDescription("Вы болтаете с сестрой, она говорит, что её бывший парень был со странностями: \"Как-то сказал мне, мол, я люблю тебя так же сильно, как срать в море. На море вместе мы больше не ходили...\"");
	        }
	        if (sisterTalk == 18) {
                AddDescription("Вы болтаете с сестрой, " + GetFamilyFemale("sistervera").DeclinationName[0] + " спрашивает, не кажется ли вам, что её левая бровь намного сексуальней правой?");
	        }

            AddDescription(@"<center><img src='/images/qwest/alter/sister.jpg' height='400'></center>");
        }

        private dynamic talkingScene;

        public override void GetView()
        {
            var Book = new
            {
                Name = "Читать книгу",
                Scene = "gorodok/parentflat/readbook",
                t = 30
            };
            var press = new
            {
                Name = "Делать упражнения на пресс 15 мин",
                Scene = "gorodok/parentflat/press",
                Description = "Повышает выносливость",
                c = (Action)(() =>
                 {
                     int r = Random(1, 10);
                     if (r > 8)
                     {
                         GetPlayer().Vitality += 1;
                         ShowMessage(@"Вы качали пресс очень усердно.");
                     }
                     else if (r == 1)
                     {
                         GetPlayer().Vitality -= 1;
                         GetPlayer().Strength -= 1;
                         ShowMessage(@"Вы потянули мышцу во время пресса.");
                     }
                     else
                     {
                         ShowMessage(@"Вы качали пресс в течении 15 минут.");
                     }
                     Set("press", 1);
                     AddTime(15);
                 })
            };
            var otzimanija = new
            {
                Name = "Делать отжимания 15 мин",
                Scene = "gorodok/parentflat/otzimanija",
                Description = "Повышает силу",
                c = (Action)(() =>
                 {
                     int r = Random(1, 10);
                     if (r > 8)
                     {
                         GetPlayer().Strength += 1;
                         ShowMessage(@"Я отжималась очень усердно.");
                     }
                     else if (r == 1)
                     {
                         GetPlayer().Strength -= 1;
                         ShowMessage(@"Я потянула мышцу во время отжиманий.");
                     }
                     else
                     {
                         ShowMessage(@"Я отжималась в течении 15 минут.");
                     }
                     Set("otzimanija", 1);
                     AddTime(15);
                 })
            };

            AddDynamicAction(Book);
            if (Get("press") == 0)
            {
                AddDynamicAction(press);
            }
            if (Get("otzimanija") == 0)
            {
                AddDynamicAction(otzimanija);
            }
            AddDirection(game.location.koridor, new { Name = "Выйти в кодидор" });
            AddDirection(game.location.bedparent, new { Name = "Лечь на кровать" });
            AddDirection(game.location.bedparenttable, new { Name = "Сесть за мой стол" });

            AddDirection(game.location.mojatumbochkaroditeli);
            AddDirection(game.location.shkafroditeli);
            AddDescription(@"
<center><img src='/images/imgpreview/bedrPar2.jpg'></center>
Маленькая комната в которой с трудом втиснулся шкаф, ваша кровать, письменный стол и кровать сестры.");

            if ((GetHour() >= 14 && GetHour() < 16) || (GetHour() > 20 && GetHour() <= 23))
            {

                AddDynamicActorAction(GetFamilyFemale("sistervera"), new
                {
                    Description = "Cидит на кровати",
                    c = (Action)(() =>
                    {
                        if (GetHour() > 10)
                        {
                            AddDescription(@"Сестра " + GetFamilyFemale("sistervera").Name);
                            AddDescription(@"" + GetPlayer().Name + " мне пора идти");
                            AddDescription(@"<center><img src='/images/qwest/alter/sister.jpg' height='400'></center>");
                            AddDynamicAction(new
                            {
                                Name = "Отойти",
                                c = (Action)(() =>
                                {
                                    AddTime(1);
                                })
                            });
                        }
                        else
                        {
                            AddDescription(@"<center><img src='/images/qwest/alter/sister.jpg' height='400'></center>");
                            AddDescription(@"Сестра " + GetFamilyFemale("sistervera").Name);
                            AddDescription(GetActorRelationship(GetFamilyFemale("sistervera")));
                            talkingScene = new
                            {
                                Name = "Болтать",
                                c = (Action)(() =>
                                {
                                    int talk = GetFamilyFemale("sistervera").Get("talk") + 1;
                                    GetFamilyFemale("sistervera").Set("talk", talk);
                                    if (GetFamilyFemale("sistervera").Relationship < 20)
                                    {
                                        TalkSister1();
                                    }
                                    else if (GetFamilyFemale("sistervera").Relationship >= 20 && GetFamilyFemale("sistervera").Relationship < 40)
                                    {
                                        TalkSister2();
                                    }
                                    else
                                    {
                                        TalkSister3();
                                        AddDynamicAction(new
                                        {
                                            Name = "Отойти",
                                            t = 1
                                        });
                                        if (GetFamilyFemale("sistervera").Get("talk") < 4)
                                        {
                                            AddDynamicScene(talkingScene);
                                        }
                                        else
                                        {
                                            AddDescription(@"Всё хватит на сегодня болтать");
                                        }
                                    }
                                    AddTime(Random(10, 15));

                                })
                            };
                            if (GetFamilyFemale("sistervera").Get("talk") < 4)
                            {
                                AddDynamicScene(talkingScene);
                            }
                            AddDynamicAction(new
                            {
                                Name = "Отойти",
                                c = (Action)(() =>
                                {
                                    AddTime(1);
                                })
                            });
                        }
                    })
                });
            }
            if (GetHour() >= 0 && GetHour() < 7)
            {
                AddDynamicActorAction(GetFamilyFemale("sistervera"), new
                {
                    Description = "Спит на кровати",
                    c = (Action)(() =>
                    {
                        int r = Random(0, 7);
                        AddDescription(@"Сестра " + GetFamilyFemale("sistervera").Name + " спит на кровати");
                        AddDescription(@"<center><img src='/images/qwest/alter/sister/sleep0" + r + ".jpg' height='400'></center>");
                        AddDynamicAction(new
                        {
                            Name = "Отойти",
                            c = (Action)(() =>
                            {
                                AddTime(1);
                            })
                        });
                    })
                });
            }
            AddDynamicAction(new
            {
                Name = "Выйти из комнаты",
                Scene = "gorodok/parentflat/koridor",
                t = 30
            });
            AddDynamicAction(new
            {
                Name = "Сесть за мой стол",
                Scene = "gorodok/parentflat/bedparenttable"
            });
            if (game.player.SmallBag != null)
            {
                AddDynamicAction(new
                {
                    Name = "Положить " + game.player.SmallBag.Name + " в комнате",
                    Scene = "gorodok/parentflat/myroom",
                    c = (Action)(() =>
                     {
                         DropBag(game.player.SmallBag);
                     })
                });
            }

            if (game.player.Bag != null)
            {
                AddDynamicAction(new
                {
                    Name = "Положить " + game.player.Bag.Name + " в комнате",
                    Scene = "gorodok/parentflat/myroom",
                    c = (Action)(() =>
                     {
                         DropBag(game.player.Bag);
                     })
                });
            }
        }
    }
}
