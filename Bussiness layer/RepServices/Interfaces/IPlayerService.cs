using Bussiness_layer.Models;
using Bussiness_layer.Models.CreateModels;
using Bussiness_layer.Models.EditModels;
using Bussiness_layer.Models.LoginModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_layer.RepServices.Interfaces
{
    public interface IPlayerService
    {
        IEnumerable<PlayerModel> players(Expression<Func<PlayerModel, bool>> filter = null);
        PlayerModel GetById(Guid id);
        Task Create(PlayerCreateModel model);
        Task Update(PlayerEditModel model);
        Task Delete(Guid id);
        PlayerModel GetAllTournamentsOfPlayer(Guid id);
        PlayerAuthModel GetUserByName(string name);
        Task TakePartInTournament(Guid playerId, Guid tournamentId);
        Task QuitTournament(Guid playerId, Guid tournamentId);
    }
}
