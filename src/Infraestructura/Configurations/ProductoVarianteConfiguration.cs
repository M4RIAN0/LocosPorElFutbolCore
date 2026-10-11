using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infraestructura.Configurations
{
    public class ProductoVarianteConfiguration : IEntityTypeConfiguration<ProductoVariante>
    {
        public void Configure(EntityTypeBuilder<ProductoVariante> builder)
        {
            builder.HasIndex(v => new { v.ProductoId, v.Talle })
                .IsUnique()
                .HasDatabaseName("IX_ProductoVariante_ProductoId_Talle")
                .HasFilter("[IsDeleted] = 0");

            builder.HasIndex(v => v.CodigoBarra)
                .IsUnique()
                .HasDatabaseName("IX_ProductoVariante_CodigoBarra")
                .HasFilter("[IsDeleted] = 0");

            builder.HasData(GenerarVariantesMasivas());
        }

        private static List<ProductoVariante> GenerarVariantesMasivas()
        {
            var variantes = new List<ProductoVariante>();
            int varianteId = 1;
            int productoIdActual = 1;

            var random = new Random(456);

            var tallesRopa = new string[] { "XS", "S", "M", "L", "XL" };
            var tallesCalzado = new string[] { "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46" };

            // 1. Replicamos los mismos diccionarios para que el bucle sea idéntico al de Producto
            var marcas = new Dictionary<int, string> {
        { 1, "Nike" }, { 2, "Adidas" }, { 3, "Puma" }, { 4, "Reebok" },
        { 5, "Dc" }, { 6, "Vans" }, { 7, "Adidas-Classic" }, { 8, "Under-Armour" }
    };

            var categorias = new Dictionary<int, string> {
        { 1, "Camisetas Futbol" },
        { 2, "Shorts" },
        { 3, "Pantalones" },
        { 4, "Camperas" },
        { 5, "Zapatillas" } // Zapatillas ahora es 5, no 8
    };

            var generos = new string[] { "Hombre", "Mujer", "Unisex" };

            foreach (var cat in categorias)
            {
                bool esCalzado = (cat.Key == 5);
                var catalogoTalles = esCalzado ? tallesCalzado : tallesRopa;

                foreach (var mar in marcas)
                {
                    foreach (var genero in generos)
                    {
                        if (cat.Key == 1)
                        {
                            if (mar.Key == 6 || (mar.Key == 5 && genero == "Mujer"))
                            {
                                productoIdActual++;
                                continue;
                            }
                        }

                        if (cat.Key == 2)
                        {
                            if (mar.Key == 6 && genero == "Mujer")
                            {
                                productoIdActual++;
                                continue;
                            }

                        }

                        // Generamos talles aleatorios para el producto actual
                        int cantidadTalles = esCalzado ? random.Next(3, 8) : random.Next(1, 4);
                        var tallesSeleccionados = catalogoTalles.OrderBy(x => random.Next()).Take(cantidadTalles).ToList();

                        foreach (var talle in tallesSeleccionados)
                        {
                            bool sinStock = random.Next(1, 101) <= 25;
                            int stockActual = sinStock ? 0 : random.Next(1, 50);

                            variantes.Add(new ProductoVariante
                            {
                                ID = varianteId,
                                ProductoId = productoIdActual, // Este ID ahora está 100% sincronizado
                                Talle = talle,
                                Stock = stockActual,
                                CodigoBarra = (100000 + varianteId).ToString()
                            });

                            varianteId++;
                        }

                        productoIdActual++;
                    }
                }
            }

            return variantes;
        }
    }
}