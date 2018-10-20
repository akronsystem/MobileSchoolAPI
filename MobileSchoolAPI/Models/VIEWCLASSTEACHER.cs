namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWCLASSTEACHER")]
    public partial class VIEWCLASSTEACHER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ASSIGNTEACHERID { get; set; }

        public long? EMPLOYEEID { get; set; }

        [StringLength(150)]
        public string DIVISIONNAME { get; set; }

        [StringLength(100)]
        public string STANDARDNAME { get; set; }

        public long? DISPLAY { get; set; }

        [StringLength(50)]
        public string ACADEMICYEAR { get; set; }
    }
}
