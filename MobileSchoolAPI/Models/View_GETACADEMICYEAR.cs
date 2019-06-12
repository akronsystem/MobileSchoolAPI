namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GETACADEMICYEAR
    {
        [StringLength(30)]
        public string ACADEMICYEAR { get; set; }

        [Key]
        public long ACADENICID { get; set; }
    }
}
