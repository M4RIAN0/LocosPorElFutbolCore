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
                 new Role { Id = "11111111-1111-1111-1111-111111111111", Name = "Administrador", NormalizedName = "ADMINISTRADOR", ConcurrencyStamp = "11111111-1111-1111-1111-111111111111" },
                 new Role { Id = "22222222-2222-2222-2222-222222222222", Name = "Cliente", NormalizedName = "CLIENTE", ConcurrencyStamp = "22222222-2222-2222-2222-222222222222" }
            );
        }
    }
}
