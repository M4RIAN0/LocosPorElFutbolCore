using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infraestructura.Configurations
{
    public class PersonaClienteConfiguration : IEntityTypeConfiguration<PersonaCliente>
    {
        public void Configure(EntityTypeBuilder<PersonaCliente> builder)
        {
            builder.HasIndex(m => new { m.Nombre, m.Apellido, m.Dni })
            .IsUnique()
            .HasDatabaseName("IX_PersonaCliente_Nombre_Apellido_Dni");

            builder.HasData(
               new PersonaCliente
               {
                   ID = 1,
                   Apellido = "Martinez Melek",
                   Nombre = "Maria Lourdes",
                   Dni = "39140888",
                   Direccion = "Matienzo 1870, Planta baja B, San Miguel de Tucumán, Tucumán",
                   Sexo = "Femenino",
                   FechaNacimiento = DateOnly.FromDateTime(new DateTime(1995, 8, 12)),
                   Celular = "3814498305",
                   Email = "admin@gmail.com"
               }
            );
        }
    }
}