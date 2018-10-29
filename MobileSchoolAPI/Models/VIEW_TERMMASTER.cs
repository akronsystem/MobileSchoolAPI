namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_TERMMASTER
    {
        [Key]
        public long TERMID { get; set; }

        [StringLength(50)]
        public string TERM { get; set; }
    }
}
