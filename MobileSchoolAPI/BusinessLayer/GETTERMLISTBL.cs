using MobileSchoolAPI.Models;
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
                var getlist = db.VIEW_TERMMASTER.ToList();

                if (getlist == null)
                    return new Error() { IsError = true, Message = "TERM LIST NOT FOUND." };
                else
                    return new TermListResult(){ IsSuccess = "true",TermList = getlist}; ;

            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
    }
}