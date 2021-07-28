using AutoMapper;
using MoviesApi.Domain.DTOs.MovieViewer;
using MoviesApi.Domain.Entities;
using MoviesApi.Domain.Interfaces.Repository;
using MoviesApi.Domain.Interfaces.Services.MovieViewerService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Service.Services
{
    public class MovieViewerService : IMovieViewerService
    {
        private readonly IRepository<MovieViewer> _repository;
        private readonly IMapper _mapper;

        public MovieViewerService(IRepository<MovieViewer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieViewerDTO>> GetAllAsync()
        {
            var movieViewers = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<MovieViewerDTO>>(movieViewers);
        }

        public async Task<MovieViewerDTO> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<MovieViewerDTO>(entity);
        }

        public async Task<MovieViewerDTO> PostAsync(MovieViewerDTO movieViewer)
        {
            var entity = _mapper.Map<MovieViewer>(movieViewer);
            var result = await _repository.AddAsync(entity);
            return _mapper.Map<MovieViewerDTO>(result);
        }

        public async Task<MovieViewerDTO> PutAsync(MovieViewerDTO movieViewer)
        {
            var entity = _mapper.Map<MovieViewer>(movieViewer);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<MovieViewerDTO>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
