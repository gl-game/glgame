using GLCore.Actors;
using GLCore.SupportObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLHelpers
{
    public class Rand : Random
    {
        public new int Next(int a, int b)
        {
            return base.Next(a, b + 1);
        }
    }
    public class Helpers
    {
        public void LessonLearning(String[] lessons, Player player)
        {
            foreach (String lesson in lessons)
            {
                var lessonId = player.Lessons.GetById(lesson);
                if (lessonId.IsVisited == 1) { lessonId.LessonVisited++; } else { lessonId.LessonMissed++; }
                lessonId.IsVisited = 0;
            }
        }

        public int LessonDuration(GameTime time, int CurrentLesson)
        {
            int minutes = time.GetHour() * 60 + time.GetMinute();
            switch (CurrentLesson)
            {
                case 1:
                    if (minutes < 8 * 60 + 15)
                    {
                        return 8 * 60 + 15 - minutes;
                    }
                    else if (minutes < 8 * 60 + 30)
                    {
                        return 8 * 60 + 30 - minutes;
                    }
                    else
                    {
                        return 8 * 60 + 40 - minutes;
                    }
                case 2:
                    if (minutes < 9 * 60 + 5)
                    {
                        return 9 * 60 + 5 - minutes;
                    }
                    else if (minutes < 9 * 60 + 20)
                    {
                        return 9 * 60 + 20 - minutes;
                    }
                    else
                    {
                        return 9 * 60 + 30 - minutes;
                    }
                case 3:
                    if (minutes < 9 * 60 + 55)
                    {
                        return 9 * 60 + 55 - minutes;
                    }
                    else if (minutes < 10 * 60 + 10)
                    {
                        return 10 * 60 + 10 - minutes;
                    }
                    else
                    {
                        return 10 * 60 + 20 - minutes;
                    }
                case 4:
                    if (minutes < 10 * 60 + 55)
                    {
                        return 10 * 60 + 55 - minutes;
                    }
                    else if (minutes < 11 * 60 + 10)
                    {
                        return 11 * 60 + 10 - minutes;
                    }
                    else
                    {
                        return 11 * 60 + 20 - minutes;
                    }
                case 5:
                    if (minutes < 11 * 60 + 50)
                    {
                        return 11 * 60 + 50 - minutes;
                    }
                    else if (minutes < 12 * 60 + 10)
                    {
                        return 12 * 60 + 10 - minutes;
                    }
                    else
                    {
                        return 12 * 60 + 10 - minutes;
                    }
            }
            return 10;
        }
    }
}