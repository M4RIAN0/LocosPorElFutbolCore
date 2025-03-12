using LXF.Web.Models.Dto;
using LXF.Web.Service.IService;
using Newtonsoft.Json;
using System.Text;
using static LXF.Web.Utility.SD;

namespace LXF.Web.Service
{
    public class ServiceBase : IServiceBase
    {
        // usamos cliente Factory para las consultas a la api 
        private readonly IHttpClientFactory _httpClientFactory;
        public ServiceBase(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("LXFApi"); //creamos un cliente con un nombre cualquiera
                HttpRequestMessage message = new(); // usamos HttpRequestMessage para hacer las llamadas
                message.Headers.Add("Accept", "application/json"); // se puede aplicar configuraciones sobre message
                                                                   // aplicamos que acepte llamadas de tipo Json

                message.RequestUri = new Uri(requestDto.Url); // uri de la llamada

                if (requestDto.Data != null) // si la consulta tiene datos para enviar en la llamada se debe serializar el string que mandamos
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json"); //serializamos el payload

                // la llamada puede tener una respuesta por lo que cremos una variable para almacenar esa respuesta
                HttpResponseMessage? apiRepsonse = null;

                // seteamos el tipo de metodo que se utilizo
                switch (requestDto.ApiType) 
                {
                    case ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                // realizamos la llamada asyncrona y le pasamos el message que se armo como parametro y lo almacenamos en la variable apiResponse
                apiRepsonse = await client.SendAsync(message);

                //verificamos el estado que devolvio la llamada
                switch (apiRepsonse.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case System.Net.HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiRepsonse.Content.ReadAsStringAsync(); // serializa la respuesta del content de la llamada
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent); // deserializamos la respuesta en el tipo ResponseDto

                        return apiResponseDto;
                }
            }
            catch(Exception ex)
            {
                return new() { Message = ex.Message.ToString(), IsSuccess = false, }; 
            }

        }
    }
}
