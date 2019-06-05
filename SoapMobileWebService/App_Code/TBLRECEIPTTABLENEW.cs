   using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLRECEIPTTABLENEW")]
    public partial class TBLRECEIPTTABLENEW
    {
        [Key]
        public int RECEIPTID { get; set; }

        public string RECEIPTNO { get; set; }

        [StringLength(50)]
        public string STUDENTID { get; set; }

        [StringLength(20)]
        public string ACADEMICYEAR { get; set; }
    }

