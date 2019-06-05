namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_RemainingFeeDisplay
    {
        [Column(TypeName = "numeric")]
        public decimal? AMOUNT { get; set; }

        public long? STUDENTID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int COLLECTIONID { get; set; }
    }
}
