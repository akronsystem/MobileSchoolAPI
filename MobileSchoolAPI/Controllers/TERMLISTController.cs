using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
    public class TERMLISTController : ApiController
    {
        [HttpGet]

        public object GETTERMLIST()
        {
            GETTERMLISTBL OBJTERM = new GETTERMLISTBL();
            var GETTERMVAR = OBJTERM.TERMLISTBL();
            //return GETTERMVAR;
            return new STUDENTLISTRESULT() { IsSuccess = "TERM LIST", StudentResult = Convert.ToString(GETTERMVAR) };
        }
    }
}
