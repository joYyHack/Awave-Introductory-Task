using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFavouriteGames.DAL.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime? LastTimeVotedDate { get; set; }

        public ICollection<UserGame> VotedGames { get; set; }

    }
}
