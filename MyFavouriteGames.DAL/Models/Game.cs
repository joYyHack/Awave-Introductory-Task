using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFavouriteGames.DAL.Models
{
    public class Game
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int ReleaseYear { get; set; }

        public ICollection<UserGame> VotedUsers { get; set; }
    }
}
