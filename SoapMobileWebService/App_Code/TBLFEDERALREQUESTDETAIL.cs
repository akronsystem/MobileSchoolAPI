
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLFEDERALREQUESTDETAILS")]
    public partial class TBLFEDERALREQUESTDETAIL
    {
        [Key]
        public long BANKREQUESTID { get; set; }

        public string REQUESTID { get; set; }

        [StringLength(50)]
        public string ENROLLMENTNO { get; set; }

        public DateTime? REQUESTDATE { get; set; }
    }

