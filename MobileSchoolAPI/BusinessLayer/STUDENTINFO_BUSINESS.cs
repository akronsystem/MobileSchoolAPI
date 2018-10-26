using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BUSINESSLAYER
{
    
    public class STUDENTINFO_BUSINESS
    {
        SchoolContext db = new SchoolContext();
        public object objmethod(StudinfoParameters probj)
        {

            var result = db.VW_STUDENT_INFO.Where(r => r.STUDENTID == probj.STUDENTID);

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