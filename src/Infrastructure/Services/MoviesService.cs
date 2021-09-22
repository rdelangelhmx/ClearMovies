using Application.Common.Interfaces;
using Application.DataAccess.Interfaces;
using Application.DataAccess.Movies.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MoviesService : IMoviesDAC
    {
        private readonly ILogger logger;
        private readonly IMediator mediator;

        public MoviesService(ILogger<MoviesService> _logger, IMediator _mediator)
        {
            mediator = _mediator;
            logger = _logger;
        }

        public async Task<IPaginate<VwMovie>> GetAllMovies(string filterTitle, string filterGenre, string filterActor, int? Page, int? RecordsPage)
        {
            Page = Page ?? 1;
            RecordsPage = RecordsPage ?? 999999999;
            try
            {
                return await mediator.Send(new GetAllMovies { filterTitle = filterTitle, filterGenre = filterGenre, filterActor = filterActor, page = (int)Page, recordsPage = (int)RecordsPage });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, this.GetType().Name);
            }
            return null;
        }

    }
}
