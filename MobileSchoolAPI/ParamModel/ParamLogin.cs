using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
	public class ParamLogin
	{
		public string UserName { get; set; }
		public string Password { get; set; }

        
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
	}
}