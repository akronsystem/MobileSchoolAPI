namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLASSIGNCOMPETENCIES")]
    public partial class TBLASSIGNCOMPETENCy
    {
        [Key]
        public long ASSIGNCOMPID { get; set; }

        public int? STANDARDID { get; set; }

        public int? SUBJECTID { get; set; }

        public int? COMPETENCIESID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }

        public int? DISPLAY { get; set; }

        [StringLength(50)]
        public string ACADEMICYEAR { get; set; }
    }
}
