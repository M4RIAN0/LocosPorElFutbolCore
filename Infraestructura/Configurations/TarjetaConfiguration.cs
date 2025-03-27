using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations
{
    public class TarjetaConfiguration : IEntityTypeConfiguration<Tarjeta>
    {
        public void Configure(EntityTypeBuilder<Tarjeta> builder)
        {
            builder.HasIndex(m => new { m.Nombre, m.BancoId})
           .IsUnique()
           .HasDatabaseName("IX_Tarjeta_Nombre_BancoId"); // Nombre del índice en la base de datos
        }
    }
}
