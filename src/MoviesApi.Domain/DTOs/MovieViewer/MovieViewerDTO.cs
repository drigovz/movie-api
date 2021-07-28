using MoviesApi.Domain.DTOs.Movies;
using MoviesApi.Domain.DTOs.Viewers;

namespace MoviesApi.Domain.DTOs.MovieViewer
{
    public class MovieViewerDTO
    {
        public int MovieId { get; set; }
        public MovieDTO Movies { get; set; }
        public int ViewerId { get; set; }
        public ViewerDTO Viewers { get; set; }
    }
}
