using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Domain.DTOs.Viewers
{
    public class ViewerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [MinLength(2, ErrorMessage = "Name not valid!")]
        public string Name { get; set; }

        [Range(1, 140, ErrorMessage = "Age not valid!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone number.")]
        public string PhoneNumber { get; set; }
    }
}
