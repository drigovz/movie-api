namespace MoviesApi.Domain.Entities
{
    public class MovieViewer : BaseEntity
    {
        public int MovieId { get; set; }
        public Movie Movies { get; set; }
        public int ViewerId { get; set; }
        public Viewer Viewers { get; set; }
    }
}
