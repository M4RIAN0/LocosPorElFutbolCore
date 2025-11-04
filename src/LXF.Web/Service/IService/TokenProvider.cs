using LXF.Web.Utility;

namespace LXF.Web.Service.IService
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void ClearToken() // limpira el token 
        {
            //setea las cookies expiradas, es decir elemina limpia el token 
            _contextAccessor.HttpContext?.Response.Cookies.Delete(SD.TokenCookie);
        }

        public string? GetToken() // retrorna el token
        {
            string? token = null;

            // se hace un request para retorna el token, se usa 'TryGetValue' para retorna en un string el token si exisitiera
            bool? hastoken = _contextAccessor.HttpContext?.Request.Cookies.TryGetValue(SD.TokenCookie, out token);

            return hastoken is true ? token : null;
        }

        public void SetToken(string token) // Crea el Token
        {
            // se adjunta el Token por medio del 'Append' a las cookies en la respuesta Http
            _contextAccessor.HttpContext?.Response.Cookies.Append(SD.TokenCookie, token);
        }
    }
}
