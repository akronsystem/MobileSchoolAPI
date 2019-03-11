
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GetConcessionDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long STUDENTID { get; set; }

        [StringLength(10)]
        public string CONCESSION { get; set; }

        public long? CONCESSIONREASON { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONCESSIONPERCENTAGE { get; set; }

        [StringLength(200)]
        public string STUDENTNAME { get; set; }

        [StringLength(60)]
        public string ENROLLMENTNO { get; set; }

        [StringLength(15)]
        public string ACADEMICYEAR { get; set; }
    }

