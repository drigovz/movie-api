using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesApi.Domain.Interfaces.Repository;
using MoviesApi.Infra.Data.Context;
using MoviesApi.Infra.Data.Repository;
using System.IO;

namespace MoviesApi.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            var pathEnvFile = Path.GetFullPath("../../.env");

            DotNetEnv.Env.Load(pathEnvFile);
            var server = DotNetEnv.Env.GetString("SQL_SERVER_ADDRESS");
            var catalog = DotNetEnv.Env.GetString("SQL_CATALOG");
            var userId = DotNetEnv.Env.GetString("SQL_USER_ID");
            var password = DotNetEnv.Env.GetString("SQL_PASSWORD");

            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer($"Data Source={server}; initial catalog={catalog}; user id={userId}; password={password}; Integrated Security=False;")
            );
        }
    }
}
