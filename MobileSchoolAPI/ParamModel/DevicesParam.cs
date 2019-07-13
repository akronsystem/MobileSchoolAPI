using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
    public class DevicesParam
    {
       
        public string userid { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public string Date { get; set; }
    }
}