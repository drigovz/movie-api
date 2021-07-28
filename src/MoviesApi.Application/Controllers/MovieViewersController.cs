using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesApi.Domain.DTOs.Movies;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMoviesOfViewerAsync([BindRequired] int id)
        {
            try
            {
                var viewer = await _service.GetMoviesOfViewer(id);
                return Ok(viewer);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }
    }
}
