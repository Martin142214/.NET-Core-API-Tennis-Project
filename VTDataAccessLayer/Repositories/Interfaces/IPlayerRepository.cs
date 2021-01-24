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
        IEnumerable<Player> GetAllPlayersTakingPartInTournament(Expression<Func<Player, bool>> filter = null);
        Player GetPlayer(Guid id);
        Task TakePartInTournament(Guid playerId, Guid tournamentId);
        Task QuitTournament(Guid playerId, Guid tournamentId);
        Player GetUserByName(string name);
    }
}
