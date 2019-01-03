namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	[Table("ViewGetEmployeeBirthDetail")]
	public partial class ViewGetEmployeeBirthDetail
    {
        [Key]
        public long EMPLOYEEID { get; set; }

        [StringLength(50)]
        public string EMPLOYEENAME { get; set; }

        [StringLength(50)]
        public string IMAGEPATH { get; set; }

        public DateTime? DATEOFBIRTH { get; set; }
    }
}
