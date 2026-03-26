using AutoMapper;
using Dominio;
using Dominio.Entidades;
using Dominio.Repositorio;
using Dominio.Repositorio.Gateways;
using Infraestructura;
using Infraestructura.Configurations;
using Infraestructura.Gateways;
using Infraestructura.Repositorio;
using IServicio;
using IServicio.Email;
using IServicio.Identity;
using IServicio.JwToken;
using IServicio.Mail;
using IServicio.MercadoPago;
using LxF.API;
using LxF.API.Extensions;
using LxF.Support;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Servicio;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

#region DbContext
builder.Services.AddDbContext<LxfContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region JWT
//configuracion para popular JwtOptions con los valores del appsettings
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
#endregion

#region Identity
builder.Services.AddIdentity<Usuario, Role>().AddEntityFrameworkStores<LxfContext>().AddDefaultTokenProviders();
#endregion

#region Culture
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "es-ES", "en-US" };
    options.DefaultRequestCulture = new RequestCulture("es-ES");
    options.SupportedCultures = supportedCultures.Select(x => new CultureInfo(x)).ToList();
    options.SupportedUICultures = supportedCultures.Select(x => new CultureInfo(x)).ToList();
});
#endregion

#region Automapping
IMapper mapper = MappingConfig.RegisterMps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region Email
var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));
#endregion

#region Swagger
// configuracion para anadir autenticacion y autorizacion a Swagger 
builder.Services.AddSwaggerGen(option =>
{   // anadimos AddSecurityDefinition donde el name es 'Bearer' y 'securityScheme' tiene varios valores
    option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization", // nombre que le damos a 'OpenApiSecurityScheme'
        // ponemos la descripcion que quieramos
        Description = "Enter the Bearer Authorization string as following: 'Bearer Generated-JWT-Token'",
        // 'In' representa la localizacion del token bearer
        In = ParameterLocation.Header,
        // el tipo es 'ApiKey'
        Type = SecuritySchemeType.ApiKey,
        // Scheme es bearer
        Scheme = "Bearer"
    });

    // anadimos secuiriryRequirement
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            }, new string[]{} // lista de valores
        }
    });
});
#endregion

#region MercadoPago
builder.Services.Configure<MercadoPagoConfiguration>(builder.Configuration.GetSection("MercadoPagoConfiguration"));
#endregion

#region Dependency Injection
// Services
builder.Services.AddScoped<IIdentityService, IndentityService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEnvioService, EnvioService>();
builder.Services.AddScoped<IEnvioRepository, EnvioRepository>();
builder.Services.AddScoped<IPersonaClienteService, PersonaClienteService>();
builder.Services.AddScoped<IPersonaClienteRepository, PersonaClienteRepository>();
builder.Services.AddScoped<ITalleService, TalleService>();
builder.Services.AddScoped<ITalleRepository, TalleRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<IPersonaClienteService, PersonaClienteService>();
builder.Services.AddScoped<IPersonaClienteRepository, PersonaClienteRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IComprobanteRepository, ComprobanteRepository>();
builder.Services.AddScoped<IDetalleComprobanteService, DetalleComprobanteService>();
builder.Services.AddScoped<IDetalleComprobanteRepository, DetalleComprobanteRepository>();
builder.Services.AddScoped<IMovimientoService, MovimientoService>();
builder.Services.AddScoped<IMovimientoRepository, MovimientoRepository>();
builder.Services.AddScoped<IOrdenCompraService, OrdenCompraService>();
builder.Services.AddScoped<IOrdenCompraRepository, OrdenCompraRepository>();
builder.Services.AddScoped<ICarroComprasService, CarroCompraService>();
builder.Services.AddScoped<ICarroCompraRepository, CarroCompraRepository>();
builder.Services.AddScoped<IDetalleCarroCompraService, DetalleCarroCompraService>();
builder.Services.AddScoped<IDetalleCarroCompraRepository, DetalleCarroCompraRepository>();
builder.Services.AddScoped<IDetalleOrdenCompraService, DetallOrdenCompraService>();
builder.Services.AddScoped<IDetalleOrdenCompraRepository, DetalleOrdenCompraRepository>();
builder.Services.AddScoped<IProvinciaService, ProvinciaService>();
builder.Services.AddScoped<IProvinciaRepository, ProvinciaRepository>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IJwTokenGenerator, JwTokenGenerator>(); // inyeccion service IJwTokenGenerator
builder.Services.AddSingleton<IMercadoPagoGateway, MercadoPagoGateway>(); // Gateay MercadoPago
builder.Services.AddSingleton<IMercadoPagoService, MercadoPagoService>();
#endregion

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();

builder.AddAppAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestLocalization();

app.MapRazorPages();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseGlobalExceptionHandler();

app.Run();
