namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLGRADEMASTER")]
    public partial class TBLGRADEMASTER
    {
        [Key]
        public long GRADEID { get; set; }

        public long? MARKSFROM { get; set; }

        public long? MARKSTO { get; set; }

        [StringLength(50)]
        public string GRADE { get; set; }

        public long? DISPLAY { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }
    }
}
