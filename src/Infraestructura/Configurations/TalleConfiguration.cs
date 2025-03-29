using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations
{
    public class TalleConfiguration : IEntityTypeConfiguration<Talle>
    {
        public void Configure(EntityTypeBuilder<Talle> builder)
        {
            builder.HasData(
           new Talle
           {
               ID = 1,
               Numero = 36,
               Letra = "XS"
           },
           new Talle
           {
               ID = 2,
               Numero = 38,
               Letra = "S"
           },
           new Talle
           {
               ID = 3,
               Numero = 40,
               Letra = "M"
           },
           new Talle
           {
               ID = 4,
               Numero = 42,
               Letra = "L"
           },
           new Talle
           {
               ID = 5,
               Numero = 44,
               Letra = "XL"
           },
           new Talle
           {
               ID = 6,
               Numero = 46,
               Letra = "XXL"
           });

        }
    }
}
