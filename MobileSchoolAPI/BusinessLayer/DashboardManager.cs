using MobileSchoolAPI.Models;
using MobileSchoolAPI.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.BusinessLayer
{
	public class DashboardManager
	{
		SchoolContext db = new SchoolContext();


		public VWSTUDENTINFO   GetStudentInfo(ParamDashboardStudentInfo objStudent)
		{  
			var student = db.VWSTUDENTINFO.FirstOrDefault(r => r.STUDENTID == objStudent.StudentId);
			return student;

		}
	}
}