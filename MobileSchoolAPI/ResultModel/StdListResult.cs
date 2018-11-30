using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ResultModel
{
    public class StdListResult
    {
        public bool IsSuccess
        {
            get;set;
        }
        public object StandardList
        {
            get; set;
        }
    }
}