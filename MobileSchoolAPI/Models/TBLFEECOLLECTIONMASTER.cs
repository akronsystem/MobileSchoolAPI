namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLFEECOLLECTIONMASTER")]
    public partial class TBLFEECOLLECTIONMASTER
    {
        [Key]
        public int COLLECTIONID { get; set; }

        public long? STUDENTID { get; set; }

        [StringLength(50)]
        public string ENROLLMENTNO { get; set; }

        public long? STANDARDID { get; set; }

        [StringLength(15)]
        public string ACADEMICYEAR { get; set; }

        public DateTime? PAYMENTDATE { get; set; }

        [StringLength(50)]
        public string CREATEDID { get; set; }

        [StringLength(50)]
        public string PAYMENTTYPE { get; set; }

        public string RECEIPRNO { get; set; }

        public int? DISPLAY { get; set; }

        [StringLength(20)]
        public string CUSTID { get; set; }

        [StringLength(20)]
        public string PAYMENTSTATUS { get; set; }

        [StringLength(200)]
        public string CHEQUEDDNO { get; set; }

        [StringLength(200)]
        public string BANKNAME { get; set; }

        [StringLength(200)]
        public string BRANCHNAME { get; set; }

        [StringLength(100)]
        public string UTRNO { get; set; }

        public DateTime? DEPOSITDATE { get; set; }

        [StringLength(100)]
        public string ACCOUNTNAME { get; set; }

        [StringLength(100)]
        public string SCHOOLRECEIPTNO { get; set; }
    }
}
