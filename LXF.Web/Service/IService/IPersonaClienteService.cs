using IServicio.Dtos;
using LXF.Web.Models.Dto;

namespace LXF.Web.Service.IService
{
    public interface IPersonaClienteService
    {
        Task<ResponseDto?> Add(PersonaClienteDto dto);
        Task<ResponseDto?> Update(PersonaClientePutDto dto);
        Task<ResponseDto?> SoftDelete(int id);
        Task<ResponseDto?> GetByFilter(string cadenaBuscar);
        Task<ResponseDto?> GetAll();
        Task<ResponseDto?> GetById(int? id);
    }
}
