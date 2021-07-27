using MoviesApi.Domain.Entities;
using MoviesApi.Domain.Interfaces.Repository;
using MoviesApi.Domain.Interfaces.Services.MovieService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _repository;

        public MovieService(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Movie> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Movie> PostAsync(Movie movie)
        {
            return await _repository.AddAsync(movie);
        }

        public async Task<Movie> PutAsync(Movie movie)
        {
            return await _repository.UpdateAsync(movie);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
