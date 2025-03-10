using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations
{
    public class ProvinciaConfiguration : IEntityTypeConfiguration<Provincia>
    {
        public void Configure(EntityTypeBuilder<Provincia> builder)
        {
            builder.HasData(
            new Provincia { ID = 1, Nombre = "Buenos Aires" },
            new Provincia { ID = 2, Nombre = "Catamarca	" },
            new Provincia { ID = 3, Nombre = "Chaco" },
            new Provincia { ID = 4, Nombre = "Chubut" },
            new Provincia { ID = 5, Nombre = "Cordoba" },
            new Provincia { ID = 6, Nombre = "Corrientes" },
            new Provincia { ID = 7, Nombre = "Entre Ríos" },
            new Provincia { ID = 8, Nombre = "Formosa" },
            new Provincia { ID = 9, Nombre = "Jujuy" },
            new Provincia { ID = 10, Nombre = "La Pampa" },
            new Provincia { ID = 11, Nombre = "La Rioja" },
            new Provincia { ID = 12, Nombre = "Mendoza" },
            new Provincia { ID = 13, Nombre = "Misiones" },
            new Provincia { ID = 14, Nombre = "Neuquén" },
            new Provincia { ID = 15, Nombre = "Río Negro" },
            new Provincia { ID = 16, Nombre = "Salta" },
            new Provincia { ID = 17, Nombre = "San Juan" },
            new Provincia { ID = 18, Nombre = "San Luis" },
            new Provincia { ID = 19, Nombre = "Santa Cruz" },
            new Provincia { ID = 20, Nombre = "Santa Fe" },
            new Provincia { ID = 21, Nombre = "Santiago del Estero" },
            new Provincia { ID = 22, Nombre = "Tierra del Fuego" },
            new Provincia { ID = 23, Nombre = "Tucumán" });
        }
    }
}
