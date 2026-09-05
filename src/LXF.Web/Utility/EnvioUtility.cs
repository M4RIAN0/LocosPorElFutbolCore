namespace LXF.Web.Utility
{
    public static class EnvioUtility
    {
        public const string CompraConfirmada = "Compra confirmada";
        public const string EnPreparacion = "En preparación";
        public const string EnCamino = "En camino";
        public const string Entregado = "Entregado";


        public static string GetRandomState()
        {
            var estados = new[]
            {
                CompraConfirmada,
                EnPreparacion,
                EnCamino,
                Entregado
            };

            var random = new Random();
            int indice = random.Next(estados.Length);
            return estados[indice];
        }

        public static decimal CalcularCostoEnvio(string? provincia)
        {
            if (string.IsNullOrEmpty(provincia)) return 8500m; // Tarifa base por defecto

            string prov = provincia.Trim().ToLower();

            // 1. Tucumán (E-Commerce local) -> GRATIS
            if (prov.Contains("tucuman") || prov.Contains("tucumán"))
            {
                return 0m;
            }

            // 2. NOA / Provincias Cercanas (Salta, Jujuy, Catamarca, Santiago del Estero)
            if (prov.Contains("salta") || prov.Contains("jujuy") ||
                prov.Contains("catamarca") || prov.Contains("santiago"))
            {
                return 4500m;
            }

            // 3. Centro / Cuyo (Córdoba, Santa Fe, Mendoza, La Rioja, San Juan, San Luis)
            if (prov.Contains("córdoba") || prov.Contains("cordoba") ||
                prov.Contains("santa fe") || prov.Contains("mendoza") ||
                prov.Contains("rioja") || prov.Contains("san juan") || prov.Contains("san luis"))
            {
                return 7200m;
            }

            // 4. AMBA / Buenos Aires / Entre Ríos / Corrientes
            if (prov.Contains("buenos aires") || prov.Contains("entre ríos") ||
                prov.Contains("entre rios") || prov.Contains("corrientes") || prov.Contains("chaco"))
            {
                return 9500m;
            }

            // 5. Patagonia y provincias lejanas (Tierra del Fuego, Santa Cruz, Chubut, Río Negro, Neuquén, Misiones)
            return 12500m;
        }
    }
}