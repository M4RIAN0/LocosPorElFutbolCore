using static LXF.Web.Utility.SD;

namespace LXF.Web.Models.Dto
{
    public class RequestDto // VALOR DEVUELTO EN LA SOLICITUD DE LLAMADA DE LA API
    {
        public ApiType ApiType { get; set; } = ApiType.GET; // TIPO DE LLAMADA (GET, POST, PUT, DELETE)
        public string Url { get; set; } // URI de la solicitud
        public object Data { get; set; } // data de la solictud en JSON FORMAT
        public string AccesToken { get; set; } // TOKEN de autenticacion para acceder a API PRIVADA (JWT)
    }
}
