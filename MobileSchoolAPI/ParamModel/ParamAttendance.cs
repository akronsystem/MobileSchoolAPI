using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.Models
{
    public class ParamAttendance
    {
        public int MONTH { get; set; }
        //public int STANDARDID { get; set; }

        public int DIVISIONID { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
       
    }
}