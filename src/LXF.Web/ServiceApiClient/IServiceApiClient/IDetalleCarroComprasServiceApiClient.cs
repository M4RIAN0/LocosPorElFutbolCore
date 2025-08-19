using LXF.Web.Models.ViewModels;

namespace LXF.Web.ServiceApiClient.IServiceApiClient
{
    public interface IDetalleCarroComprasServiceApiClient
    {
        Task<ResponseViewModel?> Add(DetalleCarroComprasViewModel vm);
        Task<ResponseViewModel?> Update(DetalleCarroComprasPutViewModel vm);
        Task<ResponseViewModel?> SoftDelete(int id);
        Task<ResponseViewModel?> GetByFilter(string cadenaBuscar);
        Task<ResponseViewModel?> GetAll();
        Task<ResponseViewModel?> GetById(int? id);
    }
}
