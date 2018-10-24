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
    public class HomeWorkController : ApiController
    {
        SchoolContext db = new SchoolContext();
        [HttpPost]

        public object ViewHomework([FromBody] PARAMHOMEWORK obj)
        {

            GETHOMEWORK objhome = new GETHOMEWORK();
           return objhome.GetHomework(obj);
           
        }


        public object ViewDivision([FromBody]PARAMSTD objstd)
        {
            GETHOMEWORK objhome = new GETHOMEWORK();
            return objhome.GetStandard(objstd);
        }
    }
}
