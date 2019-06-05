
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GetFeeData
    {
        [Column(TypeName = "numeric")]
        public decimal? PAID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long STUDENTID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string STATUS { get; set; }

        [StringLength(200)]
        public string STUDENTNAME { get; set; }

        [StringLength(25)]
        public string STANDARDID { get; set; }

        [StringLength(60)]
        public string ENROLLMENTNO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TOTALFEES { get; set; }
    }

