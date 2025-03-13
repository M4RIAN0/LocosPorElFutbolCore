using IServicio.Dtos;
using LXF.Web.Service.IService;

namespace LXF.Web.Service
{
    public class EnvioService : IEnvioService
    {
        private readonly IServiceBase _baseService;

        public EnvioService(IServiceBase serviceBase)
        {
            _baseService = serviceBase;
        }

        public void Add(EnvioDto Dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EnvioDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EnvioDto> GetByFilter(string cadenaBuscar)
        {
            throw new NotImplementedException();
        }

        public EnvioDto GetById(int? Id)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(EnvioDto Dto)
        {
            throw new NotImplementedException();
        }
    }
}
