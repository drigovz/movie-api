using AutoMapper;
using MoviesApi.Domain.DTOs.Movies;
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
        private readonly IMapper _mapper;

        public MovieService(IRepository<Movie> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDTO>> GetAllAsync()
        {
            var movies = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public async Task<MovieDTO> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<MovieDTO>(entity);
        }

        public async Task<MovieDTO> PostAsync(MovieDTO movie)
        {
            var entity = _mapper.Map<Movie>(movie);
            var result = await _repository.AddAsync(entity);
            return _mapper.Map<MovieDTO>(result);
        }

        public async Task<MovieDTO> PutAsync(MovieDTO movie)
        {
            var entity = _mapper.Map<Movie>(movie);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<MovieDTO>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
