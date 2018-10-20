using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
    public class CalendarController : ApiController
    {
        SchoolContext db = new SchoolContext();

        /// <summary>	
        /// To Confirm Login UserName and Password
        /// If passed then Json object return else Error message 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost]
        public object Confirm(DateTime Date)
        {
            try
            {
                var attendance = db.VIEWATTENDANCEs.
                                    Where(r => r.ATTEDANCEDATE ==Date)
                                    .FirstOrDefault();
                if (attendance == null)
                    return new Error() { IsError = true, Message = "ATTENDANCE IS NOT AVAILABLE." };
                else
                    return "ATTENDANCE IS DONE FOR THAT DATE.";
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}
