namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_DisplayStudentDetails
    {
        public DateTime? ADMISSIONDATE { get; set; }

        [StringLength(200)]
        public string STUDENTNAME { get; set; }

        [StringLength(200)]
        public string FATHERNAME { get; set; }

        [StringLength(200)]
        public string MOTHERNAME { get; set; }

        [StringLength(30)]
        public string DOB { get; set; }

        [StringLength(15)]
        public string GENDER { get; set; }

        [StringLength(15)]
        public string ACADEMICYEAR { get; set; }

        [StringLength(10)]
        public string CONCESSION { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long STUDENTID { get; set; }

        [StringLength(15)]
        public string GMOBILE { get; set; }

        [StringLength(200)]
        public string IMAGEPATH { get; set; }
    }
}
