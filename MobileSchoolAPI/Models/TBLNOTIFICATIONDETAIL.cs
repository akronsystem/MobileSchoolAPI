namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLNOTIFICATIONDETAIL")]
    public partial class TBLNOTIFICATIONDETAIL
    {
        [Key]
        public long NOTIFICATIONDID { get; set; }

        public long? NOTIFICATIONID { get; set; }

        public long? STUDENTID { get; set; }

        public long? STATUS { get; set; }
    }
}
