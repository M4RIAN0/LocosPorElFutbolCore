using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IServicio.TemporalObject
{
    public class TemporalObjectService : ITemporalObjectService
    {
        private readonly IMemoryCache _cache;
        // Duración de vida de los datos temporales (ej. 60 minutos)
        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(60);
    
        public TemporalObjectService(IMemoryCache cache)
        {
            _cache = cache;
        }
    
        // El método que genera la clave única para Mercado Pago (External Reference)
        public string GetUniqueReference()
        {
            // Usamos un GUID simplificado para mayor seguridad y unicidad.
            return Guid.NewGuid().ToString("N");
        }
    
        // ⭐ 1. Guardar la Colección Genérica ⭐
        public async Task StoreObjectsCollectionAsync<T>(string reference, IEnumerable<T> coleccion)
        {
            if (coleccion == null)
            {
                throw new ArgumentNullException(nameof(coleccion), "La colección de objetos temporales no puede ser nula.");
            }
    
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(CacheDuration);
    
            // Almacena la colección (ej. IEnumerable<object>) en la caché.
            _cache.Set(reference, coleccion, cacheEntryOptions);
    
            await Task.CompletedTask;
        }
    
        // ⭐ 2. Recuperar la Colección Genérica ⭐
        public Task<IEnumerable<T>?> RetrieveObjectsCollectionAsync<T>(string reference)
        {
            // Intenta obtener el valor de la caché. 
            // TryGetValue intenta automáticamente castear el objeto almacenado a IEnumerable<T>.
            if (_cache.TryGetValue(reference, out IEnumerable<T>? coleccion))
            {
                return Task.FromResult(coleccion);
            }
    
            // Si no se encuentra (expiró o no existe), devuelve null (el valor por defecto de T?).
            return Task.FromResult<IEnumerable<T>?>(default);
        }
    
        // ⭐ 3. Eliminar la Colección Temporal ⭐
        public void RemoveObjectsCollectionTemporal(string reference)
        {
            // Remove elimina la clave y el valor asociado de la caché.
            _cache.Remove(reference);
        }
    }
}