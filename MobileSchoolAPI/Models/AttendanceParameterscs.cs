using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.Models
{
    public class AttendanceParameterscs
    {
       

        public string EDUCATIONYEAR { get; set; }

        public long STANDARDID { get; set; }

        public DateTime ATTEDANCEDATE { get; set; }

        public long DIVISIONID { get; set; }

        public int DISPLAY { get; set; }
        public DateTime CREATEDON { get; set; }
        public string Absentno { get; set; }
        
    }
}