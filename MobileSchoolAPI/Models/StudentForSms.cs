using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.Models
{
    public class StudentForSms
    {
        public int studentid
        {
            get;
            set;

        }
        public int DIVISIONID { get; set; }
        public string STANDARDID { get; set;}
    }
}