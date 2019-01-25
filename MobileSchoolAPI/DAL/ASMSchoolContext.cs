using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.DAL
{
    public class ASMSchoolContext:SchoolMainContext
    {
        public ASMSchoolContext()
			: base("name=ASMSchoolContext")
		{

        }
    }
}