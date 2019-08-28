using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
    public class CommunicationController : ApiController
    {
        [HttpPost]
        public object Communication(TeacherRatingParam obj)
        {
            try
            {
                CommunicationBusiness objp = new CommunicationBusiness();
                var Rate = objp.Communicate(obj);
                return Rate;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }          
           
        }
        [HttpPost]
        public object CommunicationToParents(TeacherRatingParam obj)
        {
            try
            {
                CommunicationBusiness objp = new CommunicationBusiness();
                var Rate = objp.CommunicateWithParents(obj);
                return Rate;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
      

    }
}
