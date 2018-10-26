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
        public object objmethod(TeacherInfoParameters probj)
        {

            var result = db.VW_EMPLOYEE.Where(r => r.EMPLOYEEID == probj.EMPLOYEEID);
           
            if (result == null)
            {
                return "not found";
            }
            else
            {
                return result;
            }
            return result;
        }
    }
}