namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DeviceLog
    {
        [Key]
        [Column(Order = 0)]
        public int DeviceLogId { get; set; }

        public DateTime? DownloadDate { get; set; }

        public int DeviceId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime LogDate { get; set; }

        [StringLength(255)]
        public string Direction { get; set; }

        [StringLength(255)]
        public string AttDirection { get; set; }

        [StringLength(255)]
        public string C1 { get; set; }

        [StringLength(255)]
        public string C2 { get; set; }

        [StringLength(255)]
        public string C3 { get; set; }

        [StringLength(255)]
        public string C4 { get; set; }

        [StringLength(255)]
        public string C5 { get; set; }

        [StringLength(255)]
        public string C6 { get; set; }

        [StringLength(255)]
        public string C7 { get; set; }

        [StringLength(255)]
        public string WorkCode { get; set; }
    }
}
