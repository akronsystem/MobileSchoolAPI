using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ResultModel
{
	public class ResultLogin
	{
		public bool IsSuccess
		{
			get; set;
		}
		public object UserData
		{
			get; set;
		}
	}
}