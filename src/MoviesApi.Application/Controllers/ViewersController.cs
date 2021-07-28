using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesApi.Domain.DTOs.Viewers;
using MoviesApi.Domain.Interfaces.Services.MovieViewerService;
using MoviesApi.Domain.Interfaces.Services.ViewerService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ViewersController : ControllerBase
    {
        private readonly IViewerService _service;
        private readonly IMovieViewerService _movieViewerService;

        public ViewersController(IViewerService service, IMovieViewerService movieViewerService)
        {
            _service = service;
            _movieViewerService = movieViewerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewerDTO>>> GetAllAsync()
        {
            try
            {
                var viewers = await _service.GetAllAsync();
                return Ok(viewers);
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
                var viewer = await _service.GetAsync(id);
                viewer.Movies = await _movieViewerService.GetMoviesOfViewer(id);
                viewer.TotalMovies = viewer.Movies.Count();
                return new ObjectResult(viewer);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ViewerDTO viewer)
        {
            try
            {
                if (viewer == null)
                    return BadRequest();

                var result = await _service.PostAsync(viewer);
                if (result != null)
                    return new ObjectResult(result);
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to add a new viewer");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAsync([BindRequired] int id, [FromBody] ViewerDTO viewer)
        {
            try
            {
                var obj = await _service.GetAsync(id);
                if (obj == null)
                    return BadRequest($"Viewer with id {id} not found");

                var result = await _service.PutAsync(viewer);
                if (result != null)
                    return StatusCode(StatusCodes.Status200OK, $"Viewer id {id} update successful");
                else
                    return BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to update viewer id {id}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync([BindRequired] int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                return StatusCode(StatusCodes.Status200OK, "Viewer deleted successfully");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to delete viewer id {id}");
            }
        }
    }
}
