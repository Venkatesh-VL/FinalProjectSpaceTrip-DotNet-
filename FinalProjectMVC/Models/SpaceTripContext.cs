using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinalProjectWEBAPI.Models
{
    public partial class SpaceTripContext : DbContext
    {
        public SpaceTripContext()
        {
        }

        public SpaceTripContext(DbContextOptions<SpaceTripContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Userinfo> Userinfos { get; set; }
        public virtual DbSet<Year> Years { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               // optionsBuilder.UseSqlServer("data source=.;initial catalog=SpaceTrip;integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Userinfo>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__userinfo__A9D10535E33075BA");

                entity.ToTable("userinfo");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Asthma)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Diabetes)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Reason).IsRequired();

                entity.Property(e => e.Waitlistno)
                    .IsRequired()
                    .HasMaxLength(107)
                    .HasComputedColumnSql("(concat('ST-',[Years],'-',right(concat('00',[Id]),(3))))", false);

                entity.Property(e => e.Years)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Year>(entity =>
            {
                entity.ToTable("year");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Years).HasColumnName("years");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
