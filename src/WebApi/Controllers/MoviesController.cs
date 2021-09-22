using Application.DataAccess.Interfaces;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ApiController
    {
        readonly ILogger logger;
        readonly IMoviesDAC movies;
        readonly ConfigApp configApp;
        public MoviesController(ILogger<MoviesController> _logger, IMoviesDAC _movies, ConfigApp _configApp)
        {
            logger = _logger;
            movies = _movies;
            configApp = _configApp;
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] string filterTitle, [FromQuery] string filterGenre, [FromQuery] string filterActor, [FromQuery] int? page)
        {
            try
            {
                page = page ?? 1;
                var dataTags = await movies.GetAllMovies(filterTitle, filterGenre, filterActor, page, configApp.Application.RecordsPage);
                if (dataTags != null)
                    return Ok(new { exito = true, data = dataTags });
                return Ok(new { exito = false, mensaje = "Not found Movies" });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Try to find Movies");
                return NotFound(new { exito = false, mensaje = "Not found Movies" });
            }
        }
    }
}
