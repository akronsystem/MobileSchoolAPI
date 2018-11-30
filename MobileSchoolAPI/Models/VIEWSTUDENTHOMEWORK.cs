namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWSTUDENTHOMEWORK")]
    public partial class VIEWSTUDENTHOMEWORK
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HOMEWORKID { get; set; }

        public DateTime? HOMEWORKDATE { get; set; }

        [StringLength(50)]
        public string TIME { get; set; }

        public long? STANDARDID { get; set; }

        public long? DIVISIONID { get; set; }

        public string HOMEWORK { get; set; }

        [StringLength(50)]
        public string ACADEMICYEAR { get; set; }

        [StringLength(300)]
        public string FILEPATH { get; set; }

        public long? DISPLAY { get; set; }

        public DateTime? SUBMISSIONDATE { get; set; }

        [StringLength(100)]
        public string STANDARDNAME { get; set; }

        [StringLength(150)]
        public string DIVISIONNAME { get; set; }

        public string SUBJECTNAME { get; set; }

        [StringLength(50)]
        public string EMPLOYEENAME { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }
    }
}
