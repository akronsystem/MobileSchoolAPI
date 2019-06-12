namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Timetable
    {
        //[Key]
       // [Column(Order = 0)]
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long TIMETABLEID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EMPLOYEEID { get; set; }

        //[Key]
        //[Column(Order = 2)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int STANDARDID { get; set; }

        //[Key]
        //[Column(Order = 3)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int SUBJECTID { get; set; }

        //[Key]
        //[Column(Order = 4)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int BATCHID { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(25)]
        public string WORKINGDAYS { get; set; }

        [StringLength(25)]
        public string EDUYEAR { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DISPLAY { get; set; }

        public long? DIVISION { get; set; }

        [StringLength(100)]
        public string STANDARDNAME { get; set; }

        public string SUBJECTNAME { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(30)]
        public string BATCHNAME { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(30)]
        public string BATCHTIME { get; set; }
    }
}
