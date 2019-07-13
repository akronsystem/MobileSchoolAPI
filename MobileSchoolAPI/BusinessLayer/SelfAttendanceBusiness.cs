using MobileSchoolAPI.DAL;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class SelfAttendanceBusiness
    {
        public object DisplayAttendace(GetTeacherParam tobj)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(tobj.UserName, tobj.Password);
            BiometricContext Bdb = new BiometricContext();
            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }

            var Info = db.TBLUSERLOGINs.Where(r => r.UserName == tobj.UserName && r.Password == tobj.Password).FirstOrDefault();
            if (Info == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            string lt = string.Empty;
            string et = string.Empty;
            int TotalPresent = 0, TotalAbscent = 0, Totalhalfday = 0;
            var academicyear = db.View_GETACADEMICYEAR.FirstOrDefault();
            int EmployeeID = Convert.ToInt16(Info.EmpCode);
            int year = DateTime.Now.Year;
            int month = Convert.ToInt32(tobj.Month);
            string monthstr = month.ToString();
            if (monthstr.Length == 1)
            {
                monthstr = "0" + monthstr;
            }

            //year = Convert.ToInt32(academicyear.ACADEMICYEAR);

            string TableName = "DeviceLogs" + "_" + month + "_" + year;
            var results = Bdb.Database.SqlQuery<DevicesParam>("TeacherAttendance @TableName,@Month", new SqlParameter("@TableName", TableName), new SqlParameter("@Month", month)).ToList();
           
                var TodayRecords= Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                         .Select(day => new DateTime(year, month, day)) // Map each day to a date
                         .ToList(); // Load dates into a list
            List<DateTime> li = TodayRecords;
            var EmployeeList = db.View_GetEmployee.ToList();
            var EmployeeWiseList = db.View_GetEmployeeWiseData.Where(r => r.EMPLOYEEID == EmployeeID).ToList();
            for (int i = 0; i < EmployeeWiseList.Count(); i++)
            {
                lt = Convert.ToDateTime(EmployeeList[i].LATE).ToString();
                et= Convert.ToDateTime(EmployeeList[i].EARLY).ToString();
                for (int k = 0; k < li.Count; k++)
                {
                    string s = Convert.ToDateTime(li[k]).ToString("dd/MM/yyyy").Replace("-", "/"); //Convert.ToDateTime(dtfilter.Rows[k]["logdate"]).ToString("dd/MM/yyyy");
                    if (lt == "00:00:00" && et == "00:00:00")
                    {
                        TotalPresent++;
                    }
                    else
                    {
                        TotalAbscent++;
                    }

                }
            }
            //  var courseList = ctx.Database.SqlQuery<Course>("exec GetCoursesByStudentId @StudentId ", idParam).ToList<Course>();
            return TotalAbscent;

        }
    }
}