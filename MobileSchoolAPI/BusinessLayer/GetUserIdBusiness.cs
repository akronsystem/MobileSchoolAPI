using MobileSchoolAPI.BUSINESSLAYER;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GetUserIdBusiness
    {
       

        public object getUserInfo(GetUserId UserId)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(UserId.UserId, UserId.PASSWORD);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message  = "Invalid User" } ;
                }
                object result = "";
                var getUserType = db.VW_GET_USER_TYPE.Where(r => r.UserId == UserId.UserId).FirstOrDefault();

                if (getUserType != null)
                {

                    if (getUserType.UserType == "STUDENT")
                    {
                        STUDENTINFO_BUSINESS GetStudobj = new STUDENTINFO_BUSINESS();
                        result = GetStudobj.getStudInfo(int.Parse(getUserType.EmpCode), UserId.UserId,UserId.PASSWORD);
						var notificationUnreadCount = GetStudobj.getNotifCount(int.Parse(getUserType.EmpCode), Convert.ToInt16(UserId.UserId), UserId.PASSWORD); 
						if (result!=null && result is VW_STUDENT_INFO)
						{
							(result as VW_STUDENT_INFO).HomeworkNotificationUnreadCount = (int)notificationUnreadCount;
							InstituteBusiness Ibl = new InstituteBusiness();
							var inresult = Ibl.GetInstituteName(UserId);
							if (inresult != null && inresult is ResultBirth)
							{
								var r = inresult as ResultBirth;
								var n = r.Result as ViewGetInstituteName;	  
								(result as VW_STUDENT_INFO).InstituteName =n.INSTITUTE_NAME;
							}
								
						}
							
					}
                    else if (getUserType.UserType == "Alumini")
                    {

                        return new Results
                        {
                            IsSuccess = true,
                            Message =  "Alumini User" 
                        };

                      
                    }
                    else
                    {
                        GetTeacherInfoBusiness GetTeacherobj = new GetTeacherInfoBusiness();
                        result = GetTeacherobj.getTeacherInfo(int.Parse(getUserType.EmpCode), UserId.UserId, UserId.PASSWORD);
						if(result!=null && result is VW_EMPLOYEE)
						{
							InstituteBusiness Ibl = new InstituteBusiness();
							var inresult = Ibl.GetInstituteName(UserId);
							if (inresult != null && inresult is ResultBirth)
							{
								var r = inresult as ResultBirth;
								var n = r.Result as ViewGetInstituteName;
								(result as VW_EMPLOYEE).InstituteName = n.INSTITUTE_NAME;
							}
						}
                    }
                    return result;
                }

                return new Results
                {
                    IsSuccess = false,
                    Message =  "User Not Found" 
                };


            

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