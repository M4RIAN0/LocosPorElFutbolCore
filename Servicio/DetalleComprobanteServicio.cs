using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using Servicio.Base;

namespace Servicio
{
    public class DetalleComprobanteServicio : ServicioBase, IDetalleComprobanteServicio
    {
        private readonly IDetalleComprobanteRepository _repository;
        private readonly IMapper _mapper;

        public DetalleComprobanteServicio(IDetalleComprobanteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public void Add(DetalleComprobanteDto dto)
        {
            var model = ToEntity(dto);

            _repository.Add(model);
            _repository.Save();
        }

        public DetalleComprobanteGetDto GetById(int? id)
        {
            var model = _repository.GetById(id);
            return ToGetDto(model);
        }

        #region Private Mhetods
        private DetalleComprobanteGetDto ToGetDto(DetalleComprobante model)
        {
            return _mapper.Map<DetalleComprobanteGetDto>(model);
        }

        private DetalleComprobante ToEntity(DetalleComprobanteDto dto)
        {
            return _mapper.Map<DetalleComprobante>(dto);
        }

        #endregion


    }
}
