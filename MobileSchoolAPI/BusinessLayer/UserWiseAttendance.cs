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
                    var checkattendace = objSc.VIewAttendaceClasswiseChecks.Where(r => r.UserId == obj.UserId && r.ATTEDANCEDATE == obj.AttendanceDate && r.DISPLAY == 1 && r.EDUCATIONYEAR == "2018-2019" && r.ACADEMICYEAR == "2018-2019").ToList();
                    if (checkattendace.Count() == 0)
                    {
                        return "Status : Attendance Is Not Marked By Class Teacher For This Date";
                    }
                    else
                    { 
                        var StudentAttendance = objSc.VWATTENDANCEBYDATESTUDENTs.Where(r => r.UserId == obj.UserId && r.ATTEDANCEDATE == obj.AttendanceDate).ToList();
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

                }
                else
                {
                    var EMPATTENDANCE = objSc.VWATTENDANCEEMPLOYEEs.Where(r => r.UserId == obj.UserId && r.ATTEDANCEDATE == obj.AttendanceDate && r.DISPLAY == 1).ToList();
                    if (usertype[0].UserType == "CLASS TEACHER")

                    {
                        if (EMPATTENDANCE.Count() == 0)
                        {
                            return "Status : Attendance Not Completed";

                        }
                        else
                        {
                            return "Status : Attendance Completed";
                        }
                    }
                    else
                    {
                        return "Status : User is not class Teacher";
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