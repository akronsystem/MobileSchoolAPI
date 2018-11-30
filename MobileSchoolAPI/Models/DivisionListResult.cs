using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.Models
{
    public class DivisionListResult
    {

        public bool IsSuccess { get; set; }

        public object DivisionListByUser { get; set; }

        public object HomeWork { get; set; }

        public object SubjectList { get; set; }

        public object Notification { get; set; }

    }
}