using AutoMapper;
using Bussiness_layer.Models;
using Bussiness_layer.Models.AddedModels;
using Bussiness_layer.Models.CreateModels;
using Bussiness_layer.Models.EditModels;
using Bussiness_layer.Models.LoginModels;
using Bussiness_layer.Models.ManyToManyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTDataAccessLayer.Entities.AddedModels;
using VTDataAccessLayer.UserRoles;

namespace VirtualTennisApplication.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Player, PlayerCreateModel>().ReverseMap();
            CreateMap<Player, PlayerEditModel>().ReverseMap();
            CreateMap<Tournament, TournamentModel>().ReverseMap();
            CreateMap<Tournament, TournamentEditModel>().ReverseMap();
            CreateMap<Tournament, TournamentCreateModel>().ReverseMap();
            CreateMap<Player, PlayerAuthModel>().ReverseMap();
            CreateMap<Player, AuthModel>().ReverseMap();

            CreateMap<Player, PlayerModel>()
                .ForMember(u => u.tournaments, u =>
                u.MapFrom(u => u.PlayersTournament.Select(bu => bu.Tournament)))
                .ForMember(r => r.IsMainOrNormalPlayer, m => m.MapFrom(ro => ro.PrRoles == PlayerRoles.MainPlayer));

            CreateMap<PlayerModel, Player>()
                .ForMember(u => u.PlayersTournament, um => um.MapFrom(um => um.tournaments
                .Select(b => new PlayersTournaments { TournamentId = b.Id, PlayerId = um.Id })))
                .ForMember(pr => pr.PrRoles, m => m.MapFrom(i => i.IsMainOrNormalPlayer ? PlayerRoles.MainPlayer : PlayerRoles.NormalPlayer));
            
            CreateMap<Player, PlayerCreateModel>()
                .ForMember(u => u.IsMainOrNormalPlayer, m => m.MapFrom(ro=>ro.PrRoles == PlayerRoles.MainPlayer));
            CreateMap<PlayerCreateModel, Player>()
                .ForMember(pr => pr.PrRoles, m => m.MapFrom(i => i.IsMainOrNormalPlayer ? PlayerRoles.MainPlayer : PlayerRoles.NormalPlayer));

            CreateMap<Player, PlayerEditModel>()
                .ForMember(u => u.IsMainOrNormalPlayer, m => m.MapFrom(ro => ro.PrRoles == PlayerRoles.MainPlayer));
            CreateMap<PlayerEditModel, Player>()
                .ForMember(pr => pr.PrRoles, m => m.MapFrom(i => i.IsMainOrNormalPlayer ? PlayerRoles.MainPlayer : PlayerRoles.NormalPlayer));
        }           
    }
}
