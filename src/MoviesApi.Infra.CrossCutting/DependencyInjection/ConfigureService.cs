using Microsoft.Extensions.DependencyInjection;
using MoviesApi.Domain.Interfaces.Services.MovieService;
using MoviesApi.Service.Services;

namespace MoviesApi.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesServices(IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
        }
    }
}
