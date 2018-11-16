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
                string TeacherBaseUrl = "";
                string StudentBaseUrl = "";

                LoginManager objLogin = new LoginManager();
				var logindetail = objLogin.GetLoginDetails(userLogin);
                

                if(logindetail.UserType=="STUDENT")
                {
                    StudentBaseUrl = ConfigurationManager.AppSettings["StxavierBaseUrlStudent"];
                    logindetail.BaseUrl=StudentBaseUrl+logindetail.IMAGEPATH;
                }
                else
                {
                    TeacherBaseUrl = ConfigurationManager.AppSettings["StxavierBaseUrlTeacher"];
                    logindetail.BaseUrl = TeacherBaseUrl + logindetail.IMAGEPATH;
                }
				if (logindetail == null)
					return new Error() { IsError = true, Message = "User Name & Passowrd is Incorrect" };
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
