namespace AppConexion
{
    public static class StringConexion
    {
        // comentar lo cual no sea de mi proyecto

        public const string Servidor = @"DESKTOP-DF7MS3I";
        public const string BaseDatos = "LXFDB";
        public const string Usuario = "MARCOS";
        public const string Password = "1234";

        //public const string Servidor = @"Mi Servidor";
        //public const string BaseDatos = "Mi Base de Datos";
        //public const string Usuario = "Mi Usuario";
        //public const string Password = "Mi Password";

        public static string ObtenerCadenaConexion()
        {
            return $"Data Source = {Servidor}; " +
                   $"Initial Catalog = {BaseDatos}; " +
                   $"User Id = {Usuario}; " +
                   $"Password = {Password};";
        }
    }
}

