﻿using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
	public class LoginManager
	{
		 //SchoolContext db = new SchoolContext();

		public TBLUSERLOGIN GetLoginDetails(ParamLogin userLogin)
		{
			SchoolMainContext db = new ConcreateContext().GetContext(userLogin.UserName, userLogin.Password);
            if (db == null)
            {
               return null;
            }
            string Password = CryptIt.Decrypt("HZy7aySL2L5aIjyVSYQDJw==");
            string passecrypt = CryptIt.Encrypt(userLogin.Password);
			var logindetail = db.TBLUSERLOGINs.
								Where(r => r.UserName == userLogin.UserName && r.Password == passecrypt && r.STATUS == "ACTIVE")
								.FirstOrDefault();
          
            return logindetail;
		}
	}
}