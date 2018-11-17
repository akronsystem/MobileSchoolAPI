using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.Models
{
    public class CheckUsernamePassword
    {
        SchoolContext objSC = new SchoolContext();
        public bool ValidateUsernamePassword(Int32 USERID,string PASSWORD)
        {
            string pwd = CryptIt.Encrypt(PASSWORD);
            var usernamepwd = objSC.VW_GET_USER_TYPE.Where(r => r.UserId == USERID && r.Password == pwd).ToList();
            if(usernamepwd.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}