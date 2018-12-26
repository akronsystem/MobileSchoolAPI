namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ViewGetTodayBirthDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long STUDENTID { get; set; }

        [StringLength(60)]
        public string ENROLLMENTNO { get; set; }

        [StringLength(200)]
        public string STUDENTNAME { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(200)]
        public string IMAGEPATH { get; set; }

        [StringLength(100)]
        public string STANDARDNAME { get; set; }

        [StringLength(150)]
        public string DIVISIONNAME { get; set; }
    }
}
