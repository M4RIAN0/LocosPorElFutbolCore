using IServicio.Dtos;
using LXF.Web.Models.Dto;

namespace LXF.Web.Service.IService
{
    public interface IProductoService
    {
        Task<ResponseDto?> Add(ProductoDto dto);
        Task<ResponseDto?> Update(ProductoPutDto dto);
        Task<ResponseDto?> SoftDelete(int id);
        Task<ResponseDto?> GetByFilter(string cadenaBuscar);
        Task<ResponseDto?> GetAll();
        Task<ResponseDto?> GetById(int? id);
    }
}
