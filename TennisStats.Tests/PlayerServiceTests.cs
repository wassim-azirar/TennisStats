using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using TennisStats.Application.Services;
using TennisStats.Domain.Models;
using TennisStats.Infrastructure.Interfaces;

namespace TennisStats.Tests
{
    [TestFixture]
    public class PlayerServiceTests
    {
        private IPlayerRepository _playerRepository;

        [SetUp]
        public void Setup()
        {
            _playerRepository = Substitute.For<IPlayerRepository>();
        }

        [Test]
        public void GetAllTest_ShouldReturnAllPlayers()
        {
            // Arrange
            _playerRepository.GetAll().Returns(GetPlayers());

            // Act
            var playerService = new PlayerService(_playerRepository);
            var allPlayers = playerService.GetAll();

            // Assert
            Assert.AreEqual(2, allPlayers.Count());
        }

        [Test]
        public void GetByIdTest_WhenPlayerIdFound_ReturnThePlayer()
        {
            // Arrange
            const int id = 52;
            var expectedPlayer = GetPlayers().FirstOrDefault(p => p.Id == id);
            _playerRepository.GetById(id).Returns(expectedPlayer);

            // Act
            var playerService = new PlayerService(_playerRepository);
            var player = playerService.GetById(id);

            // Assert
            Assert.NotNull(player);
            Assert.AreEqual(expectedPlayer.Firstname, player.Firstname);
        }

        [Test]
        public void GetByIdTest_WhenPlayerIsNotFound_ReturnNull()
        {
            // Arrange
            const int id = 99;
            var expectedPlayer = GetPlayers().FirstOrDefault(p => p.Id == id);
            _playerRepository.GetById(id).Returns(expectedPlayer);

            // Act
            var playerService = new PlayerService(_playerRepository);
            var player = playerService.GetById(id);

            // Assert
            Assert.IsNull(player);
        }


        [Test]
        public void DeleteByIdTest_WhenPlayerExists_ReturnTrue()
        {
            // Arrange
            const int id = 52;
            _playerRepository.DeleteById(id).Returns(GetPlayers().Any(p => p.Id == id));

            // Act
            var playerService = new PlayerService(_playerRepository);
            var isDeleted = playerService.DeleteById(id);

            // Assert
            Assert.AreEqual(true, isDeleted);
        }

        [Test]
        public void DeleteByIdTest_WhenPlayerDoesNotExists_ReturnFalse()
        {
            // Arrange
            const int id = 99;
            _playerRepository.DeleteById(id).Returns(GetPlayers().Any(p => p.Id == id));

            // Act
            var playerService = new PlayerService(_playerRepository);
            var isDeleted = playerService.DeleteById(id);

            // Assert
            Assert.AreEqual(false, isDeleted);
        }

        private List<Player> GetPlayers()
        {
            var player1 = new Player
            {
                Id = 52,
                Firstname = "Novak",
                Lastname = "Djokovic",
                Shortname = "N.DJO",
                Sex = "M",
                Country = new Country
                {
                    Picture = "https://i.eurosport.com/_iss_/geo/country/flag/medium/6944.png",
                    Code = "SRB"
                },
                Picture = "https://i.eurosport.com/_iss_/person/pp_clubteam/large/565920.jpg",
                Data = new Data
                {
                    Rank = 2,
                    Points = 2542,
                    Weight = 80000,
                    Height = 188,
                    Age = 31,
                    Last = new List<long> { 1, 1, 1, 1, 1 }
                }
            };

            var player2 = new Player
            {
                Id = 95,
                Firstname = "Venus",
                Lastname = "Williams",
                Shortname = "V.WIL",
                Sex = "F",
                Country = new Country
                {
                    Picture = "https://i.eurosport.com/_iss_/person/pp_clubteam/large/136449.jpg",
                    Code = "USA"
                },
                Picture = "https://i.eurosport.com/_iss_/person/pp_clubteam/large/136450.jpg",
                Data = new Data
                {
                    Rank = 52,
                    Points = 1105,
                    Weight = 74000,
                    Height = 185,
                    Age = 38,
                    Last = new List<long> { 0, 1, 0, 0, 1 }
                }
            };

            return new List<Player> {player1, player2};
        }
    }
}
