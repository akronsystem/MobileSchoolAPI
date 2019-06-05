namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWNOTIFICATIONGEN")]
    public partial class VIEWNOTIFICATIONGEN
    {
        [Key]
        public long NOTIFICATIONID { get; set; }

        public string TITLE { get; set; }

        public DateTime? NOTIFICATIONDATE { get; set; }

        [StringLength(50)]
        public string NOTIFICATIONTIME { get; set; }

        public string EMPLOYEEID { get; set; }

        public long? STUDENTID { get; set; }

        public long? DIVISIONID { get; set; }

        public long? COURSEID { get; set; }

        [StringLength(50)]
        public string INSTITUTECODE { get; set; }

        [StringLength(50)]
        public string ACADEMICYEAR { get; set; }

        [StringLength(50)]
        public string NOTIFICATIONTYPE { get; set; }

        public long? COURSEYEARID { get; set; }

        [StringLength(50)]
        public string SEMESTER { get; set; }

        [StringLength(50)]
        public string CurrentTime { get; set; }
    }
}
