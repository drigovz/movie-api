using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesApi.Domain.DTOs.MovieViewer;
using MoviesApi.Domain.Interfaces.Services.MovieViewerService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MovieViewersController : ControllerBase
    {
        private readonly IMovieViewerService _service;

        public MovieViewersController(IMovieViewerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieViewerDTO>>> GetAllAsync()
        {
            try
            {
                var movieViwers = await _service.GetAllAsync();
                return Ok(movieViwers);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync([BindRequired] int id)
        {
            try
            {
                var movieViewer = await _service.GetAsync(id);
                return new ObjectResult(movieViewer);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] MovieViewerDTO movie)
        {
            try
            {
                if (movie == null)
                    return BadRequest();

                var result = await _service.PostAsync(movie);
                if (result != null)
                    return new ObjectResult(result);
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to add a new movie viewer");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAsync([BindRequired] int id, [FromBody] MovieViewerDTO movieViewer)
        {
            try
            {
                var obj = await _service.GetAsync(id);
                if (obj == null)
                    return BadRequest($"Movie viewer with id {id} not found");

                var result = await _service.PutAsync(movieViewer);
                if (result != null)
                    return StatusCode(StatusCodes.Status200OK, $"Movie viewer id {id} update successful");
                else
                    return BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to update movie viewer id {id}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync([BindRequired] int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                return StatusCode(StatusCodes.Status200OK, "Movie viewer deleted successfully");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to delete movie viewer id {id}");
            }
        }
    }
}
