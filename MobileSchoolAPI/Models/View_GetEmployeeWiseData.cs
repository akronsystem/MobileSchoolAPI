namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GetEmployeeWiseData
    {
        [StringLength(20)]
        public string late { get; set; }

        [StringLength(20)]
        public string early { get; set; }

        [StringLength(20)]
        public string Intime { get; set; }

        [StringLength(20)]
        public string Outtime { get; set; }

        [StringLength(50)]
        public string EMPLOYEENAME { get; set; }

        [StringLength(11)]
        public string MOBILENO { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EMPLOYEEID { get; set; }
    }
}
