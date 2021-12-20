using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFavouriteGames.DAL.Context
{
    public class MyFavouriteGamesDbContext : DbContext
    {
        public MyFavouriteGamesDbContext(DbContextOptions<MyFavouriteGamesDbContext> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
