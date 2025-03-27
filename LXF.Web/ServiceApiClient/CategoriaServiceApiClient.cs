using LXF.Web.Models.ViewModels;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

namespace LXF.Web.ServiceApiClient;

public class CategoriaServiceApiClient : ICategoriaServiceApiClient
{
    private readonly IServiceBaseApiClient _baseServiceApiClient;

    public CategoriaServiceApiClient(IServiceBaseApiClient ServiceApiClientBase)
    {
        _baseServiceApiClient = ServiceApiClientBase;
    }

    public async Task<ResponseViewModel?> Add(CategoriaViewModel ViewModel)
    {
        // llamamos a SendAsync que es donde se genera la peticion http y toda sus configuraciones pertinentes
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.POST, // el tipo de peticion HTTP es POST
            Data = ViewModel, // los datos del objeto que vamos a dar de alta
            Url = $"{SD.LXFApiBase}/api/Categoria" // generamos el endpoint del APi que vamos a consumir
        });
    }

    public async Task<ResponseViewModel?> Update(CategoriaPutViewModel ViewModel)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.PUT, // el tipo de peticion HTTP es PUT
            Data = ViewModel, // los datos del objeto que vamos a dar de alta
            Url = $"{SD.LXFApiBase}/api/Categoria/" // generamos el endpoint del APi que vamos a consumir
        });

    }

    public async Task<ResponseViewModel?> SoftDelete(int id)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.PUT, // el tipo de peticion HTTP es PUT
            Url = $"{SD.LXFApiBase}/api/Categoria/{id}/delete" // generamos el endpoint del APi que vamos a consumir
        });
    }

    public async Task<ResponseViewModel?> GetAll()
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.GET, // el tipo de peticion HTTP es GET
            Url = $"{SD.LXFApiBase}/api/Categoria" // generamos el endpoint del APi que vamos a consumir
        });
    }

    public async Task<ResponseViewModel?> GetByFilter(string cadenaBuscar)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.GET, // el tipo de peticion HTTP es GET
            Url = $"{SD.LXFApiBase}/api/Categoria/GetByFilter{cadenaBuscar}" // generamos el endpoint del APi que vamos a consumir
        });
    }

    public async Task<ResponseViewModel?> GetById(int? id)
    {
        return await _baseServiceApiClient.SendAsync(new RequestViewModel
        {
            ApiType = SD.ApiType.GET, // el tipo de peticion HTTP es GET
            Url = $"{SD.LXFApiBase}/api/Categoria/{id}" // generamos el endpoint del APi que vamos a consumir
        });
    }
}
