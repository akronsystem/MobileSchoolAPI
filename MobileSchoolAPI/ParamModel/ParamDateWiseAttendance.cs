using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
    public class ParamDateWiseAttendance
    {
        public int UserId { get; set; }
        public int DivisionId { get; set; }

        public DateTime AttendanceDate { get; set; }
    }
}