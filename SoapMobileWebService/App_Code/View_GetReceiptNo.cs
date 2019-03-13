
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GetReceiptNo
    {
        [Key]
        public int RECEIPTID { get; set; }

        public string RECEIPTNO { get; set; }
    }

