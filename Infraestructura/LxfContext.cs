using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class LxfContext : DbContext
    {
        
        public LxfContext(DbContextOptions<LxfContext> options) : base(options)
        {

        }

        public DbSet<Banco> Banco { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Comprobante> Comprobante { get; set; }
        public DbSet<CuponDescuento> CuponDescuento { get; set; }
        public DbSet<DetalleComprobante> DetalleComprobantes { get; set; }
        public DbSet<Envio> Envio { get; set; }
        public DbSet<CuponDescuento> Factura { get; set; }
        public DbSet<ListaPrecio> ListaPrecio { get; set; }
        public DbSet<ListaPrecioProducto> ListaPrecioProducto { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Persona_Cliente> Persona_Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Rubro> Rubro { get; set; }
        public DbSet<SubRubro> SubRubro { get; set; }
        public DbSet<Talle> Talle { get; set; }
        public DbSet<Tarjeta> Tarjeta { get; set; }
        public DbSet<TipoTarjeta> TipoTarjeta { get; set; }
        public DbSet<Usuario> Usuario { get; set;}
    }








}
