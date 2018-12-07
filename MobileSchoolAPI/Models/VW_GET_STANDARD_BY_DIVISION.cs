namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_GET_STANDARD_BY_DIVISION
    {
        [StringLength(100)]
        public string STANDARDID { get; set; }

        [Key]
        public long DIVISIONID { get; set; }
    }
}
