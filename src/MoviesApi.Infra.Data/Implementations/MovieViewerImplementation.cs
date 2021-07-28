using Microsoft.EntityFrameworkCore;
using MoviesApi.Domain.Entities;
using MoviesApi.Domain.Interfaces.Repository.MovieViewers;
using MoviesApi.Infra.Data.Context;
using MoviesApi.Infra.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Infra.Data.Implementations
{
    public class MovieViewerImplementation : BaseRepository<MovieViewer>, IMovieViewerRepository
    {
        private readonly DbSet<MovieViewer> _dataset;
        private readonly DbSet<Movie> _movieDataset;

        public MovieViewerImplementation(AppDbContext context)
            : base(context)
        {
            _dataset = context.Set<MovieViewer>();
            _movieDataset = context.Set<Movie>();
        }

        public async Task<List<Movie>> MoviesOfViewer(int viewerId)
        {
            var movies = new List<Movie>();
            var movieViewers = await _dataset.Where(x => x.ViewerId == viewerId).ToListAsync();

            foreach (var itemMovie in movieViewers)
            {
                var movie = await _movieDataset.FirstOrDefaultAsync(m => m.Id == itemMovie.MovieId);
                movies.Add(movie);
            }

            return movies;
        }

        public async Task<int> ViewersOfMovie(int movieId)
        {
            var viewersMovie = await _dataset.Where(x => x.MovieId == movieId).ToListAsync();
            var result = viewersMovie.Count() > 0 ? viewersMovie.Count() : 0;
            return result;
        }
    }
}
