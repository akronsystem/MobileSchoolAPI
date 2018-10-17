using MobileSchoolAPI.Models;
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
				//return new Error() { IsError = true, Message = ex.Message };
			}


		}
	}
}
