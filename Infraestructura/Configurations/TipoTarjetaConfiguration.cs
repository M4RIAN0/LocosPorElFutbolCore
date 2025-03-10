using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations
{
    public class TipoTarjetaConfiguration : IEntityTypeConfiguration<TipoTarjeta>
    {
        public void Configure(EntityTypeBuilder<TipoTarjeta> builder)
        {
            builder.HasData(
            new TipoTarjeta { ID = 1, Tipo = "Credito" },
            new TipoTarjeta { ID = 2, Tipo = "Debito" });
        }
    }
}
