using System.ComponentModel.DataAnnotations;

namespace MyFavouriteGames.DAL.Models
{
    public class UserGame
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }

        [Required]
        public byte VotedRank { get; set; }

        public string GameComment { get; set; }
    }
}
