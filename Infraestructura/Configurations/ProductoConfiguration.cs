using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasIndex(m => m.Descripcion)
           .IsUnique()
           .HasDatabaseName("IX_Producto_Descripcion"); // Nombre del índice en la base de datos

            builder.HasData(
            new Producto { ID = 1, Descripcion = "Camiseta Titular Manchester United 24/25", Precio = 150000.00m, TalleId = 1, MarcaId = 1, CategoriaId = 1, CodigoBarra = 123123, Stock = 10 },
            new Producto { ID = 2, Descripcion = "Camiseta Titular Mancheste City 24/25", Precio = 175000.00m, TalleId = 1, MarcaId = 1, CategoriaId = 1, CodigoBarra = 323232, Stock = 10 });
        }
    }
}
