﻿using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GetDivisionInfoBusiness
    {
       


        public object GetDivision(ParamDIVISIONLIST objdiv)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(objdiv.userid, objdiv.password);
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
                var EmpDivision = db.VIEWEMPDIVISIONs.Where(r=>r.UserId==objdiv.userid && r.ACADEMICYEAR==AcadamicYear.ACADEMICYEAR && r.DISPLAY==1).ToList();
                if (EmpDivision.Count == 0)
                {
                    var StudentDivision = db.VIEWSTUDENTDIVISIONs.Where(r => r.UserId == objdiv.userid && r.ACADEMICYEAR == AcadamicYear.ACADEMICYEAR && r.DISPLAY == 1).ToList();
                    if (StudentDivision.Count == 0)
                    {

                        return new Results
                        {
                            IsSuccess = false,
                            Message = "No Attendance Is Found Of This DateDivision is not assigned for this user"    
                        };
                       
                    }
                    else
                    {
                        return new DivisionListByUserResult() { IsSuccess = true, DivisionList = StudentDivision };
                       
                    }
                }
                else
                {
                    return new DivisionListByUserResult() { IsSuccess = true, DivisionList = EmpDivision };
                   
                }
            }
            catch (Exception E)
            {

                return new Results
                {
                    IsSuccess = false,
                    Message =   E.Message 
                };

               
            }
        }

    }
}