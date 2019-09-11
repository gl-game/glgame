using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.SupportObjects
{
    public class GameTime
    {
        public delegate void EventContainer(int x);
        public event EventContainer minuteChange;
        public event EventContainer hourChange;
        public event EventContainer dayChange;

        public bool IsEventHandlerRegistered()
        {
            var list = minuteChange.GetInvocationList();
            return false;
        }

        public DateTime time { get; set; }

        public String GetTime()
        {
            return FirstCharToUpper(time.ToString("dddd, d MMMM yyyy г. HH:mm", CultureInfo.GetCultureInfo("ru-ru")));
        }

        public DateTime GetDateTime()
        {
            return time;
        }

        public int GetHour()
        {
            return Convert.ToInt32(time.ToString("HH", CultureInfo.GetCultureInfo("ru-ru")));
        }

        public int GetMinute()
        {
            return Convert.ToInt32(time.ToString("mm", CultureInfo.GetCultureInfo("ru-ru")));
        }

        public int GetDay()
        {
            return Convert.ToInt32(time.ToString("dd", CultureInfo.GetCultureInfo("ru-ru")));
        }

        public int GetYear()
        {
            return Convert.ToInt32(time.ToString("YY", CultureInfo.GetCultureInfo("ru-ru")));
        }

        public int GetMonth()
        {
            return Convert.ToInt32(time.ToString("MM", CultureInfo.GetCultureInfo("ru-ru")));
        }

        public int GetWeekDay()
        {
            int dw = Convert.ToInt32(time.DayOfWeek);
            if (dw == 0) {
                dw = 7;
            }
            return dw;
        }

        public void AddTime(int Minutes)
        {
            if (Minutes < 1)
            {
                return;
            }
            DateTime pastTime = time;
            time = time.AddMinutes(Minutes);
            if (minuteChange != null)
            {
                minuteChange(Minutes);
            }
            int HoursTotal = Convert.ToInt32(Math.Floor(Convert.ToDouble((pastTime.Minute + Minutes) / 60)));
            int DaysTotal = Convert.ToInt32(Math.Floor(Convert.ToDouble((pastTime.Hour * 60 + pastTime.Minute + Minutes) / 1440)));
            if (HoursTotal > 0 && hourChange != null)
            {
                hourChange(HoursTotal);
            }
            if (DaysTotal > 0 && dayChange != null)
            {
                dayChange(DaysTotal);
            }


        }

        public static String FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }
    }
}
