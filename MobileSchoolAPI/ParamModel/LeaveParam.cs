using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
    public class LeaveParam
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public long LEAVETYPE { get; set; }

       // public int EMPLOYEEID { get; set; }

        public DateTime FROMDATE { get; set; }

        public DateTime TODATE { get; set; }

        //[Column(TypeName = "numeric")]
        public decimal NOOFDAYS { get; set; }

        public string REASON { get; set; }

        //[StringLength(20)]
       // public string ACADEMICYEAR { get; set; }

       // [StringLength(30)]
        public string SUBSTITUTEID { get; set; }

        //public int CREATEDID { get; set; }

        //public DateTime CREATEDON { get; set; }

        //[StringLength(20)]

        //public string CreationTime { get; set; }
    }
}