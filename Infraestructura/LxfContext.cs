using Dominio.Entidades;
using Infraestructura.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infraestructura
{
    public class LxfContext : IdentityDbContext<Usuario, Role, string>
    {
        public LxfContext(DbContextOptions<LxfContext> options) : base(options)
        { }

        public LxfContext()
        { }

        public DbSet<Banco> Banco { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Comprobante> Comprobante { get; set; }
        public DbSet<DetalleComprobante> DetalleComprobantes { get; set; }
        public DbSet<Envio> Envio { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<PersonaCliente> Persona_Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Talle> Talle { get; set; }
        public DbSet<Tarjeta> Tarjeta { get; set; }
        public DbSet<TipoTarjeta> TipoTarjeta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PersonaCliente>().HasData(
            new PersonaCliente
            {
                ID = 1,
                Codigo = 123,
                Apellido = "Martinez",
                Nombre = "Marcos",
                Dni = "38060619",
                Direccion = "Jujuy 362",
                Sexo = "Masculino",
                FechaNacimiento = DateTime.Today,
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
                FechaNacimiento = DateTime.Today,
                Celular = "34567",
                Email = "juan@gmail.com"
            });

            builder.Entity<Talle>().HasData(
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

            builder.Entity<Categoria>().HasData(
           new Categoria
           {
               ID = 1,
               Descripcion = "Camisetas Futbol Masculinas"
           },
           new Categoria
           {
               ID = 2,
               Descripcion = "Camisetas Futbol Femeninas"
           },
           new Categoria
           {
               ID = 3,
               Descripcion = "Remeras"
           },
           new Categoria
           {
               ID = 4,
               Descripcion = "Musculosas"
           },
           new Categoria
           {
               ID = 5,
               Descripcion = "Shorts"
           },
           new Categoria
           {
               ID = 6,
               Descripcion = "Medias"
           },
           new Categoria
           {
               ID = 7,
               Descripcion = "Pantalones"
           });

            builder.Entity<Marca>().HasData(
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


            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.Entity<IdentityUserRole<string>>().ToTable("UsuarioRoles");

            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();

        }
    }
}


