using GLCore.Extensions;
using GLCore.SupportObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Actors
{
    public class Actor : IActor
    {
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

        public void Set(String key, dynamic val)
        {
            variables[key] = val;
        }

        public void SetTimeout(String key, dynamic val, int timeout)
        {
            variables[key] = val;
            variables_timeout[key] = CurrentTime.time.AddMinutes(timeout);
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

        public int Relationship { get; set; }
        public int SexAddiction { get; set; }

        public static GameTime CurrentTime { get; set; }

        public String NN
        {
            get
            {
                return Name + " " + MiddleName;
            }
        }
        public String Name { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Image { get; set; }
        public String SmallImage { get; set; }
        public String Scene { get; set; }
        public String Description { get; set; }
        public String[] DeclinationName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }


        public Decimal Money { get; set; }

        public int HairBrush { get; set; }
        public int HairColor { get; set; }
        public int HairStyle { get; set; }
        public int ShortHair { get; set; }
        
        public int LipSize { get; set; }
        public int SkinStatus { get; set; }
        public int SkinTone { get; set; }
        public int EyelashsSize { get; set; }
        public int EyeSize { get; set; }
        public int EyeBrows { get; set; }
        public int EyeBrowsPermanent { get; set; }

        public int SchoolLessonsMissed { get; set; }
        public int SchoolLessonsUnlearned { get; set; }
        public int SchoolLessonsLearned { get; set; }
        

        public bool Enema { get; set; }

        public int Parfume { get; set; }
        public DateTime ParfumeExpire { get; set; }
        
        /* 0-100 */
        public int Health { get; set; }
        public int Energy { get; set; }
        public int Drink { get; set; }
        public int Sleep { get; set; }
        public int Mana { get; set; }
        public int Mind { get; set; }

        public int Age
        {
            get
            {
                return CurrentTime.time.Year - DateOfBirth.Year;
            }
        }

        public int maxMana
        {
            get
            {
                return Intellect * 5 + Vitality * 2;
            }
        }
        public int maxHealth
        {
            get
            {
                return Vitality * 10 + Strength * 5;
            }
        }
        public int maxEnergy
        {
            get
            {
                return 24;
            }
        }
        public int maxDrink
        {
            get
            {
                return 24;
            }
        }
        public int maxSleep
        {
            get
            {
                return 24;
            }
        }
        public int maxMind
        {
            get
            {
                return Intellect * 5 + WillPower * 5;
            }
        }

        public int DrunkStatus
        {
            get
            {
                if (Drunk >= 3 && Drunk < 10)
                {
                    return 1;
                }
                else if (Drunk >= 10 && Drunk < 17)
                {
                    return 2;
                }
                else if (Drunk >= 17 && Drunk < 25)
                {
                    return 3;
                }
                else if (Drunk >= 25)
                {
                    return 4;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Vmeat
        {
            get
            {
                return Strength + Vitality;
            }
        }

        public int Weight
        {
            get
            {
                //ves = Kves + krost - (agil/10)
                /*
                 * vitalbuf = vital
	vmeat = strenbuf + vitalbuf
	vmeat = vmeat/8
	vfat = salo/10
	Kves = vmeat + vfat
	krost = rost - 130
	ves = Kves + krost - (agilbuf/10)
	talia = ves - (agilbuf/10)
	grudi = talia + 10 + vfat + silicone
	grutal = talia
	bedra = talia + 15 + (vmeat/2) + vfat
	titK = grudi - talia*/
                int vMeat = Vmeat / 8;
                int Kves = Vmeat + VFat;
                int krost = Height - 130;
                return Kves + krost - (Agility / 10);
            }
        }

        public int VFat
        {
            get
            {
                return Fat / 10;
            }
        }

        public int Talia
        {
            get
            {
                return Weight - (Agility / 10);
            }
        }

        public int Bedra
        {
            get
            {
                return Talia + 15 + ((Vmeat / 8) / 2) + VFat;
            }

        }

        public int Fat { get; set; }
        public int Drunk { get; set; }
        public int Sweat { get; set; }

        public int Height { get; set; }

        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Agility { get; set; }
        public int Vitality { get; set; }
        public int Reaction { get; set; }
        public int BodyMuscules { get; set; }
        public int WillPower { get; set; }
        public int Intellect { get; set; }
        public int SexualView { get; set; }
        public int SexualOrientation { get; set; }
        public int Lust { get; set; }
        private int _excite;
        public int NextExcite { get; set; }
        public int Excite
        {
            get
            {
                return _excite;
            }
            set
            {
                if (value < 0)
                {
                    _excite = 0;
                    return;
                }
                if (value > _excite)
                {
                    NextExcite = 1;
                }
                if (value > 101)
                {
                    _excite = 101;
                }
                else
                {
                    _excite = value;
                }
            }
        }
        public Dictionary<String, TimerObject> TimerPropery { get; set; }
        public TimerObject GetProperty(String propname)
        {
            if (TimerPropery.Any(x => x.Key == propname))
            {
                return TimerPropery[propname]; 
            }
            return null;
        }
        public void SetProperty(String propname, int Value)
        {
            TimerPropery[propname] = new TimerObject()
            {
                PropValue = Value,
                Timeout = 1440
            };
        }

        public int AnalPain { get; set; }
        public int VaginalPain { get; set; }
        public int OralPain { get; set; }

        public String c { get; set; }
        public int t { get; set; }

        public Actor()
        {
            variables = new Dictionary<string, dynamic>();
            variables_timeout = new Dictionary<String, DateTime>();
            TimerPropery = new Dictionary<String, TimerObject>();
            DeclinationName = new String[6];
        }

        public static String GetActorGeneralProperties(IActor actor, DateTime? today = null)
        {
            if (today == null)
            {
                today = DateTime.Today;
            }

            String a = "";
            if (actor.DateOfBirth != null)
            {
                int age = ((DateTime)today).Year - actor.DateOfBirth.Year;
                a += "Возраст: " + age + " лет<br>";
            }
            a += "Отношения: " + GetActorRelationship(actor);
            return a;
        }

        public static String GetActorRelationship(IActor actor)
        {
            if (actor.Relationship < 20) return "У вас с ужасный скандал.";
            if (actor.Relationship >= 20 && actor.Relationship < 40) return "У вас напряженные отношения.";
            if (actor.Relationship >= 40 && actor.Relationship < 60) return "У вас нормальные отношения.";
            if (actor.Relationship >= 60 && actor.Relationship < 80) return "У вас хорошие отношения.'";
            if (actor.Relationship >= 80) return "У вас с отличные отношения.";
            return "";
        }

        public String GetActorExcite()
        {
            if (Excite == 0) return Name + " не возбужден";
            if (Excite >= 0 && Excite < 20) return Name + " слабо возбужден";
            if (Excite >= 20 && Excite < 40) return Name + " легко возбужден";
            if (Excite >= 40 && Excite < 60) return Name + " хорошо возбужден";
            if (Excite >= 60 && Excite < 80) return Name + " очень возбужден";
            if (Excite >= 80) return Name + " сильно возбужден";
            if (Excite == 100) return Name + " сейчас кончит возбужден";
            return "";
        }
    }
}
