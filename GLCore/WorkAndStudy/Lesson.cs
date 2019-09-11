using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.WorkAndStudy
{
    [Serializable]
    public class Lesson : ILesson
    {
        public String id { get; set; }
        public String classname { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int IsVisited { get; set; }
        public int LessonVisited { get; set; }
        public int LessonMissed { get; set; }
        public int SuccessRate { get; set; }
    }
}
