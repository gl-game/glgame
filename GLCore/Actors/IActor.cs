using GLCore.Extensions;
using GLCore.SupportObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Actors
{
    public interface IActor
    {
        Dictionary<String, dynamic> variables { get; set; }
        Dictionary<String, DateTime> variables_timeout { get; set; }
        dynamic Get(String key);
        void Set(String key, dynamic val);
        void SetTimeout(String key, dynamic val, int timeout);
        void Add(String key, dynamic val);


        int Relationship { get; set; }
        int SexAddiction { get; set; }
        int SexualView { get; set; }
        int SexualOrientation { get; set; }
        int Lust { get; set; }
        int Excite { get; set; }
        int NextExcite { get; set; }

        Dictionary<String, TimerObject> TimerPropery { get; set; }
        TimerObject GetProperty(String propname);
        void SetProperty(String propname, int value);

        String NN { get; }
        String Name { get; set; }
        String MiddleName { get; set; }
        String LastName { get; set; }
        String Image { get; set; }
        String Scene { get; set; }
        String Description { get; set; }
        String c { get; set; }
        int t { get; set; }
        String SmallImage { get; set; }

        int HairBrush { get; set; }
        int HairColor { get; set; }
        int HairStyle { get; set; }
        int ShortHair { get; set; }

        String[] DeclinationName { get; set; }
        DateTime DateOfBirth { get; set; }
        int Gender { get; set; }
        Decimal Money { get; set; }

        bool Enema { get; set; }
        int Parfume { get; set; }
        DateTime ParfumeExpire { get; set; }

        int Health { get; set; }
        int Energy { get; set; }
        int Drink { get; set; }
        int Sleep { get; set; }
        int Mana { get; set; }
        int Mind { get; set; }

        int LipSize { get; set; }
        int SkinStatus { get; set; }
        int SkinTone { get; set; }
        int EyelashsSize { get; set; }
        int EyeSize { get; set; }
        int EyeBrows { get; set; }
        int EyeBrowsPermanent { get; set; }

        int SchoolLessonsMissed { get; set; }
        int SchoolLessonsUnlearned { get; set; }
        int SchoolLessonsLearned { get; set; }
        
        int Fat { get; set; }
        int Drunk { get; set; }
        int Sweat { get; set; }

        int Height { get; set; }

        int Strength { get; set; }
        int Speed { get; set; }
        int Agility { get; set; }
        int Vitality { get; set; }
        int Reaction { get; set; }
        int BodyMuscules { get; set; }
        int WillPower { get; set; }
        int Intellect { get; set; }


        String GetActorExcite();
    }
}
