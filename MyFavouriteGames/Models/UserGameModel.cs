using System;
using System.ComponentModel.DataAnnotations;

namespace MyFavouriteGames.Models
{
    public class UserGameModel
    {
        [Required(ErrorMessage = "Your name is too important for us")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hmmm.....Where is you email?")]
        [EmailAddress(ErrorMessage = "Please check your email address. Looks like it's a bit incorrect")]
        public string Email { get; set; }

        public string GameComment { get; set; }

        [Required(ErrorMessage = "This field can not be empty")]
        [Range(1, 10, ErrorMessage = "The rank must be between 1 and 10")]
        public byte VotedRank { get; set; }

        public DateTime? LastTimeVotedDate { get; } = DateTime.UtcNow;

        [Required]
        public int GameId { get; set; }
    }
}
