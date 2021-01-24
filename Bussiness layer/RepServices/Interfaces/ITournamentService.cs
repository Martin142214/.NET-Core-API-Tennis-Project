using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bussiness_layer.Models.AddedModels;
using Bussiness_layer.Models.CreateModels;
using Bussiness_layer.Models.EditModels;

namespace Bussiness_layer.RepServices.Interfaces
{
    public interface ITournamentService
    {
        List<TournamentModel> GetAll(Expression<Func<TournamentModel, bool>> filter = null);
        Task Create(TournamentCreateModel model);
        Task Delete(Guid id);
        TournamentModel GetById(Guid id);
        Task Update(TournamentEditModel model);
        TournamentModel GetAllPlayersOfTournament(Guid id);
    }
}