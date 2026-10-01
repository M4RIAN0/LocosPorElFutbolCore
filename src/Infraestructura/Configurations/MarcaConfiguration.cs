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
                Descripcion = "Puma"
            },
            new Marca
            {
                ID = 4,
                Descripcion = "Reebok"
            },
            new Marca
            {
                ID = 5,
                Descripcion = "Dc"
            },
            new Marca
            {
                ID = 6,
                Descripcion = "Vans"
            },
            new Marca
            {
                ID = 7,
                Descripcion = "Adidas-Classic"
            },
            new Marca
            {
                ID = 8,
                Descripcion = "Under-Armour"
            });
        }
    }
}
