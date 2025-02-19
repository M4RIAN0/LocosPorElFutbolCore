using AutoMapper;
using Dominio;
using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura;
using Infraestructura.Repositorio;
using IServicio.Categoria;
using IServicio.Email;
using IServicio.Identity;
using IServicio.Mail;
using IServicio.Marca;
using IServicio.PersonaCliente;
using IServicio.Producto;
using IServicio.Talle;
using LxF.API;
using LxF.Support;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Servicio;
using Servicio.Email;
using Servicio.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region DbContext
builder.Services.AddDbContext<LxfContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region Identity
builder.Services.AddIdentity<Usuario, Role>().AddEntityFrameworkStores<LxfContext>().AddDefaultTokenProviders();
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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servicios
builder.Services.AddScoped<IIdentityServicio, IndentityServicio>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IPersonaClienteServicio, PersonaClienteServicio>();
builder.Services.AddScoped<IPersonaClienteRepository, PersonaClienteRepository>();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseGlobalExceptionHandler();

app.Run();
