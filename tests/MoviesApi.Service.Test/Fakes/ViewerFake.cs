using MoviesApi.Domain.DTOs.Movies;
using MoviesApi.Domain.DTOs.Viewers;
using System;
using System.Collections.Generic;

namespace MoviesApi.Service.Test.Fakes
{
    public class ViewerFake
    {
        private Random random = new Random();
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ViewerDTO ViewerDto { get; set; }
        public ViewerDetailsDTO ViewerDetailsDto { get; set; }
        public List<ViewerDTO> ViewersDto { get; set; } = new List<ViewerDTO>();
        public List<MovieDTO> MoviesDto { get; set; } = new List<MovieDTO>();

        public ViewerFake()
        {
            Id = Faker.RandomNumber.Next(100);
            Name = Faker.Name.FullName();
            Age = random.Next(5, 40);
            Email = Faker.Internet.Email();
            PhoneNumber = Faker.Phone.Number();

            ViewerDto = new ViewerDTO
            {
                Id = Id,
                Name = Name,
                Age = Age,
                Email = Email,
                PhoneNumber = PhoneNumber
            };

            int randomValue = Faker.RandomNumber.Next(10, 30);
            for (int i = 0; i < randomValue; i++)
            {
                var dto = new MovieDTO
                {
                    Id = Faker.RandomNumber.Next(100),
                    Title = Faker.Lorem.Words(30).ToString(),
                    Synopsis = Faker.Lorem.Words(200).ToString(),
                    ReleaseYear = Faker.Identification.DateOfBirth().Year,
                    DirectedBy = Faker.Name.FullName(),
                    TotalViewers = Faker.RandomNumber.Next(35, 300)
                };

                MoviesDto.Add(dto);
            }

            for (int i = 0; i < randomValue; i++)
            {
                var viewerDto = new ViewerDTO
                {
                    Id = Faker.RandomNumber.Next(100),
                    Name = Faker.Name.FullName(),
                    Age = Faker.RandomNumber.Next(5, 40),
                    Email = Faker.Internet.Email(),
                    PhoneNumber = Faker.Phone.Number()
                };

                ViewersDto.Add(viewerDto);
            }

            ViewerDetailsDto = new ViewerDetailsDTO
            {
                Id = Id,
                Name = Name,
                Age = Age,
                Email = Email,
                PhoneNumber = PhoneNumber,
                TotalMovies = MoviesDto.Count,
                Movies = MoviesDto
            };
        }
    }
}
