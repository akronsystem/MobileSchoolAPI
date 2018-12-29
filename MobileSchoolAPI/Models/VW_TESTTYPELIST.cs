namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_TESTTYPELIST
    {
        [Key]
        public long UNITID { get; set; }

        public string TESTNAME { get; set; }
    }
}
