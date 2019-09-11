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
using GLCore.DTO;

namespace GLCore.Scenes
{
    public partial class BaseScene
    {
        public delegate Action DGetAction(String actionName);
        public delegate void DAddActorAction(IActor Actor, Object cb = null, String saveDicitonary = "", bool IsDynamic = false);
        public delegate void DAddDynamicActorAction(IActor Actor, Object cb = null, String saveDicitonary = "");
        public delegate void DAddDirection(ILocation Location, Object cb = null, bool CopyToAction = false);
        public delegate String DRegisterEvent(Action e, String scheme = "");
        /*public  delegate String DRegisterEvent(String e, String scheme = """");*/
        public delegate DateTime DGetTime();
        public delegate int DGetHour();
        public delegate int DGetMinute();
        public delegate int DGetDay();
        public delegate int DGetYear();
        public delegate int DGetMonth();
        public delegate int DGetWeekDay();
        public delegate void DAddTime(int a);
        public delegate int DRandom(int a, int b);
        public delegate String DGetActorProperties(IActor a);
        public delegate String DGetFemaleSexProperties(Female a);
        public delegate void DAddDescription(String s);
        public delegate void DAddAction(IAction Action);
        public delegate void DAddDynamicAction(Object Action, bool IsDynamic = false);
        public delegate void DAddDynamicScene(Object Action);
        public delegate Player DGetPlayer();
        public delegate FamilyFemale DGetFamilyFemale(String female);
        public delegate Female DGetFemale(String female);
        protected GLData game;
        protected GLScene scene;
        public delegate dynamic DGet(String key);
        public delegate void DSet(String key, dynamic val);
        public delegate void DSetTimeout(String key, dynamic val, int timeout);
        public delegate void DAdd(String key, dynamic val);
        public delegate ILocation DGetLocation();
        public delegate Shop DGetShop();
        public delegate void DDrawShopStaff(Shop s);
        public delegate void DDrawBathRoomStaff(BathRoom s);
        public delegate Box DGetBox();
        public delegate BathRoom DGetBathRoom();
        public delegate Bed DGetBed();
        public delegate void DDrawBoxStaff(Box s);
        public delegate Wardrobe DGetWardrobe();
        public delegate void DDrawWadrobeStaff(Wardrobe s);
        public delegate void DDropBag(IBagObject bagObj);
        public delegate bool DBuyThing(IStuff s, Shop location, int count, Decimal price);

        public DGetAction GetAction;
        public DAddActorAction AddActorAction;
        public DAddDynamicActorAction AddDynamicActorAction;
        public DAddDescription AddDescription;
        public DAddDirection AddDirection;
        public DAddAction AddAction;
        public DAddDynamicAction AddDynamicAction;
        public DAddDynamicScene AddDynamicScene;
        public DRandom Random;
        public DGetTime GetTime;
        public DGetHour GetHour;
        public DGetMinute GetMinute;
        public DGetDay GetDay;
        public DGetYear GetYear;
        public DGetMonth GetMonth;
        public DGetWeekDay GetWeekDay;
        public DAddTime AddTime;
        public DGetActorProperties GetActorRelationship;
        public DGetFemaleSexProperties GetFemaleSexProperties;
        public DRegisterEvent RegisterEvent;
        public DGetPlayer GetPlayer;
        public DGetFamilyFemale GetFamilyFemale;
        public DGetFemale GetFemale;
        public DGet Get;
        public DSet Set;
        public DSetTimeout SetTimeout;
        public DAdd Add;
        public DGetLocation GetLocation;
        public DGetShop GetShop;
        public DDrawShopStaff DrawShopStaff;
        public DDrawBathRoomStaff DrawBathRoomStaff;
        public DGetBox GetBox;
        public DGetBathRoom GetBathRoom;
        public DGetBed GetBed;
        public DDrawBoxStaff DrawBoxStaff;
        public DGetWardrobe GetWardrobe;
        public DDrawWadrobeStaff DrawWadrobeStaff;
        public DDropBag DropBag;
        public DBuyThing BuyThing;

        public void InitEngine(GLData _game, GLScene _scene)
        {
            this.game = _game;
            this.scene = _scene;

            GetAction = new DGetAction(scene.GetAction);
            AddActorAction = new DAddActorAction(scene.AddActorAction);
            AddDynamicActorAction = new DAddDynamicActorAction(scene.AddDynamicActorAction);
            AddDescription = new DAddDescription(scene.AddDescription);
            AddDirection = new DAddDirection(scene.AddDirection);
            AddAction = new DAddAction(scene.AddAction);
            AddDynamicAction = new DAddDynamicAction(scene.AddDynamicAction);
            AddDynamicScene = new DAddDynamicScene(scene.AddDynamicScene);
            Random = new DRandom(game.Random);
            GetTime = new DGetTime(game.time.GetDateTime);
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
            GetFamilyFemale = new DGetFamilyFemale(game.GetFamilyFemale);
            GetFemale = new DGetFemale(game.GetFemale);
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



        public virtual void MinuteChanged(int minutes)
        {
            String noteId = "SchoolNote";
            if (!game.Notifications.Any(x => x.NotificationID == noteId) && GetHour() == 7 && GetMinute() >= 30 && Enumerable.Range(1, 5).Contains(GetWeekDay()))
            {
                game.Notifications.Add(new NotificationDTO()
                {
                    Start = GetTime(),
                    End = GetTime().AddMinutes(120),
                    Notification = "Пора в школу (В 8:00 начинаются уроки)",
                    NotificationID = noteId
                });
            }
            //Code here minute change
        }
        public virtual void HourChanged(int hours)
        {
            Set("walking_school", 0);
        }
        public virtual void DayChanged(int days)
        {
            GetFamilyFemale("sistervera").Set("talk", 0);
            GetFemale("julijamilova").Set("talk_school", 0);
            Set("sistersorryday", 0);
            Set("press", 0);
            Set("otzimanija", 0);
            Set("paid_gorodok_disko", 0);
            Set("podjezd_cat_ready", 0);

            switch (GetWeekDay())
            {
	            case 2: 
		            game.helpers.LessonLearning(new String[] { "matematika", "geografija", "russkijjazik", "istorija", "fizkultura"}, GetPlayer());
		            break;
	            case 3:
		            game.helpers.LessonLearning(new String[] { "fizika", "matematika", "himija", "istorija", "fizkultura"}, GetPlayer());
		            break;
	            case 4:
		            game.helpers.LessonLearning(new String[] { "informatika", "geografija", "fizika", "russkijjazik", "fizkultura"}, GetPlayer());
		            break;
	            case 5:
		            game.helpers.LessonLearning(new String[] { "fizika", "biologija", "istorija", "matematika", "fizkultura"}, GetPlayer());
		            break;
	            case 6:
		            game.helpers.LessonLearning(new String[] { "russkijjazik", "matematika", "himija", "informatika", "fizkultura"}, GetPlayer());
		            break;
            }
        }

        public virtual void PostActions()
        {
            if (GetPlayer().Health == 0)
            {
                GoTo("defaultevents/dead");
                return;
            }
            if (GetPlayer().Health < 0)
            {
                GetPlayer().Health = 0;
            }
            if (GetPlayer().Strength < 1)
            {
                GetPlayer().Strength = 1;
            }
            if (GetPlayer().Vitality < 1)
            {
                GetPlayer().Vitality = 1;
            }
            if (GetPlayer().Intellect > 100)
            {
                GetPlayer().Intellect = 100;
            }

            if (GetPlayer().Energy > GetPlayer().maxEnergy * 1.4)
            {
                GetPlayer().Energy = Convert.ToInt32(GetPlayer().maxEnergy * 1.4);
            }
            if (GetPlayer().Drink > GetPlayer().maxDrink * 1.4)
            {
                GetPlayer().Drink = Convert.ToInt32(GetPlayer().maxDrink * 1.4);
            }
            if (GetPlayer().Excite > 100)
            {
                GetPlayer().Excite = 100;
            }


        }

        public virtual void PreActions()
        {
            game.BlockAll = 0;
        }        

        public virtual void GetView() {
            
        }   
    }
}
