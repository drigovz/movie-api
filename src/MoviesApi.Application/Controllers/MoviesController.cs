using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesApi.Domain.DTOs.Movies;
using MoviesApi.Domain.Interfaces.Services.MovieService;
using MoviesApi.Domain.Interfaces.Services.MovieViewerService;
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
        private readonly IMovieViewerService _movieViewerService;

        public MoviesController(IMovieService service, IMovieViewerService movieViewerService)
        {
            _service = service;
            _movieViewerService = movieViewerService;
        }

        /// <summary>
        /// Buscar todos os filmes cadastrados
        /// </summary>
        /// <returns>Retorna uma lista com todos os filmes cadastrados no banco de dados</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAllAsync()
        {
            try
            {
                var movies = await _service.GetAllAsync();
                foreach (var movie in movies)
                    movie.TotalViewers = await _movieViewerService.ViewersOfMovie(movie.Id);

                return Ok(movies);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        /// <summary>
        /// Exibe detalhes de um determinado filme
        /// </summary>
        /// <param name="id">ID do filme</param>
        /// <returns>Retorna um objeto contendo todos os detalhes de um filme</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync([BindRequired] int id)
        {
            try
            {
                var movie = await _service.GetAsync(id);
                movie.TotalViewers = await _movieViewerService.ViewersOfMovie(id);
                return new ObjectResult(movie);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        /// <summary>
        /// Insere um novo filme na base de dados.
        /// </summary>
        /// <param name="movie">Dados do filme a ser inserido</param>
        /// <returns>Retorna informações do novo filme inserido</returns>
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

        /// <summary>
        /// Atualiza informações de um filme
        /// </summary>
        /// <param name="id">ID do filme a ser atualizado</param>
        /// <param name="movie">Dados do filme a ser atualizado</param>
        /// <returns>Retorna mensagem de sucesso em atualizações bem sucedidas</returns>
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

        /// <summary>
        /// Exclui um filme cadastrado
        /// </summary>
        /// <param name="id">ID do filme a ser excluído</param>
        /// <returns>Mensagem de exclusão bem sucedida</returns>
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
