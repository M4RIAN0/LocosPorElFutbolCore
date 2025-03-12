namespace LXF.Web.Utility
{
    public class SD
    {
		public static string LXFApiBase { get; set; } // valor de la url de el endpoint del API

		public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public enum ApiType // tipos de llamadas de la API
        {
            GET, POST, PUT, DELETE
        }
    }
}
