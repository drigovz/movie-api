using MoviesApi.Domain.DTOs.Movies;
using System.Collections.Generic;

namespace MoviesApi.Domain.DTOs.Viewers
{
    public class ViewerDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalMovies { get; set; } = 0;
        public IEnumerable<MovieDTO> Movies { get; set; } = new List<MovieDTO>();
    }
}
