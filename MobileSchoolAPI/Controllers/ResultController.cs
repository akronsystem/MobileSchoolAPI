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
    public class ResultController : ApiController
    {
        public object ShowResult(ResultParam obj)
        {
            ResultBusiness ObjTerm = new ResultBusiness();

            var GetResult = ObjTerm.ResultShow(obj);
            return GetResult;
        }
    }
}
