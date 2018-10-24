namespace MobileSchoolAPI.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class SchoolContext : DbContext
	{
		public SchoolContext()
			: base("name=SchoolContext")
		{
		}

		public virtual DbSet<TBLUSERLOGIN> TBLUSERLOGINs { get; set; }
        public virtual DbSet<VIEWATTENDANCE> VIEWATTENDANCEs { get; set; }

        public virtual DbSet<VIEWGETSTUDENTATT> VIEWGETSTUDENTATTs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TBLUSERLOGIN>()
				.Property(e => e.EmpCode)
				.IsUnicode(false);

			modelBuilder.Entity<TBLUSERLOGIN>()
				.Property(e => e.ISPASSWORDCHANGED)
				.IsUnicode(false);
		}
	}
}
