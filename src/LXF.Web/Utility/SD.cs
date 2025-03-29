namespace LXF.Web.Utility
{
    public class SD
    {
		public static string LXFApiBase { get; set; } // valor de la url de el endpoint del API

		public const string RoleAdmin = "Administrador";
        public const string RoleCustomer = "Cliente";
        public enum ApiType // tipos de llamadas de la API
        {
            GET, POST, PUT, DELETE
        }
    }
}
