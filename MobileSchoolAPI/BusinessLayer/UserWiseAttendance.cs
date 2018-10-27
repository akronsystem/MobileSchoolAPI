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
            try
            {
                var usertype= objSc.VW_GET_USER_TYPE.Where(r => r.UserId == obj.UserId).ToList();

                if (usertype[0].UserType == "STUDENT")
                {
                    var StudentAttendance = objSc.VWATTENDANCEBYDATESTUDENTs.Where(r => r.UserId == obj.UserId && r.DIVISIONID == obj.DivisionId && r.ATTEDANCEDATE == obj.AttendanceDate).ToList();
                    if (StudentAttendance.Count() == 0)
                    {
                        return "Status : Present";
                        //EMPLOYEE logic
                        // return new Error() { IsError = true, Message = "Attendance not found" };
                    }
                    else
                    {
                        return "Status : Absent";
                    }
                }
                else
                {
                    var EMPATTENDANCE = objSc.VWATTENDANCEEMPLOYEEs.Where(r => r.UserId == obj.UserId && r.ATTEDANCEDATE == obj.AttendanceDate && r.DISPLAY == 1).ToList();
                    if (EMPATTENDANCE.Count() == 0)
                    {
                        return "User Is Not Class Teacher";

                    }
                    else
                    {
                        return "Status : Attendance Completed;";
                    }
                }
                           
                
            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
    }
}