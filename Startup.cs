using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using models;
using straviaBackend.models;
using straviaBackend.interfaces;
using straviaBackend.AccessImpl;

namespace Strava2._0Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       
        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var sqlConnectionString = Configuration["PostgreSqlConnectionString"];

            services.AddDbContext<StravaContext>(options => options.UseNpgsql("Server=localhost;Port=5432;Database=stravia2.0;User Id=postgres;Password=clave;"));
            services.AddScoped<ITipoActAccessInterface, TipoActAccess>();
            services.AddScoped<ICategoriasporCarreraAccessInterface, CategoriasporCarreraAccess>();
            services.AddScoped<IPatrociandorporCarreraAccessInterface, PatrocinadoresporCarreraAccess>();
            services.AddScoped<ICarreraAccessInterface, CarreraAccess>();
            services.AddScoped<IUsuarioAccessInterface, UsuarioAccess>();
            services.AddScoped<ICatAccessInterface, CatAccess>();
            services.AddScoped<IPatAccessInterface, PatAccess>();
            services.AddScoped<IRetoAccessInterface, RetoAccess>();
            services.AddScoped<IGrupoAccessInterface, GrupoAccess>();
            services.AddScoped<IInscripcionCarreraAccessInterface, InscripcionCarreraAccess>();
            services.AddScoped<IInscripcionRetoAccessInterface, InscripcionRetoAccess>();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("https://localhost:5001")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
