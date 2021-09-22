using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Interfaces
{
    public interface ICharactersDAC
    {
        Task<MovieCast> GetCharactersById(int idCharacter);
    }
}
