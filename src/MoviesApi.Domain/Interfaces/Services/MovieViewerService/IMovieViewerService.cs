using MoviesApi.Domain.DTOs.Movies;
using MoviesApi.Domain.DTOs.MovieViewer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Domain.Interfaces.Services.MovieViewerService
{
    public interface IMovieViewerService
    {
        Task<IEnumerable<MovieViewerDTO>> GetAllAsync();
        Task<MovieViewerDTO> GetAsync(int id);
        Task<MovieViewerDTO> PostAsync(MovieViewerDTO viewer);
        Task<MovieViewerDTO> PutAsync(MovieViewerDTO viewer);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<MovieDTO>> GetMoviesOfViewer(int viewerId);
    }
}
