namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWCHECKHOLIDAY")]
    public partial class VIEWCHECKHOLIDAY
    {
        [StringLength(50)]
        public string HOLIDAY { get; set; }

        [Key]
        public long HOLIDAYID { get; set; }

        public int? HOLIDAYDATE { get; set; }

        public DateTime? ENDDATE { get; set; }

        public int? DISPLAY { get; set; }

        public short? NUMBEROFDAYS { get; set; }
    }
}
