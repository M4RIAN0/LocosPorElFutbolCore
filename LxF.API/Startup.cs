using Dominio.Repositorio.PersonaCliente;
using Infraestructura;
using Infraestructura.Repositorio.PersonaCliente;
using IServicio.PersonaCliente;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Servicio.PersonaCliente;

namespace LxF.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LxfContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();

            // Swagger

            services.AddSwaggerGen(config => config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
            {
                Title = "Locos x el Futbol Swagger"
            }));

            // Servicios

            services.AddScoped<IPersonaClienteServicio, PersonaClienteServicio>();
            services.AddScoped<IPersonaClienteRepositorio, PersonaClienteRepositorio>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(Config => Config.SwaggerEndpoint("/swagger/v1/swagger.json", "Locos x el Futbol"));
        }
    }
}
