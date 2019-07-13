using MobileSchoolAPI.Models;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GETSTUDENTATTBL
    {
       
        public object GETSTUDENT (GETSTUDENTPARAM OBJ)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(OBJ.USERID, OBJ.PASSWORD);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                var AcadamicYear = db.View_GETACADEMICYEAR.FirstOrDefault();
                if (AcadamicYear == null)
                {
                    return new Results
                    {
                        IsSuccess = false,
                        Message = "Not Found Academic Year"
                    };
                }
                var getstudent = db.VIEWGETSTUDENTATTs.Where(r => r.DIVISIONID == OBJ.DIVISIONID && r.ACADEMICYEAR==AcadamicYear.ACADEMICYEAR).ToList();

                if (getstudent.Count() == 0)

                    return new Results
                    {
                        IsSuccess = false,
                        Message =  "Student Not Found"       
                    };

               
                else
                    //return getstudent.OrderBy(r => r.ROLL_NO).ToList();

                return new STUDENTLISTRESULT() { IsSuccess = true, StudentResult = getstudent.OrderBy(r => r.ROLL_NO).ToList() };


                //var attendance = db.VIEWATTENDANCEs.
                //                    Where(r => r.ATTEDANCEDATE == DATE && r.DISPLAY == 1 )
                //                    .FirstOrDefault();
                //if (attendance == null)
                //    return new Error() { IsError = true, Message = "ATTENDANCE IS NOT AVAILABLE." };
                //else
                //    return attendance;
            }
            catch (Exception ex)
            {

                return new Results
                {
                    IsSuccess = false,
                    Message =   ex.Message  
                };
               
            }
        }
    }
}