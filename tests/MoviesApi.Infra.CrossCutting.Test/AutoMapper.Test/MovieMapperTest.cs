using MoviesApi.Domain.DTOs.Movies;
using MoviesApi.Domain.DTOs.MovieViewer;
using MoviesApi.Domain.DTOs.Viewers;
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

        [Fact]
        public void Should_be_possible_to_mapper_ViewerDTO_to_Viewer_Entity()
        {
            var randomAge = random.Next(1, 80);

            var viewerDto = new ViewerDTO()
            {
                Id = Faker.RandomNumber.Next(100),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                Age = randomAge,
                PhoneNumber = Faker.Phone.Number()
            };

            var dtoToEntity = mapper.Map<Viewer>(viewerDto);

            Assert.Equal(viewerDto.Id, dtoToEntity.Id);
            Assert.Equal(viewerDto.Name, dtoToEntity.Name);
            Assert.Equal(viewerDto.Email, dtoToEntity.Email);
            Assert.Equal(viewerDto.Age, dtoToEntity.Age);
            Assert.Equal(viewerDto.PhoneNumber, dtoToEntity.PhoneNumber);
        }

        [Fact]
        public void Should_be_possible_to_mapper_MovieViewerDTO_to_MovieViewer_Entity()
        {
            var randomMovieId = random.Next(1, 60);
            var randomViewerId = random.Next(70, 100);

            var movieViewerDto = new MovieViewerDTO()
            {
                MovieId = randomMovieId,
                ViewerId = randomViewerId
            };

            var dtoToEntity = mapper.Map<MovieViewer>(movieViewerDto);

            Assert.Equal(movieViewerDto.MovieId, dtoToEntity.MovieId);
            Assert.Equal(movieViewerDto.ViewerId, dtoToEntity.ViewerId);
        }
    }
}
