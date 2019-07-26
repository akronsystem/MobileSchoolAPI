namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLRATINGMASTER")]
    public partial class TBLRATINGMASTER
    {
        [Key]
        public long RatingMasterId { get; set; }

        [StringLength(100)]
        public string Parameter { get; set; }

        [StringLength(100)]
        public string Rating { get; set; }

        public int? CreatedId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedId { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? Display { get; set; }
    }
}
