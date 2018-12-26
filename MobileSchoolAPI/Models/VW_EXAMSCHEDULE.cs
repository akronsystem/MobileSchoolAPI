namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_EXAMSCHEDULE
    {
        public string STANDARDID { get; set; }

        public string SUBJECTID { get; set; }

        public string EXAMDATE { get; set; }

        [StringLength(50)]
        public string EXAMTIME { get; set; }

        [StringLength(50)]
        public string ACADEMICYEAR { get; set; }

        public long? TESTTYPEID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SCHEDULEID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SCHEDULEDID { get; set; }
    }
}
