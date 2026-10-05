using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using Dominio.Repositorio.Dtos;
using IServicio;
using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio
{
    public class ProductoService : ServicioBase, IProductoService
    {
        private readonly IProductoRepository _repository;
        private readonly IProductoVarianteRepository _productoVarianteRepository;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository repository, IProductoVarianteRepository productoVarianteRepository, IMapper mapper)
        {
            _repository = repository;
            _productoVarianteRepository = productoVarianteRepository;
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
            _repository.BeginTransaction();

            _repository.SoftDelete(id);
            DeleteProductosVariantes(id);

            _repository.Save();

            _repository.Commit();
        }

        public IEnumerable<ProductoGetDto> GetAll()
        {
            return [.. _repository.GetAll("Marca,Categoria,ProductosVariantes").Select(x => ToGetDto(x))];
        }

        public IEnumerable<ProductoGetDto> GetByFilter(string cadenaBuscar)
        {
            var codigo = -1;
            int.TryParse(cadenaBuscar, out codigo);

            return [.. _repository.GetByFilter(x => x.Descripcion.Contains(cadenaBuscar)).Select(x => ToGetDto(x))];
        }

        public ProductoGetDto GetById(int id)
        {
            return ToGetDto(_repository.GetById(id, "Marca,Categoria,ProductosVariantes"));
        }

        public ProductoVarianteGetDto GetByIdProductoVariante(int productoVarianteId)
        {
            return ToGetDtoProductoVariante(_productoVarianteRepository.GetById(productoVarianteId,"Producto"));
        }

        public IEnumerable<ProductoGetDto> GetInStockProductos()
        {
            return[.. _repository.GetByFilter( p => p.ProductosVariantes.Any(v => v.Stock > 0),"Marca,Categoria,ProductosVariantes").Select(x => ToGetDto(x))];
        }

        public IEnumerable<ProductoGetDto> GetSimilProductos(int productoId, int categoriaId, int marcaId)
        {
            var enStock = GetInStockProductos();

            return [.. enStock.Where(p => p.CategoriaId == categoriaId && p.Id != productoId).OrderByDescending(p => p.MarcaId == marcaId).ThenBy(p => Guid.NewGuid()).Take(30)];
        }

        public IEnumerable<ProductoGetDto> GetInterestingProductos(int productoId)
        {
            var enStock = GetInStockProductos();

            return [.. enStock.Where(p => p.Id != productoId).OrderBy(p => Guid.NewGuid()).Take(30)];
        }

        public IEnumerable<ProductoGetDto> GetByFilterGenderProductos(string cadenaBuscar)
        {
            var enStock = GetInStockProductos();

            var codigo = -1;
            int.TryParse(cadenaBuscar, out codigo);

            return [.. enStock.Where(x => x.Genero.Equals(cadenaBuscar)).Select(x => ToGetDto(x))];
        }

        public void Update(ProductoPutDto dto)
        {
            var model = ToPutEntity(dto);

            _repository.BeginTransaction();

            CheckProductosVariantes(model);
            model.ProductosVariantes = null;
            _repository.Attach(model);
            _repository.Save();
            
            _repository.Commit();
        }

        public ProductoGetDto GetLast()
        {
            return ToGetDto (_repository.OrderByDescending(x => x.ID, "Marca,Categoria,ProductosVariantes").FirstOrDefault());
        }

        #region Private Methods

        private void CheckProductosVariantes(Producto model)
        {
            var tallesNewAndExisting = model.ProductosVariantes ?? new List<ProductoVariante>(); // talles existentes que se mantienen y nuevos que se agregan
            var talleExist = ToEntity(GetById(model.ID)).ProductosVariantes.ToList(); // talles existentes
            var listTalleId = tallesNewAndExisting.Where(x => x.ID > 0).Select(x => x.ID).ToList();// lista de IDS de solo talles existentes que se mantienen
            var tallesToDelete = talleExist.Where(x => !listTalleId.Contains(x.ID)).ToList(); // talles existentes que se eliminan

            foreach (var talle in tallesToDelete)
            {
                _productoVarianteRepository.Delete(talle.ID);
            }

            foreach (var item in talleExist.Where(x => listTalleId.Contains(x.ID)))
            {
                var talleToUpdate = tallesNewAndExisting.FirstOrDefault(x => x.ID == item.ID);

                if (talleToUpdate != null)
                {
                    item.Stock = talleToUpdate.Stock;
                    _productoVarianteRepository.Attach(item);
                }
            }

            var tallesToAdd = tallesNewAndExisting.Where(x => x.ID == 0).ToList();

            foreach (var newTalle in tallesToAdd)
            {
                newTalle.ProductoId = model.ID;
                _productoVarianteRepository.Add(newTalle);
            }

            _productoVarianteRepository.Save();
        }

        private void DeleteProductosVariantes(int productoiId)
        {
            var talleExist = GetById(productoiId).ProductosVariantes.ToList();
            foreach (var talle in talleExist)
            {
                _productoVarianteRepository.SoftDelete(talle.Id);
            }
            _repository.Save();
        }

        private ProductoGetDto ToGetDto(object? obj)
        {
            return _mapper.Map<ProductoGetDto>(obj);
        }

        private Producto ToPostEntity(object? obj)
        {
            return _mapper.Map<Producto>(obj);
        }

        private Producto ToPutEntity(object? obj)
        {
            return _mapper.Map<Producto>(obj);
        }

        private Producto ToEntity(object? obj)
        {
            return _mapper.Map<Producto>(obj);
        }

        private ProductoVarianteGetDto ToGetDtoProductoVariante(object? obj)
        {
            return _mapper.Map<ProductoVarianteGetDto>(obj);
        }

        #endregion
    }
}
