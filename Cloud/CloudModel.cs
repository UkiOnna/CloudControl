namespace Cloud
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CloudModel : DbContext
    {
        public CloudModel()
            : base("name=CloudModel")
        {
        }

        public virtual DbSet<FileBase> FileBase { get; set; }
        public virtual DbSet<Userr> Userr { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Userr>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .HasMany(e => e.FileBase)
                .WithRequired(e => e.Userr)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
