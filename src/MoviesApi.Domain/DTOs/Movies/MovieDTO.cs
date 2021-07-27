using MoviesApi.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Domain.DTOs.Movies
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Synopsis is required")]
        public string Synopsis { get; set; }

        [ValidateDtos]
        public int ReleaseYear { get; set; }

        public string DirectedBy { get; set; }
    }
}
