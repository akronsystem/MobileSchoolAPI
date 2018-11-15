namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vw_STANDARDLIST
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long STANDARDID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        public long? EMPLOYEEID { get; set; }

        public int? DISPLAY { get; set; }

        [StringLength(30)]
        public string ACADEMICYEAR { get; set; }

        [StringLength(100)]
        public string STANDARDNAME { get; set; }
    }
}
