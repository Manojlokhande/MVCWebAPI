namespace WebAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBRepository : DbContext
    {
        public DBRepository()
            : base("name=Model1")
        {
        }

        public virtual DbSet<TBL_USER> TBL_USER { get; set; }
        public virtual DbSet<TBL_EMPLOYEE> TBL_EMPLOYEE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBL_USER>()
                .Property(e => e.LOGIN)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_USER>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_USER>()
                .Property(e => e.DESIGNATION)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_USER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_USER>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_USER>()
                .Property(e => e.DEPARTMENT)
                .IsUnicode(false);


            modelBuilder.Entity<TBL_EMPLOYEE>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_EMPLOYEE>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_EMPLOYEE>()
               .Property(e => e.GENDER).IsUnicode(false);

            modelBuilder.Entity<TBL_EMPLOYEE>()
                .Property(e => e.SALARY);

        }
    }
}
