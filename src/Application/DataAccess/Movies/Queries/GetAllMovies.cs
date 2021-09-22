using Application.Common.Interfaces;
using Application.Common.UOW;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DataAccess.Movies.Queries
{
    public class GetAllMovies : IRequest<IPaginate<VwMovie>>
    {
        public string filterTitle { get; set; }
        public string filterGenre { get; set; }
        public string filterActor { get; set; }
        public int page { get; set; }
        public int recordsPage { get; set; }
    }

    public class GetAllMoviesHandle : IRequestHandler<GetAllMovies, IPaginate<VwMovie>>
    {
        readonly IUnitOfWork uow;
        readonly ILogger logger;
        public GetAllMoviesHandle(IUnitOfWork _uow, ILogger<GetAllMoviesHandle> _logger)
        {
            uow = _uow;
            logger = _logger;
        }

        public async Task<IPaginate<VwMovie>> Handle(GetAllMovies request, CancellationToken cancellationToken)
        {
            try
            {
                // get data
                var model = uow.EntityRepository<VwMovie>()
                    .GetList(
                        predicate: w => (string.IsNullOrEmpty(request.filterTitle) || w.Title.Contains(request.filterTitle)) &&
                            (string.IsNullOrEmpty(request.filterGenre) || w.GenreName.Contains(request.filterGenre)) &&
                            (string.IsNullOrEmpty(request.filterActor) || w.PersonName.Contains(request.filterActor)),
                        index: request.page,
                        size: request.recordsPage);
                return await Task.FromResult(model);
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
