using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CrowdFunding.DAL;

namespace CrowdFunding.DAL.Context
{
    public partial class CrowdfundingContext : DbContext
    {
        public CrowdfundingContext()
        {
        }

        public CrowdfundingContext(DbContextOptions<CrowdfundingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<ParameterHistory> ParameterHistories { get; set; } = null!;
        public virtual DbSet<Pledge> Pledges { get; set; } = null!;
        public virtual DbSet<PrivateMessage> PrivateMessages { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectCategory> ProjectCategories { get; set; } = null!;
        public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; } = null!;
        public virtual DbSet<ProjectStatusHistory> ProjectStatusHistories { get; set; } = null!;
        public virtual DbSet<Reward> Rewards { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CLE05PR;Database=CrowdFunding;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.Property(e => e.Created).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Text).HasMaxLength(4000);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Article_Project");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Created).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Text).HasMaxLength(1000);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Member");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Project");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.HasIndex(e => e.Name, "UK_Country_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(56)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.HasIndex(e => e.Email, "UK_Member_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UK_Member_Username")
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Created).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Email).HasMaxLength(320);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(97)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Member_Country");
            });

            modelBuilder.Entity<ParameterHistory>(entity =>
            {
                entity.ToTable("ParameterHistory");

                entity.Property(e => e.Created).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Goal).HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ParameterHistories)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParameterHistory_Project");
            });

            modelBuilder.Entity<Pledge>(entity =>
            {
                entity.ToTable("Pledge");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Created).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Pledges)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pledge_Member");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Pledges)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pledge_Project");
            });

            modelBuilder.Entity<PrivateMessage>(entity =>
            {
                entity.ToTable("PrivateMessage");

                entity.Property(e => e.Created).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Text).HasMaxLength(1000);

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.PrivateMessageRecipients)
                    .HasForeignKey(d => d.RecipientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrivateMessage_Recipient");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.PrivateMessageSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrivateMessage_Sender");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Created).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Goal).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_Member");

                entity.HasOne(d => d.ProjectCategory)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_ProjectCategory");

                entity.HasOne(d => d.ProjectStatus)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_ProjectStatus");
            });

            modelBuilder.Entity<ProjectCategory>(entity =>
            {
                entity.ToTable("ProjectCategory");

                entity.HasIndex(e => e.Name, "UK_ProjectCategory_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectStatus>(entity =>
            {
                entity.ToTable("ProjectStatus");

                entity.HasIndex(e => e.Name, "CK_ProjectStatus_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectStatusHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProjectStatusHistory");

                entity.Property(e => e.Created).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Project)
                    .WithMany()
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectStatusHistory_Project");

                entity.HasOne(d => d.ProjectStatus)
                    .WithMany()
                    .HasForeignKey(d => d.ProjectStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectStatusHistory_ProjectStatus");
            });

            modelBuilder.Entity<Reward>(entity =>
            {
                entity.ToTable("Reward");

                entity.Property(e => e.Created).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Delivery).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("smallmoney");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Rewards)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reward_Project");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
