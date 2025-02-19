using AutoMapper;
using Dominio.Entidades;
using IServicio.Categoria.Dto;
using IServicio.Identity.Dto;
using IServicio.Marca.Dto;
using IServicio.PersonaCliente.Dto;
using IServicio.Producto.Dto;
using IServicio.Talle.Dto;

namespace LxF.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonaClienteDto, PersonaCliente>();
                config.CreateMap<PersonaClientePutDto, PersonaCliente>();
                config.CreateMap<PersonaCliente, PersonaClienteGetDto>();

                config.CreateMap<Usuario, UsuarioDto>();
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

            });
            return mappingConfig;
        }
    }
}
