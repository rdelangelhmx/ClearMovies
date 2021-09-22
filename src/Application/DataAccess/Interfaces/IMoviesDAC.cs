using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Interfaces
{
    public interface IMoviesDAC
    {
        Task<IPaginate<VwMovie>> GetAllMovies(string filterTitle, string filterGenre, string filterActor, int? Page, int? RecordsPage);
    }
}
