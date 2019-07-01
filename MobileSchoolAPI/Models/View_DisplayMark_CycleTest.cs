namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_DisplayMark_CycleTest
    {
        [StringLength(5)]
        public string TOTALMARKS { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TESTID { get; set; }

        public long? STANDARDID { get; set; }

        public long? SUBJECTID { get; set; }

        public long? UNITTESTID { get; set; }

        [StringLength(15)]
        public string ACADEMICYEAR { get; set; }

        //[StringLength(10)]
        public string DISPLAY { get; set; }

        public int? DIVISIONID { get; set; }

        public long? TERMID { get; set; }

        public long? STUDENTID { get; set; }
    }
}
