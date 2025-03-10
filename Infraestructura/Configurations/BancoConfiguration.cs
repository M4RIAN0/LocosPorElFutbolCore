using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations
{
    public class BancoConfiguration : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {

            builder.HasData(
            new Banco { ID = 1, Nombre = "Nacion" },
            new Banco { ID = 2, Nombre = "Macro" },
            new Banco { ID = 3, Nombre = "BBVA Frances" },
            new Banco { ID = 4, Nombre = "Santander" },
            new Banco { ID = 5, Nombre = "Galicia" },
            new Banco { ID = 6, Nombre = "Santiago Del Estero" },
            new Banco { ID = 7, Nombre = "Galicia Mas" },
            new Banco { ID = 8, Nombre = "Comafi" });

        }
    }
}
