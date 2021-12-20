using MyFavouriteGames.DAL.Models;

namespace MyFavouriteGames.BL.DTO
{
    public class UserGameDTO
    {
        public User User { get; set; }
        public Game Game { get; set; }
        public string GameComment { get; set; }
        public byte VotedRank { get; set; }

    }
}
