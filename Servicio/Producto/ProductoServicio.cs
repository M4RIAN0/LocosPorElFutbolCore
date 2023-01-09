using Dominio.Repositorio.Producto;
using IServicio.Producto;
using IServicio.Producto.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Producto
{
    public class ProductoServicio : ServicioBase, IProductoServicio
    {
        private readonly IProductoRepositorio _productoRepositorio;

        public ProductoServicio(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        public void Add(ProductoDto Dto)
        {
            var producto = new Dominio.Entidades.Producto
            {
                Id = Dto.Id,
                Codigo = Dto.Codigo,
                CodigoBarra = Dto.CodigoBarra,
                Descripcion = Dto.Descripcion,
                Stock = Dto.Stock,
                Rubro_Id = Dto.RubroId,
                Marca_Id = Dto.MarcaId,
                Talle_Id = Dto.TalleId,
                Categoria_Id = Dto.CategoriaId,
                SubRubro_Id = Dto.SubRubroId,
                RowVersion = Dto.RowVersion

            };

            _productoRepositorio.Agregar(producto);
            _productoRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _productoRepositorio.Eliminar(Id);
            _productoRepositorio.Save();
        }

        //public IEnumerable<ProductoDto> GetAll()
        //{
        //    return _productoRepositorio.ObtenerTodo()
        //         .Select(x => new ProductoDto
        //         {
        //             Id = x.Id,
        //             Codigo = x.Codigo,
        //             CodigoBarra = x.CodigoBarra,
        //             Descripcion = x.Descripcion,
        //             Stock = x.Stock,
        //             RubroId = x.Rubro_Id,
        //             MarcaId = x.Marca_Id,
        //             TalleId = x.Talle_Id,
        //             CategoriaId = x.Categoria_Id,
        //             SubRubroId = x.SubRubro_Id,
        //             RowVersion = x.RowVersion

        //         }).ToList();
        //}

        public IEnumerable<ProductoDto> GetByFilter(string cadenaBuscar)
        {
            var codigo = -1;
            int.TryParse(cadenaBuscar, out codigo);

            return _productoRepositorio.ObtenerPorFlitro(x => x.Descripcion.Contains(cadenaBuscar) || x.CodigoBarra == codigo || x.Codigo == codigo)
               .Select(x => new ProductoDto
               {
                   Id = x.Id,
                   Codigo = x.Codigo,
                   CodigoBarra = x.CodigoBarra,
                   Descripcion = x.Descripcion,
                   Stock = x.Stock,
                   RubroId = x.Rubro_Id,
                   MarcaId = x.Marca_Id,
                   TalleId = x.Talle_Id,
                   CategoriaId = x.Categoria_Id,
                   SubRubroId = x.SubRubro_Id,
                   RowVersion = x.RowVersion

               }).ToList();
        }

        public ProductoDto GetById(long? Id)
        {
            var producto = _productoRepositorio.ObtenerPorId(Id);

            return new ProductoDto
            {
                Id = producto.Id,
                Codigo = producto.Codigo,
                CodigoBarra = producto.CodigoBarra,
                Descripcion = producto.Descripcion,
                Stock = producto.Stock,
                RubroId = producto.Rubro_Id,
                MarcaId = producto.Marca_Id,
                TalleId = producto.Talle_Id,
                CategoriaId = producto.Categoria_Id,
                SubRubroId = producto.SubRubro_Id,
                RowVersion = producto.RowVersion

            };
        }

        public void Update(ProductoDto Dto)
        {
            var producto = _productoRepositorio.ObtenerPorId(Dto.Id);

            producto.Descripcion = Dto.Descripcion;
            producto.Categoria_Id = Dto.CategoriaId;
        }
    }
}
