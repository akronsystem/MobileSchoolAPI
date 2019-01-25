using MobileSchoolAPI.DAL;
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
            if (username.StartsWith("ASM"))
                return new ASMSchoolContext();
             if (username.StartsWith("ASY"))
                return new ASYSCHOOLSchoolContext();
            if (username.StartsWith("NMS"))
                return new NMESSchoolContext();



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

            var contxt2 = new ASMSchoolContext().TBLUSERLOGINs.FirstOrDefault(r => r.UserId == UserId && r.Password == password);
            if (contxt2 != null)
                return new ASMSchoolContext();

            var contxt3 = new ASYSCHOOLSchoolContext().TBLUSERLOGINs.FirstOrDefault(r => r.UserId == UserId && r.Password == password);
            if (contxt3 != null)
                return new ASYSCHOOLSchoolContext();

            var contxt4 = new NMESSchoolContext().TBLUSERLOGINs.FirstOrDefault(r => r.UserId == UserId && r.Password == password);
            if (contxt4 != null)
                return new NMESSchoolContext();


            return null;
		}
	}
}