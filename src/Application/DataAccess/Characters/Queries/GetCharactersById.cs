using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DataAccess.Characters.Queries
{
    public class GetCharactersById : IRequest<MovieCast>
    {
        public int idMovie { get; set; }
        public int idActor { get; set; }
    }

    public class GetCharactersByIdHandle : IRequestHandler<GetCharactersById, MovieCast>
    {
        readonly IUnitOfWork uow;
        readonly ILogger logger;
        public GetCharactersByIdHandle(IUnitOfWork _uow, ILogger<GetCharactersByIdHandle> _logger)
        {
            uow = _uow;
            logger = _logger;
        }

        public async Task<MovieCast> Handle(GetCharactersById request, CancellationToken cancellationToken)
        {
            try
            {
                // get data
                var character = uow.EntityRepository<MovieCast>()
                    .GetBy(w => w.MovieId == request.idMovie && w.PersonId == request.idActor);
                return await Task.FromResult(character);
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
