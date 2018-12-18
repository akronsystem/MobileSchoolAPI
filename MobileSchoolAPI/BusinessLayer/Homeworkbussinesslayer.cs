using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;


namespace MobileSchoolAPI.BusinessLayer
{
    public class Homeworkbussinesslayer
    {
        
        public object Savehomework(homeworkparameters obj)
        {

            SchoolMainContext db = new ConcreateContext().GetContext(obj.Userid, obj.Password);
            TBLHOMEWORK objHomework = new TBLHOMEWORK();
            var getUserType = db.VW_GET_USER_TYPE.Where(r => r.UserId == obj.Userid).FirstOrDefault();
           
           
          
           
                objHomework.STANDARDID = int.Parse(obj.standardid);


                objHomework.CREATEDID = int.Parse(getUserType.EmpCode);
                objHomework.DIVISIONID = obj.division.ToString();
                objHomework.SUBJECTID = obj.subject;
                objHomework.TERMID = obj.term;
                objHomework.HOMEWORK = obj.homeworkdescription;
                objHomework.HOMEWORKDATE = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                objHomework.TIME = DateTime.Now.ToShortTimeString();
                objHomework.DISPLAY = 1;
                objHomework.ACADEMICYEAR = "2018-2019";

                db.TBLHOMEWORKs.Add(objHomework);
                db.SaveChanges();

                TBLNOTIFICATION objnotification = new TBLNOTIFICATION();
                objnotification.TITLE = obj.homeworkdescription;
                objnotification.NOTIFICATIONDATE = DateTime.Now;
                objnotification.NOTIFICATIONTIME = DateTime.Now.ToString("h:mm tt");
                objnotification.DIVISIONID = int.Parse(obj.division);
                objnotification.ACADEMICYEAR = "2018-2019";
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
                        return new Error();

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
							OBJPUSH.SendNotification("Homework", obj.homeworkdescription, device.DeviceId);
						}   

					    SMSSend(objHomework.HOMEWORK, getstudent[i].GMOBILE);
                    }
                }
                return new Results
                {

                    IsSuccess = true,
                    Message = "Homework assign successfully and SMS sent Sucessfully"
                };  

		}   

	public object SaveAttendance(AttendanceParameterscs atteobj)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(atteobj.Userid, atteobj.Password);
            TBLATTENDENCEMASTER objmster = new TBLATTENDENCEMASTER();
            TBLATTENDENCE objDetail = new TBLATTENDENCE();


            var checkatt = db.Vw_ATTENDANCECHECK.FirstOrDefault(r => r.DIVISIONID == atteobj.DIVISIONID && r.ATTEDANCEDATE == atteobj.ATTEDANCEDATE);
            //Duplicate Attendance Check
            if (checkatt == null)
            {

                try
                {

                    objmster.ATTEDANCEDATE = atteobj.ATTEDANCEDATE;

                    objmster.DIVISIONID = atteobj.DIVISIONID;
                    objmster.DISPLAY = 1;
                    objmster.EDUCATIONYEAR = "2018-2019";
                    var std = db.vw_FETCHSTANDARDBYDIVISION.Where(r => r.DIVISIONID == atteobj.DIVISIONID && r.DISPLAY == 1 && r.ACADEMICYEAR == "2018-2019").ToList();

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

                        TBLNOTIFICATIONDETAIL objnotidetails = new TBLNOTIFICATIONDETAIL();
                       // objnotidetails.NOTIFICATIONID = objnotification.NOTIFICATIONID;
                       // objnotidetails.STUDENTID = getstudent[0].STUDENTID;
                       // objnotidetails.STATUS = 0;
                       // db.TBLNOTIFICATIONDETAILs.Add(objnotidetails);
                       //  db.SaveChanges();
                    }

                    return new Results
                    {
                        IsSuccess = true,
                        Message = "Attendance Save successfully"
                    };
                }
                catch (Exception e)
                {
                    return new Error() { IsError = true, Message = e.Message };
                }


            }

            return new Results
            {
                IsSuccess = false,
                Message = "Attedance already taken for this Date "
            };



        }
		    
			 

        public bool SMSSend(string sms,string mobileno)
        {
            try
            {
               
                string str = "";
               
                str = "http://smsnow.hundiainfosys.com/rest/services/sendSMS/sendGroupSms?AUTH_KEY=7ddc928fc86d2e3adf01010536830d2&message=" + sms + "&senderId=SFNKVS&routeId=1&mobileNos=" + mobileno + "&smsContentType=english";

                //HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(str);

                //HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                //System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                //string responseString = respStreamReader.ReadToEnd();
                //respStreamReader.Close();
                //myResp.Close();

                return true;
            }
            catch
            {
                throw;
                return false;
            }
        }
        public object FileUpload(homeworkparameters obj)
        {
            int Userid = Convert.ToInt32(HttpContext.Current.Request["Userid"]);
            var Password = HttpContext.Current.Request["Password"];
            SchoolMainContext db = new ConcreateContext().GetContext(Userid, Password);
            var getUserType = db.VW_GET_USER_TYPE.Where(r => r.UserId == Userid).FirstOrDefault();
            //if (!Request.Content.IsMimeMultipartContent())
            //{
            //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //}
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                   string UploadBaseUrl = ConfigurationManager.AppSettings["UploadBaseURL"];
                    string fileName = string.Empty;
                    var filePath = string.Empty;
                    string savePath = string.Empty;
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        fileName = postedFile.FileName;
                        filePath = ConfigurationManager.AppSettings["UploadDir"] + Guid.NewGuid() + fileName;
                        savePath = HttpContext.Current.Server.MapPath(filePath); postedFile.SaveAs(savePath); // NOTE: To store in memory use postedFile.InputStream }
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
                        upload.ACADEMICYEAR = "2018-2019";

                        upload.FILEPATH = UploadBaseUrl + filePath.Replace("~/","");

						//upload.insert_date = DateTime.Now;
						db.TBLHOMEWORKs.Add(upload);
                        db.SaveChanges();

                        return upload;
                    }

                    return new Error { IsError = true, Message = "Failed to upload File" };
                }
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = "Failed to upload File" }
            ;
            }


            return null;
        }


    }
}