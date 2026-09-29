using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Infraestructura.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasIndex(m => m.Nombre)
                .IsUnique()
                .HasDatabaseName("IX_Producto_Nombre")
                .HasFilter("[IsDeleted] = 0");

            builder.HasData(GenerarProductosMasivos());
        }

        private static List<Producto> GenerarProductosMasivos()
        {
            var productos = new List<Producto>();
            int idActual = 1;

            var random = new Random(123);

            var marcas = new Dictionary<int, string> {
                { 1, "Nike" }, { 2, "Adidas" }, { 3, "Puma" }, { 4, "Reebok" },
                { 5, "Dc" }, { 6, "Vans" }, { 7, "Adidas-Classic" }, { 8, "Under-Armour" }
            };

            var categorias = new Dictionary<int, (string Original, string Singular)> {
                { 1, ("Camisetas Futbol", "Camiseta Futbol") },
                { 2, ("Shorts", "Short") },
                { 3, ("Pantalones", "Pantalon") },
                { 4, ("Camperas", "Campera") },
                { 5, ("Zapatillas", "Zapatilla") }
            };

            var generos = new string[] { "Hombre", "Mujer", "Unisex" };
            var modelosAdjetivos = new string[] { "Pro", "Elite", "Classic", "Urban", "Sport", "Essential", "Max", "Ultra", "Retro", "Tech" };

            var plantillasDescripcion = new string[]
            {
                "Increíble diseño en {0} {1} {3}. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para {2}.",
                "Descubre el confort absoluto con este modelo de {1}. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.",
                "Supera tus límites con lo nuevo en {0} {1}. Pensado especialmente para {2}, ofrece una durabilidad excepcional en cada uso gracias a su tecnología {3}.",
                "Un clásico renovado. La nueva colección de {1} destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.",
                "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de {3} una pieza indispensable en tu guardarropa."
            };

            foreach (var cat in categorias)
            {
                foreach (var mar in marcas)
                {
                    int serieIndex = 1;

                    foreach (var genero in generos)
                    {
                        decimal precio = random.Next(15, 100) * 1000m;

                        string adjetivo = modelosAdjetivos[random.Next(modelosAdjetivos.Length)];

                        string nombreProducto = $"{cat.Value.Singular} {mar.Value} {adjetivo} Serie {serieIndex}";

                        string plantillaElegida = plantillasDescripcion[random.Next(plantillasDescripcion.Length)];
                        string descripcionDinamica = string.Format(plantillaElegida, cat.Value.Singular.ToLower(), mar.Value, genero.ToLower(), adjetivo);

                        productos.Add(new Producto
                        {
                            ID = idActual++,
                            Nombre = nombreProducto,
                            Descripcion = descripcionDinamica,
                            Precio = precio,
                            MarcaId = mar.Key,
                            CategoriaId = cat.Key,
                            Genero = genero,
                            ImagenUrl = "https://placehold.co/600x600"
                        });

                        serieIndex++;
                    }
                }
            }

            return productos;
        }
    }
}