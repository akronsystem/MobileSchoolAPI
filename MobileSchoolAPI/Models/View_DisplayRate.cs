namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_DisplayRate
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RatingMasterId { get; set; }

        [StringLength(100)]
        public string Parameter { get; set; }

        [StringLength(100)]
        public string Rating { get; set; }

        public int? Display { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RatingDetailId { get; set; }

        public long? StudentId { get; set; }

        public long? TeacherId { get; set; }

        public long? SubjectId { get; set; }

        public int? Mark { get; set; }

        [StringLength(50)]
        public string AcademicYear { get; set; }

        public long? Expr1 { get; set; }
    }
}
