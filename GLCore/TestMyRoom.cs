using GLCore.Actions;
using GLCore.Actors;
using GLCore.Locations;
using GLCore.Scenes;
using GLCore.Objects;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Linq;

namespace GLCore.Dynaimc
{
    struct d
    {
        private Double peer;

        public static implicit operator d(int i)
        {
            return new d { peer = i };
        }

        public static implicit operator Double(d p)
        {
            return p.peer;
        }
    }
    public class TestMyRoom
    {        
        public delegate void DAddActorAction(IActor Actor, Object cb = null, String saveDicitonary = "", bool IsDynamic = false);
        public delegate void DAddDynamicActorAction(IActor Actor, Object cb = null, String saveDicitonary = "");
        delegate void DAddDirection(ILocation Location, Object cb = null, bool CopyToAction = false);
        delegate String DRegisterEvent(Action e, String scheme = "");
        /* delegate String DRegisterEvent(String e, String scheme = ""); */
        delegate int DGetHour();
        delegate int DGetMinute();
        delegate int DGetDay();
        delegate int DGetYear();
        delegate int DGetMonth();
        delegate int DGetWeekDay();
        delegate void DAddTime(int a);
        delegate int DRandom(int a, int b);
        delegate String DGetActorProperties(IActor a);
        delegate String DGetFemaleSexProperties(Female a);
        delegate void DAddDescription(String s);
        delegate void DAddAction(IAction Action);
        delegate void DAddDynamicAction(Object Action, bool IsDynamic = false);
        delegate void DAddDynamicScene(Object Action);
        delegate Player DGetPlayer();
        private GLData game;
        private GLScene scene;
        delegate dynamic DGet(String key);
        delegate void DSet(String key, dynamic val);
        delegate void DSetTimeout(String key, dynamic val, int timeout);
        delegate void DAdd(String key, dynamic val);
        delegate ILocation DGetLocation();
        delegate Shop DGetShop();
        delegate void DDrawShopStaff(Shop s);
        delegate void DDrawBathRoomStaff(BathRoom s);
        delegate Box DGetBox();
        delegate BathRoom DGetBathRoom();
        delegate Bed DGetBed();
        delegate void DDrawBoxStaff(Box s);
        delegate Wardrobe DGetWardrobe();
        delegate void DDrawWadrobeStaff(Wardrobe s);
        delegate void DDropBag(IBagObject bagObj);
        delegate bool DBuyThing(IStuff s, Shop location, int count, Decimal price);

        DAddActorAction AddActorAction;
        DAddDynamicActorAction AddDynamicActorAction;
        DAddDescription AddDescription;
        DAddDirection AddDirection;
        DAddAction AddAction;
        DAddDynamicAction AddDynamicAction;
        DAddDynamicScene AddDynamicScene;
        DRandom Random;
        DGetHour GetHour;
        DGetMinute GetMinute;
        DGetDay GetDay;
        DGetYear GetYear;
        DGetMonth GetMonth;
        DGetWeekDay GetWeekDay;
        DAddTime AddTime;
        DGetActorProperties GetActorRelationship;
        DGetFemaleSexProperties GetFemaleSexProperties;
        DRegisterEvent RegisterEvent;
        DGetPlayer GetPlayer;
        DGet Get;
        DSet Set;
        DSetTimeout SetTimeout;
        DAdd Add;
        DGetLocation GetLocation;
        DGetShop GetShop;
        DDrawShopStaff DrawShopStaff;
        DDrawBathRoomStaff DrawBathRoomStaff;
        DGetBox GetBox;
        DGetBathRoom GetBathRoom;
        DGetBed GetBed;
        DDrawBoxStaff DrawBoxStaff;
        DGetWardrobe GetWardrobe;
        DDrawWadrobeStaff DrawWadrobeStaff;
        DDropBag DropBag;
        DBuyThing BuyThing;
        public TestMyRoom(GLData _game, GLScene _scene)
        {
            this.game = _game;
            this.scene = _scene;
            AddActorAction = new DAddActorAction(scene.AddActorAction);
            AddDynamicActorAction = new DAddDynamicActorAction(scene.AddDynamicActorAction);
            AddDescription = new DAddDescription(scene.AddDescription);
            AddDirection = new DAddDirection(scene.AddDirection);
            AddAction = new DAddAction(scene.AddAction);
            AddDynamicAction = new DAddDynamicAction(scene.AddDynamicAction);
            AddDynamicScene = new DAddDynamicScene(scene.AddDynamicScene);
            Random = new DRandom(game.Random);
            GetHour = new DGetHour(game.time.GetHour);
            GetMinute = new DGetMinute(game.time.GetMinute);
            GetDay = new DGetDay(game.time.GetDay);
            GetYear = new DGetYear(game.time.GetYear);
            GetMonth = new DGetMonth(game.time.GetMonth);
            GetWeekDay = new DGetWeekDay(game.time.GetWeekDay);
            AddTime = new DAddTime(game.time.AddTime);
            GetActorRelationship = new DGetActorProperties(Actor.GetActorRelationship);
            GetFemaleSexProperties = new DGetFemaleSexProperties(Female.GetFemaleSexProperties);
            RegisterEvent = new DRegisterEvent(scene.RegisterEvent);
            GetPlayer = new DGetPlayer(game.player.GetPlayer);
            Get = new DGet(game.Get);
            Set = new DSet(game.Set);
            SetTimeout = new DSetTimeout(game.SetTimeout);
            Add = new DAdd(game.Add);
            GetLocation = new DGetLocation(game.GetLocation);
            GetShop = new DGetShop(game.GetShop);
            DrawShopStaff = new DDrawShopStaff(scene.DrawShopStuff);
            DrawBathRoomStaff = new DDrawBathRoomStaff(scene.DrawBathRoomStaff);
            GetBox = new DGetBox(game.GetBox);
            GetBathRoom = new DGetBathRoom(game.GetBathRoom);
            GetBed = new DGetBed(game.GetBed);
            DrawBoxStaff = new DDrawBoxStaff(scene.DrawBoxStuff);
            GetWardrobe = new DGetWardrobe(game.GetWardrobe);
            DrawWadrobeStaff = new DDrawWadrobeStaff(scene.DrawWadrobeStaff);
            DropBag = new DDropBag(scene.DropBag);
            BuyThing = new DBuyThing(game.BuyThing);

        }

        public void MinuteChanged(int minutes)
        {

        }
        public void HourChanged(int hours)
        {
            GetPlayer().Energy -= 1000;
        }
        public void DayChanged(int days)
        {
        }


        public String GetActorGeneralProperties(IActor a)
        {
            return Actor.GetActorGeneralProperties(a, game.time.time);
        }

        public void GoTo(String redirect)
        {
            scene.sc.Redirect = redirect;
        }

        public void GoTo(String redirect, String message)
        {
            scene.sc.Redirect = redirect;
            scene.sc.Error = message;
        }

        public void ShowMessage(String message)
        {
            scene.sc.Message = message;
        }

        public void AddSSActions(IActor actor)
        {
            scene.AddSFMAction(GetPlayer(), (Male)actor);
        }

        public void GetView()
        {

            if (game.actor.uchitelnicamatematiki.Get("have_sex") == 0)
            {
                AddDynamicScene(new
                {
                    Name = "Прикоснуться к груди учительницы",
                    c = (Action)(() =>
                    {
                        AddDescription("Я прикасаюсь рукой к её груди");
                        //AddDescription(game.actor.uchitelnicamatematiki.Name + " целует меня в губы");
                        scene.AddSFFAction(GetPlayer(), game.actor.uchitelnicamatematiki);

                    })
                });
            }

            AddDynamicAction(new
            {
                Name = "Местная дискотека " + ((Get("paid_gorodok_disko") == 1) ? "(Уже заплачено)" : "(Вход 25 рублей)"),
                Scene = "gorodok/sportklub/gorodokdisco"
            });


            AddDynamicScene(new
            {
                Name = "Поговорить",
                c = (Action)(() =>
                {
                    AddDescription("Выбрать тему разговора");
                    scene.AddFFTalk(GetPlayer(), game.actor.uchitelnicamatematiki, "Болтать на разные темы");
                })
            });
            AddTime(2);
            SetTimeout("saw_girls", 1, 300);

            AddDynamicScene(new
            {
                Name = "Перейти к интиму",
                c = (Action)(() =>
                {
                    AddSSActions(game.actor.fizruk);
                })
            });

            // GetBathRoom().Undress(GetPlayer());
            ((Shop)(game.location.magazinalkogolja)).DefineStuff(() =>
{
    game.location.magazinalkogolja.AddStuff(game.stuff.vodka02, 10);
    game.location.magazinalkogolja.AddStuff(game.stuff.vodka05, 10);
    game.location.magazinalkogolja.AddStuff(game.stuff.vine7gr02, 10);
    game.location.magazinalkogolja.AddStuff(game.stuff.vine7gr07, 10);
    game.location.magazinalkogolja.AddStuff(game.stuff.vine14gr07, 10);
    game.location.magazinalkogolja.AddStuff(game.stuff.lightbear03l, 10);
    game.location.magazinalkogolja.AddStuff(game.stuff.lightbear05l, 10);
    game.location.magazinalkogolja.AddStuff(game.stuff.lightbear1l, 10);
    game.location.magazinalkogolja.AddStuff(game.stuff.blackbear03l, 10);
    game.location.magazinalkogolja.AddStuff(game.stuff.blackbear05l, 10);
    game.location.magazinalkogolja.AddStuff(game.stuff.blackbear1l, 10);
});

            ((Shop)(game.location.larjokmelochej)).DefineStuff(() =>
            {
                game.location.larjokmelochej.AddStuff(game.stuff.smallbag1, 1);
                game.location.larjokmelochej.AddStuff(game.stuff.avosjka1, 1);
            });

            ((Wardrobe)(game.location.shkafroditeli)).DefineStuff(() =>
            {
                game.location.shkafroditeli.AddStuff(game.stuff.zimnajakurtka, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.bant1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.schooldress1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.schoolshoes1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.bra6, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.panties3, 1);
                //game.location.shkafroditeli.AddStuff(game.stuff.schoolbag1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.avosjka1, 1);
                // game.location.shkafroditeli.AddStuff(game.stuff.sportpants1, 1);
                // game.location.shkafroditeli.AddStuff(game.stuff.sportshirt1, 1);

            });

            game.BlockAll = 0;




            // int ideturok = 1;
            int MinutesNow = GetHour() * 60 + GetMinute();
            if (Enumerable.Range(480, 520).Contains(MinutesNow)
            || Enumerable.Range(530, 570).Contains(MinutesNow)
            || Enumerable.Range(580, 620).Contains(MinutesNow)
            || Enumerable.Range(640, 680).Contains(MinutesNow)
            )
            {
                //ideturok = 0;
            }

            ((Shop)(game.location.magazinalkogolja)).DefineStuff(() =>
            {
                game.location.larjokmelochej.AddStuff(game.stuff.vodka02, 10, 800);
                game.location.larjokmelochej.AddStuff(game.stuff.vodka05, 10, 500);
            });

            ((Box)(game.location.mojatumbochkaroditeli)).DefineStuff(() =>
            {
                game.location.mojatumbochkaroditeli.AddStuff(game.stuff.vodka02, 10);
                game.location.mojatumbochkaroditeli.AddStuff(game.stuff.vodka05, 10);
            });

            ((Wardrobe)(game.location.shkafroditeli)).DefineStuff(() =>
            {
                game.location.shkafroditeli.AddStuff(game.stuff.zimnajakurtka, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.dress1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.bant1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.jeans1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.schoolshirt3, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.schoolshoes1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.schoolskirt1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.stockings2, 1);

            });

            DrawBoxStaff(game.location.mojatumbochkaroditeli);
            //var x = 5 / 8;
            //int xz = x;
            Set("haveide", 1);
            if (Get("haveide") == 1)
            {
                Set("haveide", 2);
            }
            var Book = new
            {
                Name = "Читать книгу",
                Scene = "gorodok/parentflat/readbook",
            };
            var press = new
            {
                Name = "Делать упражнения на пресс 15 мин",
                Scene = "gorodok/parentflat/press",
                Description = "Повышает выносливость"
            };
            switch ((int)Get("coputer_test_question"))
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

            int t = (int)Get("correct_questions");
            Set("correct_questions", ++t);
            Set("coputer_test_question", 1);

            var prisjadanija = new
            {
                Name = "Делать отжимания 15 мин",
                Scene = "gorodok/parentflat/otzimanija",
                Description = "Повышает силу",
                c = (Action)(() =>
                {
                    AddTime(60);
                }),
            };
            AddDynamicAction(Book);
            AddDynamicAction(press);
            AddDynamicAction(prisjadanija);
            AddDirection(game.location.koridor);
            AddDirection(game.location.koridor, new { name = "В квартиру родителей" });
            AddDescription(@"
<center><img src='/images/imgpreview/bedrPar2.jpg'></center>
Маленькая комната в которой с трудом втиснулся шкаф, ваша кровать, письменный стол и кровать сестры.");

            if (GetHour() >= 15 && GetHour() < 17)
            {
                AddActorAction(game.actor.sistervera);
            }
            if (GetHour() == 17)
            {
                AddDynamicActorAction(game.actor.sistervera);
            }
            AddTime(1);

            AddDynamicAction(new
            {
                Name = "Положить сумку у в комнате",
                Scene = "gorodok/parentflat/myroom",
                c = (Action)(() =>
                {
                    DropBag(game.player.SmallBag);
                })
            });

            // game.BlockAll = 1;




        }
    }
}