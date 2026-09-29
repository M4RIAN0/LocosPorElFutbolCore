using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using Dominio.Repositorio.Dtos;
using IServicio;
using System.Linq;

namespace Servicio
{
    public class OrdenCompraService : IOrdenCompraService
    {
        private readonly IOrdenCompraRepository _ordenRepository;
        private readonly IMapper _mapper;

        public OrdenCompraService(IOrdenCompraRepository ordenRepository, IMapper mapper)
        {
            _ordenRepository = ordenRepository;
            _mapper = mapper;
        }


        public OrdenCompraGetDto GetLast()
        {
            return ToOrdenCompraGetDto(_ordenRepository.OrderByDescending(x => x.ID, "DetalleOrdenCompras.ProductoVariante.Producto").FirstOrDefault());
        }
        #region Private Methods
        private OrdenCompraGetDto ToOrdenCompraGetDto(object? obj)
        {
            return _mapper.Map<OrdenCompraGetDto>(obj);
        }
        #endregion
    }
}
