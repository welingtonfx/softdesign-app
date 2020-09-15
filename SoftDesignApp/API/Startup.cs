using Aplicacao;
using Dominio.Interface;
using Dominio.Interface.Aplicacao;
using Dominio.Interface.Infra;
using Dominio.Interface.Infra.Repositorio;
using Dominio.Validation.ApplicationModel;
using Infra.Comum;
using Infra.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;

namespace API
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
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddMvc().AddNewtonsoftJson();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "SoftDesign",
                        Version = "v1",
                        Description = "API - SoftDesign",
                        Contact = new OpenApiContact
                        {
                            Name = "Welington",
                            Url = new Uri("https://github.com/welingtonfx")
                        }
                    });
            });

            services.AddSwaggerGenNewtonsoftSupport();

            services.AddSingleton<IConfiguration>(Configuration);

            services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));
            services.AddSingleton<IDatabaseSettings>(f => f.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            services.AddScoped<IServicoAplicacaoApplication, ServicoAplicacaoApplication>();
            services.AddScoped<IRepositorioApplication, RepositorioApplication>();
            services.AddScoped<IApplicationValidator, ApplicationValidator>();
            services.AddScoped<IRepositorioFactory, RepositorioFactory>();
            services.AddScoped<IMongoDatabaseFactory, MongoDatabaseFactory>();
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

            app.UseCors("AllowAllOrigins");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "apis");
            });
        }
    }
}
