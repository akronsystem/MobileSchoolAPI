namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWATTENDANCECHECK")]
    public partial class VIEWATTENDANCECHECK
    {
        [Key]
        public long ATTEDANCEMID { get; set; }

        [StringLength(20)]
        public string EDUCATIONYEAR { get; set; }

        public long? STANDARDID { get; set; }

        public long? SUBJECTID { get; set; }

        public long? BATCHID { get; set; }

        public int? MONTH { get; set; }

        public long? DIVISIONID { get; set; }

        public int? DISPLAY { get; set; }

        [StringLength(50)]
        public string ATTEDANCETYPE { get; set; }

        public DateTime? ATTEDANCEDATE { get; set; }
    }
}
