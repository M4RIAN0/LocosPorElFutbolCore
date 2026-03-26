using AutoMapper;
using LXF.Web.Models.ViewModels;
using LXF.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LXF.Web.Controllers
{
    public class CompraController : Controller
    {
        private readonly IVentaService _ventaService;
        private readonly IPersonaClienteService _personaClienteService;
        private readonly IMapper _mapper;

        public CompraController(IVentaService ventaService, IPersonaClienteService personaClienteService, IMapper mapper)
        {
            _ventaService = ventaService;
            _personaClienteService = personaClienteService;
            _mapper = mapper;
        }
        public async Task<IActionResult> MisCompras()
        {
            var persona = await GetPersona();
            var personaId = persona.Id;

            var response = await _ventaService.GetComprobantesByClienteId(personaId);

            if (!response.IsSuccess)
                TempData["error"] = response?.Message;

            return View(response.Result);
        }
        //public async Task<IActionResult> 

        #region pricate mhetods
        private async Task<PersonaClienteGetViewModel> GetPersona()
        {
            var email = User.FindFirstValue("Email");
            var response = await _personaClienteService.GetByFilter(email);

            if (response.IsSuccess)
                return ((IEnumerable<object>)response.Result).Select(PersonaToGetViewMdel).FirstOrDefault();
            
            return new PersonaClienteGetViewModel();
        }

        private PersonaClienteGetViewModel PersonaToGetViewMdel(object? vm)
        {
            return _mapper.Map<PersonaClienteGetViewModel>(vm);
        }
        #endregion
    }
}
