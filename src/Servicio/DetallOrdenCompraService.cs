using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;

namespace Servicio
{
    public class DetallOrdenCompraService : IDetalleOrdenCompraService
    {
        private readonly IDetalleOrdenCompraRepository _detalleOrdenRepository;
        private readonly IOrdenCompraRepository _ordenRepository;
        private readonly IMapper _mapper;

        public DetallOrdenCompraService(IDetalleOrdenCompraRepository detalleOrdenRepository, IOrdenCompraRepository ordenRepository, IMapper mapper)
        {
            _detalleOrdenRepository = detalleOrdenRepository;
            _ordenRepository = ordenRepository;
            _mapper = mapper;
        }

        public void Add(DetalleOrdenCompraDto dto)
        {
            throw new System.NotImplementedException();

            //_detalleOrdenRepository.BeginTransaction();

            //var modelCarro = EditTotalCarro(dto.Subtotal, dto.CarroCompraId);
            //_ordenRepository.Attach(modelCarro);
            //_ordenRepository.Save();

            //var model = ToEntity(dto);
            //_detalleOrdenRepository.Add(model);
            //_detalleOrdenRepository.Save();

            //_detalleOrdenRepository.Commit();
        }

        public void Update(DetalleOrdenCompraPutDto dto)
        {
            var model = ToEntity(dto);
            _detalleOrdenRepository.Attach(model);
            _detalleOrdenRepository.Save();
        }

        public DetalleOrdenCompraGetDto GetById(int? id)
        {
            return ToGetDto(_detalleOrdenRepository.GetById(id));
        }

        #region Private Methods
        private DetalleOrdenCompraGetDto ToGetDto(object? obj)
        {
            return _mapper.Map<DetalleOrdenCompraGetDto>(obj);
        }
        private DetalleOrdenCompra ToEntity(object? obj)
        {
            return _mapper.Map<DetalleOrdenCompra>(obj);
        }
        #endregion
    }
}
