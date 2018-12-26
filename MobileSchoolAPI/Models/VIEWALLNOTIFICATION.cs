namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWALLNOTIFICATION")]
    public partial class VIEWALLNOTIFICATION
    {
        public string TITLE { get; set; }

        [Key]
        [Column(Order = 0)]
        public long NOTIFICATIONID { get; set; }

        public DateTime? NOTIFICATIONDATE { get; set; }

        [StringLength(50)]
        public string NOTIFICATIONTIME { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string STUDENTID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string STATUS { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(1)]
        public string UserType { get; set; }
    }
}
