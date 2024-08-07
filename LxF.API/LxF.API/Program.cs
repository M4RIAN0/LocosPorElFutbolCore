using AutoMapper;
using Dominio.Repositorio.PersonaCliente;
using Infraestructura;
using Infraestructura.Repositorio.PersonaCliente;
using IServicio.PersonaCliente;
using LxF.API;
using Microsoft.EntityFrameworkCore;
using Servicio.PersonaCliente;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region DbContext
builder.Services.AddDbContext<LxfContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region Automapping
IMapper mapper = MappingConfig.RegisterMps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Servicios

builder.Services.AddScoped<IPersonaClienteServicio, PersonaClienteServicio>();
builder.Services.AddScoped<IPersonaClienteRepositorio, PersonaClienteRepositorio>();

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

app.Run();
