using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VTDataAccessLayer.Entities.AddedModels;

namespace Bussiness_layer.Repositories.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Player GetAllTournamentsOfPlayer(Guid id);
        Task TakePartInTournament(Guid playerId, Guid tournamentId);
        Task QuitTournament(Guid playerId, Guid tournamentId);
        Player GetUserByName(string name);
    }
}
