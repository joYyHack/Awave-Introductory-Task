using AutoMapper;
using MyFavouriteGames.BL.DTO;
using MyFavouriteGames.DAL.Models;

namespace MyFavouriteGames.Models
{
    //Automapping(Mapping models between web, BL and DAL projects)
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Game, GameModel>()
                .ForMember(gm => gm.VotesCount, opt => opt.MapFrom(g => g.VotedUsers.Count))
                .ReverseMap();

            CreateMap<UserGameModel, UserGameDTO>()
                .ForMember(dto => dto.User, opt => opt.MapFrom(mod => new User { Name = mod.Name, Email = mod.Email, LastTimeVotedDate = mod.LastTimeVotedDate }))
                .ForMember(dto => dto.GameComment, opt => opt.MapFrom(mod => mod.GameComment))
                .ForMember(dto => dto.VotedRank, opt => opt.MapFrom(mod => mod.VotedRank))               
                .ReverseMap();
        }
    }
}
