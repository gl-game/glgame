using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.DTO
{
    public class NotificationDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String Notification { get; set; }
        public String NotificationID { get; set; }
    }
}
