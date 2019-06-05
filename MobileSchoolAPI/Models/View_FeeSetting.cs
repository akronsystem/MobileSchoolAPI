namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_FeeSetting
    {
        [Column(TypeName = "numeric")]
        public decimal? TOTALFEES { get; set; }

        [StringLength(50)]
        public string FEETYPE { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long FEETYPEID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AMOUNT { get; set; }

        [StringLength(100)]
        public string STANDARDNAME { get; set; }

        public long? STANDARDID { get; set; }
    }
}
