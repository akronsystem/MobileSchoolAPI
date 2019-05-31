using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileSchoolAPI.ParamModel
{
    public class TimeTableParam
    {
        public string Userid
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
      
        public int EMPLOYEEID
        {
            get;
            set;
        }

      
        public int STANDARDID { get; set; }

    
        public int SUBJECTID { get; set; }

     
        public int BATCHID { get; set; }


        public string WORKINGDAYS { get; set; }

      
        public string EDUYEAR { get; set; }

    
        public int DISPLAY { get; set; }

        public int COMPANYID { get; set; }

        public int CREATEDID { get; set; }

        public DateTime CREATEDON { get; set; }

        public int UPDATEDID { get; set; }

        public DateTime UPDATEDON { get; set; }

        public int CLASSROOMID { get; set; }

       
        public string TIMETABLENAME { get; set; }

        public long DIVISION { get; set; }

       
        public string ROOMTYPE { get; set; }

        public long LABBATCH { get; set; }
    }
}