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
    public class ViewExamScheduleController : ApiController
    {
        [HttpPost]
        public object GetGallery([FromBody]ParamExamSchedule OBJ)
        {
            GetExamScheduleBL GETOBJ = new GetExamScheduleBL();
            var GetExamScheduleResult = GETOBJ.GetExamSchedule(OBJ);
            return GetExamScheduleResult;
        }
    }
}
