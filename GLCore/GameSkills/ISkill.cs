using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.GameSkills
{
    public interface ISkill
    {
        String id { get; set; }
        String classname { get; set; }
        String Name { get; set; }
        String Description { get; set; }
        int Value { get; set; }
    }
}
