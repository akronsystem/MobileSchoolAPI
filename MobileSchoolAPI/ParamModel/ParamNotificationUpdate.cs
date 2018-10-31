using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
    public class ParamNotificationUpdate
    {
        public int userid { get; set; }
        public string password { get; set; }
        public int notificationid { get; set; }
        public int studentid { get; set; }
        public int status { get; set; }
    }
}