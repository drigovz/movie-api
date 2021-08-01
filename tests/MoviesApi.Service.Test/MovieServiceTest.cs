using Moq;
using MoviesApi.Domain.DTOs.Movies;
using MoviesApi.Domain.Interfaces.Services.MovieService;
using MoviesApi.Service.Test.Fakes;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MoviesApi.Service.Test
{
    public class MovieServiceTest : MovieFake
    {
        private IMovieService _service;
        private Mock<IMovieService> _serviceMock;

        [Fact]
        public async Task Should_be_possivel_to_get_movie_by_id()
        {
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.GetAsync(Id)).ReturnsAsync(MovieDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAsync(Id);

            Assert.NotNull(result);
            Assert.True(Id == result.Id);
            Assert.Equal(Title, result.Title);
            Assert.Equal(Synopsis, result.Synopsis);
            Assert.Equal(ReleaseYear, result.ReleaseYear);
            Assert.Equal(DirectedBy, result.DirectedBy);
        }

        [Fact]
        public async Task Should_be_return_null_object()
        {
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.GetAsync(It.IsAny<int>())).Returns(Task.FromResult((MovieDTO)null));
            _service = _serviceMock.Object;

            var result = await _service.GetAsync(Id);

            Assert.Null(result);
        }

        [Fact]
        public async Task Should_be_return_list_of_movies()
        {
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.GetAllAsync()).ReturnsAsync(MoviesDto);
            _service = _serviceMock.Object;

            var moviesList = await _service.GetAllAsync();

            Assert.NotNull(moviesList);
            Assert.NotEmpty(moviesList);
        }

        [Fact]
        public async Task Should_be_possible_to_create_new_movie()
        {
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.PostAsync(MovieDto)).ReturnsAsync(MovieDto);
            _service = _serviceMock.Object;

            var result = await _service.PostAsync(MovieDto);

            Assert.NotNull(result);
            Assert.Equal(Title, result.Title);
            Assert.Equal(Synopsis, result.Synopsis);
            Assert.Equal(ReleaseYear, result.ReleaseYear);
            Assert.Equal(DirectedBy, result.DirectedBy);
        }

        [Fact]
        public async Task Should_be_possible_update_movie()
        {
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.PutAsync(MovieDto)).ReturnsAsync(MovieDto);
            _service = _serviceMock.Object;

            var result = await _service.PutAsync(MovieDto);

            Assert.NotNull(result);
            Assert.Equal(MovieDto.Id, result.Id);
            Assert.Equal(MovieDto.Title, result.Title);
            Assert.Equal(MovieDto.Synopsis, result.Synopsis);
            Assert.Equal(MovieDto.ReleaseYear, result.ReleaseYear);
            Assert.Equal(MovieDto.DirectedBy, result.DirectedBy);
            Assert.Equal(MovieDto.TotalViewers, result.TotalViewers);
        }

        [Fact]
        public async Task Should_be_possible_delete_movie()
        {
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.DeleteAsync(It.IsAny<int>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.DeleteAsync(Id);

            Assert.True(result);
        }

        [Fact]
        public async Task Should_be_return_false_when_try_to_delete_unexistent_movie()
        {
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.DeleteAsync(It.IsAny<int>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            Random random = new Random();
            int randomId = random.Next(300000, 900000);
            var result = await _service.DeleteAsync(randomId);

            Assert.False(result);
        }
    }
}
