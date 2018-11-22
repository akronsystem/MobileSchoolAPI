using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GetStandardList
    {

        public object GetStdList(ParamDIVISIONLIST Stdobj)
        {
            SchoolContext db = new SchoolContext();
            var UserType = db.VW_GET_USER_TYPE.Where(r => r.UserId == Stdobj.userid).ToList();
            if(UserType[0].UserType=="STUDENT")
            {
                var STDLIST = db.Vw_STUDSTANDARD.Where(r => r.USERID == Stdobj.userid && r.ACADEMICYEAR=="2018-2019" ).ToList();


                if (STDLIST.Count == 0)
                {
                    return new Error() { IsError = true, Message = "Standard is not assigned for this user" };
                }
                else
                {
                    return new StdListResult() { IsSuccess = true, StandardList = STDLIST };
                }
              

            }
            else
            {
                var STDLIST = db.Vw_STANDARDLIST.Where(r => r.UserId == Stdobj.userid && r.ACADEMICYEAR == "2018-2019" && r.DISPLAY==1).ToList();
                if (STDLIST.Count == 0)
                {
                    return new Error() { IsError = true, Message = "Standard is not assigned for this user" };
                }
                else
                {
                    return new StdListResult() { IsSuccess = true, StandardList = STDLIST };
                }
            }
           
            
        }
    }
}