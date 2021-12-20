using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFavouriteGames.BL.Services.IServices;

namespace Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService) => this.userService = userService;

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var users = await userService.GetAllAsync();
            return Json(users);
        }
    }
}
