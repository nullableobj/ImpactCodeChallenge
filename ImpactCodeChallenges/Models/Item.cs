using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactCodeChallenges.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Copyright { get; set; }
        public DateTime PubDate { get; set; }
    }
}
