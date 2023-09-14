using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> Builder)
        {
            Builder.ToTable("User");
            Builder.Property(p => p.Id)
            .IsRequired();
            
            Builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("UserName")
            .HasMaxLength(50);

            Builder.Property(p => p.Email)
                .IsRequired()
                .IsRequired();
        
            Builder.Property(p => p.Password)
            .HasColumnName("password")

            .HasMaxLength(255)
            .IsRequired();

            Builder.HasMany(p => p.Rols)
            .WithMany(p => p.Users)
            .UsingEntity<UserRol>(
                 j => j
                .HasOne(p => p.Rol)
                .WithMany(p => p.UsersRols)
                .HasForeignKey(p => p.IdRolFk),
                 j => j
                .HasOne(p => p.User)
                .WithMany(p => p.UsersRols)
                .HasForeignKey(p => p.IdUserFk),
                j => 
                {
                    j.ToTable("userRol");
                    j.HasKey(t => new {t.IdRolFk, t.IdUserFk});
                }
            );
            Builder.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.IdUserFk);
        }
    }
