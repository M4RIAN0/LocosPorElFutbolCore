using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using System.Linq;

namespace Servicio
{
    public class CarroCompraService : ICarroCompraService
    {
        private readonly ICarroCompraRepository _carroRepository;
        private readonly IDetalleCarroCompraRepository _detalleCarroRepository;
        private readonly IMapper _mapper;

        public CarroCompraService(ICarroCompraRepository repository, IDetalleCarroCompraRepository detalleCarroCompraRepository, IMapper mapper)
        {
            _carroRepository = repository;
            _detalleCarroRepository = detalleCarroCompraRepository;
            _mapper = mapper; 
        }

        public void Add(CarroCompraDto dto)
        {
            var modelCarroCompra = ToCarroCompraEntity(dto);
            _carroRepository.Add(modelCarroCompra);
            _carroRepository.Save();
        }

        public CarroCompraGetDto GetByUserId(string userId)
        {
            return _carroRepository.GetByFilter(x => x.UserId.Equals(userId), "DetalleCarroCompra.Producto").Select(x => ToCarroCompraGetDto(x)).FirstOrDefault();
        }

        public CarroCompra GetLast()
        {
            return _carroRepository.OrderByDescending(x => x.ID).FirstOrDefault();
        }

        public CarroCompraGetDto GetById(int? id)
        {
            var model = _carroRepository.GetById(id);
            return ToCarroCompraGetDto(model);
        }

        public void Removeitem(int id)
        {
            _carroRepository.BeginTransaction();

            var item = _detalleCarroRepository.GetById(id);

            _detalleCarroRepository.Delete(id);
            _detalleCarroRepository.Save();

            var carroModel = _carroRepository.GetById(item.CarroCompraId, "DetalleCarroCompra");

            if (carroModel.DetalleCarroCompras.Any())
            {
                carroModel.Total -= item.Subtotal;
                _carroRepository.Attach(carroModel);
            }
            else
            {
                _carroRepository.Delete(carroModel.ID);
            }
            _carroRepository.Save();

            _carroRepository.Commit();
        }

        public void Update(CarroCompraPutDto dto)
        {
            _carroRepository.BeginTransaction();

            EditValuesDetalleCarroCompra(dto);

            // Actualizamos el Carro
            var carroModel = ToCarroCompraEntityPut(dto);
            carroModel.DetalleCarroCompras = null;
            _carroRepository.Attach(carroModel);
            _carroRepository.Save();

            //Actualizamos el el Item ya existente en el carro 
            var detalleCarroModel = ToDetalleCarroCompraEntity(dto.DetalleCarroCompras.First());
            _detalleCarroRepository.Attach(detalleCarroModel);
            _detalleCarroRepository.Save();

            _carroRepository.Commit();
        }

        #region Private Methods
        private void EditValuesDetalleCarroCompra(CarroCompraPutDto dto)
        {
            var carro = GetByUserId(dto.UserId);

            dto.Total = carro.Total;

            if (carro != null && dto.DetalleCarroCompras != null)
            {
                // 1. Convertir la lista del carrito existente a un diccionario para una búsqueda eficiente O(1)
                var existingItems = carro.DetalleCarroCompras.ToDictionary(x => x.ProductoId);

                // 2. Recorrer la lista del DTO que contiene los ítems a actualizar
                dto.DetalleCarroCompras.ToList().ForEach(item =>
                {
                    // 3. Usar TryGetValue para buscar el ítem en el diccionario
                    if (existingItems.TryGetValue(item.ProductoId, out var existingItem))
                    {
                        // acutalizamos el total con el item que estamos agregando
                        dto.Total += item.Cantidad * item.Precio;
                        // Actualizamos su cantidad
                        item.Cantidad += existingItem.Cantidad;
                        // Actualizamos su precio por si cambio
                        item.Precio = dto.DetalleCarroCompras.First().Precio;
                        // Actualizamos subtotal
                        item.Subtotal = item.Cantidad * item.Precio;
                    }
                });
            }
        }

        private CarroCompraGetDto ToCarroCompraGetDto(CarroCompra model)
        {
            return _mapper.Map<CarroCompraGetDto>(model);
        }

        private CarroCompra ToCarroCompraEntity(CarroCompraDto dto)
        {
            return _mapper.Map<CarroCompra>(dto);
        }

        private CarroCompra ToCarroCompraEntityPut(CarroCompraPutDto dto)
        {
            return _mapper.Map<CarroCompra>(dto);
        }

        private DetalleCarroCompra ToDetalleCarroCompraEntity(DetalleCarroCompraDto dto)
        {
            return _mapper.Map<DetalleCarroCompra>(dto);
        }
        #endregion
    }
}
