using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio
{
    public class DetalleCarroComprasService : IDetalleCarroComprasService
    {
        private readonly IDetalleCarroComprasRepository _repository;
        private readonly IMapper _mapper;

        public DetalleCarroComprasService(IDetalleCarroComprasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       
        public void Add(DetalleCarroComprasDto dto)
        {
            var model = ToEntity(dto);
            _repository.Add(model);
            _repository.Save();
        }

        public IEnumerable<DetalleCarroComprasGetDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public DetalleCarroComprasGetDto GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public DetalleCarroComprasGetDto GetByProductId(int productoId, int carroComprasId)
        {
            return _repository.GetByFilter(x => x.ProductoId == productoId && x.CarroComprasId == carroComprasId).Select(x => ToGetDto(x)).FirstOrDefault();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DetalleCarroComprasPutDto dto)
        {
            var model = ToEntityPut(dto);
            _repository.Attach(model);
            _repository.Save();
        }

        #region Private Methods
        private DetalleCarroComprasGetDto ToGetDto(DetalleCarroCompras model)
        {
            return _mapper.Map<DetalleCarroComprasGetDto>(model);
        }

        private DetalleCarroCompras ToEntity(DetalleCarroComprasDto model)
        {
            return _mapper.Map<DetalleCarroCompras>(model);
        }

        private DetalleCarroCompras ToEntityPut(DetalleCarroComprasPutDto model)
        {
            return _mapper.Map<DetalleCarroCompras>(model);
        }
        #endregion
    }
}
