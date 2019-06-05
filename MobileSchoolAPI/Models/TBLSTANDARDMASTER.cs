namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLSTANDARDMASTER")]
    public partial class TBLSTANDARDMASTER
    {
        [Key]
        public long STANDARDID { get; set; }

        [StringLength(100)]
        public string STANDARDNAME { get; set; }

        public long? SECTIONID { get; set; }

        public long? COMPANYID { get; set; }

        public long? CREATEDID { get; set; }

        [StringLength(50)]
        public string CREATEDON { get; set; }

        public long? DISPLAY { get; set; }
    }
}
