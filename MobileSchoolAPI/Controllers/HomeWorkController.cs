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

        public object ViewHomework(int standardid, int divisionid)
        {
            try
            {
               
                var homework = db.VIEWHOMEWORKs.Where(r => r.STANDARDID == standardid && r.DIVISIONID == divisionid && r.DISPLAY == 1 && r.ACADEMICYEAR == "2018-2019").
                  
                                     FirstOrDefault();
                if (homework == null)
                {
                    return new Error() { IsError = true, Message = "Homework not found" };
                }
                else
                {
                    return homework;
                }

            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }

        }
    }
}
