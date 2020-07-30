using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarketTestApi.Models
{
    public partial class TestMarkelContext : DbContext
    {
        public TestMarkelContext()
        {
        }

        public TestMarkelContext(DbContextOptions<TestMarkelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClaimType> ClaimType { get; set; }
        public virtual DbSet<Claims> Claims { get; set; }
        public virtual DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-C09JVA0\\SQLEXPRESS;Database=TestMarkel;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimType>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Claims>(entity =>
            {
                entity.HasKey(e => e.Ucr);

                entity.Property(e => e.Ucr)
                    .HasColumnName("UCR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AssuredName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClaimDate).HasColumnType("datetime");

                entity.Property(e => e.IncurredClass).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.LossDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsuranceEndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
