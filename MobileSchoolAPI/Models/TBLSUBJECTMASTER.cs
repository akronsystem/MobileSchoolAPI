namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLSUBJECTMASTER")]
    public partial class TBLSUBJECTMASTER
    {
        [Key]
        public long SUBJECTID { get; set; }

        public string SUBJECTNAME { get; set; }

        [StringLength(60)]
        public string SUBJECTCODE { get; set; }

        [StringLength(60)]
        public string SHORTNAME { get; set; }

        public long? COMPANYID { get; set; }

        public long? CREATEDID { get; set; }

        [StringLength(50)]
        public string CREATEDON { get; set; }

        public long? DISPLAY { get; set; }

        [StringLength(8)]
        public string COCURRICULARACTIVITY { get; set; }
    }
}
