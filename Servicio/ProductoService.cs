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
    public class ProductoService : ServicioBase, IProductoService
    {
        private readonly IProductoRepository _repository;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(ProductoDto dto)
        {
            var model = ToPostEntity(dto);
            _repository.Add(model);
            _repository.Save();
        }

        public void SoftDelete(int id)
        {
            _repository.SoftDelete(id);
            _repository.Save();
        }

        public IEnumerable<ProductoGetDto> GetAll()
        {
            return _repository.GetAll("Talle,Marca,Categoria")
                 .Select(x => ToGetDto(x)).ToList();
        }

        public IEnumerable<ProductoGetDto> GetByFilter(string cadenaBuscar)
        {
            var codigo = -1;
            int.TryParse(cadenaBuscar, out codigo);

            return _repository.GetByFilter(x => x.Descripcion.Contains(cadenaBuscar) || x.CodigoBarra == codigo)
               .Select(x => ToGetDto(x)).ToList();
        }

        public ProductoGetDto GetById(int? id)
        {
            var model = _repository.GetById(id);

            return ToGetDto(model);
        }

        public void Update(ProductoPutDto dto)
        {
            var model = ToPutEntity(dto);

            _repository.Attach(model);
            _repository.Save();
        }

        #region Private Methods
        private ProductoGetDto ToGetDto(Producto model)
        {
            return _mapper.Map<ProductoGetDto>(model);
        }

        private Producto ToPostEntity(ProductoDto dto)
        {
            return _mapper.Map<Producto>(dto);
        }

        private Producto ToPutEntity(ProductoPutDto dto)
        {
            return _mapper.Map<Producto>(dto);
        }
        #endregion
    }
}
