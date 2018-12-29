using MobileSchoolAPI.Models;
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
                var getlist = db.VW_TESTTYPELIST.ToList();

                if (getlist == null)
                    return new Error() { IsError = true, Message = "TEST LIST NOT FOUND." };
                else
                    return new TermListResult() { IsSuccess = "true", TermList = getlist }; ;
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
    }
}