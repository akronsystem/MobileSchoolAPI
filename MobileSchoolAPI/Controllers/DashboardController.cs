using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.BUSINESSLAYER;
using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
    public class DashboardController : ApiController
    {
        //[HttpPost]
        //public object getStudentinfo([FromBody]StudinfoParameters pobj)
        //{
        //    STUDENTINFO_BUSINESS obj = new STUDENTINFO_BUSINESS();
        //   var result= obj.objmethod(pobj);

        //    return result;
        //}

        //[HttpPost]
        //public object getTEACHERinfo([FromBody]TeacherInfoParameters pobj)
        //{
        //    GetTeacherInfoBusiness obj = new GetTeacherInfoBusiness();
        //    var result = obj.objmethod(pobj);

        //    return result;
        //}
        [HttpPost]
        public object GetDashboard([FromBody]GetUserId UserId)
        {
            GetUserIdBusiness GUIobj = new GetUserIdBusiness();
            var result = GUIobj.GetUserId(UserId);

          
            return result;
        }
    }
}
