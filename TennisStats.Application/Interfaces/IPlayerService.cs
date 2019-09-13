using System.Collections.Generic;
using TennisStats.Domain.Models;

namespace TennisStats.Application.Interfaces
{
    public interface IPlayerService
    {
        IEnumerable<Player> GetAll();

        Player GetById(int id);

        bool DeleteById(int id);
    }
}
