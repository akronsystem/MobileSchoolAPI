namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VWSTUDENTINFO")]
    public partial class VWSTUDENTINFO
    {
        [StringLength(200)]
        public string STUDENTNAME { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(200)]
        public string IMAGEPATH { get; set; }

        [Key]
        public long STUDENTID { get; set; }
    }
}
