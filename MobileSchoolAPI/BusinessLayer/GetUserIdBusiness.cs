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
        SchoolContext db = new SchoolContext();

        public object getUserInfo(GetUserIdParameter UserId)
        {
            try
            {
                object result = "";
                var getUserType = db.VW_GET_USER_TYPE.Where(r => r.UserId == UserId.UserId).FirstOrDefault();

                if (getUserType != null)
                {

                    if (getUserType.UserType == "STUDENT")
                    {
                        GetStudentInfoBusiness GetStudobj = new GetStudentInfoBusiness();
                        result = GetStudobj.getStudInfo(int.Parse(getUserType.EmpCode), UserId.UserId);
                    }
                    else if (getUserType.UserType == "Alumini")
                    {
                        return "ALUMINI USER";
                    }
                    else
                    {
                        GetTeacherInfoBusiness GetTeacherobj = new GetTeacherInfoBusiness();
                        result = GetTeacherobj.getTeacherInfo(int.Parse(getUserType.EmpCode), UserId.UserId);
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