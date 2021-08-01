using Moq;
using MoviesApi.Domain.DTOs.Viewers;
using MoviesApi.Domain.Interfaces.Services.ViewerService;
using MoviesApi.Service.Test.Fakes;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MoviesApi.Service.Test
{
    public class ViewerServiceTest : ViewerFake
    {
        private IViewerService _service;
        private Mock<IViewerService> _serviceMock;

        [Fact]
        public async Task Should_be_possivel_to_get_viewer_by_id()
        {
            _serviceMock = new Mock<IViewerService>();
            _serviceMock.Setup(m => m.GetAsync(Id)).ReturnsAsync(ViewerDetailsDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAsync(Id);

            Assert.NotNull(result);
            Assert.True(Id == result.Id);
            Assert.Equal(Name, result.Name);
            Assert.Equal(Age, result.Age);
            Assert.Equal(Email, result.Email);
            Assert.Equal(PhoneNumber, result.PhoneNumber);
        }

        [Fact]
        public async Task Should_be_return_null_object()
        {
            _serviceMock = new Mock<IViewerService>();
            _serviceMock.Setup(m => m.GetAsync(It.IsAny<int>())).Returns(Task.FromResult((ViewerDetailsDTO)null));
            _service = _serviceMock.Object;

            var result = await _service.GetAsync(Id);

            Assert.Null(result);
        }

        [Fact]
        public async Task Should_be_return_list_of_viewers()
        {
            _serviceMock = new Mock<IViewerService>();
            _serviceMock.Setup(m => m.GetAllAsync()).ReturnsAsync(ViewersDto);
            _service = _serviceMock.Object;

            var moviesList = await _service.GetAllAsync();

            Assert.NotNull(moviesList);
            Assert.NotEmpty(moviesList);
        }

        [Fact]
        public async Task Should_be_possible_to_create_new_viewer()
        {
            _serviceMock = new Mock<IViewerService>();
            _serviceMock.Setup(m => m.PostAsync(ViewerDto)).ReturnsAsync(ViewerDto);
            _service = _serviceMock.Object;

            var result = await _service.PostAsync(ViewerDto);

            Assert.NotNull(result);
            Assert.True(ViewerDto.Id == result.Id);
            Assert.Equal(ViewerDto.Name, result.Name);
            Assert.Equal(ViewerDto.Age, result.Age);
            Assert.Equal(ViewerDto.Email, result.Email);
            Assert.Equal(ViewerDto.PhoneNumber, result.PhoneNumber);
        }

        [Fact]
        public async Task Should_be_possible_update_viewer()
        {
            _serviceMock = new Mock<IViewerService>();
            _serviceMock.Setup(m => m.PutAsync(ViewerDto)).ReturnsAsync(ViewerDto);
            _service = _serviceMock.Object;

            var result = await _service.PutAsync(ViewerDto);

            Assert.NotNull(result);
            Assert.True(ViewerDto.Id == result.Id);
            Assert.Equal(ViewerDto.Name, result.Name);
            Assert.Equal(ViewerDto.Age, result.Age);
            Assert.Equal(ViewerDto.Email, result.Email);
            Assert.Equal(ViewerDto.PhoneNumber, result.PhoneNumber);
        }

        [Fact]
        public async Task Should_be_possible_delete_viewer()
        {
            _serviceMock = new Mock<IViewerService>();
            _serviceMock.Setup(m => m.DeleteAsync(It.IsAny<int>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.DeleteAsync(Id);

            Assert.True(result);
        }

        [Fact]
        public async Task Should_be_return_false_when_try_to_delete_unexistent_viewer()
        {
            _serviceMock = new Mock<IViewerService>();
            _serviceMock.Setup(m => m.DeleteAsync(It.IsAny<int>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            Random random = new Random();
            int randomId = random.Next(300000, 900000);
            var result = await _service.DeleteAsync(randomId);

            Assert.False(result);
        }
    }
}
