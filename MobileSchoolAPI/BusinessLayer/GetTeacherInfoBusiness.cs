using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BUSINESSLAYER
{
    public class GetTeacherInfoBusiness
    {
        SchoolContext db = new SchoolContext();
        public object objmethod(int probj,long UserId)
        {
            var result = db.VW_EMPLOYEE.Where(r => r.ID == probj && r.UserId == UserId).FirstOrDefault();

            if (result == null)
            {
                return new Error() { IsError = true, Message = "USER Not Found" };
            }
            else
            {
                return result;
            }
         //   return result;
            
        }
    }
}