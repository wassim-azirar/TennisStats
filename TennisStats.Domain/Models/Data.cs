using System.Collections.Generic;
using Newtonsoft.Json;

namespace TennisStats.Domain.Models
{
    public class Data
    {
        [JsonIgnore]
        public int Id { get; set; }
        public long Rank { get; set; }
        public long Points { get; set; }
        public long Weight { get; set; }
        public long Height { get; set; }
        public long Age { get; set; }
        public List<long> Last { get; set; }
    }
}
