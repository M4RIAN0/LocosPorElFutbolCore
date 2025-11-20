using AutoMapper;
using Dominio.Repositorio.Dtos;
using LXF.Web.Models.ViewModels;

namespace LXF.Web
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductoGetViewModel, ProductoViewModel>();
                config.CreateMap<ProductoGetViewModel, ProductoPutViewModel>();
                config.CreateMap<ProductoGetViewModel, ProductoGetDto>();
                config.CreateMap<ProductoGetDto, ProductoViewModel>();
                config.CreateMap<ProductoGetDto, ProductoGetViewModel>();

                config.CreateMap<MarcaGetViewModel, MarcaPutViewModel>();

                config.CreateMap<CategoriaGetViewModel, CategoriaPutViewModel>();

                config.CreateMap<CarroComprasGetViewModel, CarroComprasViewModel>();
                config.CreateMap<CarroComprasGetViewModel, CarroComprasPutViewModel>();

                config.CreateMap<DetalleCarroComprasGetViewModel, DetalleCarroComprasViewModel>();
                config.CreateMap<DetalleCarroComprasGetViewModel, DetalleCarroComprasPutViewModel>();

                config.CreateMap<OrdenComprasViewModel, OrdenComprasGetViewModel>();
                config.CreateMap<OrdenComprasGetViewModel, OrdenCompraGetDto>();
                config.CreateMap<OrdenCompraGetDto, OrdenComprasViewModel>();
                config.CreateMap<OrdenCompraGetDto, OrdenComprasGetViewModel>();

                config.CreateMap<DetalleOrdenComprasViewModel, DetalleOrdenComprasGetViewModel>();
                config.CreateMap<DetalleOrdenComprasGetViewModel, DetalleOrdenCompraGetDto>();
                config.CreateMap<DetalleOrdenCompraGetDto, DetalleOrdenComprasViewModel>();
                config.CreateMap<DetalleOrdenCompraGetDto, DetalleOrdenComprasGetViewModel>();
            });

            return mappingConfig;
        }
    }
}
