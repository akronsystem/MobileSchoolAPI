namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIewAttendaceClasswiseCheck")]
    public partial class VIewAttendaceClasswiseCheck
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        public DateTime? ATTEDANCEDATE { get; set; }

        public int? DISPLAY { get; set; }

        [StringLength(15)]
        public string ACADEMICYEAR { get; set; }

        [StringLength(20)]
        public string EDUCATIONYEAR { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ATTEDANCEMID { get; set; }
    }
}
