using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio.Dtos;
using IServicio.Dtos;
using IServicio.Identity.Dto;

namespace LxF.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMps()
        {
            var mappingConfig = new MapperConfiguration(static config =>
            {
                config.CreateMap<Usuario, UsuarioDto>()
                .ForMember(vm => vm.Celular, m => m.MapFrom(u => u.PhoneNumber));
                config.CreateMap<UsuarioDto, Usuario>()
               .ForMember(vm => vm.NormalizedEmail, m => m.MapFrom(u => u.Email.ToLower()));

                config.CreateMap<RegisterDto, Usuario>()
                .ForMember(vm => vm.Nombre, m => m.MapFrom(u => u.NombreCompleto))
                .ForMember(vm => vm.UserName, m => m.MapFrom(u => u.Email))
                .ForMember(vm => vm.NormalizedUserName, m => m.MapFrom(u => u.Email.ToUpper()))
                .ForMember(vm => vm.NormalizedEmail, m => m.MapFrom(u => u.Email.ToUpper()))
                .ForMember(vm => vm.PhoneNumber, m => m.MapFrom(u => u.Celular));
                config.CreateMap<RegisterDto, PersonaCliente>()
                .ForMember(vm => vm.FechaNacimiento, m => m.MapFrom(u => DateOnly.Parse(u.FechaNacimiento)));

                config.CreateMap<PersonaClienteDto, PersonaCliente>()
                .ForMember(vm => vm.FechaNacimiento, m => m.MapFrom(u => DateOnly.Parse(u.FechaNacimiento)));
                config.CreateMap<PersonaClientePutDto, PersonaCliente>()
                .ForMember(vm => vm.FechaNacimiento, m => m.MapFrom(u => DateOnly.Parse(u.FechaNacimiento)));
                config.CreateMap<PersonaCliente, PersonaClienteGetDto>()
                .ForMember(vm => vm.FechaNacimiento, m => m.MapFrom(u => u.FechaNacimiento.ToString()));

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
                .ForMember(vm => vm.Marca, m => m.MapFrom(u => u.Marca.Descripcion));
                config.CreateMap<ProductoGetDto, Producto>()
                .ForMember(dest => dest.Categoria, opt => opt.Ignore())
                .ForMember(dest => dest.Marca, opt => opt.Ignore());
                config.CreateMap<Producto, ProductoResumenDto>();

                config.CreateMap<ProductoVarianteDto, ProductoVariante>();
                config.CreateMap<ProductoVariante, ProductoVarianteGetDto>();
                config.CreateMap<ProductoVariantePutDto, ProductoVariante>();
                config.CreateMap<ProductoVarianteGetDto, ProductoVariante>()
                .ForMember(dest => dest.Producto, opt => opt.Ignore());

                config.CreateMap<Provincia, ProvinciaGetDto>();


                config.CreateMap<Localidad, LocalidadGetDto>();

                config.CreateMap<ComprobanteDto, Comprobante>()
                .ForMember(vm => vm.Fecha, opt => opt.MapFrom(u => DateOnly.ParseExact(u.Fecha, "yyyy-mm-dd")));
                config.CreateMap<Comprobante, ComprobanteGetDto>()
                .ForMember(vm => vm.Fecha, m => m.MapFrom(u => u.Fecha.ToString("yyyy-MM-dd")));

                config.CreateMap<DetalleComprobanteDto, DetalleComprobante>();
                config.CreateMap<DetalleComprobante, DetalleComprobanteGetDto>().
                ForMember(vm => vm.Producto, opt => opt.MapFrom(u => u.Producto));

                config.CreateMap<FacturaDto, Factura>()
                .ForMember(vm => vm.Fecha, opt => opt.MapFrom(u => DateOnly.ParseExact(u.Fecha, "yyyy-mm-dd")));
                config.CreateMap<Factura, FacturaGetDto>()
                .ForMember(vm => vm.Fecha, m => m.MapFrom(u => u.Fecha.ToString()));

                config.CreateMap<CarroCompra, CarroCompraDto>();
                config.CreateMap<CarroCompra, CarroCompraPutDto>();
                config.CreateMap<CarroCompra, CarroCompraGetDto>();
                config.CreateMap<CarroCompraDto, CarroCompra>();
                config.CreateMap<CarroCompraPutDto, CarroCompra>();

                config.CreateMap<DetalleCarroCompra, DetalleCarroCompraDto>();
                config.CreateMap<DetalleCarroCompra, DetalleCarroCompraPutDto>();
                config.CreateMap<DetalleCarroCompra, DetalleCarroCompraGetDto>();
                config.CreateMap<DetalleCarroCompraDto, DetalleCarroCompra>();
                config.CreateMap<DetalleCarroCompraPutDto, DetalleCarroCompra>();

                config.CreateMap<OrdenCompra, OrdenCompraDto>();
                config.CreateMap<OrdenCompra, OrdenCompraPutDto>();
                config.CreateMap<OrdenCompra, OrdenCompraGetDto>();
                config.CreateMap<OrdenCompraDto, OrdenCompra>()
                .ForMember(vm => vm.Fecha, opt => opt.MapFrom(u => DateOnly.ParseExact(u.Fecha, "yyyy-mm-dd")));
                config.CreateMap<OrdenCompraPutDto, OrdenCompra>();

                config.CreateMap<DetalleOrdenCompra, DetalleOrdenCompraDto>();
                config.CreateMap<DetalleOrdenCompra, DetalleOrdenCompraPutDto>();
                config.CreateMap<DetalleOrdenCompra, DetalleOrdenCompraGetDto>();
                //ForMember(vm => vm.ProductoVariante, opt => opt.MapFrom(u => u.ProductoVariante));
                config.CreateMap<DetalleOrdenCompraDto, DetalleOrdenCompra>();
                config.CreateMap<DetalleOrdenCompraPutDto, DetalleOrdenCompra>();

                config.CreateMap<EnvioDto, Envio>();
                config.CreateMap<Envio, EnvioGetDto>();

            });

            return mappingConfig;
        }
    }
}
