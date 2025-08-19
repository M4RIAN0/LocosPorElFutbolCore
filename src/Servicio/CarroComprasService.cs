using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using System.Linq;

namespace Servicio
{
    public class CarroComprasService : ICarroComprasService
    {
        private readonly ICarroComprasRepository _repository;
        private readonly IMapper _mapper;

        public CarroComprasService(ICarroComprasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public void Add(CarroComprasDto dto)
        {
            var model = ToEntity(dto);
            _repository.Add(model);
            _repository.Save();
        }

        public CarroComprasGetDto GetByUserId(string userId)
        {
            return _repository.GetByFilter(x => x.UserId.Equals(userId)).Select(x => ToGetDto(x)).FirstOrDefault();
        }

        public CarroCompras GetLast()
        {
            return _repository.OrderByDescending(x => x.ID).FirstOrDefault();
        }

        public CarroComprasGetDto GetById(int? id)
        {
            var model = _repository.GetById(id);
            return ToGetDto(model);
        }

        public void SoftDelete(int id)
        {
            _repository.SoftDelete(id);
            _repository.Save();
        }

        public void Update(CarroComprasPutDto dto)
        {
            var model = ToEntityPut(dto);
            _repository.Attach(model);
            _repository.Save();
        }

        #region Private Methods
        private CarroComprasGetDto ToGetDto(CarroCompras model)
        {
            return _mapper.Map<CarroComprasGetDto>(model);
        }

        private CarroCompras ToEntity(CarroComprasDto model)
        {
            return _mapper.Map<CarroCompras>(model);
        }

        private CarroCompras ToEntityPut(CarroComprasPutDto model)
        {
            return _mapper.Map<CarroCompras>(model);
        }
        #endregion
    }
}
