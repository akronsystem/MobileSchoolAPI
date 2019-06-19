namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLLEAVEMASTER")]
    public partial class TBLLEAVEMASTER
    {
        [Key]
        public long LEAVEID { get; set; }

        public long? LEAVETYPE { get; set; }

        public int? EMPLOYEEID { get; set; }

        public DateTime? FROMDATE { get; set; }

        public DateTime? TODATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NOOFDAYS { get; set; }

        public string REASON { get; set; }

        [StringLength(20)]
        public string ACADEMICYEAR { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        [StringLength(20)]
        public string CreationTime { get; set; }

        [StringLength(50)]
        public string PRINCIPALSTATUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SANCTIONEDNOOFDAYS { get; set; }

        [StringLength(50)]
        public string SANCTIONREASON { get; set; }

        public DateTime? PRINCIPALUPDATEDATE { get; set; }

        [StringLength(20)]
        public string PRINCIPALUPDATETIME { get; set; }

        public int? DISPLAY { get; set; }

        [StringLength(30)]
        public string SUBSTITUTEID { get; set; }

        [StringLength(20)]
        public string SUBSTITUTESTATUS { get; set; }

        public long? SUBSTITUTEUPDATEDID { get; set; }

        public DateTime? SUBSTITUTEUPDATEDATE { get; set; }

        [StringLength(15)]
        public string SUBSTITUEUPDATETIME { get; set; }

        public long? SUBSTITUTEDISAPPROVEDID { get; set; }

        public int? MONTH { get; set; }
    }
}
