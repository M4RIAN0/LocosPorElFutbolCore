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

        private string GetScriptsDirectory()
        {
            var currentDir = AppDomain.CurrentDomain.BaseDirectory;

            // Sube de nivel carpeta por carpeta hasta encontrar la que contenga "scripts"
            while (!string.IsNullOrEmpty(currentDir))
            {
                var potentialScriptDir = Path.Combine(currentDir, "scripts");
                if (Directory.Exists(potentialScriptDir))
                {
                    return potentialScriptDir;
                }
                currentDir = Directory.GetParent(currentDir)?.FullName;
            }

            throw new DirectoryNotFoundException("No se encontró la carpeta 'scripts' en el árbol de directorios hacia arriba.");
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
