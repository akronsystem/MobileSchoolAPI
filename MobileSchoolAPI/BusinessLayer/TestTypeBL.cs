using MobileSchoolAPI.Models;
using MobileSchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class TestTypeBL
    {
        public object TESTLISTBL(TERMLISTCS tobj)
        {
            try
            {
                SchoolMainContext db = new ConcreateContext().GetContext(tobj.Userid, tobj.Password);
                if (db == null)
                {
                    return new Results() { IsSuccess = false, Message  = "Invalid User" } ;
                }
                var getlist = db.VW_TESTTYPELIST.ToList();

                if (getlist == null)

                    return new Results
                    {
                        IsSuccess = false,
                        Message =   "TEST LIST NOT FOUND."  
                    };
              
                else
                    return new TermListResult() { IsSuccess = "true", TermList = getlist }; ;
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