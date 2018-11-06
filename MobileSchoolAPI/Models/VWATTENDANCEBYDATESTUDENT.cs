namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VWATTENDANCEBYDATESTUDENT")]
    public partial class VWATTENDANCEBYDATESTUDENT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        
        public int ATTMONTH { get; set; }


        public DateTime? ATTEDANCEDATE { get; set; }

        public string UserType { get; set; }
    }
}
