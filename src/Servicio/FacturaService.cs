using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio
{
    public class FacturaService : ServicioBase, IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IMapper _mapper;

        public FacturaService(IFacturaRepository facturaRepositorio, IMapper mapper)
        {
            _facturaRepository = facturaRepositorio;
            _mapper = mapper;
        }

        public IEnumerable<FacturaGetDto> GetAll()
        {
            return _facturaRepository.GetAll("PersonaCliente")
                  .Select(p => ToGetFacturaDto(p));
        }

        public FacturaGetDto GetById(int id)
        {
            return ToGetFacturaDto(_facturaRepository
                   .GetById(id, "PersonaCliente"));
        }


        #region Private Mhetods
        private FacturaGetDto ToGetFacturaDto(Factura model)
        {
            return _mapper.Map<FacturaGetDto>(model);
        }
        #endregion
    }
}
