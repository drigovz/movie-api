using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Domain.DTOs.MovieViewer;
using MoviesApi.Domain.Interfaces.Services.MovieViewerService;
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
        /// <summary>
        /// Insere um espectador em um filme
        /// </summary>
        /// <param name="movie">Objeto contendo o ID do espectador e o ID do filme</param>
        /// <returns>Retorna informações do novo espectador inserido</returns>
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
    }
}
