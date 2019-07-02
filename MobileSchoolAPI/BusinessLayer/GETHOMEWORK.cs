using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileSchoolAPI.Controllers;
using MobileSchoolAPI.ResultModel;
using System.Configuration;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GETHOMEWORK
    {
      

        //public object GetHomework(PARAMHOMEWORK obj)
        //{
        //    try
        //    {
        //        SchoolMainContext db = new ConcreateContext().GetContext(obj.user, obj.PASSWORD);
        //        var homework = db.VIEWHOMEWORKs.Where(r => r.STANDARDID == obj.standardid && r.DIVISIONID == obj.divisionid && r.DISPLAY == 1 && r.ACADEMICYEAR == "2018-2019").

        //                             FirstOrDefault();

        //        if (homework == null)
        //        {
        //            return new Error() { IsError = true, Message = "Homework not found" };
        //        }
        //        else
        //        {
        //            return homework;
        //        }

        //    }
        //    catch (Exception E)
        //    {
        //        return new Error() { IsError = true, Message = E.Message };
        //    }

        //}



        public Object GetStandard(PARAMSTD obj)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(obj.USERID, obj.PASSWORD);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }

                var GETTYPE = db.VW_GET_USER_TYPE.Where(r => r.UserId == obj.USERID).ToList();
                var AcadamicYear = db.View_GETACADEMICYEAR.FirstOrDefault();
                if (AcadamicYear == null)
                {
                    return new Results
                    {
                        IsSuccess = false,
                        Message = "Not Found Academic Year"
                    };
                }
                if (GETTYPE[0].UserType != "STUDENT")
                {
                    var Division = db.VIEWDIVISIONLISTs.Where(r => r.STANDARDID == obj.STANDARDID && r.UserId == obj.USERID && r.ACADEMICYEAR==AcadamicYear.ACADEMICYEAR).ToList();

                    if (Division.Count==0)
                    {
                        return new Results
                        {
                            IsSuccess = false,
                            Message =  "Division Not Found"     
                        };

                       
                    }
                    else
                    {
                        return new DivisionListResult() { IsSuccess = true, DivisionListByUser = Division };
                     
                    }
                }
                else
                {
                    var Division = db.VIEWDIVISIONLISTBYSTUDENTs.Where(r => r.STANDARDID == obj.STANDARDID && r.UserId == obj.USERID && r.ACADEMICYEAR==AcadamicYear.ACADEMICYEAR).ToList();

                    if (Division.Count == 0)
                    {
                        return new Results
                        {
                            IsSuccess = false,
                            Message =  "Division Not Found" 
                        };

                       
                    }
                    else
                    {
                        return new DivisionListResult() { IsSuccess = true, DivisionListByUser = Division };

                       
                    }
                }

               
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

        //internal object ViewHomeWorkbyUser(PARAMHOMEWORKBYUSER objhome)
        //{
        //    throw new NotImplementedException();
        //}

        //public object GetStdByEmp(PARAMEMP emp)
        //{
        //    try
        //    {
        //        var Division = db.VIEWDIVISIONLISTBYEMPs.Where(r => r.EMPLOYEEID == emp.EmployeeId);

        //        if (Division == null)
        //        {
        //            return new Error() { IsError = true, Message = "Division Not Found" };
        //        }
        //        else
        //        {
        //            return Division;
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        return new Error() { IsError = true, Message = E.Message };

        //    }
        //}


        public object ViewHomeWorkbyUser(ParamHOMEWORKBYUSER obj)
        {
            try
            {

                SchoolMainContext db = new ConcreateContext().GetContext(obj.userid, obj.password);
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
                var EmpHomework = db.VIEWHOMEWORKs.Where(r => r.UserId == obj.userid && r.HMMONTH==obj.Month && r.ACADEMICYEAR==AcadamicYear.ACADEMICYEAR)
					.OrderByDescending(r => r.HOMEWORKDATE).OrderByDescending(r=>r.HOMEWORKID).ToList(); ;
                string UploadBaseUrl = "";
                var logindetail = db.TBLUSERLOGINs.
                             Where(r => r.UserId == obj.userid && r.Password == obj.password && r.STATUS == "ACTIVE")
                             .FirstOrDefault();

                if (logindetail.UserName.StartsWith("NKV"))
                {
                    UploadBaseUrl = ConfigurationManager.AppSettings["NkvsBaseUrlUpload"];
                }
                else if (logindetail.UserName.StartsWith("SXS"))
                {
                    UploadBaseUrl = ConfigurationManager.AppSettings["StxavierBaseUrlUpload"];
                }
                else if (logindetail.UserName.StartsWith("ASM"))
                {
                    UploadBaseUrl = ConfigurationManager.AppSettings["AsmBaseUrlUpload"];
                }

                else if (logindetail.UserName.StartsWith("ASY"))
                {
                    UploadBaseUrl = ConfigurationManager.AppSettings["AsyBaseUrlUpload"];
                }
                else if (logindetail.UserName.StartsWith("NMS"))
                {
                    UploadBaseUrl = ConfigurationManager.AppSettings["NmsBaseUrlUpload"];
                }

                List<ResultSet> Res = new List<ResultSet>();

                if (EmpHomework.Count() == 0)
                {
                    var StudentHomework = db.VIEWSTUDENTHOMEWORKs.Where(r => r.UserId == obj.userid && r.HMMONTH == obj.Month && r.ACADEMICYEAR==AcadamicYear.ACADEMICYEAR).
						OrderByDescending(r => r.HOMEWORKDATE).OrderByDescending(r=>r.HOMEWORKID).ToList(); ;

                    if (StudentHomework.Count() == 0)
                    {

                        return new Results
                        {
                            IsSuccess = false,
                            Message = "Homework Not Found"  
                        };
                      
                    }
                    else
                    {

                        for (int i = 0; i < StudentHomework.Count; i++)
                        {
                            ResultSet rs = new ResultSet();
                            rs.UserId = StudentHomework[i].UserId;
                            rs.UserType = StudentHomework[i].UserType;
                            rs.HOMEWORKID = StudentHomework[i].HOMEWORKID;
                            rs.HOMEWORKDATE = Convert.ToDateTime(StudentHomework[i].HOMEWORKDATE);
                            rs.TIME = StudentHomework[i].TIME;
                            rs.STANDARDID = Convert.ToInt32(StudentHomework[i].STANDARDID);
                            rs.DIVISIONID = Convert.ToInt32(StudentHomework[i].DIVISIONID);
                            rs.HOMEWORK = StudentHomework[i].HOMEWORK;
                            rs.ACADEMICYEAR = StudentHomework[i].ACADEMICYEAR;
                            if(StudentHomework[i].FILEPATH!="")
                            {
                                rs.FILEPATH = UploadBaseUrl + StudentHomework[i].FILEPATH;
                            }
                            else
                            {
                                rs.FILEPATH = "";
                            }

                          
                            rs.STANDARDNAME = StudentHomework[i].STANDARDNAME;
                            rs.DIVISIONNAME = StudentHomework[i].DIVISIONNAME;
                            rs.EMPLOYEENAME = StudentHomework[i].EMPLOYEENAME;
                            rs.SUBJECTNAME = StudentHomework[i].SUBJECTNAME;
                            rs.DISPLAY = Convert.ToInt32(StudentHomework[i].DISPLAY);
                            Res.Add(rs);

                        }
                        return new DivisionListResult() { IsSuccess = true, HomeWork = Res }; 
                    }
                   
                }
                else
                {
                    for(int i=0; i<EmpHomework.Count;i++)
                    {
                        ResultSet rs = new ResultSet();
                        rs.UserId = EmpHomework[i].UserId;
                        rs.UserType = EmpHomework[i].UserType;
                        rs.HOMEWORKID = EmpHomework[i].HOMEWORKID;
                        rs.HOMEWORKDATE =Convert.ToDateTime(EmpHomework[i].HOMEWORKDATE);
                        rs.TIME = EmpHomework[i].TIME;
                        rs.STANDARDID =Convert.ToInt32( EmpHomework[i].STANDARDID);
                        rs.DIVISIONID = Convert.ToInt32(EmpHomework[i].DIVISIONID);
                        rs.HOMEWORK = EmpHomework[i].HOMEWORK;
                        rs.ACADEMICYEAR = EmpHomework[i].ACADEMICYEAR;
                        if (EmpHomework[i].FILEPATH != "")
                        {
                            rs.FILEPATH = UploadBaseUrl + EmpHomework[i].FILEPATH;
                        }
                        else
                        {
                            rs.FILEPATH = "";
                        }

                           
                        rs.STANDARDNAME = EmpHomework[i].STANDARDNAME;
                        rs.DIVISIONNAME = EmpHomework[i].DIVISIONNAME;
                        rs.EMPLOYEENAME = EmpHomework[i].EMPLOYEENAME;
                        rs.SUBJECTNAME = EmpHomework[i].SUBJECTNAME;
                        rs.DISPLAY = Convert.ToInt32(EmpHomework[i].DISPLAY);
                        Res.Add(rs);

                    }

                    return new DivisionListResult() { IsSuccess = true, HomeWork = Res }; 

                }
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




        public object ViewHomeWorkByDates(ParamHomeWorkAll obj)
        {
            try
            {

                SchoolMainContext db = new ConcreateContext().GetContext(obj.userid, obj.password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                var EmpHomework = db.VIEWHOMEWORKs.Where(r => r.UserId == obj.userid && r.HOMEWORKDATE>=obj.FromDate && r.HOMEWORKDATE<=obj.ToDate).OrderByDescending(r=>r.HOMEWORKDATE).ToList();

                string UploadBaseUrl = "";
                var logindetail = db.TBLUSERLOGINs.
                             Where(r => r.UserId == obj.userid && r.Password == obj.password && r.STATUS == "ACTIVE")
                             .FirstOrDefault();

                if (logindetail.UserName.StartsWith("NKV"))
                {
                    UploadBaseUrl = ConfigurationManager.AppSettings["NkvsBaseUrlUpload"];
                }
                else if (logindetail.UserName.StartsWith("SXS"))
                {
                    UploadBaseUrl = ConfigurationManager.AppSettings["StxavierBaseUrlUpload"];
                }
                else if (logindetail.UserName.StartsWith("ASM"))
                {
                    UploadBaseUrl = ConfigurationManager.AppSettings["AsmBaseUrlUpload"];
                }

                else if (logindetail.UserName.StartsWith("ASY"))
                {
                    UploadBaseUrl = ConfigurationManager.AppSettings["AsyBaseUrlUpload"];
                }
                else if (logindetail.UserName.StartsWith("NMS"))
                {
                    UploadBaseUrl = ConfigurationManager.AppSettings["NmsBaseUrlUpload"];
                }
                List<ResultSet> Res = new List<ResultSet>();
                if (EmpHomework.Count() == 0)
                {
                    var StudentHomework = db.VIEWSTUDENTHOMEWORKs.Where(r => r.UserId == obj.userid && r.HOMEWORKDATE >= obj.FromDate && r.HOMEWORKDATE<=obj.ToDate).OrderByDescending(r => r.HOMEWORKDATE).ToList();

                    if (StudentHomework.Count() == 0)
                    {
                        return new Results
                        {
                            IsSuccess = false,
                            Message =  "Homework Not Found" 
                        };

                      
                    }
                    else
                    {
                        for (int i = 0; i < StudentHomework.Count; i++)
                        {
                            ResultSet rs = new ResultSet();
                            rs.UserId = StudentHomework[i].UserId;
                            rs.UserType = StudentHomework[i].UserType;
                            rs.HOMEWORKID = StudentHomework[i].HOMEWORKID;
                            rs.HOMEWORKDATE = Convert.ToDateTime(StudentHomework[i].HOMEWORKDATE);
                            rs.TIME = StudentHomework[i].TIME;
                            rs.STANDARDID = Convert.ToInt32(StudentHomework[i].STANDARDID);
                            rs.DIVISIONID = Convert.ToInt32(StudentHomework[i].DIVISIONID);
                            rs.HOMEWORK = StudentHomework[i].HOMEWORK;
                            rs.ACADEMICYEAR = StudentHomework[i].ACADEMICYEAR;
                            if(StudentHomework[i].FILEPATH!="")
                            {
                                rs.FILEPATH = UploadBaseUrl + StudentHomework[i].FILEPATH;
                            }
                            else

                            {
                                rs.FILEPATH = "";
                            }
                           
                            rs.STANDARDNAME = StudentHomework[i].STANDARDNAME;
                            rs.DIVISIONNAME = StudentHomework[i].DIVISIONNAME;
                            rs.EMPLOYEENAME = StudentHomework[i].EMPLOYEENAME;
                            rs.SUBJECTNAME = StudentHomework[i].SUBJECTNAME;
                            rs.DISPLAY = Convert.ToInt32(StudentHomework[i].DISPLAY);
                            Res.Add(rs);

                        }
                        return new DivisionListResult() { IsSuccess = true, HomeWork = Res };
                    }
                   
                }
                else
                {
                    for (int i = 0; i < EmpHomework.Count; i++)
                    {
                        ResultSet rs = new ResultSet();
                        rs.UserId = EmpHomework[i].UserId;
                        rs.UserType = EmpHomework[i].UserType;
                        rs.HOMEWORKID = EmpHomework[i].HOMEWORKID;
                        rs.HOMEWORKDATE = Convert.ToDateTime(EmpHomework[i].HOMEWORKDATE);
                        rs.TIME = EmpHomework[i].TIME;
                        rs.STANDARDID = Convert.ToInt32(EmpHomework[i].STANDARDID);
                        rs.DIVISIONID = Convert.ToInt32(EmpHomework[i].DIVISIONID);
                        rs.HOMEWORK = EmpHomework[i].HOMEWORK;
                        rs.ACADEMICYEAR = EmpHomework[i].ACADEMICYEAR;
                        if(EmpHomework[i].FILEPATH!="")
                        {
                            rs.FILEPATH = UploadBaseUrl + EmpHomework[i].FILEPATH;

                        }
                        else
                        {
                            rs.FILEPATH ="";

                        }
                        rs.STANDARDNAME = EmpHomework[i].STANDARDNAME;
                        rs.DIVISIONNAME = EmpHomework[i].DIVISIONNAME;
                        rs.EMPLOYEENAME = EmpHomework[i].EMPLOYEENAME;
                        rs.SUBJECTNAME = EmpHomework[i].SUBJECTNAME;
                        rs.DISPLAY = Convert.ToInt32(EmpHomework[i].DISPLAY);
                        Res.Add(rs);

                    }

                    return new DivisionListResult() { IsSuccess = true, HomeWork = Res };

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



        public class ResultSet
        {
            public Int64  UserId {get;set;}
            public string UserType { get; set; }
            public Int64 HOMEWORKID {get;set;}
            public DateTime HOMEWORKDATE { get; set; }
            public string TIME { get; set; }
            public int STANDARDID { get; set; }
            public int DIVISIONID { get; set; }
            public string HOMEWORK { get; set; }
            public string ACADEMICYEAR { get; set; }
            public string FILEPATH { get; set; }
            public string SUBMISSIONDATE { get; set; }
            public string STANDARDNAME { get; set; }
            public string DIVISIONNAME { get; set; }
            public string EMPLOYEENAME { get; set; }
            public string SUBJECTNAME { get; set; }
            public Int64 DISPLAY { get; set; }
        }
    }
}