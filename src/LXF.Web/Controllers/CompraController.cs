using AutoMapper;
using Azure;
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

        private readonly IWebHostEnvironment _webHostEnvironment;

        public CompraController(IVentaService ventaService, IPersonaClienteService personaClienteService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _ventaService = ventaService;
            _personaClienteService = personaClienteService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
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

        public async Task<IActionResult> Detalles(int id)
        {
            var response = await _ventaService.GetComprobantebyId(id);

            if (!response.IsSuccess)
                TempData["error"] = response?.Message;

            return View(response.Result);
        }

        public async Task<IActionResult> Seguimiento(int id)
        {
            var response = await _ventaService.GetComprobantebyId(id);
            if (response == null) return NotFound();

            if (!response.IsSuccess)
                TempData["error"] = response?.Message;

            return View(response.Result);
        }

        public async Task<IActionResult> GenerarFacturaPDF(int id)
        {
            var response = await _ventaService.GetComprobantebyId(id);

            if (!response.IsSuccess)
                TempData["error"] = response?.Message;

            var comprobanteGetVM = ComprobanteToGetViewModel(response.Result);

            string logoPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "LXF_Logo_Factura.png");

            byte[] pdfBytes = await _ventaService.GeneratePDF(comprobanteGetVM, logoPath);

            if (pdfBytes == null || pdfBytes.Length == 0)
            {
                return NotFound("No se encontró el comprobante o no se pudo generar la factura.");
            }

            // 1. Armas el nombre personalizable para el archivo usando los datos de tu comprobante
            string nombreArchivo = $"Factura_B_{comprobanteGetVM.Id}.pdf";

            // 2. Le indicas al navegador que lo abra en la pestaña (inline) pero con este nombre específico
            Response.Headers.Append("Content-Disposition", $"inline; filename={nombreArchivo}");

            return File(pdfBytes, "application/pdf");
        }

        #region private mhetods
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

        private ComprobanteGetViewModel ComprobanteToGetViewModel(object? vm)
        {
            return _mapper.Map<ComprobanteGetViewModel>(vm);
        }
        #endregion
    }
}
