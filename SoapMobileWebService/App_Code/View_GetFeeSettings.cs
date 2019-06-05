
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GetFeeSettings
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long FEESETTINGID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long FEESETTINGDID { get; set; }

        public DateTime? DUEDATE { get; set; }

        [StringLength(50)]
        public string FEETYPE { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long FEETYPEID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AMOUNT { get; set; }

        public long? STANDARDID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? INSTALLMENTFINE { get; set; }

        public long? BOARDID { get; set; }

        [StringLength(60)]
        public string ENROLLMENTNO { get; set; }

        [StringLength(40)]
        public string ACADEMICYEAR { get; set; }
    }

