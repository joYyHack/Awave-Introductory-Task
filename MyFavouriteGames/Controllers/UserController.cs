using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFavouriteGames.BL.Services.IServices;

namespace Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IGameService gameService;

        public UserController(IUserService userService, IGameService gameService)
        {
            this.userService = userService;
            this.gameService = gameService;
        }

        //Return list of users ordered by last voted date(for testing purpose)
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var users = await userService.GetAllOrderedByDateAsync();
            return Json(users);
        }
    }
}
