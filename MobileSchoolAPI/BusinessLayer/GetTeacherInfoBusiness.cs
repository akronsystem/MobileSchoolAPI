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
        public object getTeacherInfo(int empcode, long UserId)
        {
            var result = db.VW_EMPLOYEE.Where(r => r.ID == empcode && r.UserId == UserId).FirstOrDefault();

            if (result == null)
            {
                return new Error() { IsError = true, Message = "User Not Found" };
            }
            else
            {
                return result;
            }
       
            
        }
    }
}