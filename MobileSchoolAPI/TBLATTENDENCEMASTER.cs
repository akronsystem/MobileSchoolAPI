namespace MobileSchoolAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLATTENDENCEMASTER")]
    public partial class TBLATTENDENCEMASTER
    {
        [Key]
        public long ATTEDANCEMID { get; set; }

        [StringLength(20)]
        public string EDUCATIONYEAR { get; set; }

        public long? STANDARDID { get; set; }

        public long? SUBJECTID { get; set; }

        public long? BATCHID { get; set; }

        public DateTime? ATTEDANCEDATE { get; set; }

        public string LESSIONPLANID { get; set; }

        public long? DIVISIONID { get; set; }

        public int? DISPLAY { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }

        [StringLength(50)]
        public string ATTEDANCETYPE { get; set; }
    }
}
