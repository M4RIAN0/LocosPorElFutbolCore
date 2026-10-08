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
                        if (cat.Key == 1)
                        {
                            if (mar.Key == 6 || (mar.Key == 5 && genero == "Mujer"))
                            {
                                idActual++;     
                                serieIndex++;   

                                random.Next(15, 100);
                                random.Next(modelosAdjetivos.Length);
                                random.Next(plantillasDescripcion.Length);

                                continue;  
                            }
                        }

                        if (cat.Key == 2)
                        {
                            if (mar.Key == 6 && genero == "Mujer")
                            {
                                idActual++;
                                serieIndex++;

                                random.Next(15, 100);
                                random.Next(modelosAdjetivos.Length);
                                random.Next(plantillasDescripcion.Length);

                                continue; 
                            }
                        }

                        decimal precio = random.Next(15, 100) * 1000m;

                        string adjetivo = modelosAdjetivos[random.Next(modelosAdjetivos.Length)];

                        string nombreProducto;

                        if (cat.Key == 1)
                        {
                            if (mar.Key == 1) // Nike
                                nombreProducto = genero == "Hombre" ? "Camiseta Futbol Nike Inter Milan Titular" :
                                                 genero == "Mujer" ? "Camiseta Futbol Nike Barcelona Alternativa" :
                                                 "Camiseta Futbol Nike Barcelona Titular";
                            else if (mar.Key == 2) // Adidas
                                nombreProducto = genero == "Hombre" ? "Camiseta Futbol Adidas River Plate Titular" :
                                                 genero == "Mujer" ? "Camiseta Futbol Adidas River Plate Alternativa" :
                                                 "Camiseta Futbol Adidas Boca Juniors Titular";
                            else if (mar.Key == 3) // Puma
                                nombreProducto = genero == "Hombre" ? "Camiseta Futbol Puma Stade Rennais Titular" :
                                                 genero == "Mujer" ? "Camiseta Futbol Puma Manchester City Titular" :
                                                 "Camiseta Futbol Puma Paraguay Titular";
                            else if (mar.Key == 4 && genero == "Hombre") // Reebok
                                nombreProducto = "Camiseta Futbol Reebok Botafogo Titular";
                            else if (mar.Key == 4 && genero == "Mujer") // Reebok
                                nombreProducto = "Camiseta Futbol Reebok Botafogo Suplente";
                            else if (mar.Key == 7 && genero == "Hombre") // Adidas-Classic
                                nombreProducto = "Camiseta Futbol Adidas Classic Argentina Suplente";
                            else if (mar.Key == 7 && genero == "Mujer") // Adidas-Classic
                                nombreProducto = "Camiseta Futbol Adidas Classic España Suplente";
                            else if (mar.Key == 8 && genero == "Hombre") // Under-Armour
                                nombreProducto = "Camiseta Futbol Under Armour Estudiantes de la Plata Titular";
                            else if (mar.Key == 8 && genero == "Mujer") // Under-Armour
                                nombreProducto = "Camiseta Futbol Under Armour Sydney FC Titular";
                            else
                                nombreProducto = $"{cat.Value.Singular} {mar.Value} {adjetivo} Serie {serieIndex}";
                        }
                        else
                        {
                            nombreProducto = $"{cat.Value.Singular} {mar.Value} {adjetivo} Serie {serieIndex}";
                        }

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
                            ImagenUrl = $@"/images/Productos/Prod-Name-{CLeanName(nombreProducto)}.jpg"
                        });

                        serieIndex++;
                    }
                }
            }

            return productos;
        }

        private static string CLeanName(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "producto-sin-nombre";

            return nombre.Replace(" ", "-").ToLower();
        }
    }
}