namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_UnreadNotificationCount
    {
        [Key]
        public long NOTIFICATIONDID { get; set; }

        public long? STUDENTID { get; set; }

        public long? STATUS { get; set; }
    }
}
