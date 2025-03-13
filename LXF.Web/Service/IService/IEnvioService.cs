using IServicio.Dtos;

namespace LXF.Web.Service.IService
{
    public interface IEnvioService
    {
        void Add(EnvioDto Dto);
        void Update(EnvioDto Dto);
        void SoftDelete(int Id);

        IEnumerable<EnvioDto> GetByFilter(string cadenaBuscar); // obtener por filtro

        IEnumerable<EnvioDto> GetAll();

        EnvioDto GetById(int? Id);
    }
}
