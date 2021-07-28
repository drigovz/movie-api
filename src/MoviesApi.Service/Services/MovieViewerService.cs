using AutoMapper;
using MoviesApi.Domain.DTOs.Movies;
using MoviesApi.Domain.DTOs.MovieViewer;
using MoviesApi.Domain.Entities;
using MoviesApi.Domain.Interfaces.Repository;
using MoviesApi.Domain.Interfaces.Repository.MovieViewers;
using MoviesApi.Domain.Interfaces.Services.MovieViewerService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Service.Services
{
    public class MovieViewerService : IMovieViewerService
    {
        private readonly IMovieViewerRepository _repository;
        private readonly IRepository<Movie> _repositoryMovie;
        private readonly IRepository<Viewer> _repositoryViewer;
        private readonly IMapper _mapper;

        public MovieViewerService(IMovieViewerRepository repository,
                                  IRepository<Movie> repositoryMovie,
                                  IRepository<Viewer> repositoryViewer,
                                  IMapper mapper)
        {
            _repository = repository;
            _repositoryMovie = repositoryMovie;
            _repositoryViewer = repositoryViewer;
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

            var movieEntity = await _repositoryMovie.GetByIdAsync(movieViewer.MovieId);
            var viewerEntity = await _repositoryViewer.GetByIdAsync(movieViewer.ViewerId);

            entity.Movies = movieEntity;
            entity.Viewers = viewerEntity;

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

        public async Task<IEnumerable<MovieDTO>> GetMoviesOfViewer(int viewerId)
        {
            var result = await _repository.MoviesOfViewer(viewerId);
            return _mapper.Map<IEnumerable<MovieDTO>>(result);
        }
    }
}
