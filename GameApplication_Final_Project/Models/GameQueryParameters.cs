using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesApplication.Models
{
    public class GameQueryParameters
    {

        public string Name { get; set; }

        public string Type { get; set; }

        public double? Price { get; set; }

        public double? Age { get; set; }

        public string SortBy { get; set; }

    }
}
