using AutoMapper;
using Dominio.Repositorio.Dtos;
using IServicio.Dtos;
using LXF.Web.Models.ViewModels;

namespace LXF.Web
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CategoriaGetViewModel, CategoriaPutViewModel>();

                config.CreateMap<CarroComprasGetViewModel, CarroComprasViewModel>();
                config.CreateMap<CarroComprasGetViewModel, CarroComprasPutViewModel>();

                config.CreateMap<DetalleCarroComprasGetViewModel, DetalleCarroComprasViewModel>();
                config.CreateMap<DetalleCarroComprasGetViewModel, DetalleCarroComprasPutViewModel>();

                config.CreateMap<DetalleOrdenCompraViewModel, DetalleOrdenCompraGetViewModel>();
                config.CreateMap<DetalleOrdenCompraViewModel, DetalleOrdenCompraDto>();
                config.CreateMap<DetalleOrdenCompraViewModel, DetalleOrdenCompraGetDto>();
                config.CreateMap<DetalleOrdenCompraGetViewModel, DetalleOrdenCompraGetDto>();
                config.CreateMap<DetalleOrdenCompraDto, DetalleOrdenCompraGetDto>();
                config.CreateMap<DetalleOrdenCompraGetDto, DetalleOrdenCompraViewModel>();
                config.CreateMap<DetalleOrdenCompraGetDto, DetalleOrdenCompraGetViewModel>();

                config.CreateMap<MarcaGetViewModel, MarcaPutViewModel>();

                config.CreateMap<OrdenCompraViewModel, OrdenCompraGetViewModel>();
                config.CreateMap<OrdenCompraViewModel, OrdenCompraGetDto>();
                config.CreateMap<OrdenCompraGetViewModel, OrdenCompraGetDto>();
                config.CreateMap<OrdenCompraDto, OrdenCompraGetDto>();
                config.CreateMap<OrdenCompraDto, OrdenCompraViewModel>();
                config.CreateMap<OrdenCompraGetDto, OrdenCompraViewModel>();
                config.CreateMap<OrdenCompraGetDto, OrdenCompraGetViewModel>();

                config.CreateMap<ProductoViewModel, ProductoGetViewModel>();
                config.CreateMap<ProductoViewModel, ProductoDto>();
                config.CreateMap<ProductoViewModel, ProductoGetDto>();
                config.CreateMap<ProductoGetViewModel, ProductoViewModel>();
                config.CreateMap<ProductoGetViewModel, ProductoPutViewModel>();
                config.CreateMap<ProductoGetViewModel, ProductoGetDto>();
                config.CreateMap<ProductoDto, ProductoGetDto>();
                config.CreateMap<ProductoGetDto, ProductoViewModel>();
                config.CreateMap<ProductoGetDto, ProductoGetViewModel>();

                config.CreateMap<FacturaViewModel, FacturaGetViewModel>();

                config.CreateMap<EnvioViewModel, EnvioGetViewModel>();
            });

            return mappingConfig;
        }
    }
}
