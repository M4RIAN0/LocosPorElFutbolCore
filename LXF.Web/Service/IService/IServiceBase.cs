using LXF.Web.Models.Dto;

namespace LXF.Web.Service.IService
{
    public interface IServiceBase
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
