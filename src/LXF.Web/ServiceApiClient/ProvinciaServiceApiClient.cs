using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient;

public class ProvinciaServiceApiClient : IProvinciaServiceApiClient
{
    private readonly IServiceBaseApiClient _baseServiceApiClient;

    public ProvinciaServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
    {
        _baseServiceApiClient = ServiceApiClientBase;
    }

    public async Task<ResponseViewModel?> GetAll()
    {
        // llamamos a SendAsync que es donde se genera la peticion http y toda sus configuraciones pertinentes
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.GET, // el tipo de peticion HTTP es POST
            Url = $"{SD.LXFApiBase}/api/Provincia/GetAll" // generamos el endpoint del API que vamos a consumir
        });
    }

}
