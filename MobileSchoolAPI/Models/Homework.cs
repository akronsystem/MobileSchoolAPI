namespace MobileSchoolAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Homework : DbContext
    {
        public Homework()
            : base("name=Homework")
        {
        }

        public virtual DbSet<TBLHOMEWORK> TBLHOMEWORKs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
