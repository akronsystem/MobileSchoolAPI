using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
    public class RatingParam
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int TeacherId { get; set; }
        public int RatingMasterId { get; set; }
        public int Mark { get; set; }
    }
}