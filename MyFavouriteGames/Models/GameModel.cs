using System.ComponentModel.DataAnnotations;

namespace MyFavouriteGames.Models
{
    public class GameModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        public double AverageRating { get; set; }

        public int VotesCount { get; set; }
    }
}
