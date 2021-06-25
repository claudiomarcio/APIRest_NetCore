using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.AspNetCore.Rewrite;
using ED.CrossCutting.Ioc;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using ED.Infra.Data.EntityConfiguration;
using ED.CrossCutting.Ioc.Resolvers;

namespace ED.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite($@"Data Source={$@"{AppDomain.CurrentDomain.BaseDirectory}\ecad.db"}"));
            services.AddScoped<ApplicationDbContext, ApplicationDbContext>();
            services.Resolvers();
            services.ConfigureAppServices();
            services.AddMvc();
            services.AddCors();
           
            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "ECAD - Gestor de Musica",
                        Version = "v1",
                        Description = "ECAD",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Claudio Marcio",
                            Url = new Uri("https://github.com/claudiomarcio/ECAD")
                        }

                    });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())

            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                            .SetIsOriginAllowed(origin => true) // allow any origin
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json",
                    "Gestor de Musica");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

        }
    }
}