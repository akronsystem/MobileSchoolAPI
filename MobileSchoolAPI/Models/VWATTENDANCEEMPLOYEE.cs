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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        public DateTime? ATTEDANCEDATE { get; set; }

        public int? DISPLAY { get; set; }
    }
}
