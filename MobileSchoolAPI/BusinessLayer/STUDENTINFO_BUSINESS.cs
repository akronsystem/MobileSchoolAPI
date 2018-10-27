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
        public object objmethod(int probj)
        {
            try
            {

                var result = db.VW_STUDENT_INFO.Where(r => r.STUDENTID == probj).ToList();

                if (result == null)
                {
                    return "not found";
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}