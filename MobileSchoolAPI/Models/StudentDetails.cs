using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.Models
{
    public class StudentDetails
    {
        public bool IsSuccess
        {
            get; set;
        }
        public object StudentInformation { get; set; }
    }
}