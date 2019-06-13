﻿using MobileSchoolAPI.Models;
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
                int EmployeeID =Convert.ToInt16(Info.EmpCode);

                TBLTIMETABLESCHEDULE data = db.TBLTIMETABLESCHEDULEs.Where(r => r.DISPLAY == 1 && r.EMPLOYEEID == EmployeeID && r.BATCHID == tobj.BATCHID).FirstOrDefault();
              
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
            SchoolMainContext db = new ConcreateContext().GetContext(obj.Username, obj.Password);
            var Password = CryptIt.Encrypt(obj.Password);
           
            var Info = db.TBLUSERLOGINs.Where(r => r.UserName == obj.Username && r.Password == Password).FirstOrDefault();
            
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
            if (obj.WORKINGDAYS=="string")
            {
                obj.WORKINGDAYS= obj.WORKINGDAYS.Replace("string", "");
            }
            if(obj.WORKINGDAYS == "")
            {
               
                var data = db.View_Timetable.Where(r =>r.EMPLOYEEID == EmployeeCode && r.DISPLAY==1 && r.EDUYEAR==AcademicYear.ACADEMICYEAR).ToList();
                if (data == null)
                {
                    return new Results() { IsSuccess = false, Message = "Data Not Found" };
                }
                else
                {
                    return new TIMETABLELIST() { IsSuccess = true, TABLELIST = data };
                }
            }
            else
            {
                var data = db.View_Timetable.Where(r =>r.EMPLOYEEID == EmployeeCode && r.WORKINGDAYS == obj.WORKINGDAYS && r.DISPLAY == 1 && r.EDUYEAR == AcademicYear.ACADEMICYEAR).ToList();
                if (data == null)
                {
                    return new Results() { IsSuccess = false, Message = "Data Not Found" };
                }
                else
                {
                    return new TIMETABLELIST() { IsSuccess = true, TABLELIST = data };
                }

            }

        }
    }
}