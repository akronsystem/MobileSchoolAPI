using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ResultModel
{
    public class LeaveList
    {
        public bool IsSuccess { get; set; }
        public  object ApplicableLeaves { get; set; }
        public object RemainingLeaves { get; set; }
    }
}