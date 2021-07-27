using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesApi.Domain.DTOs.Movies;
using MoviesApi.Domain.Interfaces.Services.MovieService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAllAsync()
        {
            try
            {
                var movies = await _service.GetAllAsync();
                return Ok(movies);
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
                var movie = await _service.GetAsync(id);
                return new ObjectResult(movie);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] MovieDTO movie)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to add a new movie");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAsync([BindRequired] int id, [FromBody] MovieDTO movie)
        {
            try
            {
                var obj = await _service.GetAsync(id);
                if (obj == null)
                    return BadRequest($"Movie with id {id} not found");

                var result = await _service.PutAsync(movie);
                if (result != null)
                    return StatusCode(StatusCodes.Status200OK, $"Movie id {id} update successful");
                else
                    return BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to update movie id {id}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync([BindRequired] int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                return StatusCode(StatusCodes.Status200OK, "Movie deleted successfully");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to delete movie id {id}");
            }
        }
    }
}
