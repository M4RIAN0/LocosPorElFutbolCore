using Dominio.Repositorio.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IServicio.TemporalObject
{
    public interface ITemporalObjectService
    {
        // Genera un ID único para usar como external_reference
        string GetUniqueReference();

        // Guarda una lista de objects completo en caché usando el ID como clave
        Task StoreObjectsCollectionAsync<T>(string reference, IEnumerable<T> coleccion);

        // Recupera una lista de objects completo de la caché
        Task<IEnumerable<T>?> RetrieveObjectsCollectionAsync<T>(string reference);

        // Elimina el registro temporal después de la finalización
        void RemoveObjectsCollectionTemporal(string reference);
    }
}
