using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DataAccess.Genres.Queries 
{
    public class GetGenresById : IRequest<MovieGenre>
    {
        public int idMovie { get; set; }
        public int idGenre { get; set; }
    }

    public class GetGenresByIdHandle : IRequestHandler<GetGenresById, MovieGenre>
    {
        readonly IUnitOfWork uow;
        readonly ILogger logger;
        public GetGenresByIdHandle(IUnitOfWork _uow, ILogger<GetGenresByIdHandle> _logger)
        {
            uow = _uow;
            logger = _logger;
        }

        public async Task<MovieGenre> Handle(GetGenresById request, CancellationToken cancellationToken)
        {
            try
            {
                // get data
                var genre = uow.EntityRepository<MovieGenre>()
                    .GetBy(
                    predicate: w => w.MovieId == request.idMovie && w.GenreId == request.idGenre, 
                    include: i => i.Include(d => d.Genre)
                );
                return await Task.FromResult(genre);
            }
            catch (NullReferenceException nex)
            {
                logger.LogError(nex, this.GetType().Name);
                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, this.GetType().Name);
                var exErr = ex;
                throw exErr;
            }
        }
    }
}
