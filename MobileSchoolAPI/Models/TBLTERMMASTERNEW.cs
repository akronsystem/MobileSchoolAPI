namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLTERMMASTERNEW")]
    public partial class TBLTERMMASTERNEW
    {
        [Key]
        public long TERMID { get; set; }

        [StringLength(50)]
        public string TERM { get; set; }

        public long? DISPLAY { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }
    }
}
