using Domain.Entities;
using System.Threading.Tasks;

namespace Application.DataAccess.Interfaces
{
    public interface IActorsDAC
    {
        Task<Person> GetActorsById(int idActor);
    }
}
