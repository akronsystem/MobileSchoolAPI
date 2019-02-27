namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWGENERALNOTIFICATION")]
    public partial class VIEWGENERALNOTIFICATION
    {
        public string TITLE { get; set; }

        public DateTime? NOTIFICATIONDATE { get; set; }

        [StringLength(50)]
        public string NOTIFICATIONTIME { get; set; }

        public long? STUDENTID { get; set; }

        public long? STATUS { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long NOTIFICATIONID { get; set; }


        public long UserId { get; set; }

        public string NOTIFICATIONTYPE { get; set; }
    }
}
