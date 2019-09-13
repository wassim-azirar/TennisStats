using System.Collections.Generic;
using TennisStats.Domain.Models;

namespace TennisStats.Infrastructure.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll();

        Player GetById(int id);

        bool DeleteById(int id);
    }
}
