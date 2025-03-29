using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infraestructura.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.Property(x => x.Name).HasColumnName("Nombre");
            builder.Property(x => x.NormalizedName).HasColumnName("NombreNormalizado");

            builder.HasData(
          new Role { Id = Guid.NewGuid().ToString(), Name = "Administrador", NormalizedName = "ADMINISTRADOR", ConcurrencyStamp = null },
          new Role { Id = Guid.NewGuid().ToString(), Name = "Cliente", NormalizedName = "CLIENTE", ConcurrencyStamp = null });
        }
    }
}
