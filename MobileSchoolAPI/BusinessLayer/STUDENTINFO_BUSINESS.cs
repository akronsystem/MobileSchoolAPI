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
        public object objmethod(int probj,long UserId)
        {
            try
            {

                var result = db.VW_STUDENT_INFO.Where(r => r.ID == probj && r.UserId== UserId).ToList();

                if (result.Count == 0)
                {
                    return "Record Not Found";
                }
                else
                {
                    return result;
                }
                //return result;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}