namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLASSIGNCLASSTEACHER")]
    public partial class TBLASSIGNCLASSTEACHER
    {
        [Key]
        public long ASSIGNTEACHERID { get; set; }

        public long? EMPLOYEEID { get; set; }

        public long? STANDARDID { get; set; }

        public long? DIVISIONID { get; set; }

        public long? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public long? DISPLAY { get; set; }

        [StringLength(50)]
        public string ACADEMICYEAR { get; set; }
    }
}
