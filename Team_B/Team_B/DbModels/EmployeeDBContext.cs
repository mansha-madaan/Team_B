using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Team_B.DbModels
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmpLogin> EmpLogin { get; set; }
        public virtual DbSet<ProfileData> ProfileData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CYG389;Database=EmployeeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpLogin>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpEmailId)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.EmpPassword)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<ProfileData>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.ToTable("profileData");

                entity.Property(e => e.Pid).HasColumnName("PId");

                entity.Property(e => e.DateJoin)
                    .HasColumnName("Date_Join")
                    .HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Skills)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TotalExp)
                    .HasColumnName("Total_Exp")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ProfileData)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__profileDa__EmpId__5CD6CB2B");
            });
        }
    }
}
