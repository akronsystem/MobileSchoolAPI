using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class Homeworkbussinesslayer
    {
        SchoolContext db = new SchoolContext();
        public object Savehomework(homeworkparameters obj)
        {
           

            TBLHOMEWORK objHomework = new TBLHOMEWORK();
            
          //  objHomework.STANDARDID = obj.standard;
        
            objHomework.DIVISIONID =obj.division;
            objHomework.SUBJECTID = obj.subject;
            objHomework.TERMID = obj.term;
            objHomework.HOMEWORK =obj.homeworkdescription;
            objHomework.HOMEWORKDATE = DateTime.Now;
            objHomework.DISPLAY = 1;
            objHomework.ACADEMICYEAR = "2018-2019";

            db.TBLHOMEWORKs.Add(objHomework);
            db.SaveChanges(); 

            TBLNOTIFICATION objnotification = new TBLNOTIFICATION();
            objnotification.TITLE = obj.homeworkdescription;
            objnotification.NOTIFICATIONDATE = DateTime.Now;
            objnotification.NOTIFICATIONTIME = DateTime.Now.ToString("h:mm tt");
            objnotification.DIVISIONID =int.Parse(obj.division);
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
                    SMSSend(objHomework.HOMEWORK, getstudent[i].GMOBILE);
                }
            }
            return "sms send successfully";
            
        }
        public object SaveAttendance(AttendanceParameterscs atteobj)
        {
			TBLATTENDENCEMASTER objmster = new TBLATTENDENCEMASTER();
            TBLATTENDENCE objDetail = new TBLATTENDENCE();


            var checkatt = db.Vw_ATTENDANCECHECK.FirstOrDefault(r => r.DIVISIONID == atteobj.DIVISIONID && r.ATTEDANCEDATE == atteobj.ATTEDANCEDATE);
            //Duplicate Attendance Check
            if (checkatt== null)
            {

                objmster.ATTEDANCEDATE = atteobj.ATTEDANCEDATE;

                objmster.DIVISIONID = atteobj.DIVISIONID;
                objmster.DISPLAY = 1;
                objmster.EDUCATIONYEAR = "2018-2019";
                var std = db.vw_FETCHSTANDARDBYDIVISION.Where(r => r.DIVISIONID == atteobj.DIVISIONID && r.DISPLAY == 1 && r.ACADEMICYEAR == "2018-2019").ToList();

                objmster.STANDARDID =Convert.ToInt32( std[0].STANDARDID);
                objmster.CREATEDON = DateTime.Now;

                objmster.CREATEDID = atteobj.Userid;

                db.TBLATTENDENCEMASTERs.Add(objmster);
                db.SaveChanges();


                string absentno = atteobj.Absentno;
                string[] sbno = absentno.Split(',');
                objDetail.ATTEDANCEMID = objmster.ATTEDANCEMID;
                for (int i = 0; i < sbno.Count(); i++)
                {
                    string abno = sbno[i].ToString();

                    int rollno = Convert.ToInt32(abno);

                    var getstudent = db.VIEWGETSTUDENTATTs.Where(r => r.DIVISIONID == atteobj.DIVISIONID && r.ROLL_NO == rollno).ToList();
                    objDetail.ATTEDANCEMID = objmster.ATTEDANCEMID;
                    objDetail.ROLLNO = sbno[i].ToString();
                    objDetail.NAME = getstudent[0].STUDENTNAME;
                    objDetail.STUDENTID = getstudent[0].STUDENTID;
                    objDetail.STATUS = "A";

                    db.TBLATTENDENCEs.Add(objDetail);
                    db.SaveChanges();

                    return new Results
                    {
                        IsSuccess = true,
                        Message = "Attendance Save successfully"
                    };
                }
            }
            
                return new Results
                {
                    IsSuccess=false,
                    Message = "Attedance already taken for this Date "
                };
 

          
        }

        internal void Students()
        {
            throw new NotImplementedException();
        }

        //public object StudentsMethod(StudentForSms obj)
        //{
        //    TBLHOMEWORK objHomework = new TBLHOMEWORK();
        //    var getstudent = db.VIEWGETSTUDENTATTs.Where(r => r.STANDARDID == obj.STANDARDID && r.DIVISIONID == obj.DIVISIONID).ToList();
        //    if (getstudent == null)
        //    {
        //        return new Error();
                
        //    }
        //    // return getstudent;
        //    for (int i = 0; i < getstudent.Count; i++)
        //    {
        //        SMSSend(objHomework.HOMEWORK, getstudent[i].Gmobile);
        //    }
        //    return "sms send successfully";
        

        //}

        private void SMSSend(string hOMEWORK, object gMOBILE)
        {
            throw new NotImplementedException();
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


    }
}