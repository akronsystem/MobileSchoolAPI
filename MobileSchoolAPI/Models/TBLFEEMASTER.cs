namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLFEEMASTER")]
    public partial class TBLFEEMASTER
    {
        [Key]
        [Column(Order = 0)]
        public long FEEMID { get; set; }

        public int? COURSEID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SUBJECTID { get; set; }

        [StringLength(15)]
        public string TERM { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal AMOUNT { get; set; }

        [StringLength(50)]
        public string CREATEDBY { get; set; }

        public DateTime? CREATEDON { get; set; }

        [StringLength(25)]
        public string UPDATEDBY { get; set; }

        public DateTime? UPDATEDON { get; set; }

        public int? COMPANYID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Display { get; set; }
    }
}
