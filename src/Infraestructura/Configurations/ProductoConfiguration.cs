using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasIndex(m => m.Nombre)
           .IsUnique()
           .HasDatabaseName("IX_Producto_Nombre")
           .HasFilter("[IsDeleted] = 0");

            builder.HasData(
            new Producto { ID = 1, Nombre = "Camiseta Titular Manchester United 24/25",
                           Descripcion = @"Camiseta 100 % Poliester, con tecnologia AdiFreeIce, ideal para cual epoca de el año",
                           Precio = 150000.00m, Talle = "M", MarcaId = 1, CategoriaId = 1, CodigoBarra = 123123, Stock = 10, ImagenUrl = "https://placehold.co/603x403" },
            new Producto { ID = 2, Nombre = "Camiseta Titular Mancheste City 24/25",
                           Descripcion = @"Camiseta 100 % Poliester, con tecnologia AdiFreeIce, ideal para cual epoca de el año",
                           Precio = 175000.00m, Talle = "L", MarcaId = 1, CategoriaId = 1, CodigoBarra = 323232, Stock = 10, ImagenUrl = "https://placehold.co/603x403" },
            new Producto
            {
                ID = 3,
                Nombre = "Campera River Plate Retro",
                Descripcion = @"Campera 100 % Algodon, con tecnologia AdiFreeIce, ideal para cualquier epoca de el año",
                Precio = 300000.00m,
                Talle = "XL",
                MarcaId = 2,
                CategoriaId = 8,
                CodigoBarra = 976898,
                Stock = 15,
                ImagenUrl = "https://placehold.co/603x403"
            });
        }
    }
}
