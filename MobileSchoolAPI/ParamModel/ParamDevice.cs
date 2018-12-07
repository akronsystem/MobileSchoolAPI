using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
    public class ParamDevice
    {
        public int Id { get; set; }

        public int UserId { get; set; }

       
        public string DeviceId { get; set; }

       
        public string DeviceType { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool Status { get; set; }
    }
}