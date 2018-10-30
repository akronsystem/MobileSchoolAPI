namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWNOTIFICATION")]
    public partial class VIEWNOTIFICATION
    {
        [StringLength(50)]
        public string UserType { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        public string TITLE { get; set; }

        public DateTime? NOTIFICATIONDATE { get; set; }

        [StringLength(50)]
        public string NOTIFICATIONTIME { get; set; }

        [StringLength(50)]
        public string NOTIFICATIONTYPE { get; set; }

        public long? STATUS { get; set; }

        public Int64 NOTIFICATIONID { get; set; }

        public Int64 STUDENTID { get; set; }
    }


}
