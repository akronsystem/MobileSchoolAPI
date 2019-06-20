using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class TimetableBusiness
    {
        public object ADDTABLE(TimeTableParam tobj)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(tobj.UserName, tobj.Password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                
                var Info = db.TBLUSERLOGINs.Where(r => r.UserName == tobj.UserName && r.Password == tobj.Password).FirstOrDefault();
                if(Info==null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                int EmployeeID =Convert.ToInt16(Info.EmpCode);

                TBLTIMETABLESCHEDULE data = db.TBLTIMETABLESCHEDULEs.Where(r => r.DISPLAY == 1 && r.EMPLOYEEID == EmployeeID && r.BATCHID == tobj.BATCHID && r.WORKINGDAYS==tobj.WORKINGDAYS).FirstOrDefault();
              
                    if (data != null)
                    {
                        return new Results() { IsSuccess = false, Message = "Already Time Table Created" };
                    }
                    else
                    {
                        var AcademicYear = db.View_GETACADEMICYEAR.FirstOrDefault();
                        TBLTIMETABLESCHEDULE obj = new TBLTIMETABLESCHEDULE();

                        obj.EMPLOYEEID = EmployeeID;
                        obj.STANDARDID = tobj.STANDARDID;
                        obj.SUBJECTID = tobj.SUBJECTID;
                        obj.BATCHID = tobj.BATCHID;
                        obj.WORKINGDAYS = tobj.WORKINGDAYS;
                        obj.EDUYEAR = AcademicYear.ACADEMICYEAR;
                        obj.DISPLAY = 1;
                        obj.COMPANYID = 1;
                        obj.CREATEDID = 1;
                        obj.UPDATEDID = 1;
                        obj.CREATEDON = System.DateTime.Now.Date;
                        obj.UPDATEDON = System.DateTime.Now.Date;
                        obj.TIMETABLENAME = tobj.TIMETABLENAME;
                        obj.CLASSROOMID = tobj.CLASSROOMID;
                        obj.DIVISION = tobj.DIVISION;
                        obj.ROOMTYPE = tobj.ROOMTYPE;
                        obj.LABBATCH = tobj.LABBATCH;
                        db.TBLTIMETABLESCHEDULEs.Add(obj);
                        db.SaveChanges();

                    }
                                    
                return new Results() { IsSuccess = true, Message = "Created Timetable" };
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                return new Results
                {
                    IsSuccess = false,
                    Message = ex.Message
                };


            }
        }
        public object GetTimetableInfo(UpdateTimeTableParam obj)
        {
            try
            {


                SchoolMainContext db = new ConcreateContext().GetContext(obj.Username, obj.Password);
              
                var Info = db.TBLUSERLOGINs.Where(r => r.UserName == obj.Username && r.Password == obj.Password).FirstOrDefault();

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
                // var days = db.View_DisplayWeekDay.ToList();
                List<string> WorkingDay = db.View_DisplayWeekDay.OrderBy(r => r.DayNo).Select(r => r.WORKINGDAYS).ToList();
                List<Day> lt = new List<Day>();

                foreach (var item in WorkingDay)
                {
                    item.ToList();
                    TIMETABLELIST ddl = new TIMETABLELIST();
                    // var data = db.View_Timetable.Where(r => r.EMPLOYEEID == EmployeeCode && r.WORKINGDAYS == item && r.DISPLAY == 1 && r.EDUYEAR == AcademicYear.ACADEMICYEAR).ToList();
                    var data_d = from c in db.View_Timetable.Where(r => r.EMPLOYEEID == EmployeeCode && r.WORKINGDAYS == item && r.DISPLAY == 1 && r.EDUYEAR == AcademicYear.ACADEMICYEAR)
                                 select new { c.DIVISION, c.SUBJECTNAME, c.STANDARDNAME, c.BATCHNAME, c.BATCHTIME };

                    if (data_d.Count() == 0)
                    {
                        lt.Add(new Day
                        {

                            WorkingDayName = item,
                            TimeTableList = data_d
                        });
                    }
                    else
                    {
                        lt.Add(new Day
                        {

                            WorkingDayName = item,
                            TimeTableList = data_d
                        });

                    }


                }
                return new TIMETABLELIST() { IsSuccess = true, TABLELIST = lt.ToArray() };

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
        public class Day
        {
            public string WorkingDayName { get; set; }
            public object TimeTableList { get; set; }
        }

    }
}