using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileSchoolAPI.Models;
namespace MobileSchoolAPI.BUSINESSLAYER
{
    public class GetTeacherInfoBusiness
    {
        SchoolContext db = new SchoolContext();
        public object objmethod(int probj)
        {
            var result = db.VW_EMPLOYEE.Where(r => r.ID == probj);
           
            if (result == null)
            {
                return "not found";
            }
            else
            {
                return result;
            }
            
        }
    }
}