using MoviesApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Domain.Interfaces.Services.MovieService
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetAsync(int id);
        Task<Movie> PostAsync(Movie movie);
        Task<Movie> PutAsync(Movie movie);
        Task<bool> DeleteAsync(int id);
    }
}
