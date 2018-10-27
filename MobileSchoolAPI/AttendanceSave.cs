namespace MobileSchoolAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AttendanceSave : DbContext
    {
        public AttendanceSave()
            : base("name=AttendanceSave")
        {
        }

        public virtual DbSet<TBLATTENDENCEMASTER> TBLATTENDENCEMASTERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
