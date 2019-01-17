using MobileSchoolAPI.Models;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class ClassTeacherData
    {
        

        /// <summary>
        ///  TO RETURN CLASS TEACHER DATA
        /// </summary>
        /// <param name="PC"></param>
        /// <returns></returns>
        //public object GetClassTeacher(ParamClassTeacher PC)
        //{
        //    try
        //    {
                

        //        var ClassTeacher = db.VIEWCLASSTEACHERs.
        //                            Where(r => r.EMPLOYEEID == PC.EMPLOYEEID && r.DISPLAY == 1 && r.ACADEMICYEAR == "2018-2019")
        //                            .FirstOrDefault();
        //        if (ClassTeacher == null)
        //            return new Error() { IsError = true, Message = "No Class is Assigned To This Teacher" };
        //        else
        //            return ClassTeacher;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Error() { IsError = true, Message = ex.Message };
        //    }
        //}


        public object GetAttendanceStatus(ParamAttendance PA)
        {
            try
            {
                
                int year = DateTime.Now.Year;
                List<DateTime> li = GetDates(year, PA.MONTH);
                CheckUsernamePassword objUP = new CheckUsernamePassword();
                bool iStrue = objUP.ValidateUsernamePassword(PA.UserId, PA.Password);
				if (iStrue == false)
				{
                    return new MonthlyAttendanceResult() { IsSuccess = false, DateWiseStatus = new InvalidUser() { IsSuccess = false, Result = "Invalid User" } };
                    
				}
                List<Result> lt = new List<Result>();
                SchoolMainContext db = new ConcreateContext().GetContext(PA.UserId, PA.Password);
                var USERTYPE = db.VW_GET_USER_TYPE.Where(r => r.UserId == PA.UserId).ToList();

                if (USERTYPE[0].UserType == "STUDENT")
                {
                    var ATTENDANCEDATA = db.VWATTENDANCEBYDATESTUDENTs.Where(r => r.ATTMONTH == PA.MONTH && r.UserId == PA.UserId).ToList();
                    //var HOLIDAYDATA = db.VIEWCHECKHOLIDAYs.Where(r => r.HOLIDAYDATE == PA.MONTH && r.DISPLAY == 1).ToList();

                    int flag = 0;
                    foreach (var item in li)
                    {
                        var checkattendace = db.VIewAttendaceClasswiseChecks.Where(r => r.UserId == PA.UserId && r.ATTEDANCEDATE == item && r.DISPLAY == 1 && r.EDUCATIONYEAR == "2018-2019" && r.ACADEMICYEAR == "2018-2019").ToList();
                        if (checkattendace.Count == 0)
                        {
                            Result ddl = new Result();
                            ddl.Date = item.ToString("dd/MM/yyyy");
                            ddl.Status = "Attendance is not marked by class teacher for this date.";
                            lt.Add(ddl);
                        }
                        else
                        {
                            flag = 0;
                            foreach (var att in ATTENDANCEDATA)
                            {

                                if (att.ATTEDANCEDATE == item)
                                {
                                    Result ddl = new Result();
                                    ddl.Date = item.ToString("dd/MM/yyyy");
                                    ddl.Status = "Absent";
                                    lt.Add(ddl);
                                    flag = 1;
                                }


                            }

                            if (flag == 0)                   
                            {

                                Result ddl = new Result();
                                ddl.Date = item.ToString("dd/MM/yyyy");
                                ddl.Status = "Present";
                                lt.Add(ddl);

                            }
                        }
                    }
                    if (lt == null)
                        return new ResultBirth { IsSuccess = false, Result = new InvalidUser() { IsSuccess = false, Result = "No Attendance Is Found Of This Date" }   };
                
                    else
                        return new MonthlyAttendanceResult() { IsSuccess = true, DateWiseStatus = lt };
                }

                else
                {
                    if (USERTYPE[0].UserType == "CLASS TEACHER")
                    {
                        var ATTENDANCEDATAEMP = db.VWATTENDANCEEMPLOYEEs.Where(r => r.ATTMONTH == PA.MONTH && r.UserId == PA.UserId && r.DISPLAY == 1).ToList();
                        //var HOLIDAYDATA = db.VIEWCHECKHOLIDAYs.Where(r => r.HOLIDAYDATE == PA.MONTH && r.DISPLAY == 1).ToList();

                        int flag = 0;
                        foreach (var item in li)
                        {
                            flag = 0;
                            foreach (var att in ATTENDANCEDATAEMP)
                            {

                                if (att.ATTEDANCEDATE == item)
                                {
                                    Result ddl = new Result();
                                    ddl.Date = item.ToString("dd/MM/yyyy");
                                    ddl.Status = "Attendance Marked";
                                    lt.Add(ddl);
                                    flag = 1;
                                }


                            }

                            if (flag == 0)
                            {

                                Result ddl = new Result();
                                ddl.Date = item.ToString("dd/MM/yyyy");
                                ddl.Status = "Attendance Not Marked";
                                lt.Add(ddl);

                            }
                        }
                        if (lt == null)

                            return new Results
                            {
                                IsSuccess = false,
                                Message = new InvalidUser() { IsSuccess = false, Result = "No Attendance Is Found Of This Date" }
                            };
                     
                        else
                            // return lt;
                            return new MonthlyAttendanceResult() { IsSuccess = true, DateWiseStatus = lt };

                    }
                    else
                    {


						return new Results
						{
							IsSuccess = false,
							Message = new InvalidUser() { IsSuccess = false, Result = "User Is Not Class Teacher" }  
                        };

                    }
                }	 
                 

            }
            catch (Exception ex)
            {
                return new Results
                {
                    IsSuccess = false,
                    Message =    ex.Message 
                };

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