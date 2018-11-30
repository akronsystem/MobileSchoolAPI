namespace MobileSchoolAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vw_ATTENDANCECHECK
    {
        [Key]
        public long ATTEDANCEMID { get; set; }

        public DateTime? ATTEDANCEDATE { get; set; }

        public long? STANDARDID { get; set; }

        public long? DIVISIONID { get; set; }
    }
}
