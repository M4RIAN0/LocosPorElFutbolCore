using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.Property(x => x.UserName).HasColumnName("NombreUsuario");
            builder.Property(x => x.NormalizedUserName).HasColumnName("NombreUsuarioNormalizado");
            builder.Property(x => x.NormalizedEmail).HasColumnName("EmailNormalizado");
            builder.Property(x => x.EmailConfirmed).HasColumnName("EmailConfirmado");
            builder.Property(x => x.PhoneNumber).HasColumnName("Celular");
            builder.Property(x => x.PhoneNumberConfirmed).HasColumnName("CelularConfirmado");
        }
    }
}
