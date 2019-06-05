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
    public class FeesController : ApiController
    {
        [HttpPost]
        public object GetFees(FeePram obj)
        {
            FeeBusiness ObjTerm = new FeeBusiness();

            var GetTermVar = ObjTerm.GetFee(obj);
            return GetTermVar;
        }

    }
}
