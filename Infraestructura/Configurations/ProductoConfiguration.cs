using Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {

            builder.HasData(
            new Producto { ID = 1, Descripcion = "Camiseta Titular Manchester United 24/25", Precio = 150000.00m, TalleId = 1, MarcaId = 1, CategoriaId = 1, CodigoBarra = 123123, Stock = 10 },
            new Producto { ID = 2, Descripcion = "Camiseta Titular Mancheste City 24/25", Precio = 175000.00m, TalleId = 1, MarcaId = 1, CategoriaId = 1, CodigoBarra = 323232, Stock = 10 });



        }
    }
}
