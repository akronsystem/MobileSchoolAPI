using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileSchoolAPI.Models;

namespace MobileSchoolAPI.ParamModel
{
    public class Result
    {
        public bool IsSucess { get; set; }
        public object ResultData { get; set; }
        public List<View_Timetable> TIMETABLELIST { get; internal set; }
    }
}