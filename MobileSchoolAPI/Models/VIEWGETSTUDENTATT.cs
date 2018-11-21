namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWGETSTUDENTATT")]
    public partial class VIEWGETSTUDENTATT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long STUDENTID { get; set; }

        public int? ROLL_NO { get; set; }

        [StringLength(200)]
        public string STUDENTNAME { get; set; }

        [StringLength(25)]
        public string STANDARDID { get; set; }

        public int? DIVISIONID { get; set; }

        [StringLength(15)]
        public string GMOBILE { get; set; }

        
    }
}
