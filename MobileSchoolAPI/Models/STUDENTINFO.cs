namespace MobileSchoolAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MobileSchoolAPI.Models;

    public partial class STUDENTINFO : DbContext
    {
        public STUDENTINFO()
            : base("name=STUDENTINFO")
        {
        }

        public virtual DbSet<VW_STUDENT_INFO> VW_STUDENT_INFO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
