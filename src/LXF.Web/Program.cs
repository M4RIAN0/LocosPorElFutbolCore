using AutoMapper;
using LXF.Web;
using LXF.Web.Service;
using LXF.Web.Service.IService;
using LXF.Web.ServiceApiClient;
using LXF.Web.ServiceApiClient.IServiceApiClient;
using LXF.Web.Utility;

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
builder.Services.AddHttpClient<ICategoriaServiceApiClient, CategoriaServiceApiClient>();
builder.Services.AddHttpClient<IComprobanteServiceApiClient, ComprobanteServiceApiClient>();
builder.Services.AddHttpClient<IDetalleComprobanteServiceApiClient, DetalleComprobanteServiceApiClient>();
builder.Services.AddHttpClient<IEnvioServiceApiClient, EnvioServiceApiClient>();
builder.Services.AddHttpClient<IFacturaServiceApiClient, FacturaServiceApiClient>();
builder.Services.AddHttpClient<IIdentityServiceApiClient, IdentityServiceApiClient>();
builder.Services.AddHttpClient<IMarcaServiceApiClient, MarcaServiceApiClient>();
builder.Services.AddHttpClient<IMovimientoServiceApiClient, MovimientoServiceApiClient>();
builder.Services.AddHttpClient<IPersonaClienteServiceApiClient, PersonaClienteServiceApiClient>();
builder.Services.AddHttpClient<IProductoServiceApiClient, ProductoServiceApiClient>();
builder.Services.AddHttpClient<ITalleServiceApiClient, TalleServiceApiClient>();
builder.Services.AddHttpClient<ITarjetaServiceApiClient, TarjetaServiceApiClient>();

// populated value of endpoint url to LXFApiBase
SD.LXFApiBase = builder.Configuration["ServicesUrl:LXFApi"];
#endregion

#region Dependence Injection
//Dependece Injection configuracion
builder.Services.AddScoped<IServiceBaseApiClient, ServiceBaseApiClient>();
builder.Services.AddScoped<ICategoriaServiceApiClient, CategoriaServiceApiClient>();
builder.Services.AddScoped<ICarroComprasServiceApiClient, CarroComprasServiceApiClient>();
builder.Services.AddScoped<IComprobanteServiceApiClient, ComprobanteServiceApiClient>();
builder.Services.AddScoped<IDetalleComprobanteServiceApiClient, DetalleComprobanteServiceApiClient>();
builder.Services.AddScoped<IEnvioServiceApiClient, EnvioServiceApiClient>();
builder.Services.AddScoped<IFacturaServiceApiClient, FacturaServiceApiClient>();
builder.Services.AddScoped<IIdentityServiceApiClient, IdentityServiceApiClient>();
builder.Services.AddScoped<IMarcaServiceApiClient, MarcaServiceApiClient>();
builder.Services.AddScoped<IMovimientoServiceApiClient, MovimientoServiceApiClient>();
builder.Services.AddScoped<IPersonaClienteServiceApiClient, PersonaClienteServiceApiClient>();
builder.Services.AddScoped<IProductoServiceApiClient, ProductoServiceApiClient>();
builder.Services.AddScoped<ITalleServiceApiClient, TalleServiceApiClient>();
builder.Services.AddScoped<ITarjetaServiceApiClient, TarjetaServiceApiClient>();

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICarroComprasService, CarroComprasService>();
builder.Services.AddScoped<ITalleService, TalleService>();
builder.Services.AddScoped<IMarcaService, MarcaService>();
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
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
