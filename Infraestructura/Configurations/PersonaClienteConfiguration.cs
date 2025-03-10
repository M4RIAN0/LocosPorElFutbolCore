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
            builder.HasMany(x => x.Facturas)
                   .WithOne(x => x.PersonaCliente)
                   .HasForeignKey(x => x.ClienteId)
                   .IsRequired();

            builder.HasData(
               new PersonaCliente
               {
                   ID = 1,
                   Codigo = 123,
                   Apellido = "Martinez",
                   Nombre = "Marcos",
                   Dni = "38060619",
                   Direccion = "Jujuy 362",
                   Sexo = "Masculino",
                   FechaNacimiento = DateOnly.FromDateTime(new DateTime(1994, 4, 22)),
                   Celular = "123",
                   Email = "marcosmartinezmelek@gmail.com"
               },
               new PersonaCliente
               {
                   ID = 2,
                   Codigo = 456,
                   Apellido = "Garcia",
                   Nombre = "Juan Carlos",
                   Dni = "45607656",
                   Direccion = "Heras 1255",
                   Sexo = "Masculino",
                   FechaNacimiento = DateOnly.FromDateTime(new DateTime(1994, 4, 22)),
                   Celular = "34567",
                   Email = "juan@gmail.com"
               });
        }
    }
}
