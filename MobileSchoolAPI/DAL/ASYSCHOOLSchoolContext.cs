using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.DAL
{
    public class ASYSCHOOLSchoolContext:SchoolMainContext
    {
        public ASYSCHOOLSchoolContext()
			: base("name=ASYSCHOOLSchoolContext")
		{

        }
    }
}