using MoviesApi.Domain.DTOs.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Domain.Interfaces.Services.MovieService
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetAllAsync();
        Task<MovieDTO> GetAsync(int id);
        Task<MovieDTO> PostAsync(MovieDTO movie);
        Task<MovieDTO> PutAsync(MovieDTO movie);
        Task<bool> DeleteAsync(int id);
    }
}
