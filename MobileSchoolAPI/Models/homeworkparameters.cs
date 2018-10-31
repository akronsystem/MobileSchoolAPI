using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.Models
{
    public class homeworkparameters
    {
        public int Userid
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string stnadrdid
        {
            get;
            set;

        }

        public int division
        {
            get; set;
        }

        public int subject
        {
            get; set;
        }
        public int term
        {
            get; set;
        }
        public string homeworkdescription
        {
            get; set;
        }
        
        
     
    }
}