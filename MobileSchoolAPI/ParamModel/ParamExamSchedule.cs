using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
    public class ParamExamSchedule
    {
        public int USERID { get; set; }
        public string PASSWORD { get; set; }
        public string STANDARDID { get; set; }
        public int TESTID { get; set; }
    }
}