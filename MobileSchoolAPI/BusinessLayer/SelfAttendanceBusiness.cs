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
            SchoolMainContext db = new ConcreateContext().GetContext(tobj.USERID, tobj.Password);
            BiometricContext Bdb = new BiometricContext();
            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }

            var Info = db.TBLUSERLOGINs.Where(r => r.UserId == tobj.USERID && r.Password == tobj.Password).FirstOrDefault();
            if (Info == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            List<Result> lts = new List<Result>();
            string lt = string.Empty;
            string et = string.Empty;
            string intime = string.Empty, outtime = string.Empty;
            string latecoming = "", earlygoing = "";
            int TotalPresent = 0, TotalAbscent = 0, Totalhalfday = 0;
            //var academicyear = db.View_GETACADEMICYEAR.FirstOrDefault();
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
                
                lt = Convert.ToDateTime(EmployeeWiseList[i].Intime).ToString("HH:mm:ss");
                et = Convert.ToDateTime(EmployeeWiseList[i].Outtime).ToString("HH:mm:ss");
                
                for (int k = 0; k < li.Count; k++)
                {
                    for(int j=0;j<results.Count();j++)
                    {
                        if(Convert.ToInt32(results[j].userid)==EmployeeID)
                        {
                            intime = Convert.ToDateTime(results[j].InTime).ToString("hh:mm:ss tt");
                            outtime = Convert.ToDateTime(results[j].OutTime).ToString("hh:mm:ss tt");
                        }
                    }
                    string s = Convert.ToDateTime(li[k]).ToString("dd/MM/yyyy").Replace("-", "/"); //Convert.ToDateTime(dtfilter.Rows[k]["logdate"]).ToString("dd/MM/yyyy");
                   
                    int late = DateTime.Compare(Convert.ToDateTime(lt), Convert.ToDateTime(intime));
                    int early = DateTime.Compare(Convert.ToDateTime(et), Convert.ToDateTime(outtime));
                    bool flag = false; bool Halfday = false;
                    if (intime == outtime && intime == "00:00:00" && intime == "00:00:00")
                    {

                    }
                    if (intime == "00:00:00" && intime == "00:00:00")
                    {
                        var Holiday = db.TBLHOLIDAYs.Where(r => r.STARTDATE <= li[k] && r.ENDDATE >= li[k] && r.TYPE == "Holiday").ToList();
                        if (Holiday.Count > 0)
                        {
                            Result ddl = new Result();
                            ddl.Date = (li[k]).ToString("dd/MM/yyyy");
                            ddl.Status = "Present";
                            lts.Add(ddl);
                        }
                        else
                        {
                            Result ddl = new Result();
                            ddl.Date = (li[k]).ToString("dd/MM/yyyy");
                            ddl.Status = "Absent";
                            lts.Add(ddl);
                        }

                    }
                    else if (intime != "00:00:00" && intime != "00:00:00" && intime == outtime)
                    {
                        Result ddl = new Result();
                        ddl.Date = (li[k]).ToString("dd/MM/yyyy");
                        ddl.Status = "Absent";
                        lts.Add(ddl);
                    }
                    else
                    {
                        if (intime != "00:00:00")
                        {
                            if (flag == false)
                            {
                                if (late == -1)
                                {
                                    TimeSpan lt1 = TimeSpan.Parse(lt);
                                    DateTime ts1new = DateTime.Parse(intime);
                                    latecoming = (ts1new - lt1).ToString();
                                    Result ddl = new Result();
                                    ddl.Date = (li[k]).ToString("dd/MM/yyyy");
                                    ddl.Status = "HalfDay";
                                    lts.Add(ddl);
                                    Halfday = true;
                                }
                            }
                        }
                        if (outtime != "00:00:00")
                        {
                            if (flag == false && Halfday == false)
                            {
                                if (early == 1)
                                {
                                    TimeSpan et1 = TimeSpan.Parse(et);
                                    TimeSpan ts2new = TimeSpan.Parse(outtime);
                                    earlygoing = (et1 - ts2new).ToString();
                                    Result ddl = new Result();
                                    ddl.Date = (li[k]).ToString("dd/MM/yyyy");
                                    ddl.Status = "HalfDay";
                                    lts.Add(ddl);
                                    Totalhalfday++;
                                }
                            }

                        }
                    }
                }
            }
            //  var courseList = ctx.Database.SqlQuery<Course>("exec GetCoursesByStudentId @StudentId ", idParam).ToList<Course>();
            return new DatewiseAttendace() { IsSuccess = false, DateWiseStatus = lts };

        }
        public class Result
        {
            public string Date { get; set; }
            public string Status { get; set; }
        }
    }
}
