namespace MobileSchoolAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
