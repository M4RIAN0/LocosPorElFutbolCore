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

            for (int categoria = 1; categoria <= 8; categoria++)
            {
                bool esCalzado = (categoria == 8);
                var catalogoTalles = esCalzado ? tallesCalzado : tallesRopa;

                for (int marca = 1; marca <= 5; marca++)
                {
                    for (int genero = 1; genero <= 3; genero++)
                    {
                        int cantidadTalles = esCalzado ? random.Next(3, 8) : random.Next(1, 4);
                        var tallesSeleccionados = catalogoTalles.OrderBy(x => random.Next()).Take(cantidadTalles).ToList();

                        foreach (var talle in tallesSeleccionados)
                        {
                            bool sinStock = random.Next(1, 101) <= 25; 
                            int stockActual = sinStock ? 0 : random.Next(1, 50);

                            variantes.Add(new ProductoVariante
                            {
                                ID = varianteId,
                                ProductoId = productoIdActual,
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