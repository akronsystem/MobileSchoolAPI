namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLASSIGNSTAFF")]
    public partial class TBLASSIGNSTAFF
    {
        [Key]
        public long ASSIGNSTAFFID { get; set; }

        public long? STNDARDID { get; set; }

        public long? EMPLOYEEID { get; set; }

        public int? SUBJECTID { get; set; }

        public int? BATCHID { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }

        public int? DISPLAY { get; set; }

        public int? BATCHSUBJECTID { get; set; }

        [StringLength(30)]
        public string ACADEMICYEAR { get; set; }

        public int? DIVISIONID { get; set; }
    }
}
