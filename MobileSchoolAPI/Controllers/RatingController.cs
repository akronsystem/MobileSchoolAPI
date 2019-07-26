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
    public class RatingController : ApiController
    {
        [HttpPost]
        public object MarkRating(RatingParam obj)
        {
            try
            {
                RatingBusiness objp = new RatingBusiness();
                var Rate = objp.AddMark(obj);
                return Rate;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }
        [HttpPost]
        public object DisplayRating(TeacherRatingParam obj)
        {
            try
            {
                RatingBusiness objp = new RatingBusiness();
                var Rate = objp.DisplayMark(obj);
                return Rate;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }
    }
}
