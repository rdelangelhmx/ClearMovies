using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public partial class MoviesContext : DbContext, IMoviesContext
    {
        public MoviesContext()
        {
        }

        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
        }
    }
}
