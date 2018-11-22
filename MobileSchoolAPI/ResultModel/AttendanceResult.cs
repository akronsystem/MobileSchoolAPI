using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ResultModel
{
    public class AttendanceResult
    {
        public bool IsSuccess { get; set; }
        public object UserWiseAttendanceList { get; set; }
    }
}