using IServicio.Dtos;
using LXF.Web.Models.Dto;
using LXF.Web.Service.IService;
using LXF.Web.Utility;

namespace LXF.Web.Service;

public class CategoriaService : ICategoriaService
{
    private readonly IServiceBase _baseService;

    public CategoriaService(IServiceBase serviceBase)
    {
        _baseService = serviceBase;
    }

    public async Task<ResponseDto?> Add(CategoriaDto dto)
    {
        // llamamos a SendAsync que es donde se genera la peticion http y toda sus configuraciones pertinentes
        return await _baseService.SendAsync(new RequestDto
        {
            ApiType = SD.ApiType.POST, // el tipo de peticion HTTP es POST
            Data = dto, // los datos del objeto que vamos a dar de alta
            Url = $"{SD.LXFApiBase}/api/Categoria" // generamos el endpoint del APi que vamos a consumir
        });
    }

    public async Task<ResponseDto?> Update(CategoriaPutDto dto)
    {
        return await _baseService.SendAsync(new RequestDto
        {
            ApiType = SD.ApiType.PUT, // el tipo de peticion HTTP es PUT
            Data = dto, // los datos del objeto que vamos a dar de alta
            Url = $"{SD.LXFApiBase}/api/Categoria/" // generamos el endpoint del APi que vamos a consumir
        });

    }

    public async Task<ResponseDto?> SoftDelete(int id)
    {
        return await _baseService.SendAsync(new RequestDto
        {
            ApiType = SD.ApiType.PUT, // el tipo de peticion HTTP es PUT
            Url = $"{SD.LXFApiBase}/api/Categoria/{id}/delete" // generamos el endpoint del APi que vamos a consumir
        });
    }

    public async Task<ResponseDto?> GetAll()
    {
        return await _baseService.SendAsync(new RequestDto
        {
            ApiType = SD.ApiType.GET, // el tipo de peticion HTTP es GET
            Url = $"{SD.LXFApiBase}/api/Categoria" // generamos el endpoint del APi que vamos a consumir
        });
    }

    public async Task<ResponseDto?> GetByFilter(string cadenaBuscar)
    {
        return await _baseService.SendAsync(new RequestDto
        {
            ApiType = SD.ApiType.GET, // el tipo de peticion HTTP es GET
            Url = $"{SD.LXFApiBase}/api/Categoria/GetByFilter{cadenaBuscar}" // generamos el endpoint del APi que vamos a consumir
        });
    }

    public async Task<ResponseDto?> GetById(int? id)
    {
        return await _baseService.SendAsync(new RequestDto
        {
            ApiType = SD.ApiType.GET, // el tipo de peticion HTTP es GET
            Url = $"{SD.LXFApiBase}/api/Categoria/{id}" // generamos el endpoint del APi que vamos a consumir
        });
    }
}
