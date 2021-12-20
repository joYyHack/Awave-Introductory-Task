using Microsoft.EntityFrameworkCore;
using MyFavouriteGames.DAL.Models;

namespace MyFavouriteGames.DAL.Context
{
    public class MyFavouriteGamesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UsersGames { get; set; }

        public MyFavouriteGamesDbContext(DbContextOptions<MyFavouriteGamesDbContext> context) : base(context)
        {
            //TODO
            //Add migrations. Code below is for testing purpose only
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGame>()
                .HasKey(ug => new { ug.UserId, ug.GameId });

            //Many to many relationship
            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.VotedGames)
                .HasForeignKey(ug => ug.UserId);

            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.Game)
                .WithMany(u => u.VotedUsers)
                .HasForeignKey(ug => ug.GameId);

            //Code below only for testing purpose
            //TODO Add some file with initial data or to scrab data from web 
            modelBuilder.Entity<Game>()
                .HasData(
                    new Game { Id = 1, Title = "Title1", Description = "Description1", ReleaseYear = 2020 },
                    new Game { Id = 2, Title = "Title2", Description = "Description2", ReleaseYear = 2021 },
                    new Game { Id = 3, Title = "Title3", Description = "Description3", ReleaseYear = 2022 },
                    new Game { Id = 4, Title = "Title4", Description = "Description4", ReleaseYear = 2023 },
                    new Game { Id = 5, Title = "Title5", Description = "Description5", ReleaseYear = 2024 },
                    new Game { Id = 6, Title = "Title6", Description = "Description6", ReleaseYear = 2025 },
                    new Game { Id = 7, Title = "Title7", Description = "Description7", ReleaseYear = 2026 },
                    new Game { Id = 8, Title = "Title8", Description = "Description8", ReleaseYear = 2027 },
                    new Game { Id = 9, Title = "Title9", Description = "Description9", ReleaseYear = 2028 }
                    );

            modelBuilder.Entity<User>()
                .HasData(
                    new User { Id = 1, Name = "Name1", Email = "email@email1" },
                    new User { Id = 2, Name = "Name2", Email = "email@email2" },
                    new User { Id = 3, Name = "Name3", Email = "email@email3" },
                    new User { Id = 4, Name = "Name4", Email = "email@email4" },
                    new User { Id = 5, Name = "Name5", Email = "email@email5" },
                    new User { Id = 6, Name = "Name6", Email = "email@email6" },
                    new User { Id = 7, Name = "Name7", Email = "email@email7" },
                    new User { Id = 8, Name = "Name8", Email = "email@email8" },
                    new User { Id = 9, Name = "Name9", Email = "email@email9" }
                    );
        }
    }
}
