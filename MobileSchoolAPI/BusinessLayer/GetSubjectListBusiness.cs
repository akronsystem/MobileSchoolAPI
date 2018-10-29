using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GetSubjectListBusiness
    {
        SchoolContext db = new SchoolContext();


        public object GetSubjectList(ParamDIVISIONWISESUBJECT objdiv)
        {
            try
            {
                var SubjectList = db.VIEWDIVISIONWISESUBJECTs.Where(r => r.DIVISIONID == objdiv.divisionid &&  r.DISPLAY == 1).ToList();
                if (SubjectList.Count == 0)
                {
                    
                        return new Error() { IsError = true, Message = "Subject Not Found" };
                   
                }
                else
                {
                    return SubjectList;
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