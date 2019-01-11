using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class DeviceBusinessLayer
    {
        public object SaveDevice(ParamDevice obj,string Password)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(obj.UserId,Password);
            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = new InvalidUser() { IsSuccess = false, Result = "Invalid User" } };
            }
            TBLDeviceRegistration objDR = new TBLDeviceRegistration();

            var getUserId = db.VW_DEVICE.Where(r => r.UserId == obj.UserId).FirstOrDefault();
            try
            {
                if (getUserId== null)
                {
                    //save
                    objDR.UserId = obj.UserId;
                    objDR.DeviceId = obj.DeviceId;
                    objDR.DeviceType = obj.DeviceType;
                    objDR.InsertDate = DateTime.Now;
                    objDR.ModifiedDate = DateTime.Now;
                    objDR.Status = true;
                    db.TBLDeviceRegistrations.Add(objDR);
                    db.SaveChanges();


                    return new Results() { IsSuccess = true, Message = "Device Registration Succesfull!" };
                  
                }
                else
                {
                    //update
                    TBLDeviceRegistration objdetail = db.TBLDeviceRegistrations.First(r => r.UserId == obj.UserId);
                    
                    objdetail.Id = getUserId.Id;
                    objdetail.UserId = getUserId.UserId;
                    objdetail.DeviceId = obj.DeviceId;
                    objdetail.DeviceType = obj.DeviceType;
                    objdetail.InsertDate = getUserId.InsertDate;
                    objdetail.ModifiedDate = DateTime.Now;
                    objdetail.Status = true;
                    
                    //db.TBLDeviceRegistrations.Add(objdetail);
                    db.SaveChanges();

                    return new Results() { IsSuccess = true, Message = "Notification Updated successfully" };
                  
                }
            }
            catch(Exception ex)
            {

                return new Results
                {
                    IsSuccess = false,
                    Message =   ex.ToString()
                };


            }
           
        }
    }
}