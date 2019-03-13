   using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLFEECOLLECTIONNKVS")]
    public partial class TBLFEECOLLECTIONNKV
    {
        [Key]
        public long COLLECTIONID { get; set; }

        [StringLength(40)]
        public string ENROLLMENTNO { get; set; }

        public long? STUDENTID { get; set; }

        public long? STANDARDID { get; set; }

        [StringLength(20)]
        public string ACADEMICYEAR { get; set; }

        public long? FEETYPEID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AMOUNT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FINE { get; set; }

        [StringLength(50)]
        public string PAYMENTTYPE { get; set; }

        public string RECEIPTNO { get; set; }

        [StringLength(20)]
        public string CUSTID { get; set; }

        [StringLength(20)]
        public string PAYMENTSTATUS { get; set; }

        [StringLength(100)]
        public string CHEQUEDDNO { get; set; }

        [StringLength(50)]
        public string BANKNAME { get; set; }

        [StringLength(200)]
        public string BRANCHNAME { get; set; }

        public string UTRNO { get; set; }

        public DateTime? DEPOSITDATE { get; set; }

        [StringLength(100)]
        public string ACCOUNTNAME { get; set; }

        [StringLength(15)]
        public string CREATEDTIME { get; set; }

        [StringLength(10)]
        public string CONCESSION { get; set; }

        public long? CONCESSIONPERCENT { get; set; }

        [StringLength(100)]
        public string CONCESSIONREASON { get; set; }

        public DateTime? CREATEDON { get; set; }

        public long? CREATEDID { get; set; }

        public string OTHERREASON { get; set; }

        public string REQUESTID { get; set; }

        [StringLength(100)]
        public string TRANSACTIONSTATUS { get; set; }

        public DateTime? UPDATEDDATE { get; set; }
    }

