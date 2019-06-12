using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.ParamModel;

namespace MobileSchoolAPI.Controllers
{
    public class PTAMemberController : ApiController
    {
        [HttpPost]
        public object GetPTAMember(PTAMemberParam obj)
        {
            GETPTAMEMBER ObjTerm = new GETPTAMEMBER();
            var GetTermVar = ObjTerm.GetMemberList(obj);
            return GetTermVar;
        }
    }
}
