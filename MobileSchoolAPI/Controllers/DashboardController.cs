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
        
        [HttpPost]
        public object GetDashboard([FromBody]GetUserId UserId)
        {
            GetUserIdBusiness GetUserIdobj = new GetUserIdBusiness();
            var result = GetUserIdobj.getUserInfo(UserId);
            
            return result;
        }
    }
}
