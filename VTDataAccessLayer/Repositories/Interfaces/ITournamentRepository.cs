using System;
using System.Collections.Generic;
using System.Text;
using VTDataAccessLayer.Entities.AddedModels;

namespace Bussiness_layer.Repositories.Interfaces
{
    public interface ITournamentRepository : IBaseRepository<Tournament>
    {
        Tournament GetAllPlayersOfTournament(Guid id);
    }
}
