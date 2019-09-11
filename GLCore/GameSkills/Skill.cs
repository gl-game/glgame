using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.GameSkills
{
    [Serializable]
    public class Skill : ISkill
    {
        public String id { get; set; }
        public String classname { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int Value { get; set; }
    }
}
