using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class UserWiseAttendance
    {
        SchoolContext objSc = new SchoolContext();

        public object GetAttendanceByUser(ParamDateWiseAttendance obj)
        {
            Result objRES = new Result();
            try
            {
                var usertype = objSc.VW_GET_USER_TYPE.Where(r => r.UserId == obj.UserId).ToList();

                if (usertype[0].UserType == "STUDENT")
                {
                    var StudentAttendance = objSc.VWATTENDANCEBYDATESTUDENTs.Where(r => r.UserId == obj.UserId && r.DIVISIONID == obj.DivisionId && r.ATTEDANCEDATE == obj.AttendanceDate).ToList();
                    if (StudentAttendance.Count() == 0)
                    {
                        objRES.Date = Convert.ToDateTime(obj.AttendanceDate);
                        objRES.Status = "Present";
                        return objRES;
                    }
                    
                    else
                    {
                        objRES.Date = Convert.ToDateTime(StudentAttendance[0].ATTEDANCEDATE);
                        objRES.Status = "Absent";
                        return objRES;
                    }
                }
                else
                {
                    var EMPATTENDANCE = objSc.VWATTENDANCEEMPLOYEEs.Where(r => r.UserId == obj.UserId && r.ATTEDANCEDATE == obj.AttendanceDate && r.DISPLAY == 1).ToList();
                    if (EMPATTENDANCE.Count() == 0)
                    {
                        objRES.Date = Convert.ToDateTime(obj.AttendanceDate);
                        objRES.Status = "User Is Not Class Teacher";
                        return objRES;
                       

                    }
                    else
                    {
                        objRES.Date = Convert.ToDateTime(EMPATTENDANCE[0].ATTEDANCEDATE);
                        objRES.Status = "Attendance Completed;";
                        return objRES;

                       
                    }
                }


            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }

            public class Result
            {
            public DateTime Date { get; set; }
               public string Status { get; set; }
    }
        
    }
}