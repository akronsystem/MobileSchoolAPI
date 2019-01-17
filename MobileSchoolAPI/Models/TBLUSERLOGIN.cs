namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLUSERLOGIN")]
    public partial class TBLUSERLOGIN
    {
        [Key]
        public long UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(20)]
        public string EmpCode { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }

        public int? ROLEID { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }

        [StringLength(10)]
        public string STATUS { get; set; }

        public int? INSTITUTEID { get; set; }

        [StringLength(80)]
        public string IMAGEPATH { get; set; }

        [StringLength(50)]
        public string ISPASSWORDCHANGED { get; set; }
 
        //ADDED NOTMAPPED FIELD
        [NotMapped]
        public string BaseURL { get; set; }
 
        [NotMapped]
        public string DeviceId { get; set; }

        [NotMapped]
        public string DeviceType { get; set; }

        [NotMapped]
        public int HomeworkNotificationUnreadCount { get; set;}

    }
}
