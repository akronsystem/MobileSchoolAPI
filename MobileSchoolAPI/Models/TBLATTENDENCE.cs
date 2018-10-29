namespace MobileSchoolAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLATTENDENCE")]
    public partial class TBLATTENDENCE
    {
        [Key]
        public long ATTEDANCEID { get; set; }

        public long? STUDENTID { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

        [StringLength(50)]
        public string ROLLNO { get; set; }

        public long ATTEDANCEMID { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }
    }
}
