
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> Builder)
        {
            Builder.ToTable("Rol");
            Builder.Property(p => p.Description)
            .IsRequired()
            .HasColumnType("varchar")
            .HasColumnName("RolNames")
            .HasMaxLength(40);

            Builder.Property(p => p.Id)
                .IsRequired();
            
        }
    }
