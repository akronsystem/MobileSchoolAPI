namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_DATEWISECLASSSTATUSATTENDANCE
    {
        [StringLength(200)]
        public string STUDENTNAME { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long STUDENTID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string STATUS { get; set; }

        [StringLength(50)]
        public string ROLLNO { get; set; }

        public DateTime? ATTEDANCEDATE { get; set; }

        public int? CREATEDID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ATTEDANCEMID { get; set; }
    }
}
