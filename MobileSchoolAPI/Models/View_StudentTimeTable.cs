namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_StudentTimeTable
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TIMETABLEID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EMPLOYEEID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string WORKINGDAYS { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DISPLAY { get; set; }

        [StringLength(25)]
        public string EDUYEAR { get; set; }

        [StringLength(100)]
        public string STANDARDNAME { get; set; }

        public string SUBJECTNAME { get; set; }

        [StringLength(150)]
        public string DIVISIONNAME { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(30)]
        public string BATCHNAME { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(30)]
        public string BATCHTIME { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STANDARDID { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BATCHID { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SUBJECTID { get; set; }

        public long? DIVISION { get; set; }

        [StringLength(50)]
        public string EMPLOYEENAME { get; set; }
    }
}
