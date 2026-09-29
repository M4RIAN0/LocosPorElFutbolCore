using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static LXF.Web.Utility.SD;

namespace LXF.Web.ServiceApiClient
{
    public class ServiceBaseApiClient : IServiceBaseApiClient
    {
        // usamos cliente Factory para las consultas a la api 
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;
        public ServiceBaseApiClient(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }
        public async Task<ResponseViewModel?> SendAsync(RequestViewModel requestViewModel, bool withBearer = true)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("LXFApi"); //creamos un cliente con un nombre cualquiera
                HttpRequestMessage message = new(); // usamos HttpRequestMessage para hacer las llamadas
                message.Headers.Add("Accept", "application/json"); // se puede aplicar configuraciones sobre message
                                                                   // aplicamos que acepte llamadas de tipo Json

                //Token
                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    // agregamos un nuevo header con el nuevo token
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }

                message.RequestUri = new Uri(requestViewModel.Url); // uri de la llamada

                if (requestViewModel.Data != null) // si la consulta tiene datos para enviar en la llamada se debe serializar el string que mandamos
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestViewModel.Data), Encoding.UTF8, "application/json"); //serializamos el payload

                // la llamada puede tener una respuesta por lo que cremos una variable para almacenar esa respuesta
                HttpResponseMessage? apiRepsonse = null;

                // seteamos el tipo de metodo que se utilizo
                switch (requestViewModel.ApiType) 
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
                // serializa la respuesta del content de la llamada
                var apiContent = await apiRepsonse.Content.ReadAsStringAsync();

                //verificamos el estado que devolvio la llamada
                switch (apiRepsonse.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        return ResponseFail(apiContent);
                    case HttpStatusCode.NotFound:
                        return ResponseFail(apiContent);
                    case HttpStatusCode.Forbidden:
                        return ResponseFail(apiContent);
                    case HttpStatusCode.Unauthorized:
                        return ResponseFail(apiContent);
                    case HttpStatusCode.Conflict:
                        return ResponseFail(apiContent);
                    case HttpStatusCode.InternalServerError:
                        return ResponseFail(apiContent);
                    default: return ResponseOk(apiContent);      
                }
            }
            catch(Exception ex)
            {
                return new() { Message = ex.Message.ToString(), IsSuccess = false, }; 
            }

        }

        #region Private Methods
        private static ResponseViewModel? ResponseOk(string apiContent)
        {
            return new[] { "isSuccess\":", "message\":\"", "result\":{" }
           .All(subString => apiContent.Contains(subString))?
           JsonConvert.DeserializeObject<ResponseViewModel>(apiContent) :
           new (){ IsSuccess = true, Message = "Ok", Result = apiContent };
        }

        private static ResponseViewModel? ResponseFail(string apiContent)
        {
            return new(){ IsSuccess = false, Message =$"{apiContent.Substring(apiContent.IndexOf("detail\":\"") + "detail\":\"".Length).Split('\"')[0]}" };
        }
        #endregion
    }
}
