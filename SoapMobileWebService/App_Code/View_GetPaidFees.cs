
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GetPaidFees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long COLLECTIONID { get; set; }

        [StringLength(200)]
        public string STUDENTNAME { get; set; }

        [StringLength(50)]
        public string FEETYPE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AMOUNT { get; set; }

        [StringLength(40)]
        public string ENROLLMENTNO { get; set; }

        [StringLength(20)]
        public string ACADEMICYEAR { get; set; }
    }

