namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLDeviceRegistration")]
    public partial class TBLDeviceRegistration
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        [StringLength(50)]
        public string DeviceId { get; set; }

        [StringLength(50)]
        public string DeviceType { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? Status { get; set; }
    }
}
