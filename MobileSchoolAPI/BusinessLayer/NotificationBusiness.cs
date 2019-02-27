using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class NotificationBusiness
    {
        

       public object SaveNotification(ParamNotification objnote)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(objnote.userid, objnote.password);

                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }

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
                        objdetail.STUDENTID = int.Parse(studid);
                        objdetail.STATUS = 0;

                        db.TBLNOTIFICATIONDETAILs.Add(objdetail);
                        db.SaveChanges();


                    }
                }


                return new DivisionListResult() { IsSuccess = true, Notification =  "Notification Saved successfully" };

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

        public object ViewNotification(ParamNotificationView obj)
        {
            try
            {

                SchoolMainContext db = new ConcreateContext().GetContext(obj.userid, obj.password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message  = "Invalid User" } ;
                }



            
                else
                {
                    var Notification = db.VIEWNOTIFICATIONs.Where(r => r.UserId == obj.userid).ToList().OrderByDescending(r => r.NOTIFICATIONID);
                    //var NotificationAll = db.VIEWALLNOTIFICATIONs.ToList().OrderByDescending(r => r.NOTIFICATIONID);
                    List<Result> lt = new List<Result>(); 


                    foreach (var att in Notification)
                    {

                        Result ddl = new Result();
                        ddl.TITLE = att.TITLE;
                        ddl.NOTIFICATIONID = att.NOTIFICATIONID;
                        ddl.NOTIFICATIONDATE =Convert.ToDateTime(att.NOTIFICATIONDATE);
                        ddl.NOTIFICATIONTIME = att.NOTIFICATIONTIME;
                        ddl.NOTIFICATIONTYPE = att.NOTIFICATIONTYPE;
                        ddl.UserId = att.UserId.ToString();
                        ddl.STUDENTID = att.STUDENTID.ToString();
                        ddl.STATUS = att.STATUS.ToString();
                        ddl.UserType = att.UserType;

                        lt.Add(ddl);




                    }

                    //foreach (var att in NotificationAll)
                    //{


                    //    Result ddl = new Result();
                    //    ddl.TITLE = att.TITLE;
                    //    ddl.NOTIFICATIONID = att.NOTIFICATIONID;
                    //    ddl.NOTIFICATIONDATE = att.NOTIFICATIONDATE.ToString();
                    //    ddl.NOTIFICATIONTIME = att.NOTIFICATIONTIME;
                    //    ddl.UserId = att.UserId.ToString();
                    //    ddl.STUDENTID = att.STUDENTID.ToString();
                    //    ddl.STATUS = att.STATUS.ToString();
                    //    ddl.UserType = att.UserType;

                    //    lt.Add(ddl);




                    //}

                    if (lt == null)
                    {

                        return new Results
                        {
                            IsSuccess = false,
                            Message = "No Notifications Found"      
                        };

                  


                    }
                    else
                    {
                        return new DivisionListResult() { IsSuccess = true, HomeworkNotification = lt.OrderByDescending(r => Convert.ToDateTime(r.NOTIFICATIONDATE)).ToList() };


                    }
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



        public object ViewGeneralNotification(ParamNotificationView obj)
        {
            try
            {

                SchoolMainContext db = new ConcreateContext().GetContext(obj.userid, obj.password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                else
                {
                    var Notification = db.VIEWGENERALNOTIFICATIONs.Where(r => r.UserId == obj.userid).ToList().OrderByDescending(r => r.NOTIFICATIONID);
                    //var NotificationAll = db.VIEWALLNOTIFICATIONs.ToList().OrderByDescending(r => r.NOTIFICATIONID);
                    List<Result> lt = new List<Result>();

                    if (Notification.Count() != 0)
                    {
                        foreach (var att in Notification)
                        {

                            Result ddl = new Result();
                            ddl.TITLE = att.TITLE;
                            ddl.NOTIFICATIONID = att.NOTIFICATIONID;
                            ddl.NOTIFICATIONDATE = Convert.ToDateTime(att.NOTIFICATIONDATE);
                            ddl.NOTIFICATIONTIME = att.NOTIFICATIONTIME;
                            ddl.NOTIFICATIONTYPE = att.NOTIFICATIONTYPE;
                            ddl.UserId = att.UserId.ToString();
                            ddl.STUDENTID = att.STUDENTID.ToString();
                            ddl.STATUS = att.STATUS.ToString();
                            ddl.UserType = att.UserType;

                            lt.Add(ddl);




                        }
                    }

                    var getUserType = db.VW_GET_USER_TYPE.Where(r => r.UserId == obj.userid).FirstOrDefault();

                    var Notificationgen = db.VIEWNOTIFICATIONGENs.Where(r => r.ACADEMICYEAR == "2018-2019").ToList().OrderByDescending(r => r.NOTIFICATIONID);

                    if (Notificationgen.Count() != 0)
                    {
                        foreach (var att in Notificationgen)
                        {

                            Result ddl = new Result();
                            ddl.TITLE = att.TITLE;
                            ddl.NOTIFICATIONID = att.NOTIFICATIONID;
                            ddl.NOTIFICATIONDATE = Convert.ToDateTime(att.NOTIFICATIONDATE);
                            ddl.NOTIFICATIONTIME = att.NOTIFICATIONTIME;
                            ddl.NOTIFICATIONTYPE = att.NOTIFICATIONTYPE;
                            ddl.UserId = obj.userid.ToString();
                            ddl.STUDENTID = "";
                            ddl.STATUS ="";
                            ddl.UserType = getUserType.UserType;

                            lt.Add(ddl);




                        }
                    }


                    if (lt == null)
                    {

                        return new Results
                        {
                            IsSuccess = false,
                            Message = "No Notifications Found"
                        };




                    }
                    else
                    {
                        return new DivisionListResult() { IsSuccess = true, GeneralNotification = lt.OrderByDescending(r =>Convert.ToDateTime(r.NOTIFICATIONDATE)).ToList() };


                    }
                }
            }
            catch (Exception E)
            {

                return new Results
                {
                    IsSuccess = false,
                    Message = E.Message
                };


            }

        }



        public object ViewAllNotification(ParamNotificationView obj)
        {
            try
            {

                SchoolMainContext db = new ConcreateContext().GetContext(obj.userid, obj.password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                else
                {
                    List<Result> lt = new List<Result>();
                    var NotificationHome = db.VIEWNOTIFICATIONs.Where(r => r.UserId == obj.userid).ToList().OrderByDescending(r => r.NOTIFICATIONID);
                    //var NotificationAll = db.VIEWALLNOTIFICATIONs.ToList().OrderByDescending(r => r.NOTIFICATIONID);



                    foreach (var att in NotificationHome)
                    {

                        Result ddl = new Result();
                        ddl.TITLE = att.TITLE;
                        ddl.NOTIFICATIONID = att.NOTIFICATIONID;
                        ddl.NOTIFICATIONDATE = Convert.ToDateTime(att.NOTIFICATIONDATE);
                        ddl.NOTIFICATIONTIME = att.NOTIFICATIONTIME;
                        ddl.NOTIFICATIONTYPE = att.NOTIFICATIONTYPE;
                        ddl.UserId = att.UserId.ToString();
                        ddl.STUDENTID = att.STUDENTID.ToString();
                        ddl.STATUS = att.STATUS.ToString();
                        ddl.UserType = att.UserType;

                        lt.Add(ddl);




                    }

                    var Notification = db.VIEWGENERALNOTIFICATIONs.Where(r => r.UserId == obj.userid).ToList().OrderByDescending(r => r.NOTIFICATIONID);
                    //var NotificationAll = db.VIEWALLNOTIFICATIONs.ToList().OrderByDescending(r => r.NOTIFICATIONID);
                 

                    if (Notification.Count() != 0)
                    {
                        foreach (var att in Notification)
                        {

                            Result ddl = new Result();
                            ddl.TITLE = att.TITLE;
                            ddl.NOTIFICATIONID = att.NOTIFICATIONID;
                            ddl.NOTIFICATIONDATE = Convert.ToDateTime(att.NOTIFICATIONDATE);
                            ddl.NOTIFICATIONTIME = att.NOTIFICATIONTIME;
                            ddl.NOTIFICATIONTYPE = att.NOTIFICATIONTYPE;
                            ddl.UserId = att.UserId.ToString();
                            ddl.STUDENTID = att.STUDENTID.ToString();
                            ddl.STATUS = att.STATUS.ToString();
                            ddl.UserType = att.UserType;

                            lt.Add(ddl);




                        }
                    }

                    var getUserType = db.VW_GET_USER_TYPE.Where(r => r.UserId == obj.userid).FirstOrDefault();

                    var Notificationgen = db.VIEWNOTIFICATIONGENs.Where(r => r.ACADEMICYEAR == "2018-2019").ToList().OrderByDescending(r => r.NOTIFICATIONID);

                    if (Notificationgen.Count() != 0)
                    {
                        foreach (var att in Notificationgen)
                        {

                            Result ddl = new Result();
                            ddl.TITLE = att.TITLE;
                            ddl.NOTIFICATIONID = att.NOTIFICATIONID;
                            ddl.NOTIFICATIONDATE = Convert.ToDateTime(att.NOTIFICATIONDATE);
                            ddl.NOTIFICATIONTIME = att.NOTIFICATIONTIME;
                            ddl.NOTIFICATIONTYPE = att.NOTIFICATIONTYPE;
                            ddl.UserId = obj.userid.ToString();
                            ddl.STUDENTID = "";
                            ddl.STATUS = "";
                            ddl.UserType = getUserType.UserType;

                            lt.Add(ddl);




                        }
                    }




                 




                    if (lt == null)
                    {

                        return new Results
                        {
                            IsSuccess = false,
                            Message = "No Notifications Found"
                        };




                    }
                    else
                    {
                        return new DivisionListResult() { IsSuccess = true, AllNotification = lt.OrderByDescending(r => Convert.ToDateTime(r.NOTIFICATIONDATE)).ToList() };


                    }
                }
            }
            catch (Exception E)
            {

                return new Results
                {
                    IsSuccess = false,
                    Message = E.Message
                };


            }

        }

        public class Result
        {
            public string TITLE { get; set; }
            public Int64 NOTIFICATIONID { get; set; }

            public DateTime NOTIFICATIONDATE { get; set; }

            public string NOTIFICATIONTIME { get; set; }

            public string NOTIFICATIONTYPE { get; set; }
            public string UserId { get; set; }

            public string STUDENTID { get; set; }
            public string STATUS { get; set; }
            public string UserType { get; set; }
        }

        public object UpdateNotification(ParamNotificationUpdate obj)
        {
            try
            {

                SchoolMainContext db = new ConcreateContext().GetContext(obj.userid, obj.password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message  = "Invalid User" } ;
                }
                TBLNOTIFICATIONDETAIL objdetail = db.TBLNOTIFICATIONDETAILs.First(r => r.NOTIFICATIONID == obj.notificationid && r.STUDENTID == obj.studentid);

                objdetail.STATUS = obj.status;

                db.SaveChanges();

                return new DivisionListResult() { IsSuccess = true, Notification =  "Notification Updated successfully"   };


            

            }
            catch (Exception E)
            {
                return new Results
                {
                    IsSuccess = false,
                    Message =  E.Message  
                };
            }
        }


        public object SaveNotificationAll(ParamAllNotification objnote)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(objnote.userid, objnote.password);

                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message  = "Invalid User" } ;
                }
                TBLNOTIFICATION objmaster = new TBLNOTIFICATION();
                TBLNOTIFICATIONDETAIL objdetail = new TBLNOTIFICATIONDETAIL();

                objmaster.TITLE = objnote.Title;
                objmaster.NOTIFICATIONDATE = objnote.NotificationDate;
                objmaster.NOTIFICATIONTIME = objnote.Time;
                objmaster.ACADEMICYEAR = "2018-2019";
                objmaster.NOTIFICATIONTYPE = objnote.NotificationType;
                db.TBLNOTIFICATIONs.Add(objmaster);
                db.SaveChanges();

             


                return new DivisionListResult() { IsSuccess = true, Notification =  "Notification Saved successfully"   };

            }
            catch (Exception E)
            {
                return new Results
                {
                    IsSuccess = false,
                    Message =  E.Message  
                };
            }

        }


        public object ViewEventHoliday(ParamNotificationView obj)
        {
            try
            {

                SchoolMainContext db = new ConcreateContext().GetContext(obj.userid, obj.password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message  = "Invalid User" } ;
                }

                var EventHoliday = db.TBLHOLIDAYs.ToList().OrderByDescending(r => r.STARTDATE);

                if (EventHoliday == null)
                {

                    return new Results
                    {
                        IsSuccess = false,
                        Message = new InvalidUser() { IsSuccess = false, Result = " No Record Found" }   
                    };						    

                }
                else
                {
                    return new DivisionListResult() { IsSuccess = true, EventHolidayList = EventHoliday};
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




        public object ViewEventList(ParamNotificationView obj)
        {
            try
            {

                SchoolMainContext db = new ConcreateContext().GetContext(obj.userid, obj.password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }

                var Event = db.TBLNOTIFICATIONs.Where(r=>r.NOTIFICATIONTYPE=="News" && r.ACADEMICYEAR=="2018-2019").ToList().OrderByDescending(r => r.NOTIFICATIONDATE);

                if (Event == null)
                {

                    return new Results
                    {
                        IsSuccess = false,
                        Message = new InvalidUser() { IsSuccess = false, Result = " No Record Found" }
                    };

                }
                else
                {
                    return new DivisionListResult() { IsSuccess = true, EventNotification = Event };
                }
            }
            catch (Exception E)
            {
                return new Results
                {
                    IsSuccess = false,
                    Message = E.Message
                };


            }
        }

    }
}