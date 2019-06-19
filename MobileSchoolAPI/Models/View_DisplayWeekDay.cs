namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_DisplayWeekDay
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(25)]
        public string WORKINGDAYS { get; set; }

        public int? DayNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DISPLAY { get; set; }
    }
}
