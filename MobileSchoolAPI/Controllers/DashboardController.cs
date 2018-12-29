using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.BUSINESSLAYER;
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
    public class DashboardController : ApiController
    {
        
        [HttpPost]
        public object GetDashboard([FromBody]GetUserId UserId)
        {
            GetUserIdBusiness GetUserIdobj = new GetUserIdBusiness();
            var result = GetUserIdobj.getUserInfo(UserId);
            
            return result;
        }
        [HttpPost]
        public object GetTodayStudentBirthDay([FromBody] GetUserId Obj)
        {
            try
            {
                BirthdayBusiness getBirthDay = new BirthdayBusiness();
                var result = getBirthDay.GetTodayStudentBirthDay(Obj);
                return result;
            }
           catch(Exception ex)
            {
                return new Error { IsError = true, Message = ex.ToString() };
            }
        }
        [HttpPost]
        public object GetInstituteName([FromBody] GetUserId Obj)
        {
            try
            {
                InstituteBusiness Ibl = new InstituteBusiness();
                var result = Ibl.GetInstituteName(Obj);
                return result;
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.ToString() };
            }
        }

        [HttpPost]
        public object GetTodayEmployeeBirthDetails([FromBody]GetUserId Obj)
        {
            try
            {
                BirthdayBusiness getBirthDay = new BirthdayBusiness();
                var result = getBirthDay.GetTodayEmployeeBirthDay(Obj);
                return result;
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.ToString() };
            }
        }
    }
}
