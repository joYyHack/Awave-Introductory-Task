using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyFavouriteGames.BL.DTO;
using MyFavouriteGames.BL.Services.IServices;
using MyFavouriteGames.DAL.Models;
using MyFavouriteGames.Models;

namespace Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService gameService;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public GameController(IGameService gameService, IUserService userService, IConfiguration configuration, IMapper mapper)
        {
            this.gameService = gameService;
            this.userService = userService;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        //Return all games ordered by calculated rating and then by release year(for testing purpose)
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var games = await gameService.GetAllAsync();
                var usersCount = await userService.GetUsersCountAsync();

                _ = int.TryParse(configuration.GetSection("GameRank")["Max"], out var maxRank);
                var maxPossibleRank = usersCount * maxRank;

                var gameModels = games.Select(g =>
                    mapper.Map<Game, GameModel>(g, opt =>
                        opt.AfterMap((src, dest) =>
                            dest.AverageRating = gameService.GetGameAverageRating(game: src, maxPossibleRank: maxPossibleRank))))
                    .OrderByDescending(g => g.AverageRating)
                    .ThenByDescending(g => g.ReleaseYear)
                    .ToList();

                return Json(gameModels);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> VoteAsync([FromBody]UserGameModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    string.Join(" ", ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList())
                );
            }

            try
            {
                var game = await gameService.GetByIdAsync(model.GameId);

                if (game == null)
                    throw new Exception("There is no such game...");

                var userGameDTO = mapper.Map<UserGameModel, UserGameDTO>(model, opt =>
                    opt.AfterMap(async (src, dest) =>
                        dest.Game = await gameService.GetByIdAsync(src.GameId)));
               
                var result = await gameService.VoteForGameAsync(userGameDTO);

                if (!result.IsSuccessful)
                    throw new Exception(result.ErrorsFormatted);

                return Ok("Voted successfully!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
