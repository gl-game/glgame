using GLCore.Actors;
using GLCore.Extensions;
using GLCore.GameSkills;
using GLCore.Objects;
using GLCore.WorkAndStudy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Data
{
    class DataPlayer
    {
        public static Player CreatePlayer(dynamic Stuff, Lessons lessonObject, Skills skillObject)
        {
            Player player = new Player();
            player.Name = "Надя";
            player.LastName = "Соколова";
            player.Description = "Надя Соколова";
            player.SmallImage = "";

            player.HairColor = 0;
            player.HairStyle = 0;
            player.Height = 170;

            player.DeclinationName = new String[6] {"", "", "", "", "", ""};
            player.DateOfBirth = Convert.ToDateTime("11.10.1995");
            player.Gender = 2;
            player.Money = 50m;

            player.Enema = false;
            
            player.Excite = 0;
            player.Strength = 10;
            player.Speed = 5;
            player.Agility = 5;
            player.Reaction = 2;
            player.WillPower = 10;
            player.Intellect = 10;
            player.Vitality = 5;
            player.SexualView = 0;

            player.Health = player.maxHealth;
            player.Energy = 15;
            player.Drink = 15;
            player.Sleep = 16;
            player.Mana = player.maxMana;
            player.Mind = player.maxMind;

            /*
            player.maxHealth = 190;
            player.maxFood = 1000;
            player.maxDrink = 1000;
            player.maxSleep = 1000;
            player.maxMana = 180;
            player.maxMind = 100;
             */ 

            player.LipSize = 0;
            player.SkinTone = 0;
            player.EyelashsSize = 0;
            player.EyeSize = 0;

            //player.Drunk = 30; 
            player.Fat = 25;   
            player.BodyMuscules = 15;
            player.SexualOrientation = 30;

            player.AddStuff(GameStuff.DeepClone<IStuff>(Stuff.zontik));
            player.AddStuff(GameStuff.DeepClone<IStuff>(Stuff.vodka05));
            player.AddStuff(GameStuff.DeepClone<IStuff>(Stuff.samogon07l));
            player.AddSmallBagMe(GameStuff.DeepClone<SmallBag>(Stuff.smallbag1));
            player.AddBagMe(GameStuff.DeepClone<Bag>(Stuff.schoolbag1));
            player.WearStuff(GameStuff.DeepClone<IWear>(Stuff.schooldress1));
            player.WearStuff(GameStuff.DeepClone<IWear>(Stuff.schoolshoes1));
            player.WearStuff(GameStuff.DeepClone<IWear>(Stuff.bra6));
            player.WearStuff(GameStuff.DeepClone<IWear>(Stuff.panties3));
            player.WearStuff(GameStuff.DeepClone<IWear>(Stuff.bant1));
            player.AddSmallBag(GameStuff.DeepClone<Condom>(Stuff.condom));
            player.AddSmallBag(GameStuff.DeepClone<HandMirror>(Stuff.handmirror1));
            player.AddBag(GameStuff.DeepClone<IWear>(Stuff.sportshoes1));
            player.AddBag(GameStuff.DeepClone<IWear>(Stuff.sportpants1));
            player.AddBag(GameStuff.DeepClone<IWear>(Stuff.sportshirt1));
            /*player.WearStuff(GameStuff.DeepClone<IWear>(Stuff.jeans1));
            player.WearStuff(GameStuff.DeepClone<IWear>(Stuff.panties3));
            player.WearStuff(GameStuff.DeepClone<IWear>(Stuff.bra6));
            player.WearStuff(GameStuff.DeepClone<IWear>(Stuff.sportshoes1));
            player.WearStuff(GameStuff.DeepClone<IWear>(Stuff.shirt2));
             */
            player.Lessons.Lesson.Add(GameStuff.DeepClone<ILesson>(lessonObject.GetById("matematika")));
            player.Lessons.Lesson.Add(GameStuff.DeepClone<ILesson>(lessonObject.GetById("fizika")));
            player.Lessons.Lesson.Add(GameStuff.DeepClone<ILesson>(lessonObject.GetById("himija")));
            player.Lessons.Lesson.Add(GameStuff.DeepClone<ILesson>(lessonObject.GetById("geografija")));
            player.Lessons.Lesson.Add(GameStuff.DeepClone<ILesson>(lessonObject.GetById("informatika")));
            player.Lessons.Lesson.Add(GameStuff.DeepClone<ILesson>(lessonObject.GetById("fizkultura")));
            player.Lessons.Lesson.Add(GameStuff.DeepClone<ILesson>(lessonObject.GetById("biologija")));
            player.Lessons.Lesson.Add(GameStuff.DeepClone<ILesson>(lessonObject.GetById("istorija")));

            foreach (var so in skillObject.Skill)
            {
                player.Skills.Skill.Add(GameStuff.DeepClone<ISkill>(skillObject.GetById(so.id)));
            }

            //player.Skills.SetValue("vaginalskill", 100);
                             
            return player;
        }
    }
}
