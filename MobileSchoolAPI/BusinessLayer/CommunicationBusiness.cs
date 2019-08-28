using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class CommunicationBusiness
    {
        public object Communicate(TeacherRatingParam obj)
        {

                SchoolMainContext db = new ConcreateContext().GetContext(obj.UserName, obj.Password);

                var Info = db.TBLUSERLOGINs.Where(r => r.UserName == obj.UserName && r.Password == obj.Password).FirstOrDefault();
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                if (Info == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                var AcademicYear = db.View_GETACADEMICYEAR.FirstOrDefault();
                if (AcademicYear == null)
                {
                    return new Results() { IsSuccess = false, Message = "Academic Year Not Found" };
                }

                var EmployeeCode = Convert.ToInt16(Info.EmpCode);
                var StudentDetails = db.TBLTRANSFERSTUDENTs.Where(r => r.ACADEMICYEAR == AcademicYear.ACADEMICYEAR && r.STUDENTID == EmployeeCode).FirstOrDefault();
                int StandardId = Convert.ToInt32(StudentDetails.STANDARDID);
                int DivisionId = Convert.ToInt32(StudentDetails.DIVISIONID);
                var GetTeacherDetails = db.View_Communiation.Where(r => r.STANDARDID == StandardId && r.DIVISIONID == DivisionId).FirstOrDefault();
                if (GetTeacherDetails == null)
                {
                    return new Results() { IsSuccess = false, Message = "Teacher Not Found" };
                }
                else
                {
                    return new TeacherData() { IsSuccess = true, TeacherInformation = GetTeacherDetails };
                }

           
        }
        public object CommunicateWithParents(TeacherRatingParam obj)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(obj.UserName, obj.Password);

            var Info = db.TBLUSERLOGINs.Where(r => r.UserName == obj.UserName && r.Password == obj.Password).FirstOrDefault();

            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            if (Info == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            var AcademicYear = db.View_GETACADEMICYEAR.FirstOrDefault();
            if (AcademicYear == null)
            {
                return new Results() { IsSuccess = false, Message = "Academic Year Not Found" };
            }

            var EmployeeCode = Convert.ToInt16(Info.EmpCode);
            var GetTeacherDeatils = db.TBLASSIGNCLASSTEACHERs.Where(r => r.EMPLOYEEID == EmployeeCode).FirstOrDefault();
            var StandardId = GetTeacherDeatils.STANDARDID.ToString();
            int DivisionId =Convert.ToInt16(GetTeacherDeatils.DIVISIONID);
            var GetStudents = //db.TBLTRANSFERSTUDENTs.Where(r => r.STANDARDID == StandardId && r.DIVISIONID == DivisionId).ToList();
            from c in db.View_DisplayStudentDetails.Where(r => r.STANDARDID == StandardId && r.DIVISIONID == DivisionId)
            select new { c.STUDENTNAME, c.GENDER, c.DOB, c.GMOBILE, c.IMAGEPATH, c.STUDENTID };
            return GetStudents;
        }
        public class TeacherData
        {
            public bool IsSuccess { get; set; }
            public object TeacherInformation { get; set; }
        }
    }
}