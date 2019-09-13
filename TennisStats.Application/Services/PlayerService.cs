using System.Collections.Generic;
using TennisStats.Application.Interfaces;
using TennisStats.Domain.Models;
using TennisStats.Infrastructure.Interfaces;

namespace TennisStats.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public IEnumerable<Player> GetAll()
        {
            return _playerRepository.GetAll();
        }

        public Player GetById(int id)
        {
            return _playerRepository.GetById(id);
        }

        public bool DeleteById(int id)
        {
            return _playerRepository.DeleteById(id);
        }
    }
}
