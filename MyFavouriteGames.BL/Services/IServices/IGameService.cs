using MyFavouriteGames.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavouriteGames.BL.Services.IServices
{
    public interface IGameService
    {
        Task<List<Game>> GetAllAsync();
    }
}
