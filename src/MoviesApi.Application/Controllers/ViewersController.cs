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

        /// <summary>
        /// Buscar todos os espectadores cadastrados
        /// </summary>
        /// <returns>Retorna uma lista com todos os espectadores cadastrados no banco de dados</returns>
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

        /// <summary>
        /// Exibe detalhes de um determinado espectador
        /// </summary>
        /// <param name="id">ID do filme</param>
        /// <returns>Retorna um objeto contendo todos os detalhes de um espectador</returns>
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

        /// <summary>
        /// Insere um novo espectador na base de dados.
        /// </summary>
        /// <param name="viewer">Dados do espectador a ser inserido</param>
        /// <returns>Retorna informações do novo espectador inserido</returns>
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

        /// <summary>
        /// Atualiza informações de um espectador
        /// </summary>
        /// <param name="id">ID do espectador a ser atualizado</param>
        /// <param name="viewer">Dados do espectador a ser atualizado</param>
        /// <returns>Retorna mensagem de sucesso em atualizações bem sucedidas</returns>
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

        /// <summary>
        /// Exclui um espectador cadastrado
        /// </summary>
        /// <param name="id">ID do espectador a ser excluído</param>
        /// <returns>Mensagem de exclusão bem sucedida</returns>
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
