using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class ClassTeacherData
    {
        SchoolContext db = new SchoolContext();

        /// <summary>
        ///  TO RETURN CLASS TEACHER DATA
        /// </summary>
        /// <param name="PC"></param>
        /// <returns></returns>
        public object GetClassTeacher(ParamClassTeacher PC)
        {
            try
            {

                var ClassTeacher = db.VIEWCLASSTEACHERs.
                                    Where(r => r.EMPLOYEEID == PC.EMPLOYEEID && r.DISPLAY == 1 && r.ACADEMICYEAR == "2018-2019")
                                    .FirstOrDefault();
                if (ClassTeacher == null)
                    return new Error() { Message = "No Class is Assigned To This Teacher" };
                else
                    return ClassTeacher;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        public object GetAttendanceStatus(ParamAttendance PA)
        {
            try
            {
                int year = DateTime.Now.Year;
                List<DateTime> li = GetDates(year, PA.MONTH);

                List<Result> lt = new List<Result>();

                var  ATTENDANCEDATA =db.VIEWATTENDANCECHECKs.Where(r => r.MONTH == PA.MONTH  && r.DIVISIONID == PA.DIVISIONID).ToList();

                int flag = 0;
                foreach (var item in li)
                {
                    flag = 0;
                    foreach (var att in ATTENDANCEDATA)
                    {

                        if (att.ATTEDANCEDATE == item)
                        {
                            Result ddl = new Result();
                            ddl.Date = item.ToString("dd/MM/yyyy");
                            ddl.Status = "Done";
                            lt.Add(ddl);
                            flag = 1;
                        }
                        

                    }

                    if (flag == 0)
                    {
                       
                            Result ddl = new Result();
                            ddl.Date = item.ToString("dd/MM/yyyy");
                        ddl.Status = "Not Done";
                            lt.Add(ddl);
                        
                    }
                }

               
                if (lt == null)
                    return new Error() { IsError = true, Message = "No Attendance Is Found Of This Date" };
                else
                    return lt;

            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
         
        public class Result
        {
            public string Date { get; set; }
            public string Status { get; set; }
        }

            public List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }
    }
}