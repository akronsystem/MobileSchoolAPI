namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VWATTENDANCEEMPLOYEE")]
    public partial class VWATTENDANCEEMPLOYEE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        public DateTime? ATTEDANCEDATE { get; set; }

        public int? ATTMONTH { get; set; }

        public int? DISPLAY { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ATTEDANCEMID { get; set; }
    }
}
