using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IProductoServiceApiClient
    {
        Task<ResponseViewModel?> Add(ProductoViewModel vm);
        Task<ResponseViewModel?> Update(ProductoPutViewModel vm);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetByFilter(string cadenaBuscar);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int id);
        Task<ResponseViewModel?> GetByIdProductoVariante(int productoVarianteId);
        Task<ResponseViewModel?> GetInStockProductos();
        Task<ResponseViewModel?> GetSimilProductos(int productoId, int categoriaId, int marcaId);
        Task<ResponseViewModel?> GetInterestingProductos(int productoId);
        Task<ResponseViewModel?> GetByFilterGenderProductos(string cadenaBuscar);
        Task<ResponseViewModel?> GetLastProducto();
    }
}
