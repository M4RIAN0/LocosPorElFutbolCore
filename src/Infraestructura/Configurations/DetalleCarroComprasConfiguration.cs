using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations
{
    public class DetalleCarroComprasConfiguration : IEntityTypeConfiguration<DetalleCarroCompra>
    {
        public void Configure(EntityTypeBuilder<DetalleCarroCompra> builder)
        {
            builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }
}
