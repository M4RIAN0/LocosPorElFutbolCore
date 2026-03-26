using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient;

public class VentaServiceApiClient : IVentaServiceApiClient
{
    private readonly IServiceBaseApiClient _baseServiceApiClient;

    public VentaServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
    {
        _baseServiceApiClient = ServiceApiClientBase;
    }

    public async Task<ResponseViewModel?> Add(TransactionObjectsViewModel vm)
    {
        // llamamos a SendAsync que es donde se genera la peticion http y toda sus configuraciones pertinentes
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.POST, // el tipo de peticion HTTP es POST
            Data = vm, // los datos del objeto que vamos a dar de alta
            Url = $"{SD.LXFApiBase}/api/Venta" // generamos el endpoint del API que vamos a consumir
        });
    }

    public async Task<ResponseViewModel?> GetComprobantesByClienteId(int clienteId)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.GET, // el tipo de peticion HTTP es GET
            Url = $"{SD.LXFApiBase}/api/Venta/{clienteId}/getComprobanteByCliente" // generamos el endpoint del APi que vamos a consumir
        });
    }

    public async Task<ResponseViewModel?> GetComprobanteById(int id)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.GET, // el tipo de peticion HTTP es GET
            Url = $"{SD.LXFApiBase}/api/Venta/{id}/getComprobanteById" // generamos el endpoint del APi que vamos a consumir
        });
    }
}
