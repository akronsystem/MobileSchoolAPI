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
        SchoolContext db = new SchoolContext();

        public object GetHomework(PARAMHOMEWORK obj)
        {
            try
            {

                var homework = db.VIEWHOMEWORKs.Where(r => r.STANDARDID == obj.standardid && r.DIVISIONID == obj.divisionid && r.DISPLAY == 1 && r.ACADEMICYEAR == "2018-2019").

                                     FirstOrDefault();

                if (homework == null)
                {
                    return new Error() { IsError = true, Message = "Homework not found" };
                }
                else
                {
                    return homework;
                }

            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }

        }



        public Object GetStandard(PARAMSTD obj)
        {
            try
            {

                var Division = db.VIEWDIVISIONLISTs.Where(r => r.STANDARDID == obj.STANDARDID);

                if (Division == null)
                {
                    return new Error() { IsError = true, Message = "Division Not Found" };
                }
                else
                {
                    return Division;
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        internal object ViewHomeWorkbyUser(PARAMHOMEWORKBYUSER objhome)
        {
            throw new NotImplementedException();
        }

        public object GetStdByEmp(PARAMEMP emp)
        {
            try
            {
                var Division = db.VIEWDIVISIONLISTBYEMPs.Where(r => r.EMPLOYEEID == emp.EmployeeId);

                if (Division == null)
                {
                    return new Error() { IsError = true, Message = "Division Not Found" };
                }
                else
                {
                    return Division;
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };

            }
        }


        public object ViewHomeWorkbyUser(ParamHOMEWORKBYUSER obj)
        {
            try
            {
                var EmpHomework = db.VIEWHOMEWORKs.Where(r => r.UserId == obj.userid && r.DIVISIONID==obj.divisionid).ToList();



                if (EmpHomework.Count() == 0)
                {
                    var StudentHomework = db.VIEWSTUDENTHOMEWORKs.Where(r => r.UserId == obj.userid && r.DIVISIONID == obj.divisionid).ToList();

                    if (StudentHomework.Count() == 0)
                    {
                        return new Error() { IsError = true, Message = "HomeWork Not Found." };
                    }
                    else
                    {
                        return StudentHomework;
                    }
                   
                }
                else
                {
                    return EmpHomework;
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };

            }
        }


    }
}