using MoviesApi.Domain.DTOs.Viewers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Domain.Interfaces.Services.ViewerService
{
    public interface IViewerService
    {
        Task<IEnumerable<ViewerDTO>> GetAllAsync();
        Task<ViewerDetailsDTO> GetAsync(int id);
        Task<ViewerDTO> PostAsync(ViewerDTO viewer);
        Task<ViewerDTO> PutAsync(ViewerDTO viewer);
        Task<bool> DeleteAsync(int id);
    }
}
