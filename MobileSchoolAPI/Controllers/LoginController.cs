<<<<<<< HEAD
﻿using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.Models;
//using MobileSchoolAPI.ParamModel;
=======
﻿using MobileSchoolAPI.Models;
>>>>>>> 9f4aadd178ab2b1f0954397a0170cdc7f401be82
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MobileSchoolAPI.Controllers
{
    public class LoginController : ApiController
    {
		// GET api/values
		SchoolContext db = new SchoolContext();

		/// <summary>	
		/// To Confirm Login UserName and Password
		/// If passed then Json object return else Error message 
		/// </summary>
		/// <param name="UserName"></param>
		/// <param name="Password"></param>
		/// <returns></returns>
<<<<<<< HEAD
		//[HttpPost]
		//public object Confirm([FromBody]ParamLogin userLogin)
		//{
		//	try
		//	{
		//		LoginManager objLogin = new LoginManager();
		//		var logindetail = objLogin.GetLoginDetails(userLogin);
		//		if (logindetail == null)
		//			return new Error() { IsError = true, Message = "User Name & Passowrd is Incorrect" };
		//		else
		//			return logindetail;
		//	}
		//	catch (Exception ex)
		//	{
		//		return new Error() { IsError = true, Message = ex.Message };
		//	}   
		//}
=======
		[HttpPost]
		public object Confirm(string UserName,string Password)
		{
			try
			{
				string passecrypt = CryptIt.Encrypt(Password);
				var logindetail =	db.TBLUSERLOGINs.
									Where(r => r.UserName == UserName && r.Password == passecrypt && r.STATUS=="ACTIVE")
									.FirstOrDefault();
				if (logindetail == null)
					return new Error() { IsError = true, Message = "User Name & Passowrd is Incorrect" };
				else
					return logindetail;
			}
			catch (Exception ex)
			{
				return new Error() { IsError = true, Message = ex.Message };
			}

>>>>>>> 9f4aadd178ab2b1f0954397a0170cdc7f401be82

		}
	}
}
