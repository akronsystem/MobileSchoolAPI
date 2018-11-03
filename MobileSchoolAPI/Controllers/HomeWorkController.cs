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
	public class HomeWorkController : ApiController
	{
		SchoolContext db = new SchoolContext();
		[HttpPost]

		


		


		

		public object ShowHomeWork([FromBody]ParamHOMEWORKBYUSER objhome)
		{
			GETHOMEWORK obj = new GETHOMEWORK();
			//return obj.ViewHomeWorkbyUser(objhome);
			return new DivisionListResult() { IsSuccess = "true", HomeWork = obj.ViewHomeWorkbyUser(objhome) };

		}
	}
}