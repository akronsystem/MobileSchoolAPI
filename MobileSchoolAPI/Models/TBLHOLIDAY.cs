namespace MobileSchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLHOLIDAY")]
    public partial class TBLHOLIDAY
    {
        [Key]
        public long HOLIDAYID { get; set; }

        [StringLength(50)]
        public string HOLIDAY { get; set; }

		[NotMapped]
		public string STR_STARTDATE
		{
			get { return this.STARTDATE.Value.ToString("yyyy-MM-dd"); }
		}

		[NotMapped]
		public string STR_ENDDATE
		{
			get { return this.ENDDATE.Value.ToString("yyyy-MM-dd"); }
		}



		public DateTime? STARTDATE { get; set; }

        public DateTime? ENDDATE { get; set; }

        public string STANDARDNAME { get; set; }

        public short? NUMBEROFDAYS { get; set; }

        public int? COMPANYID { get; set; }

        public int? CREATEDID { get; set; }

        public DateTime? CREATEDON { get; set; }

        public int? UPDATEDID { get; set; }

        public DateTime? UPDATEDON { get; set; }

        public int? DISPLAY { get; set; }

        [StringLength(50)]
        public string TYPE { get; set; }

		[NotMapped]
        [StringLength(20)]
        public string ACADEMICYEAR { get; set; }
    }
}
