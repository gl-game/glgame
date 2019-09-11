using GLCore.GameSkills;
using GLHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.Extensions
{
    public class Skills
    {
        public List<ISkill> Skill { get; set; }
        public Skills()
        {
            Skill = new List<ISkill>();
        }
        public ISkill GetById(String id)
        {
            var z = Skill.FirstOrDefault(x => x.id == id);
            return z;
        }
        public int GetValue(String id)
        {
            var z = Skill.FirstOrDefault(x => x.id == id);
            return z.Value;
        }

        public void SetValue(String id, int Value)
        {
            var z = Skill.FirstOrDefault(x => x.id == id);
            z.Value = Value;
        }

        public void LearnSkill(String id, int Level = 0)
        {
            Rand r = new Rand();
            int number = r.Next(1, 10);
            var sk = Skill.FirstOrDefault(x => x.id == id);
            if (sk == null)
            {
                return;
            }
            switch (Level)
            {
                case 0:
                    sk.Value += (number > 8) ? 1 : 0;
                    break;
                case 1:
                    sk.Value += (number > 7) ? 1 : 0;
                    break;
                case 2:
                    sk.Value += (number > 5) ? 1 : 0;
                    break;
                case 3:
                    sk.Value += (number > 2) ? 1 : 0;
                    break;
            }
        }
    }
}