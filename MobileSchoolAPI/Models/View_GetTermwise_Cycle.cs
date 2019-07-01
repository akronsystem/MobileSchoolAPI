namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GetTermwise_Cycle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UNITID { get; set; }

        [StringLength(50)]
        public string ACADEMICYEAR { get; set; }

        public string TESTNAME { get; set; }

        public long? DISPLAY { get; set; }

        [StringLength(50)]
        public string TERM { get; set; }

        public long? Term_ID { get; set; }
    }
}
