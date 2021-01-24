using Bussiness_layer.Models.ManyToManyModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace VTDataAccessLayer.Entities.AddedModels
{
    public class Tournament : BaseEntity
    {
        public string TournamentName { get; set; }
        public int Award { get; set; }
        public string Country { get; set; }
        public List<PlayersTournaments> PlayersTournament { get; set; }// = new List<PlayersTournaments>();
    }
}
