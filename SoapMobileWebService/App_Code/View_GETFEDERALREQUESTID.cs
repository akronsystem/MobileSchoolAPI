   using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GETFEDERALREQUESTID
    {
        [Key]
        public long BANKREQUESTID { get; set; }

        public string REQUESTID { get; set; }
    }

