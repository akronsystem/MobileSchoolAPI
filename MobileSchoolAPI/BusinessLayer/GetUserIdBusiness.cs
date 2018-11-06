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

        public object GetUserId(GetUserId UserId)
        {
      
            try
            {
                object result = "";
                var getusertype = db.VW_GET_USER_TYPE.Where(r => r.UserId == UserId.UserId).FirstOrDefault();

                if (getusertype!=null)
                {

                    if (getusertype.UserType == "STUDENT")
                    {
                        STUDENTINFO_BUSINESS obj = new STUDENTINFO_BUSINESS();
                        result = obj.objmethod(int.Parse(getusertype.EmpCode), UserId.UserId);
                    }
                    else if (getusertype.UserType == "Alumini")
                    {
                        return "ALUMINI USER";
                    }
                    else
                    {
                        GetTeacherInfoBusiness obj = new GetTeacherInfoBusiness();
                        result = obj.objmethod(int.Parse(getusertype.EmpCode), UserId.UserId);
                    }
                    return result;
                }
                return new Error() { IsError = true, Message = "USER Not Found" };

            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }

        }
    }
}