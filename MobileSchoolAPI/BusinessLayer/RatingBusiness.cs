using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class RatingBusiness
    {
        public object AddMark(RatingParam obj)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(obj.UserName, obj.Password);

                var Info = db.TBLUSERLOGINs.Where(r => r.UserName == obj.UserName && r.Password == obj.Password).FirstOrDefault();
               
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                if (Info == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                var AcademicYear = db.View_GETACADEMICYEAR.FirstOrDefault();
                if (AcademicYear == null)
                {
                    return new Results() { IsSuccess = false, Message = "Academic Year Not Found" };
                }
                var EmployeeCode = Convert.ToInt16(Info.EmpCode);
                var StudentDetails = db.TBLTRANSFERSTUDENTs.Where(r => r.STUDENTID == EmployeeCode && r.ACADEMICYEAR == AcademicYear.ACADEMICYEAR).FirstOrDefault();
                int STNDARDID =Convert.ToInt32(StudentDetails.STANDARDID);
                int DIVISIONID=Convert.ToInt32(StudentDetails.DIVISIONID);
                var AssignTeacher = db.TBLASSIGNSTAFFs.Where(r => r.EMPLOYEEID == obj.TeacherId && r.STNDARDID == STNDARDID && r.DIVISIONID == DIVISIONID).ToList();
                if (AssignTeacher.Count==0)
                {
                    return new Results() { IsSuccess = false, Message = "Teacher Not Assign" };
                }
                TBLRATINGDETAIL tblobj = new TBLRATINGDETAIL();
                if (obj.Mark>=10)
                {
                    return new Results() { IsSuccess = false, Message = "Mark is less than 10" };
                }
                var DuplicateEntry = db.TBLRATINGDETAILS.Where(r => r.StudentId == EmployeeCode && r.TeacherId == obj.TeacherId && r.RatingMasterId == obj.RatingMasterId).FirstOrDefault();
                if(DuplicateEntry!=null)
                {
                    return new Results() { IsSuccess = false, Message = "You have already rated this Subject" };
                }
               // tblobj.RatingMasterId=
                tblobj.TeacherId = obj.TeacherId;
                tblobj.RatingMasterId = obj.RatingMasterId;
                tblobj.StudentId = EmployeeCode;
                tblobj.Mark = obj.Mark;
                tblobj.AcademicYear = AcademicYear.ACADEMICYEAR;
                tblobj.CreatedId = EmployeeCode;
                tblobj.CreatedOn = System.DateTime.Today.Date;
                db.TBLRATINGDETAILS.Add(tblobj);
                db.SaveChanges();
                return new Results() { IsSuccess = true, Message = "Rating Sucessfully" };
            }
            catch (Exception ex)
            {
                return new Results
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public object DisplayMark(TeacherRatingParam obj)
        {
            SchoolMainContext db = new ConcreateContext().GetContext(obj.UserName, obj.Password);

            var Info = db.TBLUSERLOGINs.Where(r => r.UserName == obj.UserName && r.Password == obj.Password).FirstOrDefault();

            if (db == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            if (Info == null)
            {
                return new Results() { IsSuccess = false, Message = "Invalid User" };
            }
            var AcademicYear = db.View_GETACADEMICYEAR.FirstOrDefault();
            if (AcademicYear == null)
            {
                return new Results() { IsSuccess = false, Message = "Academic Year Not Found" };
            }

            var EmployeeCode = Convert.ToInt16(Info.EmpCode);
            var AssignTeacher = db.TBLASSIGNSTAFFs.Where(r => r.EMPLOYEEID == EmployeeCode).FirstOrDefault();
            if (AssignTeacher == null)
            {
                return new Results() { IsSuccess = false, Message = "Teacher Not Assign" };
            }
            List<string> Parameter = db.TBLRATINGMASTERs.OrderBy(r => r.RatingMasterId).Select(r => r.Parameter).ToList();
            var PramerterList = db.TBLRATINGMASTERs.Where(r => r.Display == 1).Distinct().ToList();
            List<Rate> lt = new List<Rate>();

            foreach (var item in Parameter)
            {
                item.ToList();
                double totalcount = 0;
                double Counts = 0;
                double GetStars = 0;
                double GettingStars = 0;
                double GetAvrage = 0;
                string Stars = "";
                TIMETABLELIST ddl = new TIMETABLELIST();
                // var data = db.View_Timetable.Where(r => r.EMPLOYEEID == EmployeeCode && r.WORKINGDAYS == item && r.DISPLAY == 1 && r.EDUYEAR == AcademicYear.ACADEMICYEAR).ToList();
                var data_d = db.View_DisplayRate.Where(r => r.TeacherId == EmployeeCode).ToList();
                for(int i=0;i<data_d.Count();i++)
                {               
                if (item== data_d[i].Parameter)
                {
                        Counts++;
                        totalcount += Convert.ToDouble(data_d[i].Mark);
                        GetStars = (totalcount / Counts * 10);
                        GettingStars = (GetStars * 5) / 100;
                        GetAvrage = Math.Round(GettingStars);
                        if(GetAvrage==1)
                        {
                            Stars = "One Star";
                        }
                       else if(GetAvrage == 2)
                       {
                            Stars = "Two Star";
                       }
                       else if (GetAvrage == 3)
                       {
                            Stars = "Three Star";
                       }
                       else if (GetAvrage == 4)
                       {
                            Stars = "Four Star";
                       }
                        else
                        {
                            Stars = "Five Star";
                        }
                        if (Counts<=1)
                        {
                            lt.Add(new Rate
                            {
                                PramerterName = item,
                                Stars = Stars
                            });
                        }
                       else
                       {
                            lt.RemoveAll(r => r.PramerterName == item);
                            lt.Add(new Rate
                            {
                                PramerterName = item,
                                Stars = Stars
                            });
                       }
                 
                }
                //else
                //{
                //        lt.RemoveAll(r => r.Stars =="" && r.PramerterName==item);
                //        lt.Add(new Rate
                //        {
                //            PramerterName = item,
                //            Stars = Stars
                //        });
                //}



                }
                 if (data_d.Count() == 0 )
                 {
                    lt.Add(new Rate
                    {
                        PramerterName = item,
                        Stars = Stars
                    });
                 }
                 if( data_d.Count() <= 1)
                {
                    lt.RemoveAll(r =>r.PramerterName == item);
                    lt.Add(new Rate
                    {
                        PramerterName = item,
                        Stars = Stars
                    });
                }
            }
            return new RateParameterList() { IsSuccess = true, GetStars = lt.ToArray() };
        }
        public class Rate
        {
            public string PramerterName { get; set; }
            public object Stars { get; set; }
        }

    }
}