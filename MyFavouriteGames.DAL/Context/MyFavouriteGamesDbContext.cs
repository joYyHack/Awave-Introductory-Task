using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFavouriteGames.DAL.Models;

namespace MyFavouriteGames.DAL.Context
{
    public class MyFavouriteGamesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        public MyFavouriteGamesDbContext(DbContextOptions<MyFavouriteGamesDbContext> context) : base(context)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Users)
                .WithOne(u => u.Game)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
