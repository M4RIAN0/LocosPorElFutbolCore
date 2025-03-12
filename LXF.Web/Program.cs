using LXF.Web.Service;
using LXF.Web.Service.IService;
using LXF.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region HttpClient
// Configuration HttpClient for Dependence Injection
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICategoriaService, CategoriaService>();
builder.Services.AddHttpClient<IComprobanteService, ComprobanteService>();
builder.Services.AddHttpClient<IDetalleComprobanteService, DetalleComprobanteService>();
builder.Services.AddHttpClient<IEnvioService, EnvioService>();
builder.Services.AddHttpClient<IFacturaService, FacturaService>();
builder.Services.AddHttpClient<IMarcaService, MarcaService>();
builder.Services.AddHttpClient<IMovimientoService, MovimientoService>();
builder.Services.AddHttpClient<IPersonaClienteService, PersonaClienteService>();
builder.Services.AddHttpClient<IProductoService, ProductoService>();
builder.Services.AddHttpClient<ITalleService, TalleService>();
builder.Services.AddHttpClient<ITarjetaService, TarjetaService>();

// populated value of endpoint url to LXFApiBase
SD.LXFApiBase = builder.Configuration["ServicesUrl:LXFApi"];
#endregion

#region #Dependence Injection
//Dependece Injection configuracion
builder.Services.AddScoped<IServiceBase, ServiceBase>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IComprobanteService, ComprobanteService>();
builder.Services.AddScoped<IDetalleComprobanteService, DetalleComprobanteService>();
builder.Services.AddScoped<IEnvioService, EnvioService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IMovimientoService, MovimientoService>();
builder.Services.AddScoped<IPersonaClienteService, PersonaClienteService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<ITalleService, TalleService>();
builder.Services.AddScoped<ITarjetaService, TarjetaService>();
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
