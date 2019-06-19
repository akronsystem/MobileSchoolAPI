using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class LeaveBusiness
    {
        public object CreateLeave(LeaveParam tobj)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(tobj.UserName, tobj.Password);
            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }

            var Info = db.TBLUSERLOGINs.Where(r => r.UserName == tobj.UserName && r.Password == tobj.Password).FirstOrDefault();
            if (Info == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            double SactionDays = 0,AvailableDays=0;

            int EmployeeID = Convert.ToInt16(Info.EmpCode);
            var GetInfo = db.TBLLEAVEMASTERs.Where(r => r.EMPLOYEEID == EmployeeID && r.DISPLAY == 1 ).ToList();
            if(GetInfo.Count!=0)
            {
                for(int i=0;i<GetInfo.Count();i++)
                {
                    SactionDays +=Convert.ToDouble(GetInfo[i].SANCTIONEDNOOFDAYS);
                }
                var GetTotalLeave = db.TBLLEAVETYPEMASTERs.Where(r => r.EMPLOYEETYPEID == EmployeeID && r.LEAVETYPEID==tobj.LEAVETYPE && r.DISPLAY == 1).FirstOrDefault();
                    AvailableDays =Convert.ToDouble(GetTotalLeave.DAYS - SactionDays);

               // return new LeaveList() { IsSuccess = true, ApplicableLeaves = GetTotalLeave.DAYS,RemainingLeaves=AvailableDays };
            }
            else
            {
                var GetTotalLeave = db.TBLLEAVETYPEMASTERs.Where(r => r.EMPLOYEETYPEID == EmployeeID && r.LEAVETYPEID == tobj.LEAVETYPE && r.DISPLAY == 1).FirstOrDefault();
                //AvailableDays = Convert.ToDouble(GetTotalLeave.DAYS - SactionDays);
                //return new LeaveList() { IsSuccess = true, ApplicableLeaves = GetTotalLeave.DAYS, RemainingLeaves = GetTotalLeave.DAYS };
            }
            TBLLEAVEMASTER obj = new  TBLLEAVEMASTER();
            obj.LEAVETYPE = tobj.LEAVETYPE;
            obj.EMPLOYEEID = EmployeeID;
            obj.FROMDATE = tobj.FROMDATE;
            obj.TODATE = tobj.TODATE;
            obj.REASON = tobj.REASON;
            obj.NOOFDAYS = tobj.NOOFDAYS;
            obj.ACADEMICYEAR = tobj.ACADEMICYEAR;
            obj.CREATEDID = 1;
            obj.CREATEDON = System.DateTime.Today.Date;
            obj.CreationTime = System.DateTime.Today.TimeOfDay.ToString();
            obj.DISPLAY = 1;
            db.TBLLEAVEMASTERs.Add(obj);
            db.SaveChanges();
            return null;
        }
        public object GetLeave(GetLeaveParam tobj)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(tobj.UserName, tobj.Password);
            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }

            var Info = db.TBLUSERLOGINs.Where(r => r.UserName == tobj.UserName && r.Password == tobj.Password).FirstOrDefault();
            if (Info == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            double SactionDays = 0, AvailableDays = 0;

            int EmployeeID = Convert.ToInt16(Info.EmpCode);
            var GetInfo = db.TBLLEAVEMASTERs.Where(r => r.EMPLOYEEID == EmployeeID && r.DISPLAY == 1).ToList();
            if (GetInfo.Count != 0)
            {
                for (int i = 0; i < GetInfo.Count(); i++)
                {
                    SactionDays += Convert.ToDouble(GetInfo[i].SANCTIONEDNOOFDAYS);
                }
                var GetTotalLeave = db.TBLLEAVETYPEMASTERs.Where(r => r.EMPLOYEETYPEID == EmployeeID && r.LEAVETYPEID == tobj.LeaveType && r.DISPLAY == 1).FirstOrDefault();
                AvailableDays = Convert.ToDouble(GetTotalLeave.DAYS - SactionDays);

                return new LeaveList() { IsSuccess = true, ApplicableLeaves = GetTotalLeave.DAYS, RemainingLeaves = AvailableDays };
            }
            else
            {
                var GetTotalLeave = db.TBLLEAVETYPEMASTERs.Where(r => r.EMPLOYEETYPEID == EmployeeID && r.LEAVETYPEID == tobj.LeaveType && r.DISPLAY == 1).FirstOrDefault();
                //AvailableDays = Convert.ToDouble(GetTotalLeave.DAYS - SactionDays);
                return new LeaveList() { IsSuccess = true, ApplicableLeaves = GetTotalLeave.DAYS, RemainingLeaves = GetTotalLeave.DAYS };
            }
        }

    }
}