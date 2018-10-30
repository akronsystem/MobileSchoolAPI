using MobileSchoolAPI.BusinessLayer;
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
        [HttpPost]

        public object GETTERMLIST()
        {
            GETTERMLISTBL OBJTERM = new GETTERMLISTBL();
            var GETTERMVAR = OBJTERM.TERMLISTBL();
            return GETTERMVAR;
        }
    }
}
