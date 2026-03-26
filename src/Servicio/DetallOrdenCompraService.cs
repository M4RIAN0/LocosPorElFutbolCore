using AutoMapper;
using Dominio.Repositorio;
using IServicio;

namespace Servicio
{
    public class DetallOrdenCompraService : IDetalleOrdenCompraService
    {
        private readonly IDetalleOrdenCompraRepository _detalleOrdenRepository;
        private readonly IMapper _mapper;

        public DetallOrdenCompraService(IDetalleOrdenCompraRepository detalleOrdenRepository, IMapper mapper)
        {
            _detalleOrdenRepository = detalleOrdenRepository;
            _mapper = mapper;
        }
    }
}
