namespace MobileSchoolAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_STUDENT_INFO
    {
        [Key]
        public long STUDENTID { get; set; }

        [StringLength(200)]
        public string STUDENTNAME { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(15)]
        public string MOBILENO { get; set; }

        [StringLength(30)]
        public string ACADEMICYEAR { get; set; }

        [StringLength(200)]
        public string IMAGEPATH { get; set; }
    }
}
