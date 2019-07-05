namespace MobileSchoolAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<View_EventHolidayNotification>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<View_EventHolidayNotification>()
                .Property(e => e.ACADEMICYEAR)
                .IsUnicode(false);
        }
    }
}
