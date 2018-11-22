using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GetDivisionInfoBusiness
    {
        SchoolContext db = new SchoolContext();


        public object GetDivision(ParamDIVISIONLIST objdiv)
        {
            try
            {
                var EmpDivision = db.VIEWEMPDIVISIONs.Where(r=>r.UserId==objdiv.userid && r.ACADEMICYEAR=="2018-2019" && r.DISPLAY==1).ToList();
                if (EmpDivision.Count == 0)
                {
                    var StudentDivision = db.VIEWSTUDENTDIVISIONs.Where(r => r.UserId == objdiv.userid && r.ACADEMICYEAR == "2018-2019" && r.DISPLAY == 1).ToList();
                    if (StudentDivision.Count == 0)
                    {
                        return new Error() { IsError = true, Message = "Division is not assigned for this user" };
                    }
                    else
                    {
                        return new DivisionListByUserResult() { IsSuccess = true, DivisionList = StudentDivision };
                       
                    }
                }
                else
                {
                    return new DivisionListByUserResult() { IsSuccess = true, DivisionList = EmpDivision };
                   
                }
            }
            catch (Exception E)
            {
                return new Error()
                {
                    IsError = true,
                    Message = E.Message

                };
            }
        }

    }
}