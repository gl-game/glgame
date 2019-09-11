using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore
{
    public static class StaticTypes
    {
        public static String StartNamespace()
        {
            return @"using GLCore.Actions;
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
{";
        }

        public static String EndNamespace()
        {
            return "}";

        }
        public static String GetExecutibleString(String ClassName, String Add, String m, String h, String d) {
            var s = @"

    public class " + ClassName + @"
    {
        delegate void DAddActorAction(IActor Actor, Object cb = null, bool IsDynamic = false);
        delegate void DAddDynamicActorAction(IActor Actor, Object cb = null);
        delegate void DAddDirection(ILocation Location, Object cb = null, bool CopyToAction = false);
        delegate String DRegisterEvent(Action e, String scheme = """");
/*delegate String DRegisterEvent(String e, String scheme = """");*/
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

        public " + ClassName + @"(GLData _game, GLScene _scene) {
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



        public void MinuteChanged(int minutes)
        {
            " + m + @"
        }
        public void HourChanged(int hours)
        {
            " + h + @"
        }
        public void DayChanged(int days)
        {
            " + d + @"
        }

        public void GetView() {
            " + Add + @"
        }        
    }

";
            return s;
        }
    }
}
