using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient;

public class DetalleCarroComprasServiceApiClient : IDetalleCarroComprasServiceApiClient
{
    private readonly IServiceBaseApiClient _baseServiceApiClient;

    public DetalleCarroComprasServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
    {
        _baseServiceApiClient = ServiceApiClientBase;
    }

    public async Task<ResponseViewModel?> Add(DetalleCarroComprasViewModel vm)
    {
        // llamamos a SendAsync que es donde se genera la peticion http y toda sus configuraciones pertinentes
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.POST, // el tipo de peticion HTTP es POST
            Data = vm, // los datos del objeto que vamos a dar de alta
            Url = $"{SD.LXFApiBase}/api/DetalleCarro" // generamos el endpoint del APi que vamos a consumir
        });
    }
}
