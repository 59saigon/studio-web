using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Studio.API.Models;

namespace Studio.API.Context
{
    public partial class StudioContext : DbContext
    {
        public StudioContext()
        {
        }

        public StudioContext(DbContextOptions<StudioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Moment> Moments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moment>(entity =>
            {
                entity.ToTable("Moment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(36)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.MomentId)
                    .HasMaxLength(36)
                    .HasColumnName("momentId")
                    .HasDefaultValueSql("(CONVERT([nvarchar](36),newid()))");

                entity.Property(e => e.Picture).HasColumnName("picture");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Moments)
                    .HasPrincipalKey(p => p.UserId)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Moment_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.HasIndex(e => e.RoleId, "UQ__Role__CD98462BFA0C8F07")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(36)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(36)
                    .HasColumnName("roleId")
                    .HasDefaultValueSql("(CONVERT([nvarchar](36),newid()))");

                entity.Property(e => e.RoleName).HasColumnName("roleName");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.UserId, "UQ__User__CB9A1CFE32F561FE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Avatar).HasColumnName("avatar");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(36)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.FullName).HasColumnName("fullName");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(36)
                    .HasColumnName("roleId");

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .HasColumnName("userId")
                    .HasDefaultValueSql("(CONVERT([nvarchar](36),newid()))");

                entity.Property(e => e.Username).HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasPrincipalKey(p => p.RoleId)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
