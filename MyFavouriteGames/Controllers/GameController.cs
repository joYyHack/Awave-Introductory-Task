using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFavouriteGames.BL.Services.IServices;

namespace Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService) => this.gameService = gameService;

        // GET: GameController
        public async Task<ActionResult> Index()
        {
            var games = await gameService.GetAllAsync();
            return Json(games);
        }
    }
}
