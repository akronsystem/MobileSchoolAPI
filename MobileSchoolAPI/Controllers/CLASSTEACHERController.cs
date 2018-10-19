using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
    public class CLASSTEACHERController : ApiController
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
        public object Confirm(int EMPLOYEEID)
        {
            try
            {
                var attendance = db.VIEWCLASSTEACHERs.
                                    Where(r => r.EMPLOYEEID == EMPLOYEEID && r.DISPLAY==1 && r.ACADEMICYEAR=="2018-2019")
                                    .FirstOrDefault();
                if (attendance == null)
                    return new Error() { IsError = true, Message = "ATTENDANCE IS NOT AVAILABLE." };
                else
                    return attendance;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}
