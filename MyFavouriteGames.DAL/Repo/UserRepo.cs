﻿using MyFavouriteGames.DAL.Context;
using MyFavouriteGames.DAL.Models;
using MyFavouriteGames.DAL.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavouriteGames.DAL.Repo
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(MyFavouriteGamesDbContext dbContext) : base(dbContext)
        {

        }
    }
}