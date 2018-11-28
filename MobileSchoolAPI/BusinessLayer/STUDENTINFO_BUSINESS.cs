using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BUSINESSLAYER
{

    public class STUDENTINFO_BUSINESS
    {
       
        public object getStudInfo(int empcode,int UserId,string Password)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(UserId, Password);

                var result = db.VW_STUDENT_INFO.Where(r => r.ID == empcode && r.UserId== UserId).FirstOrDefault();
                
                if (result == null)
                {
                    return new Error() { IsError = true, Message = "User Not Found" };
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

        public object getStudLogo(int empcode, int UserId,string Password)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(UserId, Password);

                var result = db.VW_STUDENT_INFO.Where(r => r.ID == empcode && r.UserId == UserId).FirstOrDefault();
               
                if (result == null)
                {
                    //return new Error() { IsError = true, Message = "Logo Not Found" };
                    return "";
                }
                else
                {
                    return result.IMAGEPATH;
                }

            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}