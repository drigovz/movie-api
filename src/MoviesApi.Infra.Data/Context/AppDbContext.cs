using Microsoft.EntityFrameworkCore;
using MoviesApi.Domain.Entities;
using MoviesApi.Infra.Data.Mappings;
using System.IO;

namespace MoviesApi.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var pathEnvFile = Path.GetFullPath("../../.env");

            DotNetEnv.Env.Load(pathEnvFile);
            var server = DotNetEnv.Env.GetString("SQL_SERVER_ADDRESS");
            var catalog = DotNetEnv.Env.GetString("SQL_CATALOG");
            var userId = DotNetEnv.Env.GetString("SQL_USER_ID");
            var password = DotNetEnv.Env.GetString("SQL_PASSWORD");

            optionsBuilder.UseSqlServer($"Data Source={server}; initial catalog={catalog}; user id={userId}; password={password}; Integrated Security=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>(new MovieMap().Configure);
            modelBuilder.Entity<Viewer>(new ViewerMap().Configure);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Viewer> Viewers { get; set; }
    }
}
