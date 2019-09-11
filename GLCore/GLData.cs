using GLCore.Actions;
using GLCore.Actors;
using GLCore.DTO;
using GLCore.Locations;
using GLCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using GLCore.SupportObjects;
using GLCore.Objects;
using GLCore.WorkAndStudy;
using GLCore.Extensions;
using GLHelpers;
using System.Web.Script.Serialization;

namespace GLCore
{

    [Serializable]
    public class GLData
    {
        public List<NotificationDTO> Notifications { get; set; }
        public Helpers helpers { get; set; }

        public dynamic location { get; set; }
        public dynamic actor { get; set; }
        public dynamic stuff { get; set; }

        public int BlockActors { get; set; }
        public int BlockBag { get; set; }
        public int BlockWear { get; set; }

        public int BlockAll
        {
            set
            {
                if (value == 1)
                {
                    BlockActors = 1;
                    BlockBag = 1;
                    BlockWear = 1;
                }
                else
                {
                    BlockActors = 0;
                    BlockBag = 0;
                    BlockWear = 0;
                }
            }
        }

        public int BlockStats
        {
            set
            {
                if (value == 1)
                {
                    BlockBag = 1;
                    BlockWear = 1;
                }
                else
                {
                    BlockBag = 0;
                    BlockWear = 0;
                }
            }
        }


        public Lessons lessons { get; set; }
        public Skills skills { get; set; }

        public GameTime time { get; set; }
        public Player player { get; set; }

        public String CurrentScene { get; set; }
        public ILocation CurrentLocation { get; set; }
        public ICity CurrentLocationCity { get; set; }

        public Dictionary<String, dynamic> variables { get; set; }
        public Dictionary<String, DateTime> variables_timeout { get; set; }

        public dynamic Get(String key)
        {
            dynamic o;
            variables.TryGetValue(key, out o);
            if (o == null)
            {
                return 0;
            }
            return o;
        }

        public bool BuyThing(IStuff stuff, Shop location, int count, Decimal price)
        {
            IStuff st = location.GetStaff(stuff, price);
            if (player.AddStuff(st))
            {
                location.RemoveStaff(stuff, price, 1);
                player.Money = player.Money - price;
                return true;
            }
            return false;
        }

        public FamilyFemale GetFamilyFemale(String female)
        {
            var names = (IDictionary<string, object>)actor;
            return (FamilyFemale)names[female];
        }

        public Female GetFemale(String female)
        {
            var names = (IDictionary<string, object>)actor;
            return (Female)names[female];
        }

        public bool GetThning(IStuff stuff, Box location, int count)
        {
            IStuff st = location.GetStaff(stuff);
            if (player.AddStuff(st))
            {
                location.RemoveStaff(stuff, 1);
                return true;
            }
            return false;
        }
        public bool GetThningToBag(IStuff stuff, Box location, int count, IBagObject Bag)
        {
            IStuff st = location.GetStaff(stuff);
            if (player.AddStuffToBag(stuff, Bag))
            {
                location.RemoveStaff(stuff, 1);
                return true;
            }
            return false;
        }

        public bool WearToMe(IWear stuff, Wardrobe location)
        {
            IStuff st = location.GetStaff(stuff);
            switch (stuff.WearSlot)
            {
                case 1:
                    if (player.Hat != null)
                    {
                        location.MoveStuff(player.Hat, 1);
                        player.Hat = null;
                    }
                    break;
                case 2:
                    if (stuff.ConflictSlot == 3 && player.BottomDress != null)
                    {
                        return false;
                    }
                    if (player.TopDress != null)
                    {
                        location.MoveStuff(player.TopDress, 1);
                        player.TopDress = null;
                    }
                    break;
                case 3:
                    if (stuff.ConflictSlot == 2 && player.TopDress != null && player.TopDress.ConflictSlot == 3)
                    {
                        return false;
                    }
                    if (player.BottomDress != null)
                    {
                        location.MoveStuff(player.BottomDress, 1);
                        player.BottomDress = null;
                    }
                    break;
                case 4:
                    if (player.Shoes != null)
                    {
                        location.MoveStuff(player.Shoes, 1);
                        player.Shoes = null;
                    }
                    break;
                case 5:
                    if (player.Stockings != null)
                    {
                        location.MoveStuff(player.Stockings, 1);
                        player.Stockings = null;
                    }
                    break;
                case 6:
                    if (player.Coat != null)
                    {
                        location.MoveStuff(player.Coat, 1);
                        player.Coat = null;
                    }
                    break;
                case 7:
                    if (player.Bra != null)
                    {
                        location.MoveStuff(player.Bra, 1);
                        player.Bra = null;
                    }
                    break;
                case 8:
                    if (player.Panties != null)
                    {
                        location.MoveStuff(player.Panties, 1);
                        player.Panties = null;
                    }
                    break;
                case 9:
                    if (player.SmallBag != null)
                    {
                        location.MoveStuff(player.SmallBag, 1);
                        player.SmallBag = null;
                    }
                    break;
                case 10:
                    if (player.Bag != null)
                    {
                        location.MoveStuff(player.Bag, 1);
                        player.Bag = null;
                    }
                    break;
            }
            if (player.WearStuff(stuff))
            {
                location.RemoveStaff(stuff, 1);
                return true;
            }
            return false;
        }

        public void DropThning(IStuff stuff, Box location, int count, IBagObject bagObject)
        {
            IStuff st = player.HaveStuffInBox(stuff, bagObject);
            player.RemoveStaff(st, bagObject);
            location.MoveStuff(stuff, 1);

        }

        public bool Undress(IWear stuff, Wardrobe location, int count = 1)
        {
            switch (stuff.WearSlot)
            {
                case 1:
                    player.Hat = null;
                    break;
                case 2:
                    player.TopDress = null;
                    break;
                case 3:
                    player.BottomDress = null;
                    break;
                case 4:
                    player.Shoes = null;
                    break;
                case 5:
                    player.Stockings = null;
                    break;
                case 6:
                    player.Coat = null;
                    break;
                case 7:
                    player.Bra = null;
                    break;
                case 8:
                    player.Panties = null;
                    break;
                case 9:
                    /*
                    if (player.Things["SmallBag"].Count > 0)
                    {
                        return false;
                    }*/
                    player.SmallBag = null;
                    break;
                case 10:
                    /*
                    if (player.Things["Bag"].Count > 0)
                    {
                        return false;
                    }
                     */
                    player.Bag = null;
                    break;
                default:
                    return false;
            }
            location.MoveStuff(stuff, count);
            return true;
        }

        public void Set(String key, dynamic val)
        {
            variables[key] = val;
        }

        public void SetTimeout(String key, dynamic val, int timeout)
        {
            variables[key] = val;
            variables_timeout[key] = time.time.AddMinutes(timeout);
        }

        public void Add(String key, dynamic val)
        {
            var k = Get(key);
            if (Get(key) == 0)
            {
                variables[key] = val;
            }
            else if (k.GetType() == typeof(int))
            {
                variables[key] += val;
            }
            else
            {
                Set(key, val);
            }
        }

        public ILocation GetLocation()
        {
            return CurrentLocation;
        }

        public Shop GetShop()
        {
            if (CurrentLocation != null && typeof(Shop) == CurrentLocation.GetType())
            {
                return (Shop)CurrentLocation;
            }
            return null;
        }

        public Box GetBox()
        {
            if (CurrentLocation != null && typeof(Box) == CurrentLocation.GetType())
            {
                return (Box)CurrentLocation;
            }
            return null;
        }

        public BathRoom GetBathRoom()
        {
            if (CurrentLocation != null && typeof(BathRoom) == CurrentLocation.GetType())
            {
                return (BathRoom)CurrentLocation;
            }
            return null;
        }

        public Bed GetBed()
        {
            if (CurrentLocation != null && typeof(Bed) == CurrentLocation.GetType())
            {
                return (Bed)CurrentLocation;
            }
            return null;
        }

        public Wardrobe GetWardrobe()
        {
            if (CurrentLocation != null && typeof(Wardrobe) == CurrentLocation.GetType())
            {
                return (Wardrobe)CurrentLocation;
            }
            return null;
        }


        public GLData()
        {
            Notifications = new List<NotificationDTO>();
            this.lessons = new Lessons();
            this.skills = new Skills();
            this.helpers = new Helpers();
        }
        public void LoadEvents()
        {
            time.hourChange += InternalHourChanged;
            time.minuteChange += InternalMinuteChanged;
            time.dayChange += InternalDayChanged;
        }
        public void LoadDynamicData()
        {
            this.stuff = DataStuff.GetStuff();
            this.location = DataLocations.GetLocations();
            this.actor = DataActors.GetActors();
            this.lessons.Lesson = DataLesson.GetLessons();
            this.skills.Skill = DataSkill.GetSkills();
            this.variables = new Dictionary<String, dynamic>();
            this.variables_timeout = new Dictionary<String, DateTime>();
            this.player = DataPlayer.CreatePlayer(this.stuff, lessons, skills);
            this.time = new GameTime()
            {
                time = new DateTime(2011, 9, 1, 7, 0, 0)
            };
            Actor.CurrentTime = time;
        }

        public int Random(int Start, int End)
        {
            Rand rnd = new Rand();
            return rnd.Next(Start, End);
        }

        private void InternalMinuteChanged(int minutes)
        {

            Rand r = new Rand();
            for (int i = 0; i < minutes; i++)
            {
                if (player.NextExcite <= 0 && player.Excite > 0)
                {
                    player.Excite -= r.Next(1, 3);
                    if (player.Excite <= 0) player.Excite = 0;
                }
                foreach (var pain in player.TimerPropery)
                {
                    pain.Value.Timeout--;
                    if (pain.Value.Timeout < 0)
                    {
                        pain.Value.Timeout = 0;
                        pain.Value.PropValue--;
                        if (pain.Value.PropValue > 0)
                        {
                            pain.Value.Timeout = 1440;
                        }
                        else
                        {
                            player.TimerPropery[pain.Key] = null;
                        }
                    }
                }
                for (int iList = Notifications.Count - 1; iList >= 0; iList--)
                {
                    if (Notifications[iList].End < time.time)
                    {
                        Notifications.RemoveAt(iList);
                    }
                }
            }
            foreach (var vt in variables_timeout)
            {
                if (vt.Value <= time.time)
                {
                    variables[vt.Key] = 0;
                    variables_timeout.Remove(vt.Key);
                }
            }

            foreach (var vt in variables_timeout)
            {
                if (vt.Value <= time.time)
                {
                    variables[vt.Key] = 0;
                    variables_timeout.Remove(vt.Key);
                }
            }

            foreach (KeyValuePair<string, object> kvp in actor)
            {
                var actorName = (IActor)kvp.Value;
                if (actorName.variables_timeout.Count > 0)
                {
                    foreach (var vt in actorName.variables_timeout)
                    {
                        if (vt.Value <= time.time)
                        {
                            actorName.variables[vt.Key] = 0;
                            actorName.variables_timeout.Remove(vt.Key);
                        }
                    }
                }
            }

        }
        private void InternalHourChanged(int hours)
        {
            Rand r = new Rand();
            for (int i = 0; i < hours; i++)
            {
                player.Energy -= r.Next(1, 2);
                if (player.Energy <= 0)
                {
                    player.Energy = 0;
                }
                player.Drink -= r.Next(1, 3);
                if (player.Drink <= 0)
                {
                    player.Drink = 0;
                }
                player.Sleep--;
                if (player.Sleep <= 0)
                {
                    player.Sleep = 0;
                }
                if (player.Energy <= 0 && player.Hungry > 24)
                {
                    player.Health -= r.Next(1, 3);
                    player.Mana -= r.Next(1, 5);
                }
                if (player.Health <= 0)
                {
                    player.Health = 0;
                }
                if ((Double)player.Health / player.maxHealth < 0.1 &&
                    (Double)player.Energy / player.maxEnergy < 0.1)
                {
                    player.Mind -= Convert.ToInt32(Math.Floor((Double)(player.maxHealth) / r.Next(5, 10)));
                    player.Mana -= Convert.ToInt32(Math.Floor((Double)(player.maxHealth) / r.Next(5, 10)));
                }
                if (player.Energy < (Double)player.maxEnergy * 0.2)
                {
                    player.Hungry++;
                }
                else
                {
                    player.Hungry = (player.Hungry > 0) ? player.Hungry - r.Next(0, 1) : 0;
                }
                player.Drunk -= r.Next(2, 3);
                if (player.Drunk < 0)
                {
                    player.Drunk = 0;
                }

                player.NextExcite--;
                if (player.NextExcite <= 0)
                {
                    player.NextExcite = 0;
                }

                if (player.Parfume > 0 && player.ParfumeExpire < time.time)
                {
                    player.Parfume = 0;
                }
                if (player.EyeShadow > 0 && player.EyeShadowExpire < time.time)
                {
                    player.EyeShadow = 0;
                }
                if (player.Pomade > 0 && player.PomadeExpire < time.time)
                {
                    player.Pomade = 0;
                }
            }
        }
        private void InternalDayChanged(int days)
        {
            for (int i = 0; i < days; i++)
            {
                player.EyeBrows--;
                if (CurrentLocationCity != null)
                {
                    CurrentLocationCity.weather = DataLocations.CreateWeather(time, CurrentLocationCity);
                }
                player.PussyShaveСount++;
                player.LegsShaveСount++;
                if (player.PussyShaveStyle == 0 && player.PussyShaveСount == 3) { player.PussyShave = 5; }
                if (player.PussyShaveStyle == 0 && player.PussyShaveСount >= 5) { player.PussyShave = 0; player.PussyShaveStyle = 0; }
                if (player.PussyShaveStyle == 1 && player.PussyShaveСount == 4) { player.PussyShave = 6; }
                if (player.PussyShaveStyle == 1 && player.PussyShaveСount >= 7) { player.PussyShave = 0; player.PussyShaveStyle = 0; }

                if (player.LegsShaveStyle == 0 && player.LegsShaveСount == 3) { player.LegsShave = 3; }
                if (player.LegsShaveStyle == 0 && player.LegsShaveСount >= 5) { player.LegsShave = 0; player.LegsShaveStyle = 0; }
                if (player.LegsShaveStyle == 1 && player.LegsShaveСount == 4) { player.LegsShave = 4; }
                if (player.LegsShaveStyle == 1 && player.LegsShaveСount >= 7) { player.LegsShave = 0; player.LegsShaveStyle = 0; }

                if (player.HandsShaveStyle == 0 && player.HandsShaveСount == 3) { player.HandsShave = 3; }
                if (player.HandsShaveStyle == 0 && player.HandsShaveСount >= 5) { player.HandsShave = 0; player.HandsShaveStyle = 0; }
                if (player.HandsShaveStyle == 1 && player.HandsShaveСount == 4) { player.HandsShave = 4; }
                if (player.HandsShaveStyle == 1 && player.HandsShaveСount >= 7) { player.HandsShave = 0; player.HandsShaveStyle = 0; }

                foreach (KeyValuePair<String, Object> ac in actor)
                {
                    var o = (IActor)ac.Value;
                    if (o.SexAddiction > o.Relationship && o.SexAddiction > 0)
                    {
                        o.SexAddiction--;
                    }
                }
            }

        }
    }
}
