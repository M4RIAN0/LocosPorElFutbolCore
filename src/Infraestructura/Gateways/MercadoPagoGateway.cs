using Dominio.Repositorio.Dtos;
using Dominio.Repositorio.Gateways;
using Infraestructura.Configurations;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructura.Gateways
{
    public class MercadoPagoGateway : IMercadoPagoGateway
    {

        public MercadoPagoGateway(IOptions<MercadoPagoConfiguration> config)
        {
            // Inicializar la biblioteca de Mercado Pago con el Access Token
            MercadoPagoConfig.AccessToken = config.Value.AccessToken;
        }

        public async Task<string> CretePaymentPreference(string externalReferenceId, OrdenCompraGetDto dto)
        {
            if (dto.DetalleOrdenCompras == null || !dto.DetalleOrdenCompras.Any())
            {
                throw new ArgumentException("La orden de compra no contiene ítems para procesar.");
            }

            // 2. Mapear los ítems de tu DTO a los objetos del SDK
            var mpItems = dto.DetalleOrdenCompras.ToList().Select(item => new PreferenceItemRequest
            {
                // Título, cantidad y precio son obligatorios
                Title = item.ProductoVariante.Producto.Nombre,
                Description = item.ProductoVariante.Producto.Descripcion,
                Quantity = item.Cantidad,
                UnitPrice = item.Precio,
                CurrencyId = "ARS",
                Id = item.ProductoVarianteId.ToString()
            }).ToList();

            // 3. Crear el objeto de request de la preferencia
            var request = new PreferenceRequest
            {
                Items = mpItems,
                

                // Referencia externa: Clave para ligar el pago a tu OrdenCompra
                ExternalReference = externalReferenceId,

                // BackUrls: CRUCIAL para redirigir al usuario
                BackUrls = new PreferenceBackUrlsRequest
                {
                    // Estas deben ser las URLs finales de tu aplicación web (LxIF.Web/API)
                    Success = $"https://localhost:7235/Venta/Success",
                    Failure = $"https://localhost:7235/Venta/Failure",
                    Pending = "URL_DE_TU_API/Pagos/Pendiente"
                },

                // AutoReturn: Devuelve al usuario a la URL de éxito si el pago es aprobado
                AutoReturn = "approved",

                // Otros datos como el pagador, etc., se añadirían aquí
                // Payer = new PreferencePayerRequest { ... }
            };

            if (dto.CostoEnvio > 0 && dto != null)
            {
                request.Shipments = new PreferenceShipmentsRequest
                {
                    Cost = dto.CostoEnvio
                };
            }

            // 4. Llamar al SDK de Mercado Pago
            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);

            // 5. Devolver el resultado necesario
            if (preference.InitPoint != null)
            {
                // Devolvemos la URL de checkout para que la capa de Servicio/API la envíe al Frontend
                return preference.InitPoint;
            }

            // Manejo de errores si la API de MP falló
            throw new InvalidOperationException($"Error al crear url de pago:");/* {preference}");*/
        }
    }
}
