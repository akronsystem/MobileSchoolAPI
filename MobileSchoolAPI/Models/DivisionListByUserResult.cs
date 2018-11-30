using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.Models
{
    public class DivisionListByUserResult
    {
        public bool IsSuccess { get; set; }

        public object DivisionList { get; set; }
    }
}