using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infraestructura.Configurations
{
    public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.HasIndex(m => m.Descripcion)  
           .IsUnique()                   
           .HasDatabaseName("IX_Marca_Descripcion"); // Nombre del índice en la base de datos

            builder.HasData(
            new Marca
            {
                ID = 1,
                Descripcion = "Nike"
            },
            new Marca
            {
                ID = 2,
                Descripcion = "Adidas"
            },
            new Marca
            {
                ID = 3,
                Descripcion = "Fila"
            },
            new Marca
            {
                ID = 4,
                Descripcion = "Topper"
            },
            new Marca
            {
                ID = 5,
                Descripcion = "Reebok"
            },
            new Marca
            {
                ID = 6,
                Descripcion = "Umbro"
            },
            new Marca
            {
                ID = 7,
                Descripcion = "Puma"
            });

        }
    }
}
