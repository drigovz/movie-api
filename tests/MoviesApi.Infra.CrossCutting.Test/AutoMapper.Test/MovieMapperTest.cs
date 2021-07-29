using MoviesApi.Domain.DTOs.Movies;
using MoviesApi.Domain.Entities;
using MoviesApi.Infra.CrossCutting.Test.Config;
using System;
using Xunit;

namespace MoviesApi.Infra.CrossCutting.Test.AutoMapper.Test
{
    public class MovieMapperTest : BaseTestService
    {
        Random random = new Random();

        [Fact]
        public void Should_be_possible_to_mapper_MovieDTO_to_Movie_Entity()
        {
            var randomYears = random.Next(1980, DateTime.Now.Year);

            var movieDto = new MovieDTO
            {
                Id = Faker.RandomNumber.Next(100),
                Title = Faker.Lorem.Words(10).ToString(),
                Synopsis = Faker.Lorem.Words(100).ToString(),
                ReleaseYear = randomYears,
                DirectedBy = Faker.Name.FullName()
            };
             
            var dtoToEntity = mapper.Map<Movie>(movieDto);

            Assert.Equal(movieDto.Id, dtoToEntity.Id);
            Assert.Equal(movieDto.Title, dtoToEntity.Title);
            Assert.Equal(movieDto.Synopsis, dtoToEntity.Synopsis);
            Assert.Equal(movieDto.ReleaseYear, dtoToEntity.ReleaseYear);
            Assert.Equal(movieDto.DirectedBy, dtoToEntity.DirectedBy);
        }
    }
}
