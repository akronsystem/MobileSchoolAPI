namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLLEAVETYPEMASTER")]
    public partial class TBLLEAVETYPEMASTER
    {
        [Key]
        public long LEAVETYPEID { get; set; }

        [StringLength(150)]
        public string TYPE { get; set; }

        public long? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public long? DISPLAY { get; set; }

        public long? EMPLOYEETYPEID { get; set; }

        public long? DAYS { get; set; }

        [StringLength(50)]
        public string ACADEMICYEAR { get; set; }
    }
}
