using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
    public class ResultParam
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public int TermId { get; set; }
    }
}