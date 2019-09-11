using GLCore.WorkAndStudy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.Extensions
{
    public class Lessons
    {
        public List<ILesson> Lesson { get; set; }
        public Lessons()
        {
            Lesson = new List<ILesson>();
        }
        public ILesson GetById(String id)
        {
            var z = Lesson.FirstOrDefault(x => x.id == id);
            return z;
        }
    }
}