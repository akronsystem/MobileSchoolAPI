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
    public class TermListController : ApiController
    {
        [HttpPost]

        public object GETTERMLIST(TERMLISTCS tobj)
        {
            GETTERMLISTBL ObjTerm = new GETTERMLISTBL();
           
            var GetTermVar = ObjTerm.TERMLISTBL(tobj);
            return GetTermVar;
            //return new TermListResult(){ IsSuccess="true",TermList= GetTermVar};
            
        }
    }
}
