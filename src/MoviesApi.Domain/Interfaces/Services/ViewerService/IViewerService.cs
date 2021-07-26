using MoviesApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Domain.Interfaces.Services.ViewerService
{
    public interface IViewerService
    {
        Task<IEnumerable<Viewer>> GetAllAsync();
        Task<Movie> GetAsync(int id);
        Task<Movie> PostAsync(Viewer viewer);
        Task<Movie> PutAsync(Viewer viewer);
        Task<bool> DeleteAsync(int id);
    }
}
