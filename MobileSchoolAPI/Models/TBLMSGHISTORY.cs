namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLMSGHISTORY")]
    public partial class TBLMSGHISTORY
    {
        [Key]
        public long HISTID { get; set; }

        public DateTime? DATE { get; set; }

        [StringLength(50)]
        public string TIME { get; set; }

        public long? STUDENTID { get; set; }

        public string MSG { get; set; }

        [StringLength(50)]
        public string TYPE { get; set; }

        public long? CREATEDID { get; set; }

        public long? DISPLAY { get; set; }

        public long? EMPLOYEEID { get; set; }

        [StringLength(10)]
        public string TOEMPID { get; set; }

        public long? FROMEMPID { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }

        public string ATTACHMENTS { get; set; }

        public string SUBJECT { get; set; }

        [StringLength(5)]
        public string InStatus { get; set; }

        [StringLength(5)]
        public string OutStatus { get; set; }

        [StringLength(15)]
        public string OtherNos { get; set; }

        public long? ALUMNIID { get; set; }

        [StringLength(100)]
        public string REQUESTID { get; set; }
    }
}
