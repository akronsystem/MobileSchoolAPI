using MobileSchoolAPI.BusinessLayer;
using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileSchoolAPI.Controllers
{
    public class DashboardController : ApiController
    {
		
		[HttpGet]
		public object GetStudentInfo([FromBody] ParamDashboardStudentInfo StudentInfo)
		{
			try
			{
				DashboardManager objmanager = new DashboardManager();
				var student = objmanager.GetStudentInfo(StudentInfo);
				if (student == null)
					return new Error() { IsError = true, Message = "Studnet Info Not Found" };

				return student;
			}
			catch(Exception ex)
			{
				return new Error() { IsError = true, Message = ex.Message};
			}
			

		}

    }
}
