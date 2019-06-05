namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLASSIGNCLASSMASTER")]
    public partial class TBLASSIGNCLASSMASTER
    {
        [Key]
        public long CLASSASSIGNID { get; set; }

        public long? STANDARDID { get; set; }

        public long? DIVISIONID { get; set; }

        public long? EMPLOYEEID { get; set; }

        [StringLength(50)]
        public string YEAR { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }

        public int? DISPLAY { get; set; }
    }
}
