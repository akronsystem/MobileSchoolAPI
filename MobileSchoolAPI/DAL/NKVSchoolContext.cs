using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI 
{
	public class NKVSchoolContext : SchoolMainContext
	{
		public NKVSchoolContext()
			: base("name=NKVSchoolContext")
		{

		}
	}
}