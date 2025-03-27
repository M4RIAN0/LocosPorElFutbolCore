using AutoMapper;
using Dominio.Entidades;
using IServicio.Dtos;
using IServicio.Identity.Dto;

namespace LxF.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Usuario, UsuarioDto>()
                .ForMember(vm => vm.Celular, m => m.MapFrom(u => u.PhoneNumber));

                config.CreateMap<RegisterDto, Usuario>()
                .ForMember(vm => vm.Nombre, m => m.MapFrom(u => u.Nombre))
                .ForMember(vm => vm.UserName, m => m.MapFrom(u => u.Email))
                .ForMember(vm => vm.NormalizedUserName, m => m.MapFrom(u => u.Email.ToUpper()))
                .ForMember(vm => vm.NormalizedEmail, m => m.MapFrom(u => u.Email.ToUpper()))
                .ForMember(vm => vm.PhoneNumber, m => m.MapFrom(u => u.Celular));

                config.CreateMap<UsuarioDto, Usuario>()
               .ForMember(vm => vm.NormalizedEmail, m => m.MapFrom(u => u.Email.ToLower()));

                config.CreateMap<PersonaClienteDto, PersonaCliente>()
                .ForMember(vm => vm.FechaNacimiento, m => m.MapFrom(u => DateOnly.Parse(u.FechaNacimiento)));
                config.CreateMap<PersonaClientePutDto, PersonaCliente>()
                .ForMember(vm => vm.FechaNacimiento, m => m.MapFrom(u => DateOnly.Parse(u.FechaNacimiento)));
                config.CreateMap<PersonaCliente, PersonaClienteGetDto>()
                .ForMember(vm => vm.FechaNacimiento, m => m.MapFrom(u => u.FechaNacimiento.ToString()));

                config.CreateMap<Talle, TalleDto>();

                config.CreateMap<CategoriaDto, Categoria>();
                config.CreateMap<CategoriaPutDto, Categoria>();
                config.CreateMap<Categoria, CategoriaGetDto>();

                config.CreateMap<MarcaDto, Marca>();
                config.CreateMap<MarcaPutDto, Marca>();
                config.CreateMap<Marca, MarcaGetDto>();

                config.CreateMap<ProductoPutDto, Producto>();
                config.CreateMap<ProductoDto, Producto>();
                config.CreateMap<Producto, ProductoGetDto>()
                .ForMember(vm => vm.Categoria, m => m.MapFrom(u => u.Categoria.Descripcion))
                .ForMember(vm => vm.Talle, m => m.MapFrom(u => u.Talle.Letra))
                .ForMember(vm => vm.Marca, m => m.MapFrom(u => u.Marca.Descripcion));

                config.CreateMap<TarjetaDto, Tarjeta>()
                .ForMember(vm => vm.FechaExpiracion, m => m.MapFrom(u => DateOnly.Parse(u.FechaExpiracion)));
                config.CreateMap<Tarjeta, TarjetaGetDto>()
                .ForMember(vm => vm.Banco, m => m.MapFrom(u => u.Banco.Nombre))
                .ForMember(vm => vm.TipoTarjeta, m => m.MapFrom(u => u.TipoTarjeta.Tipo))
                .ForMember(vm => vm.FechaExpiracion, m => m.MapFrom(u => u.FechaExpiracion.ToString()));

                config.CreateMap<MovimientoDto, Movimiento>()
                .ForMember(vm => vm.Fecha, m => m.MapFrom(u => DateOnly.Parse(u.Fecha)));
                config.CreateMap<Movimiento, MovimientoGetDto>()
                .ForMember(vm => vm.Fecha, m => m.MapFrom(u => u.Fecha.ToString()));

                config.CreateMap<DetalleComprobanteDto, DetalleComprobante>();
                config.CreateMap<DetalleComprobante, DetalleComprobanteGetDto>()
                .ForMember(vm => vm.Producto, m => m.MapFrom(u => u.Producto.Descripcion));

                config.CreateMap<ComprobanteDto, Comprobante>()
                .ForMember(vm => vm.Fecha, m => m.MapFrom(u => DateOnly.Parse(u.Fecha)));
                config.CreateMap<Comprobante, ComprobanteGetDto>()
                .ForMember(vm => vm.Fecha, m => m.MapFrom(u => u.Fecha.ToString()));

                config.CreateMap<FacturaDto, Factura>()
                .ForMember(vm => vm.Fecha, m => m.MapFrom(u => DateOnly.Parse(u.Fecha)));
                config.CreateMap<Factura, FacturaGetDto>()
                .ForMember(vm => vm.Cliente, m => m.MapFrom(u => u.PersonaCliente.Nombre + " " + u.PersonaCliente.Apellido))
                .ForMember(vm => vm.Tarjeta, m => m.MapFrom(u => u.Tarjeta.Nombre))
                .ForMember(vm => vm.Fecha, m => m.MapFrom(u => u.Fecha.ToString()));
            });

            return mappingConfig;
        }
    }
}
