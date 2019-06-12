namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLFEETYPEMASTER")]
    public partial class TBLFEETYPEMASTER
    {
        [Key]
        [Column(Order = 0)]
        public long FEETYPEID { get; set; }

        [StringLength(50)]
        public string FEETYPE { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Display { get; set; }

        [StringLength(2)]
        public string STATUS { get; set; }
    }
}
