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
    public class ATTENDANCEController : ApiController
    {
       

        /// <summary>	
        /// To Confirm Login UserName and Password
        /// If passed then Json object return else Error message 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost]  

        public object ATTENDANCESTUDENT([FromBody]GETSTUDENTPARAM OBJ)  
        {
            GETSTUDENTATTBL GETOBJ = new GETSTUDENTATTBL();
           var GETSTUDENTRESULT= GETOBJ.GETSTUDENT(OBJ);
			return new STUDENTLISTRESULT() { IsSuccess = "True", StudentResult = GETOBJ.GETSTUDENT(OBJ) };
		}




        public object AttendanceSave([FromBody]AttendanceParameterscs atteobj)
        {

            Homeworkbussinesslayer bhobj = new Homeworkbussinesslayer();


            var result= bhobj.SaveAttendance(atteobj);
            //  bhobj.StudentsMethod(hobj);

            return new STUDENTLISTRESULT() { IsSuccess = "True", StudentResult = bhobj.SaveAttendance(atteobj) };

        }

    }
}
