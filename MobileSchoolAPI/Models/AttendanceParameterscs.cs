using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.Models
{
    public class AttendanceParameterscs
    {
       
       
        public int Userid
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;

        }
        public DateTime ATTEDANCEDATE { get; set; }

        public long DIVISIONID { get; set; }

       
       
        public string Absentno { get; set; }
        
    }
}