using MoviesApi.Domain.DTOs.Movies;
using System.Collections.Generic;

namespace MoviesApi.Service.Test.Fakes
{
    public class MovieFake
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public int ReleaseYear { get; set; }
        public string DirectedBy { get; set; }
        public List<MovieDTO> MoviesDto { get; set; } = new List<MovieDTO>();
        public MovieDTO MovieDto { get; set; }

        public MovieFake()
        {
            Id = Faker.RandomNumber.Next(100);
            Title = Faker.Lorem.Words(30).ToString();
            Synopsis = Faker.Lorem.Words(200).ToString();
            ReleaseYear = Faker.Identification.DateOfBirth().Year;
            DirectedBy = Faker.Name.FullName();

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

            MovieDto = new MovieDTO
            {
                Id = Id,
                Title = Title,
                Synopsis = Synopsis,
                ReleaseYear = ReleaseYear,
                DirectedBy = DirectedBy,
                TotalViewers = Faker.RandomNumber.Next(35, 300)
            };
        }
    }
}
