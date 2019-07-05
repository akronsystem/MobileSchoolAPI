using MobileSchoolAPI.Models;
using MobileSchoolAPI.ResultModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

using Newtonsoft.Json;

namespace MobileSchoolAPI.BusinessLayer
{
    public class Homeworkbussinesslayer
    {
        string smsstatus = ConfigurationManager.AppSettings["SmsStatus"].ToString();
        public object Savehomework(homeworkparameters obj)
        {

            SchoolMainContext db = new ConcreateContext().GetContext(obj.Userid, obj.Password);
            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            TBLHOMEWORK objHomework = new TBLHOMEWORK();
            var getUserType = db.VW_GET_USER_TYPE.Where(r => r.UserId == obj.Userid).FirstOrDefault();

            var AcadamicYear = db.View_GETACADEMICYEAR.FirstOrDefault();
            if (AcadamicYear == null)
            {
                return new Results
                {
                    IsSuccess = false,
                    Message = "Not Found Academic Year"
                };
            }


            objHomework.STANDARDID = int.Parse(obj.standardid);


            objHomework.CREATEDID = int.Parse(getUserType.EmpCode);
            objHomework.DIVISIONID = obj.division.ToString();
            objHomework.SUBJECTID = obj.subject;
            objHomework.TERMID = obj.term;
            objHomework.HOMEWORK = obj.homeworkdescription;
            objHomework.HOMEWORKDATE = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            objHomework.TIME = DateTime.Now.ToShortTimeString();
            objHomework.DISPLAY = 1;
            objHomework.ACADEMICYEAR = AcadamicYear.ACADEMICYEAR;

            db.TBLHOMEWORKs.Add(objHomework);
            db.SaveChanges();

            TBLNOTIFICATION objnotification = new TBLNOTIFICATION();
            objnotification.TITLE = obj.homeworkdescription;
            objnotification.NOTIFICATIONDATE = DateTime.Now;
            objnotification.NOTIFICATIONTIME = DateTime.Now.ToString("h:mm tt");
            objnotification.DIVISIONID = int.Parse(obj.division);
            objnotification.ACADEMICYEAR = AcadamicYear.ACADEMICYEAR;
            objnotification.NOTIFICATIONTYPE = "Homework";
            db.TBLNOTIFICATIONs.Add(objnotification);
            db.SaveChanges();


            string[] divid = objHomework.DIVISIONID.ToString().Split(',');
            for (int d = 0; d < divid.Length; d++)
            {
                int singledivision = Convert.ToInt32(divid[d]);
                var getstudent = db.VIEWGETSTUDENTATTs.Where(r => r.DIVISIONID == singledivision).ToList();

                if (getstudent == null)
                {

                    return new Results
                    {
                        IsSuccess = false,
                        Message = "Student Not Found"
                    };



                }
                // return getstudent;
                for (int i = 0; i < getstudent.Count; i++)
                {
                    TBLNOTIFICATIONDETAIL objnotidetails = new TBLNOTIFICATIONDETAIL();
                    objnotidetails.NOTIFICATIONID = objnotification.NOTIFICATIONID;
                    objnotidetails.STUDENTID = getstudent[i].STUDENTID;
                    objnotidetails.STATUS = 0;
                    db.TBLNOTIFICATIONDETAILs.Add(objnotidetails);
                    db.SaveChanges();
                    FCMPushNotification OBJPUSH = new FCMPushNotification();
                    //var getsubjectname = db.VIEWSUBJECTNAMEs.Where(r => r.SUBJECTID == obj.subject).ToList();

                    string studentid = Convert.ToString(getstudent[i].STUDENTID);
                    var userid = db.VIEWGETUSERIDFROMEMPCODEs.Where(r => r.EmpCode == studentid).FirstOrDefault();
                    var device = db.VW_DEVICE.FirstOrDefault(r => r.UserId == userid.UserId);
                    if (device != null)
                    {
                        if (!string.IsNullOrWhiteSpace(device.DeviceId))
                            OBJPUSH.SendNotification("Homework", obj.homeworkdescription, device.DeviceId);
                    }
                    //if (smsstatus == "1")
                    //{
                    //    SMSSendTESTDLR(getstudent[i].GMOBILE, objHomework.HOMEWORK);
                    //}
                }
            }
            return new Results
            {

                IsSuccess = true,
                Message = "Homework Assigned Successfully!"
            };

        }

        public object SendNotificaiton(homeworkparameters obj)
        {

            SchoolMainContext db = new ConcreateContext().GetContext(obj.Userid, obj.Password);
            if (db == null)
            {


                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            var device = db.VW_DEVICE.FirstOrDefault(r => r.UserId == obj.Userid);
            if (device != null)
            {
                FCMPushNotification OBJPUSH = new FCMPushNotification();
                return OBJPUSH.SendNotification("Homework", obj.homeworkdescription, device.DeviceId);
            }

            throw new Exception("Notification Failed");

        }

        public object SaveAttendance(AttendanceParameterscs atteobj)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(atteobj.Userid, atteobj.Password);
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
            TBLATTENDENCEMASTER objmster = new TBLATTENDENCEMASTER();
            TBLATTENDENCE objDetail = new TBLATTENDENCE();
            var logindetail = db.TBLUSERLOGINs.
                                Where(r => r.UserId == atteobj.Userid && r.Password == atteobj.Password && r.STATUS == "ACTIVE")
                                .FirstOrDefault();

            var ClassTeacherCheck = db.TBLASSIGNCLASSTEACHERs.Where(r => r.DIVISIONID == atteobj.DIVISIONID && r.ACADEMICYEAR == AcadamicYear.ACADEMICYEAR && r.DISPLAY == 1).ToList();
            if (ClassTeacherCheck.Count != 0)
            {
                var checkatt = db.Vw_ATTENDANCECHECK.FirstOrDefault(r => r.DIVISIONID == atteobj.DIVISIONID && r.ATTEDANCEDATE == atteobj.ATTEDANCEDATE);
                //Duplicate Attendance Check
                if (checkatt == null)
                {

                    try
                    {

                        objmster.ATTEDANCEDATE = atteobj.ATTEDANCEDATE;

                        objmster.DIVISIONID = atteobj.DIVISIONID;
                        objmster.DISPLAY = 1;
                        objmster.EDUCATIONYEAR = AcadamicYear.ACADEMICYEAR;
                        var std = db.vw_FETCHSTANDARDBYDIVISION.Where(r => r.DIVISIONID == atteobj.DIVISIONID && r.DISPLAY == 1 && r.ACADEMICYEAR == AcadamicYear.ACADEMICYEAR).ToList();

                        objmster.STANDARDID = Convert.ToInt32(std[0].STANDARDID);
                        objmster.CREATEDON = DateTime.Now;

                        objmster.CREATEDID = atteobj.Userid;

                        db.TBLATTENDENCEMASTERs.Add(objmster);
                        db.SaveChanges();


                        //TBLNOTIFICATION objnotification = new TBLNOTIFICATION();
                        //objnotification.TITLE = "Daily Attendance";
                        //objnotification.NOTIFICATIONDATE = DateTime.Now;
                        //objnotification.NOTIFICATIONTIME = DateTime.Now.ToString("h:mm tt");
                        //objnotification.DIVISIONID = atteobj.DIVISIONID;
                        //objnotification.ACADEMICYEAR = "2018-2019";
                        //objnotification.NOTIFICATIONTYPE = "Attendance";
                        //db.TBLNOTIFICATIONs.Add(objnotification);
                        //db.SaveChanges();

                        string absentno = atteobj.Absentno;
                        if (absentno != "")
                        {
                            string[] sbno = absentno.Split(',');

                            objDetail.ATTEDANCEMID = objmster.ATTEDANCEMID;
                            for (int i = 0; i < sbno.Length; i++)
                            {

                                string abno = sbno[i].ToString();

                                int rollno = Convert.ToInt32(abno);

                                var getstudent = db.VIEWGETSTUDENTATTs.Where(r => r.DIVISIONID == atteobj.DIVISIONID && r.ROLL_NO == rollno).ToList();
                                if (getstudent.Count == 0)
                                {
                                    return new Results() { IsSuccess = false, Message = "No students found for this division " };

                                }
                                objDetail.ATTEDANCEMID = objmster.ATTEDANCEMID;
                                objDetail.ROLLNO = sbno[i].ToString();
                                objDetail.NAME = getstudent[0].STUDENTNAME;
                                objDetail.STUDENTID = getstudent[0].STUDENTID;

                                objDetail.STATUS = "A";

                                db.TBLATTENDENCEs.Add(objDetail);
                                db.SaveChanges();
                                string[] splitname = getstudent[0].STUDENTNAME.Split(' ');
                                TBLNOTIFICATIONDETAIL objnotidetails = new TBLNOTIFICATIONDETAIL();
                                string str = "";
                                if (logindetail.UserName.StartsWith("NKV"))
                                {
                                    str = "goo.gl/NsoiKY";
                                }
                                else if (logindetail.UserName.StartsWith("SXS"))
                                {
                                    str = "goo.gl/zotf13";
                                }
                                else if (logindetail.UserName.StartsWith("ASM"))
                                {
                                    str = "goo.gl/9vNiX8";
                                }

                                else if (logindetail.UserName.StartsWith("ASY"))
                                {
                                    str = "goo.gl/SNtreT";
                                }
                                else if (logindetail.UserName.StartsWith("NMS"))
                                {
                                    str = "goo.gl/j7XjCx";
                                }
                                string txtMessage = "Dear Parent, Your Pupil " + splitname[1] + ", is absent on " + Convert.ToDateTime(atteobj.ATTEDANCEDATE).ToString("dd/MM/yyyy") + ", Kindly note. See attendance details " + str;


                                if (smsstatus == "1")
                                {
                                    /* uncomment on final launch */
                                    string responseString = SMSSendTESTDLR(getstudent[0].GMOBILE, txtMessage, logindetail.UserName);
                                    if (responseString != "")
                                    {
                                        // var jObject = JObject.Parse(responseString);
                                        //var response = jObject["response"].ToString();
                                        string RequestId = getRequestID(responseString);
                                        TBLMSGHISTORY smshist = new TBLMSGHISTORY();
                                        smshist.DATE = DateTime.Now;
                                        smshist.TIME = DateTime.Now.ToShortTimeString();
                                        smshist.MSG = txtMessage;
                                        smshist.TYPE = "ATT";
                                        smshist.CREATEDID = atteobj.Userid;
                                        smshist.DISPLAY = 1;
                                        smshist.STUDENTID = getstudent[0].STUDENTID;
                                        smshist.FROMEMPID = Convert.ToInt64(logindetail.EmpCode);
                                        smshist.STATUS = "Out";
                                        smshist.InStatus = "In";
                                        smshist.OutStatus = "Out";
                                        smshist.REQUESTID = RequestId;
                                        smshist.EMPLOYEEID = 0;
                                        smshist.TOEMPID = "0";
                                        smshist.ATTACHMENTS = "";
                                        smshist.SUBJECT = "";
                                        smshist.OtherNos = "";
                                        smshist.ALUMNIID = 0;
                                        db.TBLMSGHISTORies.Add(smshist);
                                        db.SaveChanges();

                                    }


                                }



                                //TBLNOTIFICATIONDETAIL objnotidetails = new TBLNOTIFICATIONDETAIL();

                                FCMPushNotification OBJPUSH = new FCMPushNotification();
                                //var getsubjectname = db.VIEWSUBJECTNAMEs.Where(r => r.SUBJECTID == obj.subject).ToList();

                                string studentid = Convert.ToString(getstudent[0].STUDENTID);
                                var userid = db.VIEWGETUSERIDFROMEMPCODEs.Where(r => r.EmpCode == studentid).FirstOrDefault();
                                var device = db.VW_DEVICE.FirstOrDefault(r => r.UserId == userid.UserId);
                                if (device != null)
                                {
                                    if (!string.IsNullOrWhiteSpace(device.DeviceId))
                                        OBJPUSH.SendNotification("Attendance", string.Format("Dear Parent, Your pupil is absent on dated {0}, kindly note.", objmster.ATTEDANCEDATE.Value.ToString("dd-MM-yyyy")), device.DeviceId);
                                }
                            }

                        }
                        return new Results
                        {
                            IsSuccess = true,
                            Message = "Attendance Saved Successfully!"
                        };

                    }

                    catch (Exception e)
                    {

                        return new Results
                        {
                            IsSuccess = false,
                            Message = e.Message
                        };

                    }


                }


                return new Results
                {
                    IsSuccess = false,
                    Message = "Attedance already taken for this Date"
                };

            }
            return new Results
            {
                IsSuccess = false,
                Message = "Class teacher is not assign to this division"
            };

        }



        public string SMSSendTESTDLR(string MobileNo, string Message, string UserName)
        {
            try
            {

                string str = ""; string responseString = "";


                if (UserName.StartsWith("NKV"))
                {
                    str = "http://sms.akronsystems.com/vendorsms/pushsms.aspx?user=nkvschool&password=Server@7&msisdn=" + MobileNo + "&sid=SFNKVS&msg=" + Message + "&fl=0&gwid=2";


                }
                else if (UserName.StartsWith("SXS"))
                {
                    str = "http://sms.akronsystems.com/vendorsms/pushsms.aspx?user=xavier&password=Server@7&msisdn=" + MobileNo + "&sid=XAVIER&msg=" + Message + "&fl=0&gwid=2";

                    //str = "http://smsnow.hundiainfosys.com/rest/services/sendSMS/sendGroupSms?AUTH_KEY=3555f03e24952528d1acba2e3f2e4749&message=" + Message + "&senderId=XAVIER&routeId=1&mobileNos=" + MobileNo + "&smsContentType=english";

                }
                else if (UserName.StartsWith("ASM"))
                {
                    str = "http://sms.akronsystems.com/vendorsms/pushsms.aspx?user=asmmiraj&password=Server@7&msisdn=" + MobileNo + "&sid=ALPHOS&msg=" + Message + "&fl=0&gwid=2";
                    //str = "http://smsnow.hundiainfosys.com/rest/services/sendSMS/sendGroupSms?AUTH_KEY=b963a0f8db5c6b3478df79dee5e5842e&message=" + Message + "&senderId=ALPHOS&routeId=1&mobileNos=" + MobileNo + "&smsContentType=english";
                }

                else if (UserName.StartsWith("ASY"))
                {
                    str = "http://sms.akronsystems.com/vendorsms/pushsms.aspx?user=asyich&password=Server@7&msisdn=" + MobileNo + "&sid=ALPHON&msg=" + Message + "&fl=0&gwid=2";

                    //str = "http://www.smsidea.co.in/sendsms.aspx?mobile=9923990000&pass=PKIGG&senderid=ALPHON&to=" + MobileNo + "&msg=" + Message + "";

                }
                else if (UserName.StartsWith("NMS"))
                {
                    str = "http://sms.akronsystems.com/vendorsms/pushsms.aspx?user=nnskop&password=Server@7&msisdn=" + MobileNo + "&sid=NMSKOP&msg=" + Message + "&fl=0&gwid=2";

                    //str = "http://smsnow.hundiainfosys.com/rest/services/sendSMS/sendGroupSms?AUTH_KEY=14c07610595093f4d66e18f1aac5ee88&message=" + Message + "&senderId=NMSKOP&routeId=1&mobileNos=" + MobileNo + "&smsContentType=english";

                }
                if (str != "")
                {
                    HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(str);
                    HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                    System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                    responseString = respStreamReader.ReadToEnd();
                    respStreamReader.Close();
                    myResp.Close();
                }
                return responseString;
            }
            catch
            {
                return "";
            }
        }
        public class ResponseData
        {
            public List<MessageData> MessageData { get; set; }
        }
        public class MessageData
        {
            public List<MessageParts> MessageParts { get; set; }
        }
        public class MessageParts
        {
            public string MsgId { get; set; }

        }
        public string getRequestID(string responseString)
        {
            string MsgID = "";
            // string responseString = @"{""ErrorCode"":""000"",""ErrorMessage"":""Success"",""JobId"":""3368673"",""MessageData"":[{""Number"":""919158704048"",""MessageParts"":[{""MsgId"":""919158704048 - 7a17b74a1ba2467cae04db7c310d1629"",""PartId"":1,""Text"":""Test SMS from Akron""}]}]}";
            var myModel = JsonConvert.DeserializeObject<ResponseData>(responseString);
            foreach (var fac in myModel.MessageData)
            {
                foreach (var fc in fac.MessageParts)
                {
                    MsgID = fc.MsgId;
                }
            }
            return MsgID;
        }
        public object FileUpload(homeworkparameters obj)
        {
            int Userid = Convert.ToInt32(HttpContext.Current.Request["Userid"]);
            var Password = HttpContext.Current.Request["Password"];
            SchoolMainContext db = new ConcreateContext().GetContext(Userid, Password);
            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            var logindetail = db.TBLUSERLOGINs.
                              Where(r => r.UserId == Userid && r.Password == Password && r.STATUS == "ACTIVE")
                              .FirstOrDefault();
            var getUserType = db.VW_GET_USER_TYPE.Where(r => r.UserId == Userid).FirstOrDefault();
            //if (!Request.Content.IsMimeMultipartContent())
            //{
            //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //}
            try
            {
                string UploadBaseUrl = "";
                var httpRequest = HttpContext.Current.Request;
                var AcadamicYear = db.View_GETACADEMICYEAR.FirstOrDefault();
                if(AcadamicYear==null)
                {
                    return new Results
                    {
                        IsSuccess = false,
                        Message = "Not Found Academic Year"
                    };
                }
                if (httpRequest.Files.Count > 0)
                {
                    if (logindetail.UserName.StartsWith("NKV"))
                    {

                        UploadBaseUrl = ConfigurationManager.AppSettings["NkvsBaseUrl"];
                    }
                    else if (logindetail.UserName.StartsWith("SXS"))
                    {
                        UploadBaseUrl = ConfigurationManager.AppSettings["StxavierBaseUrl"];
                    }
                    else if (logindetail.UserName.StartsWith("ASM"))
                    {
                        UploadBaseUrl = ConfigurationManager.AppSettings["AsmBaseUrl"];
 
                    }

                    else if (logindetail.UserName.StartsWith("ASY"))
                    {

                        UploadBaseUrl = ConfigurationManager.AppSettings["AsyBaseUrl"];
                    }
                    else if (logindetail.UserName.StartsWith("NMS"))
                    {
                        UploadBaseUrl = ConfigurationManager.AppSettings["NmsBaseUrl"];
 
                    }
                    string fileName = string.Empty;
                    var filePath = string.Empty;
                    string savePath = string.Empty;
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        fileName = postedFile.FileName;
                        filePath = ConfigurationManager.AppSettings["UploadDir"] + Guid.NewGuid() + fileName;
                        savePath = HttpContext.Current.Server.MapPath(filePath); //postedFile.SaveAs(savePath); // NOTE: To store in memory use postedFile.InputStream }
                        TBLHOMEWORK upload = new TBLHOMEWORK();
                        //upload.file_id = Guid.NewGuid().ToString();
                        //upload.name = fileName;

                        upload.STANDARDID = Convert.ToInt32(HttpContext.Current.Request["standardid"]);
                        upload.CREATEDID = int.Parse(getUserType.EmpCode);
                        upload.DIVISIONID = HttpContext.Current.Request["division"];
                        upload.SUBJECTID = Convert.ToInt32(HttpContext.Current.Request["subject"]);
                        upload.TERMID = Convert.ToInt32(HttpContext.Current.Request["term"]);
                        upload.HOMEWORK = HttpContext.Current.Request["homeworkdescription"];
                        upload.HOMEWORKDATE = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        upload.TIME = DateTime.Now.ToShortTimeString();
                        upload.DISPLAY = 1;
                        upload.ACADEMICYEAR = AcadamicYear.ACADEMICYEAR;

                        upload.FILEPATH = UploadBaseUrl + filePath.Replace("~/", "");

                        //upload.insert_date = DateTime.Now;
                        db.TBLHOMEWORKs.Add(upload);
                        db.SaveChanges();

                        return new Results
                        {
                            IsSuccess = true,
                            Message = "HomeWork Save Successfully"
                        };
                    }

                    return new Results
                    {
                        IsSuccess = false,
                        Message = "Failed to upload File"
                    };



                }
                else
                {
                    TBLHOMEWORK upload = new TBLHOMEWORK();
                    //upload.file_id = Guid.NewGuid().ToString();
                    //upload.name = fileName;

                    upload.STANDARDID = Convert.ToInt32(HttpContext.Current.Request["standardid"]);
                    upload.CREATEDID = int.Parse(getUserType.EmpCode);
                    upload.DIVISIONID = HttpContext.Current.Request["division"];
                    upload.SUBJECTID = Convert.ToInt32(HttpContext.Current.Request["subject"]);
                    upload.TERMID = Convert.ToInt32(HttpContext.Current.Request["term"]);
                    upload.HOMEWORK = HttpContext.Current.Request["homeworkdescription"];
                    upload.HOMEWORKDATE = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    upload.TIME = DateTime.Now.ToShortTimeString();
                    upload.DISPLAY = 1;
                    upload.ACADEMICYEAR = AcadamicYear.ACADEMICYEAR;

                    upload.FILEPATH = null;

                    //upload.insert_date = DateTime.Now;
                    db.TBLHOMEWORKs.Add(upload);
                    db.SaveChanges();

                    return new Results
                    {
                        IsSuccess = true,
                        Message = "HomeWork Save Successfully"
                    };
                }
            }
            catch (Exception ex)
            {
                return new Results
                {
                    IsSuccess = false,
                    Message = ex.ToString()
                };
            }


           
        }


    }
}