using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LXF.Web.Models;
using AutoMapper;
using LXF.Web.Service.IService;
using LXF.Web.Models.ViewModels;

namespace LXF.Web.Controllers;

public class HomeController : Controller
{
    private readonly IProductoService _service;
    private readonly IMapper _mapper;

    public HomeController(IProductoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        ResponseViewModel? response = await _service.GetAll();

        if (!response.IsSuccess)
            TempData["error"] = response?.Message;

        var list = response.IsSuccess ? response.Result : new List<ProductoGetViewModel>();

        return View(list);
    }

    public async Task<IActionResult> ProductoDetails(int id)
    {
        ResponseViewModel? response = await _service.GetById(id);

        if (!response.IsSuccess)
            TempData["error"] = response?.Message;

            return View(response.Result);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
