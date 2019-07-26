namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLRATINGDETAILS")]
    public partial class TBLRATINGDETAIL
    {
        [Key]
        public long RatingDetailId { get; set; }

        public long? RatingMasterId { get; set; }

        public long? StudentId { get; set; }

        public long? TeacherId { get; set; }

        public long? SubjectId { get; set; }

        public int? Mark { get; set; }

        [StringLength(50)]
        public string AcademicYear { get; set; }

        public int? CreatedId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedId { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? Display { get; set; }
    }
}
