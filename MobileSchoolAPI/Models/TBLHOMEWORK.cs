namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLHOMEWORK")]
    public partial class TBLHOMEWORK
    {
        [Key]
        public long HOMEWORKID { get; set; }

        public DateTime? HOMEWORKDATE { get; set; }

        [StringLength(50)]
        public string TIME { get; set; }

        [StringLength(15)]
        public string SMSSTATUS { get; set; }

        public long? STANDARDID { get; set; }

        public string DIVISIONID { get; set; }

        public long? TERMID { get; set; }

        public long? SUBJECTID { get; set; }

        public string HOMEWORK { get; set; }

        [StringLength(50)]
        public string ACADEMICYEAR { get; set; }

        [StringLength(300)]
        public string FILEPATH { get; set; }

        [StringLength(20)]
        public string SEMISTER { get; set; }

        [StringLength(30)]
        public string INSTITUTECODE { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }

        public long? DISPLAY { get; set; }

        public DateTime? SUBMISSIONDATE { get; set; }
    }
}
