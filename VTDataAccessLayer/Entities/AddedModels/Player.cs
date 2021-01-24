using Bussiness_layer.Models.ManyToManyModel;
using System;
using System.Collections.Generic;
using System.Text;
using VTDataAccessLayer.UserRoles;

namespace VTDataAccessLayer.Entities.AddedModels
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public string AuthenticationCode { get; set; }
        public int TournamentsPlayed { get; set; }
        public int RankListPoints { get; set; }
        public List<PlayersTournaments> PlayersTournament { get; set; } //= new List<PlayersTournaments>();
        public PlayerRoles PrRoles { get; set; }
    }
}
