namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLTRANSFERSTUDENT")]
    public partial class TBLTRANSFERSTUDENT
    {
        [Key]
        [Column(Order = 0)]
        public long TRASFERID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long STUDENTID { get; set; }

        [StringLength(15)]
        public string ACADEMICYEAR { get; set; }

        [StringLength(50)]
        public string ROLLNO { get; set; }

        [StringLength(25)]
        public string STANDARDID { get; set; }

        public int? COURSEID { get; set; }

        [StringLength(50)]
        public string TRANSFERSTATUS { get; set; }

        [StringLength(50)]
        public string HALLTICKETNO { get; set; }

        [StringLength(10)]
        public string TRANSFERED { get; set; }

        public int? DIVISIONID { get; set; }

        public short? TRANSPORTSTATUS { get; set; }

        [StringLength(3)]
        public string HOSTELSTATUS { get; set; }

        [StringLength(50)]
        public string GRNO { get; set; }

        [StringLength(20)]
        public string ACADEMICSTATUS { get; set; }

        [StringLength(10)]
        public string CONCESSION { get; set; }

        public long? CONCESSIONREASON { get; set; }

        [StringLength(100)]
        public string OTHERREASON { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONCESSIONPERCENTAGE { get; set; }
    }
}
