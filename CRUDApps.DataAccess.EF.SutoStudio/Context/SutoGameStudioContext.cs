using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CRUDApps.DataAccess.EF.SutoStudio.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CRUDApps.DataAccess.EF.SutoStudio.Context
{
    public partial class SutoGameStudioContext : DbContext
    {
        public SutoGameStudioContext()
        {
        }

        public SutoGameStudioContext(DbContextOptions<SutoGameStudioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fpsblasts> Fpsblasts { get; set; }
        public virtual DbSet<Mmoslashers> Mmoslashers { get; set; }
        public virtual DbSet<RpgstoryMakers> RpgstoryMakers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;DataBase=SutoGameStudio;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fpsblasts>(entity =>
            {
                entity.ToTable("FPSBlast");

                entity.HasKey(e => e.FpsblastId);
                entity.Property(e => e.FpsblastId).HasColumnName("FPSBlastId");

                entity.Property(e => e.Expansion1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OwnFpsblastGame)
                    .HasColumnName("OwnFPSBlastGame")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Mmoslashers>(entity =>
            {
                entity.ToTable("MMOSlasher");

                entity.HasKey(e => e.MmoslasherId);

                entity.Property(e => e.MmoslasherId).HasColumnName("MMOSlasherId");

                entity.Property(e => e.ActiveLast30Days)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Expansion1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OwnMmoslasherGame)
                    .HasColumnName("OwnMMOSlasherGame")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RpgstoryMakers>(entity =>
            {
                entity.ToTable("RPGStoryMaker");

                entity.HasKey(e => e.RpgstoryMakerId);

                entity.Property(e => e.RpgstoryMakerId).HasColumnName("RPGStoryMakerId");

                entity.Property(e => e.GameCompleted)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OwnRpgstoryMakerGame)
                    .HasColumnName("OwnRPGStoryMakerGame")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId); 

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerFirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerLastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerState)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
