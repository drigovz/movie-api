using AutoMapper;
using MoviesApi.Domain.DTOs.Viewers;
using MoviesApi.Domain.Entities;
using MoviesApi.Domain.Interfaces.Repository;
using MoviesApi.Domain.Interfaces.Services.ViewerService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Service.Services
{
    public class ViewerService : IViewerService
    {
        private readonly IRepository<Viewer> _repository;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IMapper _mapper;

        public ViewerService(IRepository<Viewer> repository, IRepository<Movie> movieRepository, IMapper mapper)
        {
            _repository = repository;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ViewerDTO>> GetAllAsync()
        {
            var viewer = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<ViewerDTO>>(viewer);
        }

        public async Task<ViewerDetailsDTO> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ViewerDetailsDTO>(entity);
        }

        public async Task<ViewerDTO> PostAsync(ViewerDTO viewer)
        {
            var entity = _mapper.Map<Viewer>(viewer);
            var result = await _repository.AddAsync(entity);
            return _mapper.Map<ViewerDTO>(result);
        }

        public async Task<ViewerDTO> PutAsync(ViewerDTO viewer)
        {
            var entity = _mapper.Map<Viewer>(viewer);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<ViewerDTO>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
