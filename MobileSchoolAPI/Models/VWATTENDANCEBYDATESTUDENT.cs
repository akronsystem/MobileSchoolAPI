namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VWATTENDANCEBYDATESTUDENT")]
    public partial class VWATTENDANCEBYDATESTUDENT
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        public DateTime? ATTEDANCEDATE { get; set; }

        public int? ATTMONTH { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ATTEDANCEMID { get; set; }
    }
}
