namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEWGETUSERIDFROMEMPCODE")]
    public partial class VIEWGETUSERIDFROMEMPCODE
    {
        [Key]
        public long UserId { get; set; }

        [StringLength(20)]
        public string EmpCode { get; set; }
    }
}
