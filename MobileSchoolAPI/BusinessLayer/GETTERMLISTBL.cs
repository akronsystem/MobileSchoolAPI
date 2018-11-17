using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
    public class GETTERMLISTBL
    {
        SchoolContext db = new SchoolContext();

        public object TERMLISTBL()
        {
            try
            {
                var getlist = db.VIEW_TERMMASTER.ToList();

                if (getlist == null)
                    return new Error() { IsError = true, Message = "TERM LIST NOT FOUND." };
                else
                    return getlist;

            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
    }
}