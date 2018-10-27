namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_GET_USER_TYPE
    {
        [Key]
        public long UserId { get; set; }

        [StringLength(20)]
        public string EmpCode { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }
    }
}
