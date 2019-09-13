using System;
using System.Collections.Generic;
using LiteDB;
using TennisStats.Domain.Models;
using TennisStats.Infrastructure.Interfaces;

namespace TennisStats.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly string _databaseUrl = $"{AppDomain.CurrentDomain.BaseDirectory}/headtohead.db";

        public PlayerRepository()
        {
            using (var db = new LiteDatabase(_databaseUrl))
            {
                var collection = db.GetCollection<Player>("players");

                InitPlayers(collection);
            }
        }

        public IEnumerable<Player> GetAll()
        {
            using (var db = new LiteDatabase(_databaseUrl))
            {
                var collection = db.GetCollection<Player>("players");
                return collection.FindAll();
            }
        }

        public Player GetById(int id)
        {
            using (var db = new LiteDatabase(_databaseUrl))
            {
                var collection = db.GetCollection<Player>("players");
                return collection.FindById(id);
            }
        }

        public bool DeleteById(int id)
        {
            using (var db = new LiteDatabase(_databaseUrl))
            {
                var collection = db.GetCollection<Player>("players");
                return collection.Delete(id);
            }
        }

        #region InitPlayers

        private static void InitPlayers(LiteCollection<Player> collection)
        {
            // Delete previous data
            var allPlayers = collection.FindAll();
            foreach (var player in allPlayers)
            {
                collection.Delete(player.Id);
            }

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

            var player3 = new Player
            {
                Id = 65,
                Firstname = "Stan",
                Lastname = "Wawrinka",
                Shortname = "S.WAW",
                Sex = "M",
                Country = new Country
                {
                    Picture = "https://i.eurosport.com/_iss_/geo/country/flag/large/2213.png",
                    Code = "SUI"
                },
                Picture = "https://i.eurosport.com/_iss_/person/pp_clubteam/large/325225.jpg",
                Data = new Data
                {
                    Rank = 21,
                    Points = 1784,
                    Weight = 81000,
                    Height = 183,
                    Age = 33,
                    Last = new List<long> { 1, 1, 1, 0, 1 }
                }
            };

            var player4 = new Player
            {
                Id = 102,
                Firstname = "Serena",
                Lastname = "Williams",
                Shortname = "S.WIL",
                Sex = "F",
                Country = new Country
                {
                    Picture = "https://i.eurosport.com/_iss_/geo/country/flag/medium/2209.png",
                    Code = "USA"
                },
                Picture = "https://i.eurosport.com/_iss_/person/pp_clubteam/large/136450.jpg",
                Data = new Data
                {
                    Rank = 10,
                    Points = 3521,
                    Weight = 72000,
                    Height = 175,
                    Age = 37,
                    Last = new List<long> { 0, 1, 1, 1, 0 }
                }
            };

            var player5 = new Player
            {
                Id = 17,
                Firstname = "Rafael",
                Lastname = "Nadal",
                Shortname = "R.NAD",
                Sex = "M",
                Country = new Country
                {
                    Picture = "https://i.eurosport.com/_iss_/geo/country/flag/large/2203.png",
                    Code = "ESP"
                },
                Picture = "https://i.eurosport.com/_iss_/person/pp_clubteam/large/435121.jpg",
                Data = new Data
                {
                    Rank = 1,
                    Points = 1982,
                    Weight = 85000,
                    Height = 185,
                    Age = 33,
                    Last = new List<long> { 1, 0, 0, 0, 1 }
                }
            };

            collection.Insert(player1);
            collection.Insert(player2);
            collection.Insert(player3);
            collection.Insert(player4);
            collection.Insert(player5);
        }

        #endregion
    }
}
