using AutoMapper;
using LXF.Web.Models.ViewModels;

namespace LXF.Web
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductoGetViewModel, ProductoPutViewModel>();

                config.CreateMap<MarcaGetViewModel, MarcaPutViewModel>();

                config.CreateMap<CategoriaGetViewModel, CategoriaPutViewModel>();
            });

            return mappingConfig;
        }
    }
}
