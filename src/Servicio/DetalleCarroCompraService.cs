using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;

namespace Servicio
{
    public class DetalleCarroCompraService : IDetalleCarroCompraService
    {
        private readonly IDetalleCarroCompraRepository _detalleCarroRepository;
        private readonly ICarroCompraRepository _carroRepository;
        private readonly IMapper _mapper;

        public DetalleCarroCompraService(IDetalleCarroCompraRepository detalleCarroRepository, ICarroCompraRepository carroRepository, IMapper mapper)
        {
            _detalleCarroRepository = detalleCarroRepository;
            _carroRepository = carroRepository;
            _mapper = mapper;
        }

        public void Add(DetalleCarroCompraDto dto)
        {
            _detalleCarroRepository.BeginTransaction();

            var modelCarro = EditTotalCarro(dto.Subtotal, dto.CarroCompraId);
            _carroRepository.Attach(modelCarro);
            _carroRepository.Save();

            var model = ToEntity(dto);
            _detalleCarroRepository.Add(model);
            _detalleCarroRepository.Save();

            _detalleCarroRepository.Commit();
        }

        public void Update(DetalleCarroCompraPutDto dto)
        {
            var model = ToEntity(dto);
            _detalleCarroRepository.Attach(model);
            _detalleCarroRepository.Save();
        }

        public DetalleCarroCompraGetDto GetById(int? id)
        {
            return ToGetDto(_detalleCarroRepository.GetById(id));
        }

        #region Private Methods
        private DetalleCarroCompraGetDto ToGetDto(object? obj)
        {
            return _mapper.Map<DetalleCarroCompraGetDto>(obj);
        }
        private DetalleCarroCompra ToEntity(object? obj)
        {
            return _mapper.Map<DetalleCarroCompra>(obj);
        }
        //Carro
        private CarroCompra GetCarroById(int id)
        {
            return _carroRepository.GetById(id);
        }
        private CarroCompra EditTotalCarro(decimal subtotal, int id)
        {
            var carro = GetCarroById(id);
            carro.Total += subtotal;
            carro.DetalleCarroCompras = null;
            return carro;
        }
        #endregion
    }
}
