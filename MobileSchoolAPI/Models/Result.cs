using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.Models
{
	public class Results
	{
		public int ResultType { get; set; }
		public DateTime Date { get; set; }
		public String Message { get; set; }
	}
}