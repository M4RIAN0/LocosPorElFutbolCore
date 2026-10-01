using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;
using MercadoPago.Resource.User;

namespace LXF.Web.ServiceApiClient;

public class CarroComprasServiceApiClient : ICarroComprasServiceApiClient
{
    private readonly IServiceBaseApiClient _baseServiceApiClient;

    public CarroComprasServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
    {
        _baseServiceApiClient = ServiceApiClientBase;
    }

    public async Task<ResponseViewModel?> Add(CarroComprasViewModel vm)
    {
        // llamamos a SendAsync que es donde se genera la peticion http y toda sus configuraciones pertinentes
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.POST, // el tipo de peticion HTTP es POST
            Data = vm, // los datos del objeto que vamos a dar de alta
            Url = $"{SD.LXFApiBase}/api/Carro" // generamos el endpoint del API que vamos a consumir
        });
    }

    public async Task<ResponseViewModel?> Update(CarroComprasPutViewModel vm)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.PUT, // el tipo de peticion HTTP es PUT
            Data = vm, // los datos del objeto que vamos a dar de alta
            Url = $"{SD.LXFApiBase}/api/Carro/" // generamos el endpoint del APi que vamos a consumir
        });

    }

    public async Task<ResponseViewModel?> AddItem(int id)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.PUT, // el tipo de peticion HTTP es PUT
            Url = $"{SD.LXFApiBase}/api/Carro/{id}/addItem" // generamos el endpoint del APi que vamos a consumir
        });

    }

    public async Task<ResponseViewModel?> SubtractItem(int id)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.PUT, // el tipo de peticion HTTP es PUT
            Url = $"{SD.LXFApiBase}/api/Carro/{id}/substractItem" // generamos el endpoint del APi que vamos a consumir
        });

    }

    public async Task<ResponseViewModel?> Remove(int id)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.DELETE, // el tipo de peticion HTTP es DELETE
            Url = $"{SD.LXFApiBase}/api/Carro/{id}/delete" // generamos el endpoint del APi que vamos a consumir
        });
    }

    public async Task<ResponseViewModel?> RemoveItem(int id)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.DELETE, // el tipo de peticion HTTP es DELETE
            Url = $"{SD.LXFApiBase}/api/Carro/{id}/deleteItem" // generamos el endpoint del APi que vamos a consumir
        });
    }

    public async Task<ResponseViewModel?> GetByUserId(string userId)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.GET, // el tipo de peticion HTTP es GET
            Url = $"{SD.LXFApiBase}/api/Carro/{userId}" // generamos el endpoint del APi que vamos a consumir
        });
    }

    public async Task<ResponseViewModel?> GetAnyWithProductId(int productId)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.GET, // el tipo de peticion HTTP es GET
            Url = $"{SD.LXFApiBase}/api/Carro/GetAnyWithProductId/{productId}" // generamos el endpoint del APi que vamos a consumir
        });
    }
}
