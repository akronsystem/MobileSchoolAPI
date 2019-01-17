using MobileSchoolAPI.Models;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BUSINESSLAYER
{
    public class GetTeacherInfoBusiness
    {
        
        public object getTeacherInfo(int empcode, int UserId,string Password)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(UserId, Password);
            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = new InvalidUser() { IsSuccess = false, Result = "Invalid User" } };
            }
            var result = db.VW_EMPLOYEE.Where(r => r.ID == empcode && r.UserId == UserId).FirstOrDefault();

            if (result == null)
            {
                return new Results
                {
                    IsSuccess = false,
                    Message = new InvalidUser() { IsSuccess = false, Result = "User Not Found" }    
                };


               
            }
            else
            {
                return result;
            }
       
            
        }
        public object getTeacherLogo(int empcode, int UserId,string Password)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(UserId, Password);
            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = new InvalidUser() { IsSuccess = false, Result = "Invalid User" } };
            }
            var result = db.VW_EMPLOYEE.Where(r => r.ID == empcode && r.UserId == UserId).FirstOrDefault();

            if (result == null)
            {
                return result;
            }
            else
            {
                return result.IMAGEPATH;
            }


        }
    }
}