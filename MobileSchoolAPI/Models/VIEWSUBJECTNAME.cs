namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWSUBJECTNAME")]
    public partial class VIEWSUBJECTNAME
    {
        public string SUBJECTNAME { get; set; }

        [Key]
        public long SUBJECTID { get; set; }
    }
}
