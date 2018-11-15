using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Configuration;
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
		public object Confirm([FromBody]ParamLogin userLogin)
		{
			try
			{

                LoginManager objLogin = new LoginManager();
				var logindetail = objLogin.GetLoginDetails(userLogin);

                string baseUrl  = ConfigurationManager.AppSettings["BaseUrl"];
                string imgPath  = logindetail.IMAGEPATH;
                logindetail.BaseURL = baseUrl + imgPath;

				if (logindetail == null)
					return new Error() { IsError = true, Message = "User Name & Password is Incorrect" };
				else
					return logindetail;
			}
			catch (Exception ex)
			{
				return new Error() { IsError = true, Message = ex.Message };
			}
		}
        
	}
}
