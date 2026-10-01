using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using System;
using System.Linq;

namespace Servicio
{
    public class CarroCompraService : ICarroComprasService
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

        public CarroCompraGetDto GetByUserId(string userId)
        {
            var result = _carroRepository.GetByFilter(x => x.UserId.Equals(userId), "DetalleCarroCompras.ProductoVariante.Producto");

            // Evaluamos el primer registro de forma segura usando el operador nulo condicional
            var carritoDb = result?.FirstOrDefault();

            // Si no hay carrito, devolvemos null pacíficamente sin lanzar excepciones
            if (carritoDb == null)
            {
                return null;
            }

            // Solo mapeamos si estamos seguros de que el carrito existe
            return ToCarroCompraGetDto(carritoDb);
        }

        public void Add(CarroCompraDto dto)
        {
            var modelCarroCompra = ToCarroCompraEntity(dto);
            _carroRepository.Add(modelCarroCompra);
            _carroRepository.Save();
        }

        public void Remove(int id)
        {
            _carroRepository.Delete(id);
            _carroRepository.Save();
        }

        public void AddItem(int id)
        {
            var detalleCarroModel = _detalleCarroRepository.GetById(id);
            detalleCarroModel.Cantidad += 1;
            detalleCarroModel.SubTotal = detalleCarroModel.Cantidad * detalleCarroModel.Precio;

            var carroModel = _carroRepository.GetById(detalleCarroModel.CarroComprasId);
            carroModel.Total += detalleCarroModel.Precio; // sumamos el valor del nuevo item al total del carro
            carroModel.LastModified = DateTime.Now;

            _detalleCarroRepository.BeginTransaction();

            _detalleCarroRepository.Attach(detalleCarroModel);
            _detalleCarroRepository.Save();

            _carroRepository.Attach(carroModel);
            _carroRepository.Save();

            _detalleCarroRepository.Commit();

        }

        public void SubtractItem(int id)
        {

            var detalleCarroModel = _detalleCarroRepository.GetById(id);
            var carroModel = _carroRepository.GetById(detalleCarroModel.CarroComprasId);
            carroModel.Total -= detalleCarroModel.SubTotal; // restamos el subtotal del item al total del carro

            detalleCarroModel.Cantidad -= 1;
            detalleCarroModel.SubTotal = detalleCarroModel.Cantidad * detalleCarroModel.Precio;
            carroModel.Total += detalleCarroModel.SubTotal; // sumamos el nuevo subtotal del item al total del carro
            carroModel.LastModified = DateTime.Now;

            _detalleCarroRepository.BeginTransaction();

            _carroRepository.Attach(carroModel);

            if (detalleCarroModel.Cantidad >= 1)
            {
                _detalleCarroRepository.Attach(detalleCarroModel);
            }
            else
            {
                _detalleCarroRepository.Delete(detalleCarroModel.ID);

                if (carroModel.Total == 0m)
                    _carroRepository.Delete(carroModel.ID);
               
            }

            _detalleCarroRepository.Save();
            _carroRepository.Save();

            _detalleCarroRepository.Commit();

        }

        public void Removeitem(int id)
        {
            _carroRepository.BeginTransaction();

            var item = _detalleCarroRepository.GetById(id);

            _detalleCarroRepository.Delete(id);
            _detalleCarroRepository.Save();

            var carroModel = _carroRepository.GetById(item.CarroComprasId, "DetalleCarroCompras");

            if (carroModel.DetalleCarroCompras.Any())
            {
                carroModel.Total -= item.SubTotal;
                carroModel.LastModified = DateTime.Now;
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
            carroModel.LastModified = DateTime.Now;
            carroModel.DetalleCarroCompras = null;
            _carroRepository.Attach(carroModel);
            _carroRepository.Save();

            //Actualizamos el Item ya existente en el carro 
            var detalleCarroModel = ToDetalleCarroCompraEntity(dto.DetalleCarroCompras.First());
            _detalleCarroRepository.Attach(detalleCarroModel);
            _detalleCarroRepository.Save();

            _carroRepository.Commit();
        }

        public bool GetAnyWithProductId(int productId)
        {
            var result = _carroRepository.GetByFilter(x => x.DetalleCarroCompras.Any(d => d.ProductoVariante.ProductoId == productId));
            return result.Any();
        }

        #region Private Methods
        private void EditValuesDetalleCarroCompra(CarroCompraPutDto dto)
        {
            var carro = GetByUserId(dto.UserId);

            dto.Total = carro.Total;

            if (carro != null && dto.DetalleCarroCompras != null)
            {
                // 1. Convertir la lista del carrito existente a un diccionario para una búsqueda eficiente O(1)
                var existingItems = carro.DetalleCarroCompras.ToDictionary(x => x.ProductoVarianteId);

                // 2. Recorrer la lista del DTO que contiene los ítems a actualizar
                dto.DetalleCarroCompras.ToList().ForEach(item =>
                {
                    // 3. Usar TryGetValue para buscar el ítem en el diccionario
                    if (existingItems.TryGetValue(item.ProductoVarianteId, out var existingItem))
                    {
                        // acutalizamos el total con el item que estamos agregando
                        dto.Total += item.Cantidad * item.Precio;
                        // Actualizamos su cantidad
                        item.Cantidad += existingItem.Cantidad;
                        // Actualizamos su precio por si cambio
                        item.Precio = dto.DetalleCarroCompras.First().Precio;
                        // Actualizamos SubTotal
                        item.SubTotal = item.Cantidad * item.Precio;
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
