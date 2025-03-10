using AutoMapper;
using Dominio;
using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura;
using Infraestructura.Repositorio;
using IServicio;
using IServicio.Email;
using IServicio.Identity;
using IServicio.Mail;
using LxF.API;
using LxF.Support;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddControllers();
builder.Services.AddRazorPages();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servicios
builder.Services.AddScoped<IIdentityServicio, IndentityServicio>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IPersonaClienteServicio, PersonaClienteServicio>();
builder.Services.AddScoped<IPersonaClienteRepository, PersonaClienteRepository>();
builder.Services.AddScoped<ITalleServicio, TalleServicio>();
builder.Services.AddScoped<ITalleRepository, TalleRepository>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IMarcaServicio, MarcaServicio>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IFacturaServicio, FacturaServicio>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IComprobanteServicio, ComprobanteServicio>();
builder.Services.AddScoped<IComprobanteRepository, ComprobanteRepository>();
builder.Services.AddScoped<IDetalleComprobanteServicio, DetalleComprobanteServicio>();
builder.Services.AddScoped<IDetalleComprobanteRepository, DetalleComprobanteRepository>();
builder.Services.AddScoped<IMovimientoServicio, MovimientoServicio>();
builder.Services.AddScoped<IMovimientoRepository, MovimientoRepository>();
builder.Services.AddScoped<ITarjetaServicio, TarjetaServicio>();
builder.Services.AddScoped<ITarjetaRepository, TarjetaRepository>();


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

app.UseAuthorization();

app.MapControllers();

app.UseGlobalExceptionHandler();

app.Run();
