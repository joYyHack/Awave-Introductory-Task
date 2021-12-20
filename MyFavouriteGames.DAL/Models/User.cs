using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavouriteGames.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string GameComment { get; set; }
        public byte VotedRank { get; set; }
        public DateTime? VotingDate { get; set; }
        public Game Game { get; set; }

    }
}
