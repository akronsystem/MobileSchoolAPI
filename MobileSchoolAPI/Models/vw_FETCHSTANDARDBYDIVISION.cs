namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_FETCHSTANDARDBYDIVISION
    {
        [Key]
        public long DIVISIONID { get; set; }

        [StringLength(100)]
        public string STANDARDID { get; set; }

        public long? DISPLAY { get; set; }

        [StringLength(50)]
        public string ACADEMICYEAR { get; set; }
    }
}
