using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileSchoolAPI.Controllers;

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

                var GETTYPE = db.VW_GET_USER_TYPE.Where(r => r.UserId == obj.USERID).ToList();

                if (GETTYPE[0].UserType != "STUDENT")
                {
                    var Division = db.VIEWDIVISIONLISTs.Where(r => r.STANDARDID == obj.STANDARDID && r.UserId == obj.USERID && r.ACADEMICYEAR=="2018-2019").ToList();

                    if (Division.Count==0)
                    {
                        return new Error() { IsError = true, Message = "Division Not Found" };
                    }
                    else
                    {
                        return new DivisionListResult() { IsSuccess = true, DivisionListByUser = Division };
                     
                    }
                }
                else
                {
                    var Division = db.VIEWDIVISIONLISTBYSTUDENTs.Where(r => r.STANDARDID == obj.STANDARDID && r.UserId == obj.USERID && r.ACADEMICYEAR=="2018-2019").ToList();

                    if (Division.Count == 0)
                    {
                        return new Error() { IsError = true, Message = "Division Not Found" };
                    }
                    else
                    {
                        return new DivisionListResult() { IsSuccess = true, DivisionListByUser = Division };

                       
                    }
                }

               
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
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
                var EmpHomework = db.VIEWHOMEWORKs.Where(r => r.UserId == obj.userid && r.HOMEWORKDATE==obj.homeworkdate).ToList();



                if (EmpHomework.Count() == 0)
                {
                    var StudentHomework = db.VIEWSTUDENTHOMEWORKs.Where(r => r.UserId == obj.userid && r.HOMEWORKDATE == obj.homeworkdate).ToList();

                    if (StudentHomework.Count() == 0)
                    {
                        return new Error() { IsError = true, Message = "HomeWork Not Found." };
                    }
                    else
                    {
                         return new DivisionListResult() { IsSuccess = true, HomeWork = StudentHomework }; ;
                    }
                   
                }
                else
                {
                    return new DivisionListResult() { IsSuccess = true, HomeWork = EmpHomework }; ;

                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };

            }
        }


    }
}