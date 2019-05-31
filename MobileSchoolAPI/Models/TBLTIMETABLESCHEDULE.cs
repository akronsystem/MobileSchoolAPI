namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLTIMETABLESCHEDULE")]
    public partial class TBLTIMETABLESCHEDULE
    {
        [Key]
        public long TIMETABLEID { get; set; }

        public int EMPLOYEEID { get; set; }

        public int STANDARDID { get; set; }

        public int SUBJECTID { get; set; }

        public int BATCHID { get; set; }

        [Required]
        [StringLength(25)]
        public string WORKINGDAYS { get; set; }

        [StringLength(25)]
        public string EDUYEAR { get; set; }

        public int DISPLAY { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }

        public int? CLASSROOMID { get; set; }

        [StringLength(50)]
        public string TIMETABLENAME { get; set; }

        public long? DIVISION { get; set; }

        [StringLength(50)]
        public string ROOMTYPE { get; set; }

        public long? LABBATCH { get; set; }
    }
}
