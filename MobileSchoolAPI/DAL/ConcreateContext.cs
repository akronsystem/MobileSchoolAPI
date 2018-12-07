using MobileSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI 
{
	public class ConcreateContext  
	{
		 
		public SchoolMainContext GetContext(string username, string password)
		{
			if (username.StartsWith("SXS"))
				return new SchoolContext();
			if (username.StartsWith("NKV"))
				return new NKVSchoolContext();

			return null;
		}

		public SchoolMainContext GetContext(int UserId, string password)
		{
			 
			var contxt = new   SchoolContext().TBLUSERLOGINs.FirstOrDefault(r=>r.UserId==UserId && r.Password == password);
			if (contxt != null)
				return new SchoolContext();
			var contxt1 = new NKVSchoolContext().TBLUSERLOGINs.FirstOrDefault(r => r.UserId == UserId && r.Password == password);
			if (contxt1 != null)
				return new NKVSchoolContext();

            return null;
		}
	}
}