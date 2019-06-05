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


        public string TITLE { get; set; }



        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long NOTIFICATIONID { get; set; }

        public DateTime? NOTIFICATIONDATE { get; set; }

        [StringLength(50)]
        public string NOTIFICATIONTIME { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        public long? STUDENTID { get; set; }

        public long? STATUS { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }

        public string NOTIFICATIONTYPE { get; set; }
    }
}
