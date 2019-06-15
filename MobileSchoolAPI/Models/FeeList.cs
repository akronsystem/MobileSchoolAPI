using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.Models
{
    public class FeeList
    {
        public bool IsSuccess { get; set; }
        public object TotalFee { get; set; }
        public object PaindingFee { get; set; }
    }
}