namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Communiation
    {
        [StringLength(50)]
        public string EMPLOYEENAME { get; set; }

        [StringLength(11)]
        public string MOBILENO { get; set; }

        [StringLength(50)]
        public string IMAGEPATH { get; set; }

        [StringLength(50)]
        public string EDUYEAR { get; set; }

        public int? DISPLAY { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EMPLOYEEID { get; set; }

        public long? STANDARDID { get; set; }

        public long? DIVISIONID { get; set; }
    }
}
