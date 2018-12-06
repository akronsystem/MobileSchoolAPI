using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
    public class ParamHomeWorkAll
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int userid { get; set; }

        public String password { get; set; }
    }
}