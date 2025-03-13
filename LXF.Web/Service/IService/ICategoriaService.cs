using IServicio.Dtos;
using LXF.Web.Models.Dto;

namespace LXF.Web.Service.IService
{
    public interface ICategoriaService
    {
        Task<ResponseDto?> Add(CategoriaDto dto);
        Task<ResponseDto?> Update(CategoriaPutDto dto);
        Task<ResponseDto?> SoftDelete(int id);
        Task<ResponseDto?> GetByFilter(string cadenaBuscar);
        Task<ResponseDto?> GetAll();
        Task<ResponseDto?> GetById(int? id);
    }
}
