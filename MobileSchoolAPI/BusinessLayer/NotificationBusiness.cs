using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class NotificationBusiness
    {
        SchoolContext db = new SchoolContext();

       public object SaveNotification(ParamNotification objnote)
        {
            TBLNOTIFICATION objmaster = new TBLNOTIFICATION();
            TBLNOTIFICATIONDETAIL objdetail = new TBLNOTIFICATIONDETAIL();

            objmaster.TITLE = objnote.Title;
            objmaster.NOTIFICATIONDATE = objnote.NotificationDate;
            objmaster.NOTIFICATIONTIME = objnote.Time;
            objmaster.ACADEMICYEAR = "2018-2019";
            objmaster.NOTIFICATIONTYPE = objnote.NotificationType;
            db.TBLNOTIFICATIONs.Add(objmaster);
            db.SaveChanges();

            objdetail.NOTIFICATIONID = objmaster.NOTIFICATIONID;
            string studentid = objnote.student;
            string[] student = studentid.Split(',');
            if (student.Length > 0)
            {
                for (int j = 0; j < student.Length; j++)
                {
                    var studid = student[j];
                    objdetail.STUDENTID =int.Parse(studid);
                    objdetail.STATUS = 0;

                    db.TBLNOTIFICATIONDETAILs.Add(objdetail);
                    db.SaveChanges();
                    

                }
            }
            return "Notification Saved successfully";

        }

        public object ViewNotification(ParamNotificationView obj)
        {
            try
            {
                var Notification = db.VIEWNOTIFICATIONs.Where(r => r.UserId == obj.userid).ToList();
                if (Notification.Count == 0)
                {

                    return new Error() { IsError = true, Message = "No Notifications Found" };

                }
                else
                {
                    return Notification;
                }
            }
            catch (Exception E)
            {
                return new Error()
                {
                    IsError = true,
                    Message = E.Message

                };
            }
        }

        public object UpdateNotification(ParamNotificationUpdate obj)
        {
            try
            {

                TBLNOTIFICATIONDETAIL objdetail = db.TBLNOTIFICATIONDETAILs.First(r => r.NOTIFICATIONID == obj.notificationid && r.STUDENTID == obj.studentid);

                objdetail.STATUS = obj.status;

                db.SaveChanges();

                return "Notification Updated successfully";

            }
            catch (Exception E)
            {
                return new Error()
                {
                    IsError = true,
                    Message = E.Message

                };
            }
        }

    }
}