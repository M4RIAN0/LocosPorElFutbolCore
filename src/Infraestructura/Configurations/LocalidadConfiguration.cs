using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations
{
    public class LocalidadConfiguration : IEntityTypeConfiguration<Localidad>
    {
        public void Configure(EntityTypeBuilder<Localidad> builder)
        {

            builder.HasData(
            new Localidad { ID = 1, Nombre = "Adolfo Alsina", CP = 6430, ProvinciaId = 1 },
            new Localidad { ID = 2, Nombre = "Avellaneda", CP = 1870, ProvinciaId = 1 },
            new Localidad { ID = 3, Nombre = "San Fernando del Valle de Catamarca", CP = 4751, ProvinciaId = 2 },
            new Localidad { ID = 4, Nombre = "Santa Maria", CP = 4139, ProvinciaId = 2 },
            new Localidad { ID = 5, Nombre = "Resistencia", CP = 3500, ProvinciaId = 3 },
            new Localidad { ID = 6, Nombre = "Barranqueras", CP = 3503, ProvinciaId = 3 },
            new Localidad { ID = 7, Nombre = "Trelew", CP = 9100, ProvinciaId = 4 },
            new Localidad { ID = 8, Nombre = "Puerto Madryn", CP = 9120, ProvinciaId = 4 },
            new Localidad { ID = 9, Nombre = "Carlos Paz", CP = 5152, ProvinciaId = 5 },
            new Localidad { ID = 10, Nombre = "Jesus Maria", CP = 5223, ProvinciaId = 5 },
            new Localidad { ID = 11, Nombre = "Paso de la Patria", CP = 3409, ProvinciaId = 6 },
            new Localidad { ID = 12, Nombre = "Ituzaingo", CP = 3302, ProvinciaId = 6 },
            new Localidad { ID = 13, Nombre = "Parana", CP = 3100, ProvinciaId = 7 },
            new Localidad { ID = 14, Nombre = "Concordia", CP = 3200, ProvinciaId = 7 },
            new Localidad { ID = 15, Nombre = "Las Lomitas", CP = 3630, ProvinciaId = 8 },
            new Localidad { ID = 16, Nombre = "Clorinda", CP = 3610, ProvinciaId = 8 },
            new Localidad { ID = 17, Nombre = "San Salvador de Jujuy", CP = 4600, ProvinciaId = 9 },
            new Localidad { ID = 18, Nombre = "San Pedro", CP = 4500, ProvinciaId = 9 },
            new Localidad { ID = 19, Nombre = "Santa Rosa", CP = 6300, ProvinciaId = 10 },
            new Localidad { ID = 20, Nombre = "General Pico", CP = 6360, ProvinciaId = 10 },
            new Localidad { ID = 21, Nombre = "Chalecito", CP = 5360, ProvinciaId = 11 },
            new Localidad { ID = 22, Nombre = "Alfaro", CP = 26540, ProvinciaId = 11 },
            new Localidad { ID = 23, Nombre = "Godoy Cruz", CP = 5501, ProvinciaId = 12 },
            new Localidad { ID = 24, Nombre = "Lujan de Cuyo", CP = 5507, ProvinciaId = 12 },
            new Localidad { ID = 25, Nombre = "Posadas", CP = 3300, ProvinciaId = 13 },
            new Localidad { ID = 26, Nombre = "Puerto Iguazu", CP = 3370, ProvinciaId = 13 },
            new Localidad { ID = 27, Nombre = "Neuquen", CP = 8300, ProvinciaId = 14 },
            new Localidad { ID = 28, Nombre = "Plottier", CP = 8316, ProvinciaId = 14 },
            new Localidad { ID = 29, Nombre = "General Roca", CP = 8332, ProvinciaId = 15 },
            new Localidad { ID = 30, Nombre = "Cipolletti", CP = 8324, ProvinciaId = 15 },
            new Localidad { ID = 31, Nombre = "Metan", CP = 4440, ProvinciaId = 16 },
            new Localidad { ID = 32, Nombre = "Guemes", CP = 4430, ProvinciaId = 16 },
            new Localidad { ID = 33, Nombre = "Rivadavia", CP = 5400, ProvinciaId = 17 },
            new Localidad { ID = 34, Nombre = "Santa Lucia", CP = 5411, ProvinciaId = 17 },
            new Localidad { ID = 35, Nombre = "Juan Martín de Pueyrredón", CP = 5700, ProvinciaId = 18 },
            new Localidad { ID = 36, Nombre = "San Francisco del Monte de Oro", CP = 5705, ProvinciaId = 18 },
            new Localidad { ID = 37, Nombre = "Río Gallegos", CP = 9400, ProvinciaId = 19 },
            new Localidad { ID = 38, Nombre = "El Calafate", CP = 9405, ProvinciaId = 19 },
            new Localidad { ID = 39, Nombre = "Rosario", CP = 2000, ProvinciaId = 20 },
            new Localidad { ID = 40, Nombre = "Reconquista", CP = 3560, ProvinciaId = 20 },
            new Localidad { ID = 41, Nombre = "Santiago del Estero", CP = 4200, ProvinciaId = 21 },
            new Localidad { ID = 42, Nombre = "La Banda", CP = 4202, ProvinciaId = 21 },
            new Localidad { ID = 43, Nombre = "Ushuaia ", CP = 9410, ProvinciaId = 22 },
            new Localidad { ID = 44, Nombre = "Rio Grande", CP = 9420, ProvinciaId = 22 },
            new Localidad { ID = 45, Nombre = "San Miguel de Tucuman", CP = 4000, ProvinciaId = 23 },
            new Localidad { ID = 46, Nombre = "Yerba Buena", CP = 4001, ProvinciaId = 23 });
        }
    }
}