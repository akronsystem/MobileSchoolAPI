using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
    public class UserWiseAttendanceController : ApiController
    {

        /// <summary>
        /// Pass Date in mm/DD/yyyy format
        /// </summary>
        /// <param name="PA"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetAttendanceDetails([FromBody]ParamDateWiseAttendance PA)
        {
            try
            {
                UserWiseAttendance objUA = new UserWiseAttendance();
                var Result = objUA.GetAttendanceByUser(PA);

<<<<<<< HEAD
                return new Results() { Date = PA.AttendanceDate, Message = Convert.ToString( Result) };
=======
            //  return new Result() { Date = PA.AttendanceDate, Message = Convert.ToString( Result) };
                return new AttendanceResult()
                {
                    IsSuccess = "true",
                    UserWiseAttendanceList = Result
                };

>>>>>>> faa998539307dd3ba94483a43146395a7e5bdb79
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };

            }
        }
    }
}
