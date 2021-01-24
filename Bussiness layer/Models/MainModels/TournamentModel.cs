using Bussiness_layer.Models.ManyToManyModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness_layer.Models.AddedModels
{
    public class TournamentModel : BaseModel
    {
        public TournamentModel()
        {
            players = new List<PlayerModel>();
        }

        public Guid Id { get; set; }
        public string TournamentName { get; set; }
        public int Award { get; set; }
        public string Country { get; set; }
        public List<PlayerModel> players { get; set; }
    }
}
