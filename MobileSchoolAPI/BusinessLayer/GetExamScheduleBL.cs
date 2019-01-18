using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GetExamScheduleBL
    {
        public object GetExamSchedule(ParamExamSchedule OBJ)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(OBJ.USERID, OBJ.PASSWORD);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = "Invalid User" };
                }
                var result = db.VW_EXAMSCHEDULE.Where(r=>r.STANDARDID.Contains(""+OBJ.STANDARDID+"") && r.TESTTYPEID==OBJ.TESTID && r.ACADEMICYEAR=="2018-2019" ).ToList();
                if(result.Count==0)
                {
                    return new InvalidUser() { IsSuccess = false, Result = "Record Not Found" };
                }
                List<examclass> Details = new List<examclass>();
                for (int i = 0; i < result.Count; i++)
                {
                    string[] std = result[i].STANDARDID.Split(',');
                    int count = 0;

                    for (int j = 0; j < std.Length; j++)
                    {
                        if (std[j] == OBJ.STANDARDID)
                        {
                            count = j;
                        }
                    }

                    string[] sub = result[i].SUBJECTID.Split(',');
                    int subid = int.Parse(sub[count]);
                    var subname = db.VIEWSUBJECTNAMEs.Where(r => r.SUBJECTID == subid).SingleOrDefault();
                    int testid =int.Parse(result[i].TESTTYPEID.ToString());
                    var testname = db.VW_UNITMASTER.Where(r => r.UNITID == testid).SingleOrDefault();
                    Details.Add(new examclass
                    {
                        Subject = subname.SUBJECTNAME,
                        Test= testname.TESTNAME,
                        ExamDate=result[i].EXAMDATE,
                        ExamTime=result[i].EXAMTIME
                    });
                }
                return new InvalidUser() { IsSuccess = true, Result = Details.ToArray() };
            }
            catch(Exception ex)
            {
                return new Results
                {
                    IsSuccess = false,
                    Message =    ex.Message 
                };

                
            }
        }

        public class examclass
        {
            public string Subject { get; set; }
            public string Test { get; set; }
            public string ExamDate { get; set; }
            public string ExamTime { get; set; }
        }
    }
}