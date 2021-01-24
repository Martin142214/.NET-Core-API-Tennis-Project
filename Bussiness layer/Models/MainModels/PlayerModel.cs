using Bussiness_layer.Models.AddedModels;
using Bussiness_layer.Models.ManyToManyModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness_layer.Models
{
    public class PlayerModel : BaseModel
    {
        public PlayerModel()
        {
            tournaments = new List<TournamentModel>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthenticationCode { get; set; }
        public int TournamentsPlayed { get; set; }
        public int RankListPoints { get; set; }
        public List<TournamentModel> tournaments { get; set; }
        public bool IsMainOrNormalPlayer { get; set; }
    }
}
