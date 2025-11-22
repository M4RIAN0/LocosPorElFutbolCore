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

}
