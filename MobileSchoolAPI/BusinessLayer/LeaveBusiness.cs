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
            var academicyear = db.View_GETACADEMICYEAR.FirstOrDefault();
            int EmployeeID = Convert.ToInt16(Info.EmpCode);
            var GetInfo = db.TBLLEAVEMASTERs.Where(r => r.EMPLOYEEID == EmployeeID && r.DISPLAY == 1 && r.ACADEMICYEAR==academicyear.ACADEMICYEAR ).ToList();
            if(GetInfo.Count!=0)
            {
                var GetStatus = db.TBLLEAVEMASTERs.Where(r => r.EMPLOYEEID == EmployeeID && r.DISPLAY == 1 && r.LEAVETYPE == tobj.LEAVETYPE && r.ACADEMICYEAR == academicyear.ACADEMICYEAR).OrderByDescending(r=>r.LEAVEID).FirstOrDefault();
                if(GetStatus!=null)
                {
                    if(tobj.SUBSTITUTEID=="No Load")
                    {
                        //
                    }
                    else
                    {
                        string[] subID = tobj.SUBSTITUTEID.Split(',');

                        for (int i = 0; i < subID.Count(); i++)
                        {
                            var ID = int.Parse(subID[i]);
                            var substitute = db.TBLEMPLOYEEMASTERs.Where(r => r.EMPLOYEEID == ID && r.DEPARTMENTID == 24 && r.DISPLAY == 1 && r.EDUYEAR == academicyear.ACADEMICYEAR).ToList();
                            if (substitute.Count == 0)
                            {
                                return new LeaveInfo() { Issucess = false, Status = "Not Found SUBSTITUTEID" };
                            }
                        }
                    }                  
                   
                    if(GetStatus.PRINCIPALSTATUS == "DisApproved" || GetStatus.PRINCIPALSTATUS == "Pending")
                    {
                            return new LeaveInfo() { Issucess = false, Status = "Your Fisrt Leave are not Approved By PRINCIPAL " };
                    }
                    else
                    {
                            for (int i = 0; i < GetInfo.Count(); i++)
                            {
                                SactionDays += Convert.ToDouble(GetInfo[i].NOOFDAYS);
                            }
                            var GetTotalLeave = db.TBLLEAVETYPEMASTERs.Where(r => r.EMPLOYEETYPEID == EmployeeID && r.LEAVETYPEID == tobj.LEAVETYPE && r.DISPLAY == 1 && r.ACADEMICYEAR == academicyear.ACADEMICYEAR).FirstOrDefault();
                           if(GetTotalLeave==null)
                           {
                            return new Results() { IsSuccess = false, Message = "Does Not Created Department.Please Contact Admin" };
                           }
                            AvailableDays = Convert.ToDouble(GetTotalLeave.DAYS - SactionDays);

                            //string[] subID = tobj.SUBSTITUTEID.Split(',');

                            //for (int i = 0; i < subID.Count(); i++)
                            //{
                            //    var ID = int.Parse(subID[i]);
                            //    var substitute = db.TBLEMPLOYEEMASTERs.Where(r => r.EMPLOYEEID == ID && r.DEPARTMENTID == 24 && r.DISPLAY==1 && r.EDUYEAR == academicyear.ACADEMICYEAR).ToList();
                            //    if (substitute.Count == 0)
                            //    {
                            //        return new LeaveInfo() { Issucess = false, Status = "Not Found SUBSTITUTEID" };
                            //    }
                            //}
                            if(AvailableDays>=SactionDays || AvailableDays==0)
                            {
                                return new LeaveList() { IsSuccess = false, ApplicableLeaves = GetTotalLeave.DAYS, RemainingLeaves = AvailableDays };
                            }
                            if(tobj.DayType=="Half Day")
                            {
                            var DayType = 0.5;
                            tobj.NOOFDAYS = Convert.ToDecimal(DayType);
                            }
                            TBLLEAVEMASTER obj = new TBLLEAVEMASTER();
                            obj.LEAVETYPE = tobj.LEAVETYPE;
                            obj.EMPLOYEEID = EmployeeID;
                            obj.FROMDATE = tobj.FROMDATE;
                            obj.TODATE = tobj.TODATE;
                            obj.REASON = tobj.REASON;
                            obj.NOOFDAYS = tobj.NOOFDAYS;
                            obj.ACADEMICYEAR = academicyear.ACADEMICYEAR;
                            obj.CREATEDID = 1;
                            obj.CREATEDON = System.DateTime.Today.Date;
                            obj.CreationTime = System.DateTime.Today.TimeOfDay.ToString();
                            obj.DISPLAY = 1;
                            obj.SANCTIONEDNOOFDAYS = Convert.ToDecimal(SactionDays) + tobj.NOOFDAYS;
                            obj.SUBSTITUTESTATUS = "Pending";
                            obj.PRINCIPALSTATUS = "Pending";
                            obj.SUBSTITUTEID = tobj.SUBSTITUTEID;
                            db.TBLLEAVEMASTERs.Add(obj);
                            db.SaveChanges();
                            
                    }
                    return new LeaveInfo() { Issucess = true, Status = "Apply Leave Successfully" };
                    
                }
               

               // return new LeaveList() { IsSuccess = true, ApplicableLeaves = GetTotalLeave.DAYS,RemainingLeaves=AvailableDays };
            }
            else
            {

                
                var GetTotalLeave = db.TBLLEAVETYPEMASTERs.Where(r => r.EMPLOYEETYPEID == EmployeeID && r.LEAVETYPEID == tobj.LEAVETYPE && r.DISPLAY == 1 && r.ACADEMICYEAR == academicyear.ACADEMICYEAR).FirstOrDefault();

                if (GetTotalLeave == null)
                {
                    return new Results() { IsSuccess = false, Message = "Does Not Created Department.Please Contact Admin" };
                }
                if (tobj.SUBSTITUTEID == "No Load")
                {
                    //
                }
                else
                {
                    string[] subID = tobj.SUBSTITUTEID.Split(',');

                    for (int i = 0; i < subID.Count(); i++)
                    {
                        var ID = int.Parse(subID[i]);
                        var substitute = db.TBLEMPLOYEEMASTERs.Where(r => r.EMPLOYEEID == ID && r.DEPARTMENTID == 24 && r.DISPLAY == 1 && r.EDUYEAR == academicyear.ACADEMICYEAR).ToList();
                        if (substitute.Count == 0)
                        {
                            return new LeaveInfo() { Issucess = false, Status = "Not Found SUBSTITUTEID" };
                        }
                    }
                }
                for (int i = 0; i < GetInfo.Count(); i++)
                {
                    SactionDays += Convert.ToDouble(GetInfo[i].NOOFDAYS);
                }
                // var GetTotalLeave = db.TBLLEAVETYPEMASTERs.Where(r => r.EMPLOYEETYPEID == EmployeeID && r.LEAVETYPEID == tobj.LEAVETYPE && r.DISPLAY == 1 && r.ACADEMICYEAR == academicyear.ACADEMICYEAR).FirstOrDefault();
                AvailableDays = Convert.ToDouble(GetTotalLeave.DAYS - SactionDays);
                if (AvailableDays >= SactionDays || AvailableDays == 0)
                {
                    return new LeaveList() { IsSuccess = false, ApplicableLeaves = GetTotalLeave.DAYS, RemainingLeaves = AvailableDays };
                }
                if (tobj.DayType == "Half Day")
                {
                    var DayType = 0.5;
                    tobj.NOOFDAYS = Convert.ToDecimal(DayType);
                }
                SactionDays = Convert.ToDouble(tobj.NOOFDAYS);
                TBLLEAVEMASTER obj = new TBLLEAVEMASTER();
                obj.LEAVETYPE = tobj.LEAVETYPE;
                obj.EMPLOYEEID = EmployeeID;
                obj.FROMDATE = tobj.FROMDATE;
                obj.TODATE = tobj.TODATE;
                obj.REASON = tobj.REASON;
                obj.NOOFDAYS = tobj.NOOFDAYS;
                obj.ACADEMICYEAR = academicyear.ACADEMICYEAR;
                obj.CREATEDID = 1;
                obj.CREATEDON = System.DateTime.Today.Date;
                obj.CreationTime = System.DateTime.Today.TimeOfDay.ToString();
                obj.DISPLAY = 1;
                obj.SANCTIONEDNOOFDAYS = Convert.ToDecimal(SactionDays);
                obj.SUBSTITUTESTATUS = "Pending";
                obj.PRINCIPALSTATUS = "Pending";
                obj.SUBSTITUTEID = tobj.SUBSTITUTEID;
                db.TBLLEAVEMASTERs.Add(obj);
                db.SaveChanges();
                
                //AvailableDays = Convert.ToDouble(GetTotalLeave.DAYS - SactionDays);
                //return new LeaveList() { IsSuccess = true, ApplicableLeaves = GetTotalLeave.DAYS, RemainingLeaves = GetTotalLeave.DAYS };
            }
            return new LeaveInfo() { Issucess = true, Status = "Apply Leave Successfully" };

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
            var academicyear = db.View_GETACADEMICYEAR.FirstOrDefault();
            int EmployeeID = Convert.ToInt16(Info.EmpCode);
            var GetInfo = db.TBLLEAVEMASTERs.Where(r => r.EMPLOYEEID == EmployeeID && r.DISPLAY == 1 && r.ACADEMICYEAR==academicyear.ACADEMICYEAR).ToList();
            if (GetInfo.Count != 0)
            {
                for (int i = 0; i < GetInfo.Count(); i++)
                {
                    SactionDays += Convert.ToDouble(GetInfo[i].SANCTIONEDNOOFDAYS);
                }
                var GetTotalLeave = db.TBLLEAVETYPEMASTERs.Where(r => r.EMPLOYEETYPEID == EmployeeID && r.LEAVETYPEID == tobj.LeaveType && r.DISPLAY == 1 && r.ACADEMICYEAR == academicyear.ACADEMICYEAR).FirstOrDefault();
                AvailableDays = Convert.ToDouble(GetTotalLeave.DAYS - SactionDays);

                return new LeaveList() { IsSuccess = true, ApplicableLeaves = GetTotalLeave.DAYS, RemainingLeaves = AvailableDays };
            }
            else
            {
                var GetTotalLeave = db.TBLLEAVETYPEMASTERs.Where(r => r.EMPLOYEETYPEID == EmployeeID && r.LEAVETYPEID == tobj.LeaveType && r.DISPLAY == 1 && r.ACADEMICYEAR == academicyear.ACADEMICYEAR).FirstOrDefault();
                //AvailableDays = Convert.ToDouble(GetTotalLeave.DAYS - SactionDays);
                return new LeaveList() { IsSuccess = true, ApplicableLeaves = GetTotalLeave.DAYS, RemainingLeaves = GetTotalLeave.DAYS };
            }
        }

    }
}