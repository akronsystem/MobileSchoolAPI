using MobileSchoolAPI.BUSINESSLAYER;
using MobileSchoolAPI.Models;
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
                object result = "";
                var getUserType = db.VW_GET_USER_TYPE.Where(r => r.UserId == UserId.UserId).FirstOrDefault();

                if (getUserType != null)
                {

                    if (getUserType.UserType == "STUDENT")
                    {
                        STUDENTINFO_BUSINESS GetStudobj = new STUDENTINFO_BUSINESS();
                        result = GetStudobj.getStudInfo(int.Parse(getUserType.EmpCode), UserId.UserId,UserId.PASSWORD);
                    }
                    else if (getUserType.UserType == "Alumini")
                    {
                        return "ALUMINI USER";
                    }
                    else
                    {
                        GetTeacherInfoBusiness GetTeacherobj = new GetTeacherInfoBusiness();
                        result = GetTeacherobj.getTeacherInfo(int.Parse(getUserType.EmpCode), UserId.UserId, UserId.PASSWORD);
                    }
                    return result;
                }
                return new Error() { IsError = true, Message = "User Not Found" };

            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }

        }
    }
}