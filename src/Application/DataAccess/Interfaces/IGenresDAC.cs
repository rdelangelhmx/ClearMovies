using Domain.Entities;
using System.Threading.Tasks;

namespace Application.DataAccess.Interfaces
{
    public interface IGenresDAC
    {
        Task<Genre> GetGenresById(int idGenre);
    }
}
