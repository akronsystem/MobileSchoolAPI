namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vw_STUDSTANDARD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long STUDENTID { get; set; }
        public Int64 USERID { get; set; }
        [StringLength(25)]
        public string STANDARDID { get; set; }

        [StringLength(100)]
        public string STANDARDNAME { get; set; }

        public long? DISPLAY { get; set; }

        [StringLength(15)]
        public string ACADEMICYEAR { get; set; }
    }
}
