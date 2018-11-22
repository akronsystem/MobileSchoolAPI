namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWSTUDENTDIVISION")]
    public partial class VIEWSTUDENTDIVISION
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        [StringLength(100)]
        public string STANDARDID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long DIVISIONID { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }

        [StringLength(251)]
        public string DIVISIONAME { get; set; }

        [StringLength(50)]
        public string ACADEMICYEAR { get; set; }

        public long? DISPLAY { get; set; }
    }
}
