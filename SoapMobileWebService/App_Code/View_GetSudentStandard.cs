
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GetSudentStandard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long STUDENTID { get; set; }

        [StringLength(25)]
        public string STANDARDID { get; set; }

        [StringLength(60)]
        public string ENROLLMENTNO { get; set; }
    }

