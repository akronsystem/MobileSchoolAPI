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

        public object EventHolidayList { get; set; }
		public object EventNotification { get; set; }

        public object HomeworkNotification { get; set; }

        public object GeneralNotification { get; set; }

        public object AllNotification { get; set; }
    }
}