using MobileSchoolAPI.Models;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GETTERMLISTBL
    {
      
        public object TERMLISTBL(TERMLISTCS tobj)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(tobj.Userid, tobj.Password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message = new InvalidUser() { IsSuccess = false, Result = "Invalid User" } };
                }
                var getlist = db.VIEW_TERMMASTER.ToList();

                if (getlist == null)

                    return new Results
                    {
                        IsSuccess = false,
                        Message =   "TERM LIST NOT FOUND." 
                    };
               
                else
                    return new TermListResult(){ IsSuccess = "true",TermList = getlist}; ;

            }
            catch (Exception ex)
            {

                return new Results
                {
                    IsSuccess = false,
                    Message =   ex.Message  
                };

               
            }
        }
    }
}