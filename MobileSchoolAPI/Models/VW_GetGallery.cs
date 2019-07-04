namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_GetGallery
    {
        [Key]
        public long MYALBUMID { get; set; }

        public string ALBUMNAME { get; set; }

        public string IMAGEPATH { get; set; }

        public DateTime? CREATEDON { get; set; }

        [StringLength(50)]
        public string EDUYEAR { get; set; }
    }
}
