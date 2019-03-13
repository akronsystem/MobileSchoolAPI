
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLRECEIPTTABLENEWFEDEREAL")]
    public partial class TBLRECEIPTTABLENEWFEDEREAL
    {
        [Key]
        [Column("RECEIPTID ")]
        public int RECEIPTID_ { get; set; }

        public int? RECEIPTNO { get; set; }

        [StringLength(50)]
        public string STUDENTID { get; set; }

        [StringLength(15)]
        public string ACADEMICYEAR { get; set; }
    }

