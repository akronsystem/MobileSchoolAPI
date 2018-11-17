using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
 
    public class ClassTeacherController : ApiController
    {
        SchoolContext db = new SchoolContext();
        

        /// FOR SELECTING ATTENDANCE ON DATE
        /// 
        [HttpPost]
        public object GetAttendanceData([FromBody]ParamAttendance objPA)
        {
            int year = DateTime.Now.Year;
            int days = DateTime.DaysInMonth(year, objPA.MONTH);
            ClassTeacherData objCT = new ClassTeacherData();                
            var result = objCT.GetAttendanceStatus(objPA);
            return result;
           // return new MonthlyAttendanceResult() { IsSuccess = "true", DateWiseStatus = result }; 

        }
    }
}
