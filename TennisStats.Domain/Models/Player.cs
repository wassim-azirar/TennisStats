using System;
using Newtonsoft.Json;

namespace TennisStats.Domain.Models
{
    public class Player
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Shortname { get; set; }
        public string Sex { get; set; }
        public Country Country { get; set; }
        public string Picture { get; set; }
        public Data Data { get; set; }
    }
}
