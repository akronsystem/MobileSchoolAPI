using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
    public class LeaveController : ApiController
    {
        public object ApplyLeave(LeaveParam obj)
        {
            LeaveBusiness ObjTerm = new LeaveBusiness();

            var GetTermVar = ObjTerm.CreateLeave(obj);
            return GetTermVar;

        }
        public object ShowLeave(GetLeaveParam obj)
        {
            LeaveBusiness ObjTerm = new LeaveBusiness();

            var GetTermVar = ObjTerm.GetLeave(obj);
            return GetTermVar;

        }
    }
}
