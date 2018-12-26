namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewGetInstituteName")]
    public partial class ViewGetInstituteName
    {
        [Key]
        public int REGID { get; set; }

        [StringLength(50)]
        public string INSTITUTE_NAME { get; set; }
    }
}
