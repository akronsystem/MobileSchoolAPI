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
                SchoolMainContext db = new ConcreateContext().GetContext(tobj.Userid, tobj.Password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
 
                TBLTIMETABLESCHEDULE data = db.TBLTIMETABLESCHEDULEs.Where(r => r.DISPLAY == 1 && r.EMPLOYEEID == tobj.EMPLOYEEID).FirstOrDefault();
                if(data!=null)
                {
                    var info = db.TBLTIMETABLESCHEDULEs.Where(r => r.DISPLAY == 1  && r.BATCHID == tobj.BATCHID ).FirstOrDefault();
                         if(info!=null)
                         {
                             return new Results() { IsSuccess = false, Message = "Already Time Table Created" };
                         }
                    else
                    {
                        TBLTIMETABLESCHEDULE obj = new TBLTIMETABLESCHEDULE();

                        obj.EMPLOYEEID = tobj.EMPLOYEEID;
                        obj.STANDARDID = tobj.STANDARDID;
                        obj.SUBJECTID = tobj.SUBJECTID;
                        obj.BATCHID = tobj.BATCHID;
                        obj.WORKINGDAYS = tobj.WORKINGDAYS;
                        obj.EDUYEAR = tobj.EDUYEAR;
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
            SchoolMainContext db = new ConcreateContext().GetContext(obj.Userid, obj.Password);
            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
 

            if(obj.WORKINGDAYS=="")
            {
                var data = db.TBLTIMETABLESCHEDULEs.Where(r => r.DISPLAY == 1 && r.EMPLOYEEID == obj.EMPLOYEEID).ToList();
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
                var data = db.TBLTIMETABLESCHEDULEs.Where(r => r.DISPLAY == 1 && r.EMPLOYEEID == obj.EMPLOYEEID && r.WORKINGDAYS == obj.WORKINGDAYS).ToList();
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