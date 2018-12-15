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
                return Result;
				//return new AttendanceResult()
				//{
				//	IsSuccess = true,
				//	UserWiseAttendanceList = Result
				//};
			}
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };

            }
        }

        [HttpPost]
        public object GetClassWiseAttendanceList([FromBody]ParamDateWiseAttendance PA)
        {
            try
            {
                UserWiseAttendance objUA = new UserWiseAttendance();
                var Result = objUA.GetClassWiseStatus(PA);
                return Result;
                //return new AttendanceResult()
                //{
                //	IsSuccess = true,
                //	UserWiseAttendanceList = Result
                //};
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };

            }
        }
    }
}
