using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasIndex(m => m.Descripcion)
          .IsUnique()
          .HasDatabaseName("IX_Categoria_Descripcion"); // Nombre del índice en la base de datos

            builder.HasData(
           new Categoria
           {
               ID = 1,
               Descripcion = "Camisetas Futbol"
           },
           new Categoria
           {
               ID = 2,
               Descripcion = "Shorts"
           },
           new Categoria
           {
               ID = 3,
               Descripcion = "Pantalones"
           },
           new Categoria
           {
               ID = 4,
               Descripcion = "Camperas"
           },
           new Categoria
           {
               ID = 5,
               Descripcion = "Zapatillas"
           });

        }
    }
}
