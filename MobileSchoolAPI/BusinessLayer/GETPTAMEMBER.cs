using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GETPTAMEMBER
    {
        public object GetMemberList(PTAMemberParam obj)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(obj.UserName, obj.Password);
            if (db == null)
            {
                return new Results { IsSuccess = false, Message = "Invalid User" };
            }
            else
            {
                var data = db.TBLUSERLOGINs.Where(r => r.UserName == obj.UserName && r.Password == obj.Password).FirstOrDefault();
                int StudentId = Convert.ToInt32(data.EmpCode);
                var result = db.View_DisplayStudentDetails.Where(r => r.STUDENTID == StudentId).FirstOrDefault();
                return new StudentDetails { IsSuccess = true, StudentInformation = result };
            }
        }
    }
}