namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Device
    {
        public int DeviceId { get; set; }

        [Required]
        [StringLength(255)]
        public string DeviceFName { get; set; }

        [Required]
        [StringLength(255)]
        public string DeviceSName { get; set; }

        [StringLength(255)]
        public string DeviceDirection { get; set; }

        [StringLength(255)]
        public string SerialNumber { get; set; }

        [StringLength(255)]
        public string ConnectionType { get; set; }

        [StringLength(255)]
        public string IpAddress { get; set; }

        [StringLength(255)]
        public string BaudRate { get; set; }

        [Required]
        [StringLength(255)]
        public string CommKey { get; set; }

        [StringLength(255)]
        public string ComPort { get; set; }

        public DateTime? LastLogDownloadDate { get; set; }

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

        [StringLength(50)]
        public string TransactionStamp { get; set; }

        public DateTime? LastPing { get; set; }

        [StringLength(255)]
        public string DeviceType { get; set; }

        [StringLength(255)]
        public string OpStamp { get; set; }

        public int? DownLoadType { get; set; }

        [StringLength(50)]
        public string Timezone { get; set; }

        [StringLength(50)]
        public string DeviceLocation { get; set; }

        [StringLength(50)]
        public string TimeOut { get; set; }
    }
}
