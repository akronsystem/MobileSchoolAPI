namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLMESSAGEHISTORY")]
    public partial class TBLMESSAGEHISTORY
    {
        [StringLength(10)]
        public string ROLLNO { get; set; }

        [StringLength(50)]
        public string STUDENTNAME { get; set; }

        [StringLength(15)]
        public string SUBJECT { get; set; }

        [StringLength(15)]
        public string PMOBILE { get; set; }

        [StringLength(15)]
        public string SMOBILE { get; set; }

        public DateTime? SENDDATE { get; set; }

        [StringLength(20)]
        public string MESSAGETYPE { get; set; }

        [StringLength(150)]
        public string MESSAGETEXT { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Display { get; set; }

        [StringLength(30)]
        public string EDUYEAR { get; set; }
    }
}
