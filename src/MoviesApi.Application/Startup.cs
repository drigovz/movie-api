using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MoviesApi.Infra.CrossCutting.DependencyInjection;
using MoviesApi.Infra.CrossCutting.Mappings;
using System;
using System.IO;
using System.Reflection;

namespace MoviesApi.Application
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
            ConfigureRepository.ConfigureDependenciesRepository(services);
            ConfigureService.ConfigureDependenciesServices(services);

            var config = new MapperConfiguration(x =>
            {
                x.AddProfile(new DtoToModelProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Movies Api Doc",
                    Description = "API para gerenciamento de filmes e espectadores \n" +
                                  "Para o correto funcionamento e teste desta API. \n" +
                                  " * Primeiro cadastre filmes (Movies). Informe os campos: Title, Synopsis e ReleaseYear; \n" +
                                  " * Depois, cadastre os espectadores (Viewers) dos filmes. Informe os campos: Name, Age, Email e PhoneNumber; \n" +
                                  " * Por fim, você pode indicar que um espectador assistiu a um filme. Informe o ID do espectador e o ID do filme. \n" +
                                  "\n",
                    TermsOfService = new Uri("https://cla.opensource.microsoft.com/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Rodrigo Vaz",
                        Email = "rodrigodp2014@gmail.com",
                        Url = new Uri("https://github.com/drigovz/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Usar sobre CLA Open Source",
                        Url = new Uri("https://cla.opensource.microsoft.com/")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies Api Doc");
                c.RoutePrefix = "swagger/ui";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
