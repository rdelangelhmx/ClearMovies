using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.UOW;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
                // get movies
                var movies = uow.EntityRepository<Movie>()
                    .GetList(
                        predicate: w => (string.IsNullOrEmpty(request.filterTitle) || w.Title.Contains(request.filterTitle)),
                        index: request.page,
                        size: request.recordsPage);
                List<VwMovie> fullMovies = new List<VwMovie>();
                foreach(Movie movie in movies.Items)
                {
                    var dMovie = MapperUtility.MapTo<Movie, VwMovie>(movie, new VwMovie());
                    // Get Genres
                    var genre = uow.EntityRepository<MovieGenre>()
                        .GetAll(
                        predicate: w => w.MovieId == movie.MovieId,
                        include: i => i.Include(d => d.Genre)).ToList();
                    var Genres = new List<string>();
                    genre.ForEach(f => Genres.Add(new string(f.Genre.GenreName)));
                    dMovie.GenreName = string.Join(", ", Genres.ToArray());
                    // Get Actors
                    var actor = uow.EntityRepository<MovieCast>()
                        .GetAll(
                        predicate: w => w.MovieId == movie.MovieId,
                        include: i => i.Include(d => d.Person)).ToList();
                    var Actors = new List<string>();
                    actor.ForEach(f => Actors.Add(new string(f.Person.PersonName)));
                    dMovie.PersonName = string.Join(", ", Actors.ToArray());
                    // Get Characters
                    var Characters = new List<string>();
                    actor.ForEach(f => Characters.Add(new string(f.CharacterName)));
                    dMovie.CharacterName = string.Join(", ", Characters.ToArray());
                    // add movie to list
                    fullMovies.Add(dMovie);
                }
                Paginate<VwMovie> result = new Paginate<VwMovie>();
                result.Items = fullMovies;
                result.Count = movies.Count;
                result.From = movies.From;
                result.Index = movies.Index;
                result.Pages = movies.Pages;
                result.Size = movies.Size;
                return await Task.FromResult(result);
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
