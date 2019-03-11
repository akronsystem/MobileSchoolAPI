
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
   

    
    public partial class SoapContext : DbContext
    {
        public SoapContext()
            : base("name=SoapContext")
        {
        }
   
    public virtual DbSet<View_GetFeeSettings> View_GetFeeSettings { get; set; }
    public virtual DbSet<View_GetConcessionDetails> View_GetConcessionDetails { get; set; }
    public virtual DbSet<View_GetPaidFees> View_GetPaidFees { get; set; }

    public virtual DbSet<View_GetFeeData> View_GetFeeData { get; set; }

    public virtual DbSet<View_GETFEDERALREQUESTID> View_GETFEDERALREQUESTID { get; set; }

    public virtual DbSet<TBLFEDERALREQUESTDETAIL> TBLFEDERALREQUESTDETAILS { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<View_GetFeeSettings>()
                .Property(e => e.AMOUNT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<View_GetFeeSettings>()
                .Property(e => e.INSTALLMENTFINE)
                .HasPrecision(18, 0);
        }
    }

