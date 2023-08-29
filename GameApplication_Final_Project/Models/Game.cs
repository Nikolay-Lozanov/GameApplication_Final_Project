using System;
using System.ComponentModel.DataAnnotations;

namespace GamesApplication.Models
{
    public class Game
    {
        public int Id { get; set; }

        [StringLength(25, MinimumLength = 1, ErrorMessage = "The {0} must be between {1} and {2} chars long")]
        public string Name { get; set; }

        [Range(0, 18, ErrorMessage = "The {0} must be between {1} and {2}")]
        public double? Age { get; set; }

        [StringLength(25, MinimumLength = 1, ErrorMessage = "The {0} must be between {1} and {2} chars long")]
        public string Type { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The {0} must be between {1} and {2}")]
        public double? Price { get; set; }
    }
}
