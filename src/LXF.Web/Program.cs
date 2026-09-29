using AutoMapper;
using Dominio.Repositorio.Gateways;
using Infraestructura.Configurations;
using Infraestructura.Gateways;
using IServicio.MercadoPago;
using IServicio.TemporalObject;
using LXF.Web;
using LXF.Web.Service;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Automapping
IMapper mapper = MappingConfig.RegisterMps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region HttpClient
// Configuration HttpClient for Dependence Injection
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IDetalleCarroComprasServiceApiClient, DetalleCarroComprasServiceApiClient>();
builder.Services.AddHttpClient<ICategoriaServiceApiClient, CategoriaServiceApiClient>();
builder.Services.AddHttpClient<IDetalleComprobanteServiceApiClient, DetalleComprobanteServiceApiClient>();
builder.Services.AddHttpClient<IEnvioServiceApiClient, EnvioServiceApiClient>();
builder.Services.AddHttpClient<IFacturaServiceApiClient, FacturaServiceApiClient>();
builder.Services.AddHttpClient<IIdentityServiceApiClient, IdentityServiceApiClient>();
builder.Services.AddHttpClient<IMarcaServiceApiClient, MarcaServiceApiClient>();
builder.Services.AddHttpClient<IPersonaClienteServiceApiClient, PersonaClienteServiceApiClient>();
builder.Services.AddHttpClient<IProductoServiceApiClient, ProductoServiceApiClient>();
builder.Services.AddHttpClient<IProvinciaServiceApiClient, ProvinciaServiceApiClient>();
builder.Services.AddHttpClient<IVentaServiceApiClient, VentaServiceApiClient>();
// populated value of endpoint url to LXFApiBase
SD.LXFApiBase = builder.Configuration["ServicesUrl:LXFApi"];
#endregion

#region MercadoPago
builder.Services.Configure<MercadoPagoConfiguration>(builder.Configuration.GetSection("MercadoPagoConfiguration"));
#endregion

#region MemoryCache
builder.Services.AddMemoryCache();
#endregion

#region Dependence Injection
//Dependece Injection configuration in Services Api Clients
builder.Services.AddScoped<IServiceBaseApiClient, ServiceBaseApiClient>();
builder.Services.AddScoped<ICategoriaServiceApiClient, CategoriaServiceApiClient>();
builder.Services.AddScoped<IEnvioServiceApiClient, EnvioServiceApiClient>();
builder.Services.AddScoped<ICarroComprasServiceApiClient, CarroComprasServiceApiClient>();
builder.Services.AddScoped<IDetalleCarroComprasServiceApiClient, DetalleCarroComprasServiceApiClient>();
builder.Services.AddScoped<IDetalleComprobanteServiceApiClient, DetalleComprobanteServiceApiClient>();
builder.Services.AddScoped<IEnvioServiceApiClient, EnvioServiceApiClient>();
builder.Services.AddScoped<IFacturaServiceApiClient, FacturaServiceApiClient>();
builder.Services.AddScoped<IIdentityServiceApiClient, IdentityServiceApiClient>();
builder.Services.AddScoped<IMarcaServiceApiClient, MarcaServiceApiClient>();
builder.Services.AddScoped<IPersonaClienteServiceApiClient, PersonaClienteServiceApiClient>();
builder.Services.AddScoped<IProductoServiceApiClient, ProductoServiceApiClient>();
builder.Services.AddScoped<IProvinciaServiceApiClient, ProvinciaServiceApiClient>();
builder.Services.AddScoped<IVentaServiceApiClient, VentaServiceApiClient>();

//Dependece Injection configuration in Services
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICarroComprasService, CarroComprasService>();
builder.Services.AddScoped<EnvioService, EnvioService>();
builder.Services.AddScoped<IDetalleCarroComprasService, DetalleCarroComprasService>();
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IPersonaClienteService, PersonaClienteService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProvinciaService, ProvinciaService>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IMercadoPagoService, MercadoPagoService>();
builder.Services.AddScoped<IMercadoPagoGateway, MercadoPagoGateway>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Identity/Login";
        options.AccessDeniedPath = "/Identity/AccessDenied";
    });
builder.Services.AddScoped<ITemporalObjectService, TemporalObjectService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
