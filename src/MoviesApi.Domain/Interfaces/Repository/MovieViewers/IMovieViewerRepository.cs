using MoviesApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Domain.Interfaces.Repository.MovieViewers
{
    public interface IMovieViewerRepository : IRepository<MovieViewer>
    {
        Task<List<Movie>> MoviesOfViewer(int viewerId);
        Task<int> ViewersOfMovie(int movieId);
    }
}
