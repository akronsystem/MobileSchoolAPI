using MobileSchoolAPI.Models;
using MobileSchoolAPI.ResultModel;
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
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message  = "Invalid User" } ;
                }
                var result = db.VW_STUDENT_INFO.Where(r => r.ID == empcode && r.UserId== UserId).FirstOrDefault();
                
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
            catch (Exception ex)
            {

                return new Results
                {
                    IsSuccess = false,
                    Message =  ex.Message 
                };

                
            }
        }
        public object getNotifCount(int empcode, int UserId, string Password)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(UserId, Password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                var result = db.View_UnreadNotificationCount.Where(r => r.STUDENTID == empcode && r.STATUS==0).ToList();
                if (result == null)
                {

                    return new Results
                    {
                        IsSuccess = false,
                        Message = new InvalidUser() { IsSuccess = false, Result = "Logo Not Found" }
                    };

                }
                else
                {
                    return result.Count;
                }

            }
            catch (Exception ex)
            {

                return new Results
                {
                    IsSuccess = false,
                    Message = ex.Message
                };


            }
        }
        public object getStudLogo(int empcode, int UserId,string Password)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(UserId, Password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message  = "Invalid User" } ;
                }
                var result = db.VW_STUDENT_INFO.Where(r => r.ID == empcode && r.UserId == UserId).FirstOrDefault();
               
                if (result == null)
                {

                    return new Results
                    {
                        IsSuccess = false,
                        Message = new InvalidUser() { IsSuccess = false, Result = "Logo Not Found" }   
                    };
                
                }
                else
                {
                    return result.IMAGEPATH;
                }

            }
            catch (Exception ex)
            {

                return new Results
                {
                    IsSuccess = false,
                    Message =   ex.Message  
                };

              
            }
        }
    }
}