using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.WorkAndStudy
{
    public interface ILesson
    {
        String id { get; set; }
        String classname { get; set; }
        String Name { get; set; }
        String Description { get; set; }
        int IsVisited { get; set; }
        int LessonVisited { get; set; }
        int LessonMissed { get; set; }
        int SuccessRate { get; set; }
    }
}
