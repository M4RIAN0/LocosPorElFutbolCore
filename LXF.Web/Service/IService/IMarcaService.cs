using IServicio.Dtos;
using LXF.Web.Models.Dto;

namespace LXF.Web.Service.IService
{
    public interface IMarcaService
    {
        Task<ResponseDto?> Add(MarcaDto dto);
        Task<ResponseDto?> Update(MarcaPutDto dto);
        Task<ResponseDto?> SoftDelete(int id);
        Task<ResponseDto?> GetByFilter(string cadenaBuscar);
        Task<ResponseDto?>GetAll();
        Task<ResponseDto?> GetById(int? id);

    }
}
