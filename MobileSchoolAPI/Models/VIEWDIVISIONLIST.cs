namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWDIVISIONLIST")]
    public partial class VIEWDIVISIONLIST
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public Int64 UserId { get; set; }
        public long STANDARDID { get; set; }

        [StringLength(251)]
        public string DIVISIONNAME { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long DIVISIONID { get; set; }

     
    }
}
