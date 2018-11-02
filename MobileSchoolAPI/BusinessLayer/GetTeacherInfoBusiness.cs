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
            var result = db.VW_EMPLOYEE.Where(r => r.ID == probj && r.UserId == UserId).ToList();

            if (result.Count == 0)
            {
                return "Record Not Found";
            }
            else
            {
                return result;
            }
         //   return result;
            
        }
    }
}