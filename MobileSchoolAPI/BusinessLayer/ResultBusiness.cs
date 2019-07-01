using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace MobileSchoolAPI.BusinessLayer
{
    public class ResultBusiness
    {
        public object ResultShow(ResultParam tobj)
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
            var academicyear = db.View_GETACADEMICYEAR.FirstOrDefault();
            int EmployeeID = Convert.ToInt16(Info.EmpCode);
            double[] Display_grade ;
            var GetStudentInfo = db.TBLTRANSFERSTUDENTs.Where(r => r.STUDENTID == EmployeeID && r.ACADEMICYEAR == "2018-2019").FirstOrDefault();
            if(GetStudentInfo==null)
            {
                return new Results() { IsSuccess = false, Message = "Student Not Found" };
            }
            List<Mark> lt = new List<Mark>();
            var StandardId =Convert.ToInt32(GetStudentInfo.STANDARDID);
            var DivisionId = GetStudentInfo.DIVISIONID;
            var GetTerm = db.View_GetTermwise_Cycle.Where(r => r.Term_ID == tobj.TermId && r.DISPLAY==1 && r.TESTNAME.StartsWith("Cycle")).ToList();

           
            for (int j = 0; j < GetTerm.Count(); j++)
            {
                int UnitId =Convert.ToInt32(GetTerm[j].UNITID);

            
            var CycleTest = db.View_DisplayMark_CycleTest.Where(r => r.STANDARDID == StandardId && r.DIVISIONID == DivisionId && r.DISPLAY == "1" && r.ACADEMICYEAR=="2018-2019"  && r.TERMID==tobj.TermId && r.STUDENTID==EmployeeID && r.UNITTESTID== UnitId).OrderBy(r=>r.SUBJECTID).ToList();
                

            for(int i=0;i<CycleTest.Count();i++)
            {

                int Subjectid =Convert.ToInt32(CycleTest[i].SUBJECTID);
                var Subject = db.TBLSUBJECTMASTERs.Where(r => r.SUBJECTID == Subjectid).FirstOrDefault();
                var GetCount = db.TBLASSIGNCOMPETENCIES.Where(r => r.STANDARDID == StandardId && r.SUBJECTID == Subjectid && r.DISPLAY == 1).Count();
                int TBLCOMPETENCIES_Count = GetCount * 10;
                double totalmark =Convert.ToInt32(CycleTest[i].TOTALMARKS);
                double totmark = totalmark / TBLCOMPETENCIES_Count * 10;
                var tot_grade = db.TBLGRADEMASTERs.Where(r => r.MARKSFROM <= Math.Round(totmark) && r.MARKSTO >= Math.Round(totmark) && r.DISPLAY == 1).FirstOrDefault();
                  
                lt.Add(new Mark
                {

                    SubjectName = Subject.SUBJECTNAME,
                    Grade = totmark,

                    
                });


                    //foreach (var item in lt)
                    //{
                    //    List<double> Main_Mark = new List<double>();
                    //    List<string> Subject_List = db.TBLSUBJECTMASTERs.Where(r => r.SUBJECTNAME == item.SubjectName).Select(r => r.SUBJECTNAME).ToList();
                    //    if(item.SubjectName == Subject.SUBJECTNAME)
                    //    {
                    //        Main_Mark.Add(Convert.ToDouble(item.Grade));
                    //    }


                    //}


                }



            }
            return new ResultList() { IsSuccess = true, ResultLists = lt.ToArray() };
        }
        public class Mark
        {
            public string SubjectName { get; set; }
            public object Grade { get; set; }
            //public int[] Display_grade { get; set; }
        }
    }
}