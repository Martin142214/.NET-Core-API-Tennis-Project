using System;
using System.Collections.Generic;
using System.Text;
using VTDataAccessLayer.Entities.AddedModels;

namespace Bussiness_layer.Models.ManyToManyModel
{
    public class PlayersTournaments 
    {
        public Guid PlayerId { get; set; }
        public Guid TournamentId { get; set; }
        public Player Player { get; set; }
        public Tournament Tournament { get; set; }
    }
}
