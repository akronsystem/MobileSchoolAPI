using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
    public class ParamNotification
    {

        public int userid { get; set; }

        public string password { get; set; }
        public string NotificationType { get; set; }
        public string Title { get; set; }
        public DateTime NotificationDate { get; set; }

        public string Time { get; set; }

        public string student { get;set; }

        
    }
}