 
﻿using System; 
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
 
using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
 

namespace MobileSchoolAPI.Controllers
{
    public class TimetableController : ApiController
    {
        [HttpPost]
        public object CREATETIMETABLE(TimeTableParam tobj)
        {
            TimetableBusiness ObjTerm = new TimetableBusiness();

            var GetTermVar = ObjTerm.ADDTABLE(tobj);
            return GetTermVar;
 
        }
        [HttpPost]
        public object GETTIMETABLE(UpdateTimeTableParam obj)
        {
            TimetableBusiness ObjTerm = new TimetableBusiness();

            var GetTermVar = ObjTerm.GetTimetableInfo(obj);
            return GetTermVar;
        }
    }
}
