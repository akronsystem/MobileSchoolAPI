namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_EMPLOYEE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(90)]
        public string EMAIL { get; set; }

        [StringLength(11)]
        public string MOBILE { get; set; }

        [StringLength(10)]
        public string GENDER { get; set; }

        [StringLength(50)]
        public string IMAGEPATH { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }
    }
}
