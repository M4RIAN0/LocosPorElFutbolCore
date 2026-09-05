using Dominio.Entidades;
using Infraestructura.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class LxfContext : IdentityDbContext<Usuario, Role, string>
    {
        public LxfContext(DbContextOptions<LxfContext> options) : base(options)
        { }

        public LxfContext()
        { }

        public DbSet<CarroCompra> CarroCompra { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Comprobante> Comprobante { get; set; }
        public DbSet<DetalleCarroCompra> DetalleCarroCompra { get; set; }
        public DbSet<DetalleComprobante> DetalleComprobante { get; set; }
        public DbSet<DetalleOrdenCompra> DetalleOrdenCompra { get; set; }
        public DbSet<Envio> Envio { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }
        public DbSet<OrdenCompra> OrdenCompra { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<PersonaCliente> Persona_Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProvinciaConfiguration());
            builder.ApplyConfiguration(new LocalidadConfiguration());
            builder.ApplyConfiguration(new PersonaClienteConfiguration());
            builder.ApplyConfiguration(new MarcaConfiguration());
            builder.ApplyConfiguration(new CategoriaConfiguration());
            builder.ApplyConfiguration(new ProductoConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new DetalleCarroComprasConfiguration());
            builder.Entity<IdentityUserRole<string>>().ToTable("UsuarioRoles");

            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();

        }
    }
}


