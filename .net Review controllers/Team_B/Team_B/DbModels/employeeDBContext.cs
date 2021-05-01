using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Team_B.DbModels
{
    public partial class employeeDBContext : DbContext
    {
        public employeeDBContext()
        {
        }

        public employeeDBContext(DbContextOptions<employeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmpLogin> EmpLogin { get; set; }
        public virtual DbSet<ProfileData> ProfileData { get; set; }
        public virtual DbSet<Review> Review { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CYG328\\SQLEXPRESS;Database=employeeDB;Trusted_Connection=True;");
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
                    .HasConstraintName("FK__profileDa__EmpId__74AE54BC");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.Rid);

                entity.ToTable("review");

                entity.Property(e => e.Rid).HasColumnName("RID");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.PromotionCycle)
                    .HasColumnName("Promotion_Cycle")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QaName)
                    .HasColumnName("QA_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RName)
                    .HasColumnName("R_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReviewCycle)
                    .HasColumnName("Review_Cycle")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReviewName)
                    .HasColumnName("reviewName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RqEffect)
                    .HasColumnName("RQ_Effect")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.RqEffectStatus)
                    .HasColumnName("RQ_Effect_Status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RqFeed)
                    .HasColumnName("RQ_Feed")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.RqFeedStatus)
                    .HasColumnName("RQ_Feed_Status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RqGrowth)
                    .HasColumnName("RQ_Growth")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.RqGrowthStatus)
                    .HasColumnName("RQ_Growth_Status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RqLead)
                    .HasColumnName("RQ_Lead")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.RqLeadStatus)
                    .HasColumnName("RQ_Lead_Status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SelfEffect)
                    .HasColumnName("Self_Effect")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.SelfEffectStatus)
                    .HasColumnName("Self_Effect_Status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SelfFeed)
                    .HasColumnName("Self_Feed")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.SelfFeedStatus)
                    .HasColumnName("Self_Feed_Status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SelfGrowth)
                    .HasColumnName("Self_Growth")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.SelfGrowthStatus)
                    .HasColumnName("Self_Growth_Status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SelfLead)
                    .HasColumnName("Self_Lead")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.SelfLeadStatus)
                    .HasColumnName("Self_Lead_Status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TargetDate)
                    .HasColumnName("Target_Date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__review__EmpID__778AC167");
            });
        }
    }
}
