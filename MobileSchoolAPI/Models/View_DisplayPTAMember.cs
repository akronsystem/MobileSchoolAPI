namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_DisplayPTAMember
    {
        public int? PTAMASTERID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PTADETAILID { get; set; }

        [StringLength(50)]
        public string MEMBERNAME { get; set; }

        [StringLength(50)]
        public string MOBILENO { get; set; }

        [StringLength(50)]
        public string DESIGNATION { get; set; }

        [StringLength(50)]
        public string NOMINEEFROM { get; set; }
    }
}
