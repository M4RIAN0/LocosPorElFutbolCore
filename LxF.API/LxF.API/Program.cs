using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio.PersonaCliente;
using Infraestructura;
using Infraestructura.Repositorio.PersonaCliente;
using IServicio.Email;
using IServicio.Identity;
using IServicio.Mail;
using IServicio.PersonaCliente;
using LxF.API;
using LxF.Support;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Servicio.Email;
using Servicio.Identity;
using Servicio.PersonaCliente;

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
builder.Services.AddScoped<IPersonaClienteServicio, PersonaClienteServicio>();
builder.Services.AddScoped<IPersonaClienteRepositorio, PersonaClienteRepositorio>();
builder.Services.AddTransient<IEmailSender, EmailSender>(); 
builder.Services.AddSingleton(emailConfig);


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
