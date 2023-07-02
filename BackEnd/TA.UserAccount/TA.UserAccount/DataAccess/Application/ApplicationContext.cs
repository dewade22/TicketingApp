using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TA.UserAccount.DataAccess.Application;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ComRole> ComRoles { get; set; }

    public virtual DbSet<ComUserAccount> ComUserAccounts { get; set; }

    public virtual DbSet<ComUserInRole> ComUserInRoles { get; set; }

    public virtual DbSet<ComUserMembership> ComUserMemberships { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComRole>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("PK__com_Role__BDA103F53E0268F2");

            entity.ToTable("com_Roles");

            entity.Property(e => e.Uuid).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.RoleName).HasMaxLength(100);
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<ComUserAccount>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("PK__com_User__BDA103F5D717DF54");

            entity.ToTable("com_UserAccount");

            entity.HasIndex(e => e.EmailAddress, "UQ__com_User__49A14740D888F523").IsUnique();

            entity.Property(e => e.Uuid).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.EmailAddress).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.TimeZoneId).HasMaxLength(100);
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<ComUserInRole>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("PK__com_User__BDA103F581800733");

            entity.ToTable("com_UserInRole");

            entity.Property(e => e.Uuid).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.RoleUuid).HasMaxLength(100);
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.UserUuid).HasMaxLength(100);

            entity.HasOne(d => d.RoleUu).WithMany(p => p.ComUserInRoles)
                .HasForeignKey(d => d.RoleUuid)
                .HasConstraintName("FK_com_UserInRole_To_com_Roles");

            entity.HasOne(d => d.UserUu).WithMany(p => p.ComUserInRoles)
                .HasForeignKey(d => d.UserUuid)
                .HasConstraintName("FK_com_UserInRole_To_com_UserAccount");
        });

        modelBuilder.Entity<ComUserMembership>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("PK__com_User__BDA103F5AD6ED7E9");

            entity.ToTable("com_UserMembership");

            entity.Property(e => e.Uuid).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(200);
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.UserUuid).HasMaxLength(100);

            entity.HasOne(d => d.UserUu).WithMany(p => p.ComUserMemberships)
                .HasForeignKey(d => d.UserUuid)
                .HasConstraintName("FK_com_UserMembership_To_com_UserAccount");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
