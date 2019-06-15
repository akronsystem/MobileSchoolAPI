using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class StudentBusiness
    {
        public object GetStudent(StudentParam obj)
        {
            try
            {


                SchoolMainContext db = new ConcreateContext().GetContext(obj.UserName, obj.Password);
                if (db == null)
                {
                    return new Results { IsSuccess = false, Message = "Invalid User" };
                }
                else
                {
                    var Password = CryptIt.Encrypt(obj.Password);
                    var data = db.TBLUSERLOGINs.Where(r => r.UserName == obj.UserName && r.Password == Password).FirstOrDefault();
                    if (data == null)
                    {
                        return new Results { IsSuccess = false, Message = "Invalid User" };
                    }
                    var academicyear = db.View_GETACADEMICYEAR.FirstOrDefault();
                    if (academicyear == null)
                    {
                        return new StudentDetails { IsSuccess = true, StudentInformation = "Academic Year Not Found" };
                    }
                    if (data != null)
                    {
                        int StudentId = Convert.ToInt32(data.EmpCode);
                        var result = db.View_DisplayStudentDetails.Where(r => r.STUDENTID == StudentId && r.ACADEMICYEAR == academicyear.ACADEMICYEAR).FirstOrDefault();
                        return new StudentDetails { IsSuccess = true, StudentInformation = result };
                    }
                    else
                    {
                        return new StudentDetails { IsSuccess = true, StudentInformation = "Student Not Found" };
                    }

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
    }
}