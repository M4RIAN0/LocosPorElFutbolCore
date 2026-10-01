using Dominio.Entidades;
using Microsoft.AspNetCore.Identity;
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

            var hasher = new PasswordHasher<Usuario>();

            builder.HasData(
                new Usuario
                {
                    Id = "33333333-3333-3333-3333-333333333333", // GUID fijo
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!"), // Contraseña encriptada
                    SecurityStamp = "33333333-3333-3333-3333-333333333333",
                    PhoneNumber = "3814498305",
                    PhoneNumberConfirmed = true
                }
            );
        }
    }
}
