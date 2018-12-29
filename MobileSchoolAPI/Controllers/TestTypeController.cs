using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
    public class TestTypeController : ApiController
    {
        [HttpPost]

        public object GetTestList(TERMLISTCS tobj)
        {
            TestTypeBL ObjTerm = new TestTypeBL();

            var GetTermVar = ObjTerm.TESTLISTBL(tobj);
            return GetTermVar;
            //return new TermListResult(){ IsSuccess="true",TermList= GetTermVar};

        }
    }
}
