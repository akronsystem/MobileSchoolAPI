namespace MobileSchoolAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_EMPLOYEE
    {
        [Key]
        public long EMPLOYEEID { get; set; }

        [StringLength(50)]
        public string EMPLOYEENAME { get; set; }

        public long? DEPARTMENTID { get; set; }

        [StringLength(11)]
        public string MOBILENO { get; set; }

        [StringLength(50)]
        public string IMAGEPATH { get; set; }

        [StringLength(50)]
        public string EMPCODE { get; set; }
    }
}
