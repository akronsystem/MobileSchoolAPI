using MobileSchoolAPI.Models;
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
		SchoolContext db = new SchoolContext();

		[HttpGet]
		public object GetStudentInfo(int StudentId,string token)
		{
			var student = db.VWSTUDENTINFO.FirstOrDefault(r => r.STUDENTID == StudentId);
			if(student==null)
				return new Error() { IsError = true, Message = "Studnet Info Not Found" };

			return student;

		}

    }
}
