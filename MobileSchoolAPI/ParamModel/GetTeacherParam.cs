﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
    public class GetTeacherParam
    {
        public int Month { get; set; }
        public int USERID { get; set; }

        public string Password { get; set; }
    }
}