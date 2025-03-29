using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Infraestructura.DbContextFactory
{
    public class LxfContextFactory : IDesignTimeDbContextFactory<LxfContext>
    {
        private const string ConfigFileName = "config.json";
        private const string DefaultConnectionStringKey = "ConnectionStrings:DefaultConnection";

        // Método principal para crear el DbContext
        public LxfContext CreateDbContext(string[] args)
        {
            try
            {
                // Cargar la configuración desde el archivo config.json
                var configuration = LoadConfiguration();

                // Obtener la cadena de conexión desde la configuración
                var connectionString = GetConnectionString(configuration);

                // Crear el DbContextOptionsBuilder y configurarlo con la cadena de conexión
                var optionsBuilder = new DbContextOptionsBuilder<LxfContext>();
                optionsBuilder.UseSqlServer(connectionString);

                // Retornar el DbContext configurado
                return new LxfContext(optionsBuilder.Options);
            }
            catch (Exception ex)
            {
                // Log de error para facilitar la depuración
                Console.WriteLine($"Error al crear el DbContext: {ex.Message}");
                throw new InvalidOperationException($"Error al crear el contexto de la base de datos. {ex.Message}", ex);
            }
        }

        // Método para cargar la configuración desde 'config.json'
        private IConfiguration LoadConfiguration()
        {
            // Obtener la ruta de 'scripts' dinámicamente
            var scriptsDirectory = GetScriptsDirectory();

            // Verificar que la carpeta scripts existe
            if (!Directory.Exists(scriptsDirectory))
            {
                throw new DirectoryNotFoundException($"La carpeta 'scripts' no se encuentra en la ruta esperada: {scriptsDirectory}");
            }

            // Cargar la configuración desde el archivo 'config.json' en la carpeta 'scripts'
            var configuration = new ConfigurationBuilder()
                .SetBasePath(scriptsDirectory)  // Usamos la ruta dinámica
                .AddJsonFile(ConfigFileName)    // Cargar el archivo JSON
                .Build();

            return configuration;
        }

        // Obtener la ruta de la carpeta 'scripts' dinámicamente
        private string GetScriptsDirectory()
        {
            // Obtener la ruta del directorio que contiene el archivo ejecutable (o bin/Debug/net8.0)
            var binDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Subir hasta la raíz del proyecto (5 directorios hacia arriba, ajustado según la estructura)
            var rootDirectory = Directory.GetParent(binDirectory)?.Parent?.Parent?.Parent?.Parent?.Parent?.FullName;

            if (string.IsNullOrEmpty(rootDirectory))
            {
                throw new InvalidOperationException("No se pudo obtener la ruta raíz del proyecto.");
            }

            // Ruta completa a la carpeta 'scripts' desde la raíz del proyecto
            var scriptsDirectory = Path.Combine(rootDirectory, "scripts");

            // Verificar si la carpeta 'scripts' existe
            if (!Directory.Exists(scriptsDirectory))
            {
                throw new DirectoryNotFoundException($"La carpeta 'scripts' no se encuentra en la ruta esperada: {scriptsDirectory}");
            }

            return scriptsDirectory;
        }




        // Obtener la cadena de conexión desde la configuración
        private string GetConnectionString(IConfiguration configuration)
        {
            // Usar la clave de la sección para acceder a la cadena de conexión
            var connectionString = configuration.GetSection(DefaultConnectionStringKey).Value;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"La cadena de conexión '{DefaultConnectionStringKey}' no está configurada correctamente en el archivo {ConfigFileName}.");
            }

            return connectionString;
        }
    }
}
